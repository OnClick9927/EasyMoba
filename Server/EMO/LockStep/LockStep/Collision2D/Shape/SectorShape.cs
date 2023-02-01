using LockStep.Math;

namespace LockStep.LCollision2D
{
    /// <summary>
    /// 扇形
    /// </summary>
    public class SectorShape : Shape
    {
        /// <summary>
        /// 半径
        /// </summary>
        public LFloat radius;

        /// <summary>
        /// 扇形角
        /// </summary>
        public LFloat sectorAngle;

        public LFloat Radius { get; private set; }

        public override void Build()
        {
            base.Build();

            Radius = radius * scale;
            maxRadius = Radius;
        }
    }

}


