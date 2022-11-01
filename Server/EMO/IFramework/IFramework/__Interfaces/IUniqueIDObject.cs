using System;

namespace IFramework
{
    /// <summary>
    /// 唯一id
    /// </summary>
    public interface IUniqueIDObject
    {
        /// <summary>
        /// 唯一id
        /// </summary>
        Guid guid { get; }
    }
}
