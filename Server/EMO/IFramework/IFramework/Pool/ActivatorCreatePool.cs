using System;

namespace IFramework
{
    /// <summary>
    /// Activator 创建实例 对现池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActivatorCreatePool<T> : ObjectPool<T>
    {
        private object[] args;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="args">构造固定参数</param>
        public ActivatorCreatePool(params object[] args)
        {
            this.args = args;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected override T CreateNew(IEventArgs arg)
        {
            Type type = typeof(T);
            return (T)Activator.CreateInstance(type, args);
        }
    }
}
