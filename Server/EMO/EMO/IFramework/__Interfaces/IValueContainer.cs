namespace IFramework
{
    /// <summary>
    /// 数据容器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValueContainer<T>:IContainer
    {
        /// <summary>
        /// 数据
        /// </summary>
        T value { get; set; }
    }
}
