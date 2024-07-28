using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.Http
{
    internal sealed class HttpConnectionPool
    {
        private static ILog logger = LogManager.GetLogger(typeof(HttpConnectionPool));

        private int nextTokenId = 0;

        private Stack<AsyncHttpSocketConnection> pool;

        internal int Count => pool.Count;

        internal HttpConnectionPool(int capacity)
        {
            pool = new Stack<AsyncHttpSocketConnection>(capacity);
        }

        internal int AssignTokenId()
        {
            return Interlocked.Increment(ref nextTokenId);
        }

        internal AsyncHttpSocketConnection Pop()
        {
            lock (pool)
            {
                return pool.Pop();
            }
        }

        internal bool Contain(AsyncHttpSocketConnection conn)
        {
            lock (pool)
            {
                return pool.Contains(conn);
            }
        }

        internal void Push(AsyncHttpSocketConnection item)
        {
            if (item == null)
            {
                logger.Error("Items added to a SocketAsyncEventArgsPool cannot be null");
                return;
            }
            lock (pool)
            {
                pool.Push(item);
            }
        }
    }
}
