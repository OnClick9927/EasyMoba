using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace EasyMoba.GameLogic.Mono
{
    public class PolygonShapeComponent : ShapeComponent<PolygonShape>
    {
        public List<Vector3> points = new List<Vector3>();
        public PolygonShape shape;

        public override PolygonShape Build()
        {
            LVector2[] list = new LVector2[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                list[i] = points[i].ToLVector2XZ();
            }
            return new PolygonShape() { localPoints = list, layer = this.layer, logic = this.logic, rigidbody = this.rigid };
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            for (int i = 0; i < points.Count; i++)
            {
                var last = points[(int)Mathf.Repeat(i - 1, points.Count)] + transform.position;
                var cur = points[i] + transform.position;
                Gizmos.DrawLine(last, cur);
                Handles.Label(points[i] + transform.position, i.ToString());
            }

        }

    }
}

