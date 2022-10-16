using LMath;

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
        static bool C2C(CircleShape a, CircleShape b)
        {
            return a.radius + b.radius > (a.position - b.position).magnitude;
        }
        public static bool CouldCollision(Shape a, Shape b)
        {
            if (a is CircleShape && b is CircleShape)
            {
                return C2C(a as CircleShape, b as CircleShape);
            }
            return true;
        }
    }
}


