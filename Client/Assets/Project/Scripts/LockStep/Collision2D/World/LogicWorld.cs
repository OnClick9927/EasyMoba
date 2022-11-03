using LockStep.Math;
using System.Collections.Generic;

namespace LockStep.LCollision2D
{
    public class LogicWorld
    {
        public List<LogicUnit> objects = new List<LogicUnit>();
        public QuadTree tree;
        public LFloat delta;

        public LogicWorld(CollisionLayerConfig layer, LFloat delta)
        {
            tree = new QuadTree(LVector2.one * 100, layer);
            this.delta = delta;
        }

        public LogicUnit CreateUnit<T>(string name) where T : LogicUnit, new()
        {
            T t = new T() { name = name };
            objects.Add(t);
            t.world = this;
            return t;
        }
        public LogicUnit FindUnit(string name)
        {
            return objects.Find(x => x.name == name);
        }
        public void DestoryUnit(LogicUnit trans)
        {
            trans.need_detory = true;
        }
        public virtual void FixedUpdate(int trick)
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


