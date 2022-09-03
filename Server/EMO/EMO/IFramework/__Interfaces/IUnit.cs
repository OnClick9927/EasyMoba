using System;

namespace IFramework
{
    /// <summary>
    /// 积累接口
    /// </summary>
    public interface IUnit: IDisposable
    {
        /// <summary>
        /// 是否释放
        /// </summary>
        bool disposed { get; }
    }
}
