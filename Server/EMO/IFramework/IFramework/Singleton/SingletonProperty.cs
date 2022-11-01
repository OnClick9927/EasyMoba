namespace IFramework.Singleton
{
    /// <summary>
    /// 单例属性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SingletonProperty<T> where T : class, ISingleton
    {
        private static T _instance;
        private static readonly object lockObj = new object();
        /// <summary>
        /// 实例
        /// </summary>
        public static T instance
        {
            get
            {
                lock (lockObj)
                    if (_instance == null)
                    {
                        _instance = SingletonCreator.CreateSingleton<T>();
                        SingletonCollection.Set(_instance);
                    }

                return _instance;
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        public static void Dispose() { _instance = null; }
    }

}
