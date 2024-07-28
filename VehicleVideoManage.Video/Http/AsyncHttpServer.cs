using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewLife.Log;

namespace VehicleVideoManage.Video.Http
{
    /// <summary>
    /// 异步Http服务
    /// </summary>
    public class AsyncHttpServer
    {
        /// <summary>
        /// 当前接收的socket数
        /// </summary>
        internal int currentAcceptSockets = 0;
        /// <summary>
        /// 托管线程id
        /// </summary>
        private HashSet<int> managedThreadIds = new HashSet<int>();
        /// <summary>
        /// 托管线程
        /// </summary>
        private HashSet<Thread> managedThreads = new HashSet<Thread>();
        /// <summary>
        /// 
        /// </summary>
        private HttpBufferManager theBufferManager;

        private Socket listenSocket;

        private Semaphore theMaxConnectionsEnforcer;

        private Stack<SocketAsyncEventArgs> poolOfAcceptEventArgs;

        private HttpConnectionPool connectionPool;

        private static int connectId = 0;

        private Hashtable ReconnectTimesMap = new Hashtable();

        private object acceptCollectionLock = new object();

        private ConcurrentDictionary<string, AsyncHttpSocketConnection> Connections = new ConcurrentDictionary<string, AsyncHttpSocketConnection>();

        public ConcurrentDictionary<string, HttpConnItem> connMap = new ConcurrentDictionary<string, HttpConnItem>();

        private int releaseTimes = 0;

        public HttpServerSettings ServerSettings
        {
            get;
            set;
        }

        public IPAddress ListenOnLocalIP
        {
            get;
            set;
        }

        public int ListenPort
        {
            get;
            set;
        }

        public int processDataInterval
        {
            get;
            set;
        }

        public event SocketErrorHandler OnSocketError;
        private readonly ITracer tracer;
        public AsyncHttpServer(ITracer _tracer)
        {
            tracer = _tracer;
        }
        public void Init(HttpServerSettings settings)
        {
            ServerSettings = settings;
            if (string.IsNullOrEmpty(settings.ServerIP))
            {
                ListenOnLocalIP = IPAddress.Any;
            }
            else
            {
                ListenOnLocalIP = IPAddress.Parse(settings.ServerIP);
            }
            ListenPort = settings.Port;
        }

        public int Listen()
        {
            try
            {
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, ListenPort);
                theBufferManager = new HttpBufferManager(ServerSettings.BufferSize * ServerSettings.MaxConnections * 2, ServerSettings.BufferSize);
                connectionPool = new HttpConnectionPool(ServerSettings.MaxConnections);
                theMaxConnectionsEnforcer = new Semaphore(ServerSettings.MaxConnections, ServerSettings.MaxConnections);
                InitBuffer();
                listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(localEndPoint);
                listenSocket.Listen(ServerSettings.Backlog);
                StartAccept();
                tracer.NewSpan("启动HttpServer监听成功,端口:" + ListenPort);
                return 1;
            }
            catch (Exception ex)
            {
                if (this.OnSocketError != null)
                {
                    this.OnSocketError(null, new SocketEventArgs(0, ex.Message));
                }
                tracer.NewSpan("Http  server监听失败: " + ex.Message+","+ex.StackTrace);
            }
            return 0;
        }

        public bool Send(string SimNo, int Channel, byte[] data, int offset, int length)
        {
            string key = SimNo + "_" + Channel;
            HttpConnItem ls = null;
            if (connMap.TryGetValue(key, out ls))
            {
                return ls.Send(data, offset, length);
            }
            return false;
        }

        public List<AsyncHttpSocketConnection> GetConnectionList()
        {
            return new List<AsyncHttpSocketConnection>(Connections.Values);
        }

        public void Close()
        {
            try
            {
                listenSocket.Close();
            }
            catch (Exception ex)
            {
                tracer.NewError(ex.Message+","+ ex.StackTrace,ex);
            }
            CleanUpOnExit();
            currentAcceptSockets = 0;
        }

        public void CloseAllConnections()
        {
            try
            {
                logger.Error("系统主动关闭所有http 连接");
                connMap.Clear();
                ICollection<AsyncHttpSocketConnection> icList = Connections.Values;
                foreach (AsyncHttpSocketConnection asc in icList)
                {
                    try
                    {
                        asc.Close();
                    }
                    catch (Exception ex2)
                    {
                        logger.Error(ex2.Message);
                        logger.Error(ex2.StackTrace);
                    }
                }
                Connections.Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        public AsyncHttpServer()
        {
            currentAcceptSockets = 0;
        }

        internal void InitBuffer()
        {
            theBufferManager.InitBuffer();
            poolOfAcceptEventArgs = new Stack<SocketAsyncEventArgs>(ServerSettings.MaxAcceptNum);
            for (int j = 0; j < ServerSettings.MaxAcceptNum; j++)
            {
                poolOfAcceptEventArgs.Push(CreateNewSaeaForAccept());
            }
            for (int i = 0; i < ServerSettings.MaxConnections; i++)
            {
                AsyncHttpSocketConnection newConn = new AsyncHttpSocketConnection();
                theBufferManager.SetBuffer(newConn.recvEventArgs);
                theBufferManager.SetBuffer(newConn.sendEventArgs);
                newConn.recvEventArgs.Completed += IO_Completed;
                newConn.sendEventArgs.Completed += IO_Completed;
                connectionPool.Push(newConn);
            }
        }

        internal SocketAsyncEventArgs CreateNewSaeaForAccept()
        {
            SocketAsyncEventArgs acceptEventArg = new SocketAsyncEventArgs();
            acceptEventArg.Completed += AcceptEventArg_Completed;
            return acceptEventArg;
        }

        internal void StartAccept()
        {
            SocketAsyncEventArgs acceptEventArg;
            lock (acceptCollectionLock)
            {
                if (poolOfAcceptEventArgs.Count > 1)
                {
                    try
                    {
                        acceptEventArg = poolOfAcceptEventArgs.Pop();
                    }
                    catch
                    {
                        acceptEventArg = CreateNewSaeaForAccept();
                    }
                }
                else
                {
                    acceptEventArg = CreateNewSaeaForAccept();
                }
            }
            if (!theMaxConnectionsEnforcer.WaitOne(20000))
            {
                if (this.OnSocketError != null)
                {
                    this.OnSocketError(null, new SocketEventArgs(0, "等待连接超时"));
                }
                return;
            }
            try
            {
                if (!listenSocket.AcceptAsync(acceptEventArg))
                {
                    ProcessAccept(acceptEventArg);
                }
            }
            catch (Exception ex)
            {
                if (this.OnSocketError != null)
                {
                    this.OnSocketError(null, new SocketEventArgs(0, "AcceptAsync异常：" + ex.Message));
                }
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }
        }

        private void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        private void ProcessAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            if (acceptEventArgs.SocketError != 0)
            {
                if (this.OnSocketError != null)
                {
                    this.OnSocketError(null, new SocketEventArgs((int)acceptEventArgs.SocketError, "接入终端时报错"));
                }
                if (acceptEventArgs.SocketError == SocketError.OperationAborted)
                {
                    logger.Error("Http 监听服务已经退出");
                }
                else
                {
                    StartAccept();
                }
                return;
            }
            int numberOfConnectedSockets = Interlocked.Increment(ref currentAcceptSockets);
            StartAccept();
            AsyncHttpSocketConnection newConnection = connectionPool.Pop();
            newConnection.recvEventArgs.AcceptSocket = acceptEventArgs.AcceptSocket;
            newConnection.sendEventArgs.AcceptSocket = acceptEventArgs.AcceptSocket;
            newConnection.CreateDate = DateTime.Now;
            newConnection.ClientIP = (IPEndPoint)newConnection.recvEventArgs.AcceptSocket.RemoteEndPoint;
            if (connectId < 1000000)
            {
                Interlocked.Increment(ref connectId);
            }
            else
            {
                connectId = 1;
            }
            newConnection.ID = string.Concat(connectId);
            newConnection.PlateNo = "";
            newConnection.SimNo = "";
            NewConnection(newConnection);
            acceptEventArgs.AcceptSocket = null;
            lock (acceptCollectionLock)
            {
                poolOfAcceptEventArgs.Push(acceptEventArgs);
            }
            StartReceive(newConnection.recvEventArgs);
        }

        private void NewConnection(AsyncHttpSocketConnection asc)
        {
            Connections[asc.ID] = asc;
        }

        private void StartReceive(SocketAsyncEventArgs receiveSendEventArgs)
        {
            AsyncHttpSocketConnection receiveSendToken = (AsyncHttpSocketConnection)receiveSendEventArgs.UserToken;
            try
            {
                if (receiveSendEventArgs.AcceptSocket == null)
                {
                    logger.Error("socket已关闭");
                    return;
                }
                receiveSendEventArgs.SetBuffer(receiveSendEventArgs.Offset, ServerSettings.BufferSize);
                if (!receiveSendEventArgs.AcceptSocket.ReceiveAsync(receiveSendEventArgs))
                {
                    ProcessReceive(receiveSendEventArgs);
                }
            }
            catch (Exception ex)
            {
                if (this.OnSocketError != null)
                {
                    this.OnSocketError(receiveSendToken, new SocketEventArgs(0, "socket已关闭:" + ex.Message));
                }
            }
        }

        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            AsyncHttpSocketConnection receiveSendToken = (AsyncHttpSocketConnection)e.UserToken;
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    logger.Error("非法的IO操作");
                    break;
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs receiveSendEventArgs)
        {
            AsyncHttpSocketConnection conn = (AsyncHttpSocketConnection)receiveSendEventArgs.UserToken;
            if (receiveSendEventArgs.SocketError != 0)
            {
                logger.Error(conn.HttpUrl + "接收数据出错，被动关闭连接");
                CloseClientSocket(conn);
                return;
            }
            if (receiveSendEventArgs.BytesTransferred == 0)
            {
                logger.Error(conn.HttpUrl + "客户端正常关闭，服务器被动关闭连接");
                CloseClientSocket(conn);
                return;
            }
            int remainingBytesToProcess = (conn.lengthOfCurrentIncomingMessage = receiveSendEventArgs.BytesTransferred);
            conn.Recv();
            logger.Error("接入Http连接:" + conn.ToString());
            string key = conn.GetKey();
            if (key != null)
            {
                if (connMap.ContainsKey(key))
                {
                    HttpConnItem ls2 = connMap[key];
                    ls2.Add(conn);
                }
                else
                {
                    HttpConnItem ls = new HttpConnItem(key, conn);
                    connMap[key] = ls;
                }
            }
            else
            {
                logger.Error("http连接解析错误，没有获得SimNo数据，无法下发数据,服务器将主动关闭:" + conn.HttpUrl);
                CloseClientSocket(conn);
            }
            StartReceive(conn.recvEventArgs);
        }

        private void StartSend(SocketAsyncEventArgs sendEventArgs)
        {
            AsyncHttpSocketConnection conn = (AsyncHttpSocketConnection)sendEventArgs.UserToken;
            if (!sendEventArgs.AcceptSocket.SendAsync(sendEventArgs))
            {
                ProcessSend(sendEventArgs);
            }
        }

        private void ProcessSend(SocketAsyncEventArgs sendEventArgs)
        {
            AsyncHttpSocketConnection conn = (AsyncHttpSocketConnection)sendEventArgs.UserToken;
            if (sendEventArgs.SocketError == SocketError.Success)
            {
                conn.SendAsyncFromQueue();
                conn.DataUsage += sendEventArgs.BytesTransferred;
            }
            else
            {
                logger.Error(conn.GetKey() + "Http 异步发送数据出错，关闭连接");
                CloseClientSocket(conn);
            }
        }

        public void CloseConnection(string SimNo, int Channel)
        {
            try
            {
                if (connMap.IsEmpty)
                {
                    return;
                }
                string key = SimNo + "_" + Channel;
                HttpConnItem hi = null;
                if (!connMap.TryGetValue(key, out hi))
                {
                    return;
                }
                List<AsyncHttpSocketConnection> ls = hi.GetList();
                foreach (AsyncHttpSocketConnection asc in ls)
                {
                    CloseClientSocket(asc);
                }
                hi.Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        private void CloseClientSocket(AsyncHttpSocketConnection conn)
        {
            if (conn == null)
            {
                return;
            }
            AsyncHttpSocketConnection t = null;
            if (conn.GetKey() != null)
            {
                string key = conn.GetKey();
                HttpConnItem ls = null;
                if (connMap.TryGetValue(key, out ls))
                {
                    ls.Remove(conn);
                }
                Connections.TryRemove(conn.ID, out t);
            }
            if (conn.IsValid())
            {
                conn.Close();
            }
            if (!connectionPool.Contain(conn))
            {
                connectionPool.Push(conn);
                Interlocked.Decrement(ref currentAcceptSockets);
                releaseTimes++;
                theMaxConnectionsEnforcer.Release();
            }
        }

        private void HandleBadAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            if (acceptEventArgs.AcceptSocket != null)
            {
                acceptEventArgs.AcceptSocket.Close();
            }
            lock (acceptCollectionLock)
            {
                poolOfAcceptEventArgs.Push(acceptEventArgs);
            }
        }

        internal void CleanUpOnExit()
        {
            DisposeAllSaeaObjects();
        }

        private void DisposeAllSaeaObjects()
        {
            while (poolOfAcceptEventArgs != null && poolOfAcceptEventArgs.Count > 0)
            {
                SocketAsyncEventArgs eventArgs = poolOfAcceptEventArgs.Pop();
                eventArgs.Dispose();
            }
            foreach (AsyncHttpSocketConnection asc2 in Connections.Values)
            {
                try
                {
                    asc2.recvEventArgs.Dispose();
                    asc2.sendEventArgs.Dispose();
                    asc2.Close();
                }
                catch (Exception ex2)
                {
                    logger.Error(ex2.Message);
                    logger.Error(ex2.StackTrace);
                }
            }
            Connections.Clear();
            while (connectionPool != null && connectionPool.Count > 0)
            {
                AsyncHttpSocketConnection asc = connectionPool.Pop();
                try
                {
                    asc.recvEventArgs.Dispose();
                    asc.sendEventArgs.Dispose();
                    asc.Close();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }
            }
        }
    }
}
