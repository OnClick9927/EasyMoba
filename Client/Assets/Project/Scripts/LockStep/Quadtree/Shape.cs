using LMath;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public LFloat maxRadius { get; protected set; }

        public abstract void Build();
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
            maxRadius = Radius;
            Radius = radius * scale;
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
        public LVector2[] points;
        public Bound(LVector2[] points)
        {
            this.points = RemoveUselessPoint(points.ToList());
        }
        private static LVector2[] RemoveUselessPoint(List<LVector2> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                LVector2 last = points[(int)QuadtreeHelper.Repeat(i - 1, points.Count)];
                LVector2 cur = points[i];
                LVector2 next = points[(int)QuadtreeHelper.Repeat(i + 1, points.Count)];

                var dir1 = cur - last;
                var dir2 = next - last;
                if (dir1.x / dir1.y == dir2.x / dir2.y)
                {
                    points.RemoveAt(i);
                    RemoveUselessPoint(points);
                    break;
                }
            }
            return points.ToArray();
        }

        private static bool MoreThan180(Bound p, int i)
        {
            LVector2 last = p.points[(int)QuadtreeHelper.Repeat(i - 1, p.points.Length)];
            LVector2 cur = p.points[i];
            LVector2 next = p.points[(int)QuadtreeHelper.Repeat(i + 1, p.points.Length)];
            var dir = cur - last;
            var dir2 = next - cur;
            return LVector3.Cross(dir, dir2).z < 0;
        }
        private static bool IsLeagal(Bound p)
        {
            for (int i = 0; i < p.points.Length; i++)
            {
                if (MoreThan180(p, i))
                {
                    return false;
                }
            }
            return true;
        }
        public static Bound[] Split(Bound p, List<Bound> list)
        {
            if (list == null) list = new List<Bound>();
            if (IsLeagal(p))
            {
                list.Add(p);
            }
            else
            {
                for (int i = 0; i < p.points.Length; i++)
                {
                    if (MoreThan180(p, i))
                    {
                        int j = i;
                        while (true)
                        {
                            j++;
                            int cur = (int)QuadtreeHelper.Repeat(j, p.points.Length);
                            if (!MoreThan180(p, cur))
                            {
                                int last = (int)QuadtreeHelper.Repeat(cur - 1, p.points.Length);
                                int next = (int)QuadtreeHelper.Repeat(cur + 1, p.points.Length);

                                LVector2[] points_1 = new LVector2[3];
                                for (int k = 0; k < 3; k++)
                                {
                                    points_1[k] = p.points[(int)QuadtreeHelper.Repeat(last + k, p.points.Length)];
                                }
                                Bound _p1 = new Bound(points_1) { };

                                list.Add(_p1);
                                int p2_len = p.points.Length - 1;
                                LVector2[] points_2 = new LVector2[p2_len];

                                int _next = next;
                                int _index = 0;
                                while (true)
                                {
                                    _next = (int)QuadtreeHelper.Repeat(_next, p.points.Length);
                                    points_2[_index] = p.points[_next];
                                    if (_next == last)
                                    {
                                        break;
                                    }
                                    _index++;
                                    _next++;
                                }
                                Bound _p2 = new Bound(points_2) { };
                                Split(_p2, list);
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
    /// 多边形
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        /// 多边形的点
        /// </summary>
        public Bound bound;

        /// <summary>
        /// 实际点
        /// </summary>
        public Bound Bound;
        public Bound[] bounds;

        public override void Build()
        {
            bounds = Bound.Split(Bound, new List<Bound>());
            LFloat maxRadiusSqr = 0;
            LFloat tmpRadiusSqr;
            foreach (var point in Bound.points)
            {
                tmpRadiusSqr = Math.Sqr(point.x) + Math.Sqr(point.y);
                maxRadiusSqr = Math.Max(maxRadiusSqr, tmpRadiusSqr);
            }
            maxRadius = Math.Sqrt(maxRadiusSqr);
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


