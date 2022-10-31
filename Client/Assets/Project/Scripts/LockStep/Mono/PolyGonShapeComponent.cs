using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PolyGonShapeComponent : MonoBehaviour
{
    public List<Vector3> points = new List<Vector3>();
    public Color color = Color.black;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        for (int i = 0; i < points.Count; i++)
        {
            var last = points[(int)Mathf.Repeat(i - 1, points.Count)];
            var cur = points[i];
            Gizmos.DrawLine(last, cur);
            Handles.Label(points[i], i.ToString());
        }

    }

}
