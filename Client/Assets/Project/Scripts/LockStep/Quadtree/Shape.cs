using LMath;
using System.Collections.Generic;
using System.Linq;

namespace LCollision2D
{
    public abstract class Shape
    {
        public bool dirty { get; private set; } = true;

        public LVector2 direction { get; private set; }
        /// <summary>
        /// 角度
        /// </summary>
        public LFloat angle = LFloat.zero;
        /// <summary>
        /// 位置
        /// </summary>
        public LVector2 position;
        /// <summary>
        /// 比例
        /// </summary>
        public LFloat scale = LFloat.one;
        /// <summary>
        /// 最大半径
        /// </summary>
        public LFloat maxRadius { get; protected set; }

        public virtual void Build()
        {
            dirty = false;
            direction = LVector2.up.Rotate(angle);
        }
        public void SetDirty()
        {
            dirty = true;
        }
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

    /// <summary>
    /// 矩形
    /// </summary>
    public class RectangleShape : Shape
    {
        public LFloat width;
        public LFloat height;

        /// <summary>
        /// 实际宽
        /// </summary>
        public LFloat Width { get; private set; }
        /// <summary>
        /// 实际高
        /// </summary>
        public LFloat Height { get; private set; }

        public override void Build()
        {
            base.Build();

            maxRadius = Math.Sqrt(Math.Sqr(Width) + Math.Sqr(Height)) / 2;
            Width = width * scale;
            Height = height * scale;
        }
    }

    /// <summary>
    /// 点的集合
    /// </summary>
    public struct Bound
    {
        /// <summary>
        /// 世界坐标
        /// </summary>
        public LVector2[] points;
        public LVector2 center;
        public Bound(LVector2[] points)
        {
            this.points = points;
            LVector2 sum = LVector2.zero;
            for (int i = 0; i < points.Length; i++)
            {
                sum += points[i];
            }
            center = sum / points.Length;

        }

        public bool FindLine(LVector2 start, LVector2 end)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == start)
                {
                    int last = (int)QuadtreeHelper.Repeat(i - 1, points.Length);
                    int next = (int)QuadtreeHelper.Repeat(i + 1, points.Length);
                    if (points[last] == end || points[next] == end)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 多边形
    /// </summary>
    public class PolygonShape : Shape
    {


        public LVector2[] localPoints;
        /// <summary>
        /// 多边形的点,世界坐标
        /// </summary>
        private LVector2[] points;


        public Bound[] bounds;
        public LVector2[] nomals;
        public override void Build()
        {
            base.Build();
            LFloat maxRadiusSqr = 0;
            points = new LVector2[localPoints.Length];
            for (int i = 0; i < localPoints.Length; i++)
            {
                LVector2 point = localPoints[i];
                point = point * scale;
                maxRadiusSqr = Math.Max(maxRadiusSqr, point.sqrMagnitude);
                point = point.Rotate(angle);
                point = point + position;
                points[i] = point;
            }
            maxRadius = Math.Sqrt(maxRadiusSqr);
            bounds = SplitPoint2Bound(points, new List<Bound>());

            nomals = new LVector2[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                int last = (int)QuadtreeHelper.Repeat(i - 1, points.Length);
                int cur = (int)QuadtreeHelper.Repeat(i, points.Length);
                var _last_point = points[last];
                var cur_point = points[cur];
                for (int j = 0; j < bounds.Length; j++)
                {
                    if (bounds[i].FindLine(_last_point, cur_point))
                    {
                        var point = QuadtreeHelper.Point2LineIntersection(_last_point, cur_point, bounds[i].center);
                        LVector2 normal = (point - bounds[i].center).normalized;
                        nomals[i] = normal;
                        break;
                    }
                }
            }
        }


        private static LVector2[] RemoveUselessPoint(List<LVector2> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                LVector2 last = points[(int)QuadtreeHelper.Repeat(i - 1, points.Count)];
                LVector2 cur = points[i];
                LVector2 next = points[(int)QuadtreeHelper.Repeat(i + 1, points.Count)];

                if (QuadtreeHelper.IsPointInSegment(last, next, cur))
                {
                    points.RemoveAt(i);
                    RemoveUselessPoint(points);
                    break;
                }
            }
            return points.ToArray();
        }

        private static bool MoreThan180(LVector2[] points, int i)
        {
            LVector2 last = points[(int)QuadtreeHelper.Repeat(i - 1, points.Length)];
            LVector2 cur = points[i];
            LVector2 next = points[(int)QuadtreeHelper.Repeat(i + 1, points.Length)];
            var dir = cur - last;
            var dir2 = next - cur;
            return LVector3.Cross(dir, dir2).z < 0;
        }
        private static bool IsLeagal(LVector2[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (MoreThan180(points, i))
                {
                    return false;
                }
            }
            return true;
        }
        private static Bound[] SplitPoint2Bound(LVector2[] points, List<Bound> list)
        {
            if (list == null) list = new List<Bound>();
            points = RemoveUselessPoint(points.ToList());
            if (IsLeagal(points))
            {
                list.Add(new Bound(points));
            }
            else
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (MoreThan180(points, i))
                    {
                        int j = i;
                        while (true)
                        {
                            j++;
                            int cur = (int)QuadtreeHelper.Repeat(j, points.Length);
                            if (!MoreThan180(points, cur))
                            {
                                int last = (int)QuadtreeHelper.Repeat(cur - 1, points.Length);
                                int next = (int)QuadtreeHelper.Repeat(cur + 1, points.Length);

                                LVector2[] points_1 = new LVector2[3];
                                for (int k = 0; k < 3; k++)
                                {
                                    points_1[k] = points[(int)QuadtreeHelper.Repeat(last + k, points.Length)];
                                }


                                int p2_len = points.Length - 1;
                                LVector2[] points_2 = new LVector2[p2_len];

                                int _next = next;
                                int _index = 0;
                                while (true)
                                {
                                    _next = (int)QuadtreeHelper.Repeat(_next, points.Length);
                                    points_2[_index] = points[_next];
                                    if (_next == last)
                                    {
                                        break;
                                    }
                                    _index++;
                                    _next++;
                                }
                                SplitPoint2Bound(points_1, list);
                                SplitPoint2Bound(points_2, list);
                                break;
                            }
                        }
                        break;
                    }

                }

            }
            return list.ToArray();
        }
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

        public LFloat Radius { get; private set; }

        public override void Build()
        {
            base.Build();

            Radius = radius * scale;
            maxRadius = radius;
        }
    }



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

    }

    /// <summary>
    /// 射线击中的shape
    /// </summary>
    public struct RayHit
    {
        public LVector2 point;
        public LFloat distance;
        public Shape shape;
    }

}


