using LockStep.Math;
using System.Collections.Generic;

namespace LockStep.LCollision2D
{
    public partial class LogicUnit
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
                    last_pos = shape.position;
                    shape.position = transform.position;
                    shape.angle = transform.angle;
                    shape.scale = transform.scale;
                    shape.SetDirty();
                }
            }
            public void DoCollision(LogicWorld word, LogicUnit transform)
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
                        transform.OnTriggerExit(_shape);
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

            public void DoAdd(LogicWorld world, Shape shape)
            {
                this.shape = shape;
                world.tree.AddShape(this.shape);
            }

        }
    }

}


