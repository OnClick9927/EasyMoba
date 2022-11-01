using LockStep.Math;

namespace LockStep.LCollision2D
{
    /// <summary>
    /// 圆
    /// </summary>
    [System.Serializable]
    public class CircleShape : Shape
    {
        /// <summary>
        /// 半径
        /// </summary>
        public LFloat radius;

        /// <summary>
        /// 实际半径
        /// </summary>
        public LFloat Radius { get; private set; }

        public override void Build()
        {
            base.Build();
            Radius = radius * scale;
            maxRadius = Radius;
        }
    }

}


