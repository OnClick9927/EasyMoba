using LMath;
using System.Drawing;

namespace LCollision2D
{
    public class QuadtreeHelper
    {
        public static Node AllocateNode()
        {
            return new Node();
        }
        public static void RecyleNode(Node node)
        {
            node.parrent = null;
            node.shapes.Clear();
            node.nodes.Clear();
            node.area = LRect.zero;
        }

        /// <summary>
        /// 圆圆碰撞
        /// </summary>
        /// <param name="circle1">圆a</param>
        /// <param name="circle2">圆b</param>
        /// <returns>是否碰撞</returns>
        static bool Circle2Circle(CircleShape circle1, CircleShape circle2)
        {
            return circle1.Radius + circle2.Radius > (circle1.position - circle2.position).magnitude;
        }

        /// <summary>
        /// 圆点碰撞
        /// </summary>
        /// <param name="circle">圆</param>
        /// <param name="point">点</param>
        /// <returns>是否碰撞</returns>
        static bool Circle2Point(CircleShape circle, LVector2 point)
        {
            //比较半径和点与圆心的距离
            return circle.Radius > (circle.position - point).magnitude;
        }

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



        public static bool CouldCollision(Shape a, Shape b)
        {
            if (a is CircleShape && b is CircleShape)
            {
                return Circle2Circle(a as CircleShape, b as CircleShape);
            }
            return true;
        }
    }
}


