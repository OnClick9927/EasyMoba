﻿using LockStep.Math;
using System.Collections.Generic;
using System.Linq;

namespace LockStep.LCollision2D
{
    /// <summary>
    /// 多边形
    /// </summary>
    [System.Serializable]
    public class PolygonShape : Shape
    {


        public LVector2[] localPoints;
        /// <summary>
        /// 多边形的点,世界坐标
        /// </summary>
        public LVector2[] points;


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
                maxRadiusSqr = LMath.Max(maxRadiusSqr, point.sqrMagnitude);
                point = point.Rotate(angle);
                point = point + position;
                points[i] = point;
            }
            maxRadius = LMath.Sqrt(maxRadiusSqr);
            bounds = SplitPoint2Bound(points, new List<Bound>());

            nomals = new LVector2[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                int last = (int)CollisionHelper.Repeat(i - 1, points.Length);
                int cur = (int)CollisionHelper.Repeat(i, points.Length);
                var _last_point = points[last];
                var cur_point = points[cur];
                for (int j = 0; j < bounds.Length; j++)
                {
                    var bound = bounds[j];
                    if (bound.FindLine(_last_point, cur_point))
                    {
                        var point = CollisionHelper.Point2LineIntersection(_last_point, cur_point, bound.center);
                        LVector2 normal = (point - bound.center).normalized;
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
                var _last = (int)CollisionHelper.Repeat(i - 1, points.Count);
                LVector2 last = points[_last];
                LVector2 cur = points[i];
                LVector2 next = points[(int)CollisionHelper.Repeat(i + 1, points.Count)];

                if (CollisionHelper.IsPointInSegment(last, next, cur))
                {
                    points.Remove(points[i]);
                    RemoveUselessPoint(points);
                    break;
                }


            }
            return points.ToArray();
        }

        private static bool MoreThan180(LVector2[] points, int i)
        {
            LVector2 last = points[(int)CollisionHelper.Repeat(i - 1, points.Length)];
            LVector2 cur = points[i];
            LVector2 next = points[(int)CollisionHelper.Repeat(i + 1, points.Length)];
            var dir = cur - last;
            var dir2 = next - cur;
            return LVector3.Cross(dir, dir2).z > 0;
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
                            int cur = (int)CollisionHelper.Repeat(j, points.Length);
                            if (!MoreThan180(points, cur))
                            {
                                int last = (int)CollisionHelper.Repeat(cur - 1, points.Length);
                                int next = (int)CollisionHelper.Repeat(cur + 1, points.Length);

                                LVector2[] points_1 = new LVector2[3];
                                for (int k = 0; k < 3; k++)
                                {
                                    points_1[k] = points[(int)CollisionHelper.Repeat(last + k, points.Length)];
                                }


                                int p2_len = points.Length - 1;
                                LVector2[] points_2 = new LVector2[p2_len];

                                int _next = next;
                                int _index = 0;
                                while (true)
                                {
                                    _next = (int)CollisionHelper.Repeat(_next, points.Length);
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

}


