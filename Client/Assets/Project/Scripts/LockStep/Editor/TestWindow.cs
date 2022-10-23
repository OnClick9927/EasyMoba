using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class TestWindow : EditorWindow
{
    [MenuItem("Tool/test")]
    static void Open()
    {
        GetWindow<TestWindow>();
    }
    WindowData data;
    private void OnEnable()
    {
        data = Resources.Load<WindowData>("1");
    }
    private void DrawLine(Vector2 start, Vector2 end)
    {
        Handles.DrawAAPolyLine(2, start, end);
    }
    private void DrawPoint(Vector2 point)
    {
        Handles.color = Color.green;

        Handles.DrawWireCube(point, Vector2.one * 10);
        Handles.Label(point, point.ToString());
    }

    private void GetABC(Vector2 start, Vector2 end, out float a, out float b, out float c)
    {
        a = (start.y - end.y);
        b = (end.x - start.x);
        c = -(a * start.x + b * start.y);
    }
    private bool ping;
    private Vector2 GG(Vector2 a_start, Vector2 a_end, Vector2 b_start, Vector2 b_end)
    {
        float A1, B1, C1;
        float A2, B2, C2;
        GetABC(a_start, a_end, out A1, out B1, out C1);
        GetABC(b_start, b_end, out A2, out B2, out C2);
        ping = A1 * B2 - A2 * B1 == 0;
        float x = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
        float y = (A1 * C2 - C1 * A2) / (B1 * A2 - A1 * B2);
        return new Vector2(x, y);
    }
    private bool TwoSide(Vector2 a_start, Vector2 a_end, Vector2 b_start, Vector2 b_end)
    {
        if (a_start == b_start)
            return true;
        if (a_start == b_end)
            return true;
        if (a_end == b_start)
            return true;
        if (a_end == b_end)
            return true;
        var dir = a_end - a_start;
        var dir2 = b_start - a_start;
        var dir3 = b_end - a_start;
        var aa = Vector3.Cross(dir, dir2);
        var bb = Vector3.Cross(dir, dir3);
        return Vector3.Dot(aa, bb) < 0;
    }
    private bool GG2(Vector2 a_start, Vector2 a_end, Vector2 b_start, Vector2 b_end)
    {
        return TwoSide(a_start, a_end, b_start, b_end) && TwoSide(b_start, b_end, a_start, a_end);
    }

    private void DrawPolygon(Polygon p)
    {
        Handles.color = p.color;

        for (int i = 0; i < p.points.Length; i++)
        {
            Vector2 cur = p.points[i];
            Vector2 next = p.points[(int)Mathf.Repeat(i + 1, p.points.Length)];
            Handles.DrawAAPolyLine(2, cur, next);

        }
    }
    private bool GGGG(Polygon p)
    {
        for (int i = 0; i < p.points.Length; i++)
        {
            Vector2 last = p.points[(int)Mathf.Repeat(i - 1, p.points.Length)];
            Vector2 cur = p.points[i];
            Vector2 next = p.points[(int)Mathf.Repeat(i + 1, p.points.Length)];
            var dir = cur - last;
            var dir2 = next - cur;
            if (Vector3.Cross(dir, dir2).z < 0)
            {
                return false;
            }
        }
        return true;
    }
    private Vector2[] RemoveSth(List<Vector2> points)
    {
        for (int i = 0; i < points.Count; i++)
        {
            Vector2 last = points[(int)Mathf.Repeat(i - 1, points.Count)];
            Vector2 cur = points[i];
            Vector2 next = points[(int)Mathf.Repeat(i + 1, points.Count)];

            var dir1 = cur - last;
            var dir2 = next - last;
            if (dir1.x / dir1.y == dir2.x / dir2.y)
            {
                points.RemoveAt(i);
                RemoveSth(points);
                break;
            }
        }
        return points.ToArray();
    }
    private List<Polygon> Ga(Polygon p, List<Polygon> list)
    {
        if (list == null) list = new List<Polygon>();
        if (GGGG(p))
        {
            list.Add(p);
        }
        else
        {
            bool isdun(int i)
            {
                Vector2 last = p.points[(int)Mathf.Repeat(i - 1, p.points.Length)];
                Vector2 cur = p.points[i];
                Vector2 next = p.points[(int)Mathf.Repeat(i + 1, p.points.Length)];
                var dir = cur - last;
                var dir2 = next - cur;
                return Vector3.Cross(dir, dir2).z < 0;
            }
            for (int i = 0; i < p.points.Length; i++)
            {
                if (isdun(i))
                {
                    int j = i;
                    while (true)
                    {
                        j++;
                        int cur = (int)Mathf.Repeat(j, p.points.Length);
                        if (!isdun(cur))
                        {
                            int last = (int)Mathf.Repeat(cur - 1, p.points.Length);
                            int lastlast = (int)Mathf.Repeat(cur - 2, p.points.Length);
                            int next = (int)Mathf.Repeat(cur + 1, p.points.Length);
                            Polygon _p1 = new Polygon() { color = p.color };
                            Polygon _p2 = new Polygon() { color = p.color };
                            _p1.points = new Vector2[3];
                            for (int k = 0; k < 3; k++)
                            {
                                _p1.points[k] = p.points[(int)Mathf.Repeat(last + k, p.points.Length)];
                            }
                            list.Add(_p1);
                            int p2_len = p.points.Length - 1;
                            _p2.points = new Vector2[p2_len];
                            int _next = next;
                            int _index = 0;
                            while (true)
                            {
                                _next = (int)Mathf.Repeat(_next, p.points.Length);
                                _p2.points[_index] = p.points[_next];
                                if (_next == last)
                                {
                                    break;
                                }
                                _index++;
                                _next++;
                            }
                            _p2.points = RemoveSth(_p2.points.ToList());
                            Ga(_p2, list);
                            break;
                        }
                    }
                    break;
                }

            }

        }
        return list;
    }
    private List<Polygon> list = new List<Polygon>();
    private void OnInspectorUpdate()
    {
        Repaint();
        //list.Clear();
        //Ga(data.polygon, list);
    }
    private class Cir
    {
        public Vector2 pos = new Vector2(300, 50);
        public float r = 50;
    }
    Cir c = new Cir();
    private void OnGUI()
    {
        DrawPolygon(data.polygon);
        Handles.color = Color.green; ;
        Handles.CircleHandleCap(3, c.pos, Quaternion.identity, c.r, EventType.Repaint);

        //float range = 5f;
        Vector2 tar = Event.current.mousePosition;
        //+ new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        Vector2 move_dir = (tar - c.pos).normalized;
        //Handles.CircleHandleCap(2, tar, Quaternion.identity, c.r, EventType.Repaint);


        var _tar = tar;
        for (int i = 0; i < 3; i++)
        {
            Vector2 last = data.polygon.points[(int)Mathf.Repeat(i - 1, data.polygon.points.Length)];
            Vector2 cur = data.polygon.points[i];
            var line = cur - last;
            var line_normal = new Vector2(line.y, -line.x);
            if (Vector2.Dot(line_normal, c.pos-last) < 0)
            {
                line_normal = new Vector2(-line.y, line.x);
            }
            line_normal = line_normal.normalized;
            var jiao = GG(c.pos, c.pos + line_normal, cur, last);
            var h = jiao - tar;
            DrawLine(c.pos, tar);
            DrawLine(jiao, jiao+line_normal*100);


            GUILayout.Label("h  " + Vector2.Dot(h.normalized, move_dir).ToString());
            GUILayout.Label("l " + Vector2.Dot(line.normalized, move_dir).ToString());

            if (Vector2.Dot(h, move_dir) > 0)
            {
                if (c.r >= h.magnitude)
                {

                    var move = line_normal * (c.r - h.magnitude);
                    _tar += move;

                }
            }

        }

        //c.pos = _tar;
        //Handles.DrawWireCube(tar, Vector3.one * 5);

    }
}
