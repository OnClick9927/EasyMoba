using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;
using UnityEngine;
using LMath = LockStep.Math.LMath;

public class CircleShapeMono : MonoBehaviour
{
    public Color c;
    private CircleShape shape;
    public float radius;
    private LockStep.LCollision2D.QuadTree tree { get { return MonoTree.ins.tree; } }
    private List<Shape> result = new List<Shape>();
    private void Awake()
    {
        shape = new CircleShape();
    }
    private void OnEnable()
    {
        shape.position = this.transform.position.ToLVector2XZ();

        MonoTree.Add(shape);
    }
    private void OnDisable()
    {
        MonoTree.Remove(shape);
    }
    private void Update()
    {
        shape.radius = radius.ToLFloat();
        shape.position = this.transform.position.ToLVector2XZ();
        if (tree != null)
        {
            tree.GetCollision(shape, result);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = c;

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

        Gizmos.color = Color.yellow;

        if (result != null)
        {
            foreach (var item in result)
            {
                Gizmos.DrawLine(transform.position, item.position.ToVector3XZ());
            }
        }
    }

}
