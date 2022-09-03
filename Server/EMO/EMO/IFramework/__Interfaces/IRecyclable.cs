namespace IFramework
{
    /// <summary>
    /// 可回收
    /// </summary>
    public interface IRecyclable
    {
        /// <summary>
        /// 是否被回收
        /// </summary>
        bool recyled { get; }

        /// <summary>
        /// 回收
        /// </summary>
        void Recyle();
    }
}