using System;
using System.Threading;

namespace IFramework.Net
{
    /// <summary>
    /// 自旋锁
    /// </summary>
    public sealed class LockWait : IDisposable
    {
        private LockParam _param = null;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="param"></param>
        public LockWait(ref LockParam param)
        {
            this._param = param;
            while (Interlocked.CompareExchange(ref param.signal, 1, 0) == 1)
            {
                Thread.Sleep(param.sleepInterval);
            }
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Interlocked.Exchange(ref _param.signal, 0);
        }
    }

    /// <summary>
    /// 自旋锁信号
    /// </summary>
    public class LockParam
    {
        internal int signal = 0;

        internal int sleepInterval = 1;
    }
}
