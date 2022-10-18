using LMath;


namespace LCollision2D
{
    public abstract class Shape
    {
        /// <summary>
        /// 角度
        /// </summary>
        public LFloat angle;
        /// <summary>
        /// 位置
        /// </summary>
        public LVector2 position;
        /// <summary>
        /// 比例
        /// </summary>
        public LFloat scale;
        /// <summary>
        /// 最大半径
        /// </summary>
        public abstract LFloat maxRadius { get; }
    }

    /// <summary>
    /// 圆
    /// </summary>
    public class CircleShape : Shape
    {
        /// <summary>
        /// 半径
        /// </summary>
        public LFloat radius;
        /// <summary>
        /// 最大半径
        /// </summary>
        public override LFloat maxRadius => Radius;

        /// <summary>
        /// 实际半径
        /// </summary>
        public LFloat Radius => radius * scale; 
    }

    /// <summary>
    /// 矩形
    /// </summary>
    public class RectangleShape : Shape
    {
        public LFloat width;
        public LFloat height;

        public override LFloat maxRadius
        {
            get
            {
                return Math.Sqrt(Math.Sqr(Width) + Math.Sqr(Height)) / 2;
            }
        }

        /// <summary>
        /// 实际宽
        /// </summary>
        public LFloat Width => width * scale;
        /// <summary>
        /// 实际高
        /// </summary>
        public LFloat Height => height * scale;
    }

    /// <summary>
    /// 点的集合
    /// </summary>
    public struct Bound
    {
        public LVector2[] points;
    }

    /// <summary>
    /// 多边形
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        /// 多边形的点
        /// </summary>
        public Bound bound;

        public override LFloat maxRadius
        {
            get
            {
                LFloat maxRadiusSqr = 0;
                LFloat tmpRadiusSqr;
                foreach (var point in Bound.points)
                {
                    tmpRadiusSqr = Math.Sqr(point.x) + Math.Sqr(point.y);
                    maxRadiusSqr = Math.Max(maxRadiusSqr, tmpRadiusSqr);
                }
                return Math.Sqrt(maxRadiusSqr);
            }
        }

        /// <summary>
        /// 实际点
        /// </summary>
        public Bound Bound;
    }

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

        /// <summary>
        /// 最大半径
        /// </summary>
        public override LFloat maxRadius => Radius;


        public LFloat Radius => radius * scale;
    }



    /// <summary>
    /// 射线
    /// </summary>
    public struct Ray
    {
        /// <summary>
        /// 位置
        /// </summary>
        public LVector2 position;
        /// <summary>
        /// 方向
        /// </summary>
        public LVector2 direction;

        int layer;
    }

    /// <summary>
    /// 射线击中的shape
    /// </summary>
    public struct RayHit
    {
        public bool success;
        public Shape[] shapes;
    }

    /// <summary>
    /// 直线
    /// </summary>
    public struct Line
    {
        /// <summary>
        /// 直线上一点
        /// </summary>
        public LVector2 point;
        /// <summary>
        /// 方向
        /// </summary>
        public LVector2 direction;
    }

    /// <summary>
    /// 线段
    /// </summary>
    public struct Segment
    {
        public LVector2 point1;
        public LVector2 point2;
    }
}


