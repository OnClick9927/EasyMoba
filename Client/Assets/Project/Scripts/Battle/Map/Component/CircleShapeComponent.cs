using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;
using UnityEngine;
using LMath = LockStep.Math.LMath;

namespace EasyMoba
{
    public class CircleShapeComponent : ShapeComponent<CircleShape>
    {
        public float radius;
        public override CircleShape Build()
        {
            return new CircleShape() { radius = new LFloat(radius), layer = this.layer, logic = this.logic, rigidbody = this.rigid };
        }
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            var m_Theta = 0.0001f;
            // 设置矩阵
            Matrix4x4 defaultMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            // 绘制圆环
            Vector3 beginPoint = Vector3.zero;
            Vector3 firstPoint = Vector3.zero;
            for (float theta = 0; theta < 2 * LMath.PI; theta += m_Theta)
            {
                float x = radius * UnityEngine.Mathf.Cos(theta);
                float z = radius * UnityEngine.Mathf.Sin(theta);
                Vector3 endPoint = new Vector3(x, 0, z);
                if (theta == 0)
                {
                    firstPoint = endPoint;
                }
                else
                {
                    Gizmos.DrawLine(beginPoint, endPoint);
                }
                beginPoint = endPoint;
            }
            // 绘制最后一条线段
            Gizmos.DrawLine(firstPoint, beginPoint);

            // 恢复默认矩阵
            Gizmos.matrix = defaultMatrix;

        }


    }


}
