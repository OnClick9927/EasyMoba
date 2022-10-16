
using LMath;
using System;
using System.Collections.Generic;

namespace LCollision2D
{
    public class Node
    {
        public Guid guid = Guid.NewGuid();
        public Node parrent;
        public LRect area;
        public List<Shape> shapes = new List<Shape>();
        public List<Node> nodes = new List<Node>();
        public LFloat maxRadius;

        public LFloat UpdateMaxRadius()
        {
            maxRadius = -1;
            if (HaveChildren())
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    var tmp = nodes[i].UpdateMaxRadius();
                    if (tmp > maxRadius)
                    {
                        maxRadius = tmp;
                    }
                }
            }
            else
            {
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].maxRadius > maxRadius)
                    {
                        maxRadius = shapes[i].maxRadius;
                    }
                }
            }
            return maxRadius;
        }
        public bool HaveChildren()
        {
            return nodes.Count > 0;
        }
        public void AddNode(Node node)
        {
            if (nodes.Contains(node)) return;
            nodes.Add(node);
            node.parrent = this;
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
        }
        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }
        public bool NeedSplit()
        {
            return shapes.Count >= 10;
        }

        public bool CouldAdd(LVector2 position)
        {
            return area.Contains(position);
        }
        public List<Node> GetChildren()
        {
            return nodes;
        }

        public bool CouldIntersect(Shape shape)
        {
            var point = shape.position;

            LFloat xDistance = LMath.Math.Max(point.x - area.xMax, area.x - point.x);
            LFloat yDistance = LMath.Math.Max(point.y - area.yMax, area.y - point.y);
            xDistance = LMath.Math.Max(xDistance, LFloat.zero);
            yDistance = LMath.Math.Max(yDistance, LFloat.zero);

            var cur_max = maxRadius;
            var xx = cur_max + shape.maxRadius;
            return xDistance * xDistance + yDistance * yDistance < xx * xx;
        }

    }
}


