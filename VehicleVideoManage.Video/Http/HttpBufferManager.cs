using System.Net.Sockets;

namespace VehicleVideoManage.Video.Http
{
    /// <summary>
    /// Http缓冲区管理
    /// </summary>
    internal class HttpBufferManager
    {
        /// <summary>
        /// 缓存池总长度（字节为单位）
        /// </summary>
        private int totalBytesInBufferBlock;
        /// <summary>
        /// 缓存池所在内存空间
        /// </summary>
        private byte[] bufferBlock;
        /// <summary>
        /// 此栈记录缓存池中处于回收状态的缓存
        /// </summary>
        private Stack<int> freeIndexPool;
        /// <summary>
        /// 缓存池从最小索引值开始使用，此变量记录曾经使用到的最大值
        /// </summary>
        private int currentIndex;
        /// <summary>
        /// 单个缓存的长度（字节为单位）
        /// </summary>
        private int bufferBytesAllocatedForEachSaea;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalBytes"></param>
        /// <param name="totalBufferBytesInEachSaeaObject"></param>
        public HttpBufferManager(int totalBytes, int totalBufferBytesInEachSaeaObject)
        {
            totalBytesInBufferBlock = totalBytes;
            currentIndex = 0;
            bufferBytesAllocatedForEachSaea = totalBufferBytesInEachSaeaObject;
            freeIndexPool = new Stack<int>();
        }
        /// <summary>
        /// 初始化缓存池
        /// </summary>
        internal void InitBuffer()
        {
            bufferBlock = new byte[totalBytesInBufferBlock];
        }
        /// <summary>
        /// 为作为参数传递进来的saes划分缓存空间
        /// </summary>
        /// <param name="saea"></param>
        /// <returns></returns>
        internal bool SetBuffer(SocketAsyncEventArgs saea)
        {
            if (freeIndexPool.Count > 0) //如果存在处于回收状态的缓存
            {
                //从栈中取出缓存地址并赋予saea
                saea.SetBuffer(bufferBlock, freeIndexPool.Pop(), bufferBytesAllocatedForEachSaea);
            }
            else //没有处于回收状态的缓存
            {
                //如果缓存池空间不够则返回false
                if (totalBytesInBufferBlock - bufferBytesAllocatedForEachSaea < currentIndex)
                {
                    return false;
                }
                saea.SetBuffer(bufferBlock, currentIndex, bufferBytesAllocatedForEachSaea);//分配缓存池中的新空间
                currentIndex += bufferBytesAllocatedForEachSaea;//指定缓存池中新空间和旧空间的分界点
            }
            return true;
        }
        /// <summary>
        /// //释放saea所使用的缓存空间
        /// </summary>
        /// <param name="args"></param>
        internal void FreeBuffer(SocketAsyncEventArgs saea)
        {
            freeIndexPool.Push(saea.Offset);//将saea中用完的缓存地址压入栈中
            saea.SetBuffer(null, 0, 0);
        }
    }
}
