
using LMath;
using System.Collections.Generic;


namespace LCollision2D
{
    public class QuadTree
    {
        private Node root;
        private LVector2 startSize;
        public QuadTree(LVector2 startSize)
        {
            this.startSize = startSize;
        }

        public List<Node> nodes = new List<Node>();
        public List<Shape> shapes = new List<Shape>();
        private void SplitNode(Node node)
        {
            var area = node.area;
            var height = area.height / 2;
            var width = area.width / 2;
            var xMiddle = area.x + width;
            var yMiddle = area.y + height;
            var lt = new LRect(area.x, area.y, width, height);
            var ld = new LRect(area.x, yMiddle, width, height);
            var rd = new LRect(xMiddle, yMiddle, width, height);
            var rt = new LRect(xMiddle, area.y, width, height);
            CreateNode(lt, node);
            CreateNode(ld, node);
            CreateNode(rd, node);
            CreateNode(rt, node);
        }
        private Node CreateNode(LRect area, Node parrent)
        {
            Node node = QuadtreeHelper.AllocateNode();
            node.area = area;
            node.parrent = parrent;
            if (parrent != null)
                parrent.AddNode(node);
            nodes.Add(node);
            return node;
        }
        private void ExtendRootArea(LVector2 position)
        {
            if (root == null)
            {
                LRect r = LRect.CreateRect(position, startSize / 2);
                root = CreateNode(r, null);
            }

            while (!root.CouldAdd(position))
            {
                LRect area = root.area;
                LVector2 center = LVector2.zero;
                center.x = position.x < area.x ? area.x : area.xMax;
                center.y = position.y < area.y ? area.y : area.yMax;

                var new_rect = LRect.CreateRect(center, area.size);
                Node new_root = CreateNode(new_rect, null);
                SplitNode(new_root);
                var children = new_root.GetChildren();
                Node find = null;
                for (int i = 0; i < children.Count; i++)
                {
                    var child = children[i];
                    if (child.area == root.area)
                    {
                        find = child;
                        break;
                    }
                }

                new_root.RemoveNode(find);
                QuadtreeHelper.RecyleNode(find);

                new_root.AddNode(root);

                root = new_root;
            }
        }

        public void RemoveShape(Shape shape)
        {
            if (!shapes.Contains(shape)) return;
            shapes.Remove(shape);
        }
        public void AddShape(Shape shape)
        {
            if (shapes.Contains(shape)) return;
            shape.SetDirty();
            shapes.Add(shape);
        }
        public void BuildTree()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                QuadtreeHelper.RecyleNode(nodes[i]);
            }
            nodes.Clear();
            root = null;
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].dirty) shapes[i].Build();
                ExtendRootArea(shapes[i].position);
                AddShapeToNode(root, shapes[i]);
            }
            if (root != null)
            {
                root.UpdateMaxRadius();
            }
        }

        void AddShapeToNode(Node node, Shape shape)
        {
            if (!node.CouldAdd(shape.position)) return;
            if (node.HaveChildren())
            {
                var children = node.GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    AddShapeToNode(children[i], shape);
                }
            }
            else
            {
                node.AddShape(shape);
                if (node.NeedSplit())
                {
                    SplitNode(node);
                    var shapes = node.shapes;
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        var children = node.GetChildren();
                        for (int j = 0; j < children.Count; j++)
                        {
                            AddShapeToNode(children[j], shapes[i]);
                        }
                    }
                    node.shapes.Clear();
                }
            }
        }

        Node FindNodeByPosition(Node node, LVector2 position)
        {
            if (node.CouldAdd(position))
            {
                if (node.HaveChildren())
                {
                    var children = node.GetChildren();
                    for (int i = 0; i < children.Count; i++)
                    {
                        var find = FindNodeByPosition(children[i], position);
                        if (find != null)
                            return find;
                    }
                }
                else
                {
                    return node;
                }
            }
            return null;
        }

        public List<Shape> GetCollision(Shape shape, List<Shape> result)
        {
            result.Clear();
            GetCollision(root, shape, result);
            result.Remove(shape);
            return result;
        }

        void GetCollision(Node node, Shape shape, List<Shape> result)
        {
            if (!QuadtreeHelper.CouldCollisionShape(node.area, node.maxRadius, shape)) return;
            if (node.HaveChildren())
            {
                var children = node.GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    GetCollision(children[i], shape, result);
                }
            }
            else
            {
                for (int i = 0; i < node.shapes.Count; i++)
                {
                    if (QuadtreeHelper.CouldCollision(shape, node.shapes[i]))
                    {
                        result.Add(node.shapes[i]);
                    }
                }
            }
        }

        public bool RayCast(Ray ray, List<RayHit> hit)
        {
            if (hit == null)
                hit = new List<RayHit>();
            hit.Clear();
            GetRayCast(root, ray, hit);
            return hit.Count != 0;
        }
        void GetRayCast(Node node, Ray ray, List<RayHit> hits)
        {
            if (!QuadtreeHelper.CouldRaycastNode(ray, node.area)) return;
            if (node.HaveChildren())
            {
                var children = node.GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    GetRayCast(children[i], ray, hits);
                }
            }
            else
            {
                for (int i = 0; i < node.shapes.Count; i++)
                {
                    RayHit hit;
                    if (QuadtreeHelper.RayCast(ray, node.shapes[i], out hit))
                    {
                        hits.Add(hit);
                    }
                }
            }
        }
    }
}


