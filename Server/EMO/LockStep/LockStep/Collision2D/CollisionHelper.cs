using IFramework;
using LockStep.Math;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using LMath = LockStep.Math.LMath;

namespace LockStep.LCollision2D
{
    public class CollisionHelper
    {

        public static Node AllocateNode()
        {
            return Framework.GlobalAllocate<Node>();
        }
        public static void RecyleNode(Node node)
        {
            node.parrent = null;
            node.shapes.Clear();
            node.nodes.Clear();
            node.area = LRect.zero;
            node.GlobalRecyle();
        }

        public static bool CouldCollisionShape(LRect area, LFloat maxRadius, Shape shape)
        {
            var point = shape.position;

            LFloat xDistance = LMath.Max(point.x - area.xMax, area.x - point.x);
            LFloat yDistance = LMath.Max(point.y - area.yMax, area.y - point.y);
            xDistance = LMath.Max(xDistance, LFloat.zero);
            yDistance = LMath.Max(yDistance, LFloat.zero);

            var xx = maxRadius + shape.maxRadius;
            return xDistance * xDistance + yDistance * yDistance < xx * xx;
        }
        public static bool CouldRaycastNode(Ray ray, LRect area, LFloat maxRadius)
        {
            LFloat xmin = area.position.x - maxRadius;
            LFloat xmax = area.xMax + maxRadius;
            LFloat ymin = area.position.y - maxRadius;
            LFloat ymax = area.yMax + maxRadius;
            LVector2 lt = new LVector2(xmin, ymin);
            LVector2 ld = new LVector2(xmin, ymax);
            LVector2 rd = new LVector2(xmax, ymax);
            LVector2 rt = new LVector2(xmax, ymin);
            if (CouldLightSegmentIntersect(ray.start, ray.direction, lt, rd))
                return true;
            if (CouldLightSegmentIntersect(ray.start, ray.direction, ld, rt))
                return true;
            return false;
        }



        public static int Repeat(int value, int length)
        {
            return (value + length) % length;
        }
        private static bool IsRangeCross(LVector2 a, LVector2 b)
        {
            return LMath.Max(a.x._val, b.x._val) < LMath.Min(a.y._val, b.y._val); ;
        }

        // Ax+By+C=0 求ABC
        private static void GetLineABC(LVector2 start, LVector2 end, out LFloat a, out LFloat b, out LFloat c)
        {
            a = (start.y - end.y);
            b = (end.x - start.x);
            c = -(a * start.x + b * start.y);
        }
        // 俩直线交点
        private static LVector2 LineLineIntersectPoint(LVector2 a_start, LVector2 a_end, LVector2 b_start, LVector2 b_end)
        {
            LFloat A1, B1, C1;
            LFloat A2, B2, C2;
            GetLineABC(a_start, a_end, out A1, out B1, out C1);
            GetLineABC(b_start, b_end, out A2, out B2, out C2);
            LFloat x = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
            LFloat y = (A1 * C2 - C1 * A2) / (B1 * A2 - A1 * B2);
            return new LVector2(x, y);
        }

        // 点往直线做垂线的交点
        public static LVector2 Point2LineIntersection(LVector2 line_start, LVector2 line_end, LVector2 point)
        {
            var line = line_start - line_end;
            var normal = new LVector2(line.y, -line.x);
            var _point = LineLineIntersectPoint(line_start, line_end, point, point + normal);
            return _point;
        }
        // 判断直线是否不是平行
        private static bool CouldlineLineIntersect(LVector2 a_start, LVector2 a_end, LVector2 b_start, LVector2 b_end)
        {
            var a = a_start - a_end;
            var b = b_start - b_end;
            LFloat A1 = a.x;
            LFloat B1 = a.y;
            LFloat A2 = b.x;
            LFloat B2 = b.y;
            return A1 * B2 != A2 * B1 && A1 * B2 != -A2 * B1;
        }
        // 判断射线与线段是否相交
        private static bool CouldLightSegmentIntersect(LVector2 ray_start, LVector2 ray_dir, LVector2 seg_start, LVector2 seg_end)
        {
            if (ray_start == seg_start)
                return true;
            if (ray_start == seg_end)
                return true;

            if (!CouldlineLineIntersect(ray_start, ray_start + ray_dir, seg_start, seg_end))
            {
                return false;
            }
            var dir2 = seg_start - ray_start;
            var dir3 = seg_end - ray_start;
            var aa = LVector3.Cross(ray_dir, dir2);
            var bb = LVector3.Cross(ray_dir, dir3);
            return LVector3.Dot(aa, bb) < 0;
        }

        // 获取点到线段最近的一个点
        private static LVector2 FindNearestPointInSegment(LVector2 seg_start, LVector2 seg_end, LVector2 point)
        {
            var seg_dir = seg_end - seg_start;
            var dir = point - seg_start;
            var percent = LMath.Clamp01(LVector2.Dot(seg_dir, dir) / LVector2.Dot(seg_dir, seg_dir));
            return seg_start + percent * seg_dir;
        }
        // 获取点到射线最近的一个点
        private static LVector2 FindNearestPointInLight(LVector2 ray_start, LVector2 ray_dir, LVector2 point)
        {
            var dir = point - ray_start;

            LFloat percent = LMath.Max(LFloat.zero, LVector2.Dot(ray_dir, dir) / LVector2.Dot(dir, dir));
            return ray_start + percent * ray_dir;
        }


        // 点是否在线段上
        public static bool IsPointInSegment(LVector2 seg_start, LVector2 seg_end, LVector2 point)
        {
            return FindNearestPointInSegment(seg_start, seg_end, point) == point;
        }
        // 点是否在射线上
        private static bool IsPointInLight(LVector2 seg_start, LVector2 ray_dir, LVector2 point)
        {
            return FindNearestPointInLight(seg_start, ray_dir, point) == point;
        }
        /// <summary>
        /// 一个点在不在胶囊里面
        /// </summary>
        /// <param name="seg_start"></param>
        /// <param name="seg_end"></param>
        /// <param name="point"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private static bool IsPointInCapsule(LVector2 seg_start, LVector2 seg_end, LVector2 point, LFloat radius)
        {
            LVector2 near = FindNearestPointInSegment(seg_start, seg_end, point);
            var dir = point - near;
            return dir.sqrMagnitude < radius * radius;
        }
        private static bool IsPointInCircle(LVector2 position, LFloat radius, LVector2 point)
        {
            //比较半径和点与圆心的距离
            return radius * radius > (position - point).sqrMagnitude;
        }
        private static bool IsPointInBound(Bound bound, LVector2 point)
        {
            bool flag = false;
            for (int i = 0; i < bound.points.Length; i++)
            {
                var last = bound.points[Repeat(i - 1, bound.points.Length)];
                var cur = bound.points[i];

                LVector3 cross = LVector3.Cross(last - point, cur - point);
                if (i == 1)
                {
                    flag = cross.z <= 0;
                }
                else
                {
                    if ((cross.z <= 0) != flag)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //-------------------------------------------------------------------------------
        public static bool CouldCollision(Shape a, Shape b, QuadTree tree)
        {
            if (!tree.layer.CouldLayerCollision(a.layer, b.layer)) return false;
            var dir = a.position - b.position;
            if (dir.sqrMagnitude > a.maxRadius * a.maxRadius + b.maxRadius * b.maxRadius)
            {
                return false;
            }
            var name_a = a.GetType().Name;
            var name_b = b.GetType().Name;

            switch (name_a)
            {
                case nameof(CircleShape):
                    switch (name_b)
                    {
                        case nameof(CircleShape):
                            return Circle2Circle(a as CircleShape, b as CircleShape);
                        case nameof(PolygonShape):
                            return Circle2Polygon(a as CircleShape, b as PolygonShape);
                        case nameof(SectorShape):
                            return Circle2SectorShape(a as CircleShape, b as SectorShape);
                    }
                    break;
                case nameof(PolygonShape):
                    switch (name_b)
                    {
                        case nameof(CircleShape):
                            return Circle2Polygon(b as CircleShape, a as PolygonShape);
                        case nameof(PolygonShape):
                            return Polygon2Polygon(a as PolygonShape, b as PolygonShape);
                    }
                    break;
                case nameof(SectorShape):
                    switch (name_b)
                    {
                        case nameof(CircleShape):
                            return Circle2SectorShape(b as CircleShape, a as SectorShape);
                    }
                    break;
            }

            return false;
        }

        private static bool Circle2SectorShape(CircleShape circle, SectorShape b)
        {
            LVector2 dir = circle.position - b.position;
            LFloat rsum = circle.Radius + b.Radius;
            if (dir.sqrMagnitude > rsum * rsum)
                return false;
            var angle = b.sectorAngle / 2;
            var p1_dir = b.direction.Rotate(angle) * b.Radius;
            var p2_dir = b.direction.Rotate(-angle) * b.Radius;
            //同一方向，说明在外面
            if (LVector3.Dot(LVector3.Cross(dir, p1_dir), LVector3.Cross(dir, p2_dir)) > 0)
                return false;
            var p1 = p1_dir + b.position;
            var p2 = p2_dir + b.position;
            var point1 = FindNearestPointInSegment(b.position, p1, circle.position);
            var point2 = FindNearestPointInSegment(b.position, p2, circle.position);

            return (point1 - circle.position).sqrMagnitude <= circle.Radius * circle.Radius
                || (point2 - circle.position).sqrMagnitude <= circle.Radius * circle.Radius;
        }

        private static LVector2 GetRange(Bound bound, LVector2 normal)
        {
            LVector2 v = new LVector2();
            for (int i = 0; i < bound.points.Length; i++)
            {
                var value = LVector2.Dot(normal, bound.points[i]);
                if (i == 0)
                {
                    v.x = value;
                    v.y = value;
                }
                else
                {
                    if (value < v.x)
                        v.x = value;
                    if (value > v.y)
                        v.y = value;
                }

            }
            return v;
        }
        private static LVector2 GetRange(CircleShape c, LVector2 normal)
        {
            var value = LVector2.Dot(normal, c.position);
            return new LVector2(value - c.Radius, value + c.Radius);
        }

        private static bool Bound2Bound(Bound a, Bound b)
        {
            for (int i = 0; i < a.points.Length; i++)
            {
                var last = a.points[Repeat(i - 1, a.points.Length)];
                var cur = a.points[i];
                var dir = cur - last;
                var normal = new LVector2(dir.y, -dir.x);
                LVector2 a_range = GetRange(a, normal);
                LVector2 b_range = GetRange(b, normal);
                if (!IsRangeCross(a_range, b_range))
                {
                    return false;
                }
            }
            for (int i = 0; i < b.points.Length; i++)
            {
                var last = b.points[Repeat(i - 1, b.points.Length)];
                var cur = b.points[i];
                var dir = cur - last;
                var normal = new LVector2(dir.y, -dir.x);
                LVector2 a_range = GetRange(a, normal);
                LVector2 b_range = GetRange(b, normal);
                if (!IsRangeCross(a_range, b_range))
                {
                    return false;
                }
            }

            return true;
        }
        private static bool Bound2Circle(Bound a, CircleShape b)
        {
            long dis = -1;
            int index = 0;
            for (int i = 0; i < a.points.Length; i++)
            {
                var last = a.points[Repeat(i - 1, a.points.Length)];
                var cur = a.points[i];
                var dir = cur - last;
                var normal = new LVector2(dir.y, -dir.x).normalized;
                LVector2 a_range = GetRange(a, normal);
                LVector2 b_range = GetRange(b, normal);
                LFloat length = (a.points[i] - b.position).sqrMagnitude;
                if (i == 0 || length < dis)
                {
                    dis = length;
                    index = i;
                }

                if (!IsRangeCross(a_range, b_range))
                {
                    return false;
                }
            }

            {
                LVector2 normal = (b.position - a.points[index]).normalized;
                LVector2 a_range = GetRange(a, normal);
                LVector2 b_range = GetRange(b, normal);
                if (!IsRangeCross(a_range, b_range))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool Circle2Circle(CircleShape circle1, CircleShape circle2)
        {
            return circle1.Radius + circle2.Radius > (circle1.position - circle2.position).magnitude;
        }
        private static bool Circle2Polygon(CircleShape c, PolygonShape p)
        {
            for (int i = 0; i < p.bounds.Length; i++)
            {
                if (Bound2Circle(p.bounds[i], c))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool Polygon2Polygon(PolygonShape p1, PolygonShape p2)
        {
            for (int i = 0; i < p1.bounds.Length; i++)
            {
                for (int j = 0; j < p2.bounds.Length; j++)
                {
                    if (Bound2Bound(p1.bounds[i], p2.bounds[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //-------------------------------------------------------------------------------
        public static bool RayCast(Ray ray, Shape b, out RayHit hit)
        {
            hit = new RayHit();
            if (!ray.layer.HasFlag(b.layer)) return false;

            switch (b.GetType().Name)
            {
                case nameof(CircleShape):
                    return RayCircle(ray, b as CircleShape, out hit);
                case nameof(PolygonShape):
                    return RayPolygon(ray, b as PolygonShape, out hit);
                default:
                    break;
            }
            return false;
        }
        private static bool RayPolygon(Ray ray, PolygonShape c, out RayHit hit)
        {
            hit = new RayHit();
            var near = FindNearestPointInLight(ray.start, ray.direction, c.position);
            if (near == ray.start) return false;
            var _dir = near - c.position;
            if (_dir.sqrMagnitude > c.maxRadius * c.maxRadius) return false;
            var ray_start = ray.start;
            int index = -1;
            LFloat sqrMagnitude = new LFloat();
            LVector2 point = new LVector2();

            for (int i = 0; i < c.points.Length; i++)
            {
                var last = c.points[Repeat(i - 1, c.points.Length)];
                var cur = c.points[i];
                if (CouldLightSegmentIntersect(ray_start, ray.direction, last, cur))
                {
                    var __point = LineLineIntersectPoint(ray_start, ray.direction + ray.start, last, cur);
                    var dir = __point - ray_start;
                    var _sqrMagnitude = dir.sqrMagnitude;
                    if (index == -1 || sqrMagnitude > _sqrMagnitude)
                    {
                        index = i;
                        sqrMagnitude = _sqrMagnitude;
                        point = __point;
                    }

                }
            }
            if (index != -1)
            {
                hit.point = point;
                hit.distance = LMath.Sqrt(sqrMagnitude);
                hit.shape = c;
                hit.normal = c.nomals[index];
            }
            return index != -1;

        }
        private static bool RayCircle(Ray ray, CircleShape c, out RayHit hit)
        {
            hit = new RayHit();
            if (IsPointInCircle(c.position, c.Radius, ray.start)) return false;
            var point = FindNearestPointInLight(ray.start, ray.direction, c.position);
            if (point == ray.start) return false;
            var dir = point - c.position;
            if (dir.sqrMagnitude > c.Radius * c.Radius) return false;

            var _base = LMath.Sqrt(c.Radius * c.Radius - dir.sqrMagnitude);
            var p1 = point + ray.direction * _base;
            var p2 = point - ray.direction * _base;
            var dis_1 = (p1 - ray.direction).sqrMagnitude;
            var dis_2 = (p2 - ray.direction).sqrMagnitude;
            hit.shape = c;
            hit.normal = -ray.direction;
            if (dis_1 < dis_2)
            {
                hit.point = p1;
                hit.distance = LMath.Sqrt(dis_1);
            }
            else
            {
                hit.point = p2;
                hit.distance = LMath.Sqrt(dis_2);
            }
            return true;
        }

        //-------------------------------------------------------------------------------

        public static LVector2 PositionCorrection(LVector2 lastPos, Shape shape, List<Shape> collisons)
        {
            if (!(shape is CircleShape)) return LVector2.zero;
            CircleShape move = shape as CircleShape;
            LVector2 light = LVector2.zero;
            LVector2 cur = shape.position;
            var dir = cur - lastPos;
            for (int i = 0; i < collisons.Count; i++)
            {
                var c = collisons[i];
                var name_b = c.GetType().Name;

                switch (name_b)
                {
                    case nameof(CircleShape):
                        {
                            CircleShape cir = c as CircleShape;
                            var normal = (lastPos - cir.position).normalized;
                            var add_dir = normal;
                            var _dir = move.position - cir.position;
                            if (LVector2.Dot(normal, dir) > 0)
                            {
                                var length = cir.Radius + move.Radius - _dir.magnitude;
                                add_dir *= length;
                            }
                            else
                            {
                                var length = cir.Radius + move.Radius + _dir.magnitude;
                                add_dir *= length;
                            }
                            light += add_dir;
                        }
                        break;
                    case nameof(PolygonShape):
                        {
                            PolygonShape p = c as PolygonShape;
                            var move_dir = move.position - lastPos;
                            for (int j = 0; j < p.points.Length; j++)
                            {
                                var curPoint = p.points[(int)CollisionHelper.Repeat(j, p.points.Length)];
                                var lastpoint = p.points[(int)CollisionHelper.Repeat(j - 1, p.points.Length)];
                                var p1 = FindNearestPointInSegment(lastpoint, curPoint, lastPos);
                                var p2 = FindNearestPointInSegment(lastpoint, curPoint, move.position);
                                var p3 = (p1 + p2) / 2;
                                if (!IsPointInCapsule(lastPos, move.position, p3, move.Radius))
                                    continue;
                                var normal = p.nomals[j];

                                if (LVector2.Dot(move_dir, normal) > 0) continue;
                                var jiao = Point2LineIntersection(lastpoint, curPoint, move.position);
                                var _dir = shape.position - jiao;
                                var add_dir = normal;

                                if (LVector2.Dot(_dir, normal) > 0)
                                {
                                    var length = move.Radius - _dir.magnitude;
                                    add_dir *= length;

                                }
                                else
                                {
                                    var length = move.Radius + _dir.magnitude;
                                    add_dir *= length;

                                }
                                light += add_dir;

                            }
                        }
                        break;
                }
            }
            return light;
        }


    }
}


