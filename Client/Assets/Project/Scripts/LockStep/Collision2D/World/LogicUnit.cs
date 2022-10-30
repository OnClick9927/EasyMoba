using LockStep.Math;
using System.Collections.Generic;

namespace LockStep.LCollision2D
{


    public class LogicUnit
    {

        public class CollisionPart
        {
            private List<Shape> last_result = new List<Shape>();
            private List<Shape> result = new List<Shape>();
            private List<Shape> rigd_result = new List<Shape>();
            public Shape shape;
            public LVector2 last_pos = LVector2.one;
            public void SyncData(LogicUnit transform)
            {
                if (shape.position != transform.position ||
                  shape.angle != transform.angle ||
                  shape.scale != transform.scale
                  )
                {
                    last_pos = shape.position = transform.position;
                    shape.angle = transform.angle;
                    shape.scale = transform.scale;
                    shape.SetDirty();
                }
            }
            public void DoCollision(LogocWorld word, LogicUnit transform)
            {
                if (!shape.logic) return;
                QuadTree tree = word.tree;
                rigd_result.Clear();
                result = tree.GetCollision(shape, result);
                for (int i = 0; i < result.Count; i++)
                {
                    var _shape = result[i];
                    if (_shape.rigidbody && shape.rigidbody) rigd_result.Add(_shape);
                }

                transform.PreventPenetration(rigd_result, last_pos);
                for (int i = 0; i < last_result.Count; i++)
                {
                    var _shape = last_result[i];

                    if (result.Contains(_shape))
                    {
                        transform.OnTriggerStay(_shape);
                    }
                    else
                    {
                        transform.OnTriggerExist(_shape);
                    }
                }
                for (int i = 0; i < result.Count; i++)
                {
                    var _shape = result[i];

                    if (!last_result.Contains(_shape))
                    {
                        transform.OnTriggerEnter(_shape);
                    }
                }
                last_result.Clear();
                last_result.AddRange(result);
            }

            public void DoAdd(LogocWorld world, Shape shape)
            {
                this.shape = shape;
                world.tree.AddShape(this.shape);
            }

        }
        private LFloat _localangle = LFloat.zero;
        private LVector2 _localPosition = LVector2.zero;
        private LFloat _localScele = LFloat.one;
        public LVector2 localPosition { get { return _localPosition; } set { _localPosition = value; } }
        public LFloat localScale { get { return _localScele; } set { _localScele = value; } }
        public LFloat localAngle { get { return _localangle; } set { _localangle = value; } }
        public LVector2 position
        {
            get
            {
                if (parent != null) return parent.position + _localPosition;
                return _localPosition;
            }
            set
            {
                if (parent != null) _localPosition = value;
                else _localPosition = value - parent.position;
            }
        }
        public LFloat scale
        {
            get
            {
                if (parent != null) return parent.scale * _localScele;
                return _localScele;
            }
            set
            {
                if (parent != null) _localScele = value;
                else _localScele = value / parent.scale;
            }
        }
        public LFloat angle
        {
            get
            {
                if (parent != null) return parent.angle + _localangle;
                return _localangle;
            }
            set
            {
                if (parent != null) _localangle = value;
                else _localangle = value - parent.angle;
            }
        }
        public LVector2 forward { get { return LVector2.up.Rotate(angle); } }
        public LVector2 back { get { return LVector2.down.Rotate(angle); } }
        public LVector2 left { get { return LVector2.left.Rotate(angle); } }
        public LVector2 right { get { return LVector2.right.Rotate(angle); } }


        public LogocWorld world;
        public bool need_detory = false;
        public string name;
        private List<LogicUnit> children = new List<LogicUnit>();
        public LogicUnit _parent;
        public LogicUnit parent { get { return _parent; } }
        public int ChildCount { get { return children.Count; } }
        public LogicUnit GetChild(int index) => children[index];
        public void SetParent(LogicUnit parent, bool stay_word_pos = true)
        {
            LFloat last_angle = this.angle;
            LVector2 last_pos = this.position;
            LFloat last_scale = this.scale;

            if (this._parent != null)
                this._parent.children.Remove(this);
            this._parent = parent;
            if (this._parent != null)
                this._parent.children.Add(this);

            if (stay_word_pos)
            {
                this.position = last_pos;
            }
            this.angle = last_angle;
            this.scale = last_scale;

        }


        private CollisionPart _collision;
        public CollisionPart collision { get { return _collision; } }
        public void CreateCollision(Shape shape)
        {
            shape.unit = this;
            _collision = new CollisionPart();
            _collision.DoAdd(world, shape);
        }

        public void FixedUpdate(int trick, LFloat delta)
        {
            if (need_detory) return;
            OnFixedUpdate(trick, delta);
        }

        private void PreventPenetration(List<Shape> others, LVector2 last_pos)
        {
            var dir = CollisionHelper.PositionCorrection(last_pos, this.collision.shape, others);
            if (dir != LVector2.zero)
            {
                this.position += dir;
                this.collision.SyncData(this);
            }

        }

        protected virtual void OnFixedUpdate(int trick, LFloat delta) { }
        protected void OnTriggerEnter(Shape other) { }
        protected void OnTriggerStay(Shape other) { }
        protected void OnTriggerExist(Shape other) { }
       
        public void OnDestory() { }
    }

}


