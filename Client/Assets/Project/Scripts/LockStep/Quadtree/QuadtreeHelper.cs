using IFramework;
using LMath;
using Math = LMath.Math;

namespace LCollision2D
{
    public class QuadtreeHelper
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

            LFloat xDistance = Math.Max(point.x - area.xMax, area.x - point.x);
            LFloat yDistance = Math.Max(point.y - area.yMax, area.y - point.y);
            xDistance = Math.Max(xDistance, LFloat.zero);
            yDistance = Math.Max(yDistance, LFloat.zero);

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
            if (CouldLightSegmentIntersect(ray.start, ray.start + ray.direction, lt, rd))
                return true;
            if (CouldLightSegmentIntersect(ray.start, ray.start + ray.direction, ld, rt))
                return true;
            return false;
        }



        public static int Repeat(int value, int length)
        {
            return value % length;
        }
        private static bool IsRangeCross(LVector2 a, LVector2 b)
        {
            return Math.Max(a.x._val, b.x._val) < Math.Min(a.y._val, b.y._val); ;
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
        private static bool CouldLightSegmentIntersect(LVector2 ray_start, LVector2 ray_end, LVector2 seg_start, LVector2 seg_end)
        {
            if (ray_start == seg_start)
                return true;
            if (ray_start == seg_end)
                return true;
            if (ray_end == seg_start)
                return true;
            if (ray_end == seg_end)
                return true;
            if (!CouldlineLineIntersect(ray_start, ray_end, seg_start, seg_end))
            {
                return false;
            }
            var dir = ray_end - ray_start;
            var dir2 = seg_start - ray_start;
            var dir3 = seg_end - ray_start;
            var aa = LVector3.Cross(dir, dir2);
            var bb = LVector3.Cross(dir, dir3);
            return LVector3.Dot(aa, bb) < 0;
        }

        // 获取点到线段最近的一个点
        private static LVector2 FindNearestPointInSegment(LVector2 seg_start, LVector2 seg_end, LVector2 point)
        {
            var seg_dir = seg_end - seg_start;
            var dir = point - seg_start;
            var percent = Math.Clamp01(LVector2.Dot(seg_dir, dir) / LVector2.Dot(dir, dir));
            return seg_start + percent * seg_dir;
        }
        // 获取点到射线最近的一个点
        private static LVector2 FindNearestPointInLight(LVector2 ray_start, LVector2 ray_end, LVector2 point)
        {
            var seg_dir = ray_end - ray_start;
            var dir = point - ray_start;

            LFloat percent = Math.Max(LFloat.zero, LVector2.Dot(seg_dir, dir) / LVector2.Dot(dir, dir));
            return ray_start + percent * seg_dir;
        }

        // 点是否在线段上
        public static bool IsPointInSegment(LVector2 seg_start, LVector2 seg_end, LVector2 point)
        {
            return FindNearestPointInSegment(seg_start, seg_end, point) == point;
        }
        // 点是否在射线上
        private static bool IsPointInLight(LVector2 seg_start, LVector2 seg_end, LVector2 point)
        {
            return FindNearestPointInLight(seg_start, seg_end, point) == point;
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
        public static bool CouldCollision(Shape a, Shape b)
        {
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
            }

            return false;
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
            return new LVector2(value - c.Radius, value + c.radius);
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
        private static bool RayBound(Ray ray, Bound a, out RayHit hit)
        {
            LFloat sqrMagnitude = new LFloat();
            LVector2 point = new LVector2();
            var ray_start = ray.start;
            var ray_end = ray.direction + ray.start;
            int index = -1;
            for (int i = 0; i < a.points.Length; i++)
            {
                var last = a.points[Repeat(i - 1, a.points.Length)];
                var cur = a.points[i];

                if (CouldLightSegmentIntersect(ray_start, ray_end, last, cur))
                {
                    var _point = LineLineIntersectPoint(ray_start, ray_end, last, cur);
                    var dir = _point - ray_start;
                    var _sqrMagnitude = dir.sqrMagnitude;
                    if (index == -1 || sqrMagnitude > _sqrMagnitude)
                    {
                        index = i;
                        sqrMagnitude = _sqrMagnitude;
                        point = _point;
                    }

                }
            }
            if (index == -1)
            {
                hit = new RayHit();
            }
            else
            {
                hit = new RayHit() { point = point, distance = Math.Sqrt(sqrMagnitude) };
            }
            return index != -1;
        }

        private static bool RayPolygon(Ray ray, PolygonShape c, out RayHit hit)
        {
            hit = new RayHit();
            if (IsPointInCircle(c.position, c.maxRadius, ray.start)) return false;
            var point = FindNearestPointInLight(ray.start, ray.start + ray.direction, c.position);
            if (point == c.position) return false;
            var dir = point - c.position;
            if (dir.sqrMagnitude > c.maxRadius * c.maxRadius) return false;
            for (int i = 0; i < c.bounds.Length; i++)
            {
                if (IsPointInBound(c.bounds[i], ray.start))
                {
                    return false;
                }
            }
            int index = -1;
            for (int i = 0; i < c.bounds.Length; i++)
            {
                RayHit _hit;
                if (RayBound(ray, c.bounds[i], out _hit))
                {
                    if (index == -1 || _hit.distance < hit.distance)
                    {
                        index = i;
                        hit = _hit;
                    }
                }
            }
            if (index != -1)
            {
                hit.shape = c;
            }
            return index != -1;
        }
        private static bool RayCircle(Ray ray, CircleShape c, out RayHit hit)
        {
            hit = new RayHit();
            if (IsPointInCircle(c.position, c.Radius, ray.start)) return false;
            var point = FindNearestPointInLight(ray.start, ray.start + ray.direction, c.position);
            if (point == c.position) return false;
            var dir = point - c.position;
            if (dir.sqrMagnitude > c.Radius * c.radius) return false;

            var _base = Math.Sqrt(c.Radius * c.radius - dir.sqrMagnitude);
            var p1 = point + ray.direction * _base;
            var p2 = point - ray.direction * _base;
            var dis_1 = (p1 - ray.direction).sqrMagnitude;
            var dis_2 = (p2 - ray.direction).sqrMagnitude;
            hit.shape = c;
            if (dis_1 < dis_2)
            {
                hit.point = p1;
                hit.distance = Math.Sqrt(dis_1);
            }
            else
            {
                hit.point = p2;
                hit.distance = Math.Sqrt(dis_2);
            }
            return true;
        }

        //-------------------------------------------------------------------------------




        /// <summary>
        /// 圆矩形碰撞
        /// </summary>
        /// <param name="circle">圆形</param>
        /// <param name="rect">矩形</param>
        /// <returns>是否碰撞</returns>
        static bool Circle2Rectangle(CircleShape circle, RectangleShape rect)
        {
            //旋转圆心（角度为b的角度）得到新的坐标
            LVector2 newCenter = new LVector2();
            if (rect.angle != 0)
            {
                newCenter.x = Math.Cos(rect.angle) * (circle.position.x - rect.position.x) - Math.Sin(rect.angle) * (circle.position.y - rect.position.y) + rect.position.x;
                newCenter.y = Math.Cos(rect.angle) * (circle.position.x - rect.position.x) + Math.Cos(rect.angle) * (circle.position.y - rect.position.y) + rect.position.x;
            }
            else
            {
                newCenter = circle.position;
            }
            //判断圆心与矩形的碰撞

            //获取最近的点
            LVector2 nearPoint = new LVector2();
            if (newCenter.x < (rect.position.x - rect.Width / 2))
            {
                nearPoint.x = rect.position.x - rect.Width / 2;

            }
            else if (newCenter.x > (rect.position.x + rect.Width / 2))
            {
                nearPoint.x = rect.position.x + rect.Width / 2;
            }
            else
            {
                nearPoint.x = newCenter.x;
            }

            if (newCenter.y < (rect.position.y - rect.Height / 2))
            {
                nearPoint.y = rect.position.y - rect.Height / 2;
            }
            else if (newCenter.y > rect.position.y + rect.Height / 2)
            {
                nearPoint.x = rect.position.x + rect.Height / 2;
            }
            else
            {
                nearPoint.y = newCenter.y;
            }

            var distance = Math.Sqrt(Math.Sqr(nearPoint.x - newCenter.x) + Math.Sqr(nearPoint.y - newCenter.y));

            return distance < circle.Radius;
        }
        static LFloat SegmentPointSqrDistance(LVector2 x0, LVector2 u, LVector2 x)
        {
            LFloat t = LVector2.Dot(x - x0, u) / u.sqrMagnitude;
            return (x - (x0 + Math.Clamp(t, LFloat.zero, LFloat.one) * u)).sqrMagnitude;
        }
        static bool Circle2SectorShape(CircleShape circle, SectorShape b)
        {
            LVector2 dir = circle.position - b.position;
            LFloat rsum = circle.Radius + b.Radius;
            if (dir.sqrMagnitude > rsum * rsum)
                return false;
            LFloat px = LVector2.Dot(dir, b.direction);
            LFloat py = Math.Abs(LVector2.Dot(dir, new LVector2(-b.direction.y, b.direction.x)));

            // 3. 如果 p_x > ||p|| cos theta，两形状相交
            if (px > dir.magnitude * Math.Cos(b.sectorAngle))
                return true;

            // 4. 求左边线段与圆盘是否相交
            LVector2 q = b.Radius * new LVector2(Math.Cos(b.sectorAngle), Math.Sin(b.sectorAngle));
            LVector2 p = new LVector2(px, py);
            return SegmentPointSqrDistance(LVector2.zero, q, p) <= circle.Radius * circle.Radius;
        }

    }
}


