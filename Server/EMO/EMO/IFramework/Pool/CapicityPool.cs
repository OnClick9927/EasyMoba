namespace IFramework
{
    /// <summary>
    /// 有容量的对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CapicityPool<T>: ObjectPool<T>
    {
        private int _capcity;
        /// <summary>
        /// 存储容量
        /// </summary>
        public int capcity { get { return _capcity; } set { _capcity = value; } }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="capcity"></param>
        protected CapicityPool(int capcity) : base() { this._capcity = capcity; }
        /// <summary>
        /// 回收，当数量超过回收失败
        /// </summary>
        /// <param name="t"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected override bool OnSet(T t, IEventArgs arg)
        {
            return count <= capcity;
        }
    }

}
