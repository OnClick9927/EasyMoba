namespace IFramework
{
    /// <summary>
    /// 属于环境
    /// </summary>
    public interface IBelongToEnvironment
    {
        /// <summary>
        /// 环境
        /// </summary>
        IEnvironment env { get; }
    }
}
