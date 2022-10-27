using LMath;

namespace LCollision2D
{
    /// <summary>
    /// 射线
    /// </summary>
    public struct Ray
    {
        /// <summary>
        /// 位置
        /// </summary>
        public LVector2 start;
        /// <summary>
        /// 方向
        /// </summary>
        public LVector2 direction;
        public CollisionLayer layer;

    }

}


