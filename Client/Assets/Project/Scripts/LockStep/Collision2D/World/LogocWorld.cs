using LockStep.Math;
using System.Collections.Generic;

namespace LockStep.LCollision2D
{
    public class LogocWorld
    {
        public List<LogicUnit> objects = new List<LogicUnit>();
        public QuadTree tree;

        public LogocWorld(CollisionLayerConfig layer)
        {
            tree = new QuadTree(LVector2.one * 100, layer);
        }

        public LogicUnit CreateTransform(string name)
        {
            LogicUnit t = new LogicUnit() { name = name };
            objects.Add(t);
            t.world = this;
            return t;
        }
        public void DestoryTransform(LogicUnit trans)
        {
            trans.need_detory = true;
        }
        public void FixedUpdate(int trick, LFloat delta)
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                objects[i].OnDestory();
                if (objects[i].collision != null)
                {
                    tree.RemoveShape(objects[i].collision.shape);
                }
                objects.RemoveAt(i);
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].FixedUpdate(trick, delta);
                if (objects[i].collision != null)
                {
                    objects[i].collision.SyncData(objects[i]);
                }
            }
            tree.BuildTree();
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].collision != null)
                {
                    objects[i].collision.DoCollision(this, objects[i]);
                }
            }
        }
    }

}


