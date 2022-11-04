using LockStep.Math;

namespace LockStep.LCollision2D
{

    public abstract class Shape
    {
        public bool rigidbody = false;
        public bool logic;
        public LogicUnit unit;

        public CollisionLayer layer;
        public bool dirty { get; private set; } = true;
        public LVector2 direction { get; private set; }
        public LFloat angle = LFloat.zero;
        public LVector2 position;
        public LFloat scale = LFloat.one;
        public LFloat maxRadius { get; protected set; }

        public virtual void Build()
        {
            dirty = false;
            direction = LVector2.up.Rotate(angle);
        }
        public void SetDirty()
        {
            dirty = true;
        }
    }

}


