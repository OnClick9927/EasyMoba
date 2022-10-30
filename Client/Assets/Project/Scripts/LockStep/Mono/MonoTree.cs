using LockStep.LCollision2D;
using LockStep.Math;
using UnityEditor;
using UnityEngine;

public class MonoTree : MonoBehaviour
{

    public Vector2 v1;
    public LockStep.LCollision2D.QuadTree tree;
    public static MonoTree ins;
    private void Awake()
    {
        ins = this;
        tree = new LockStep.LCollision2D.QuadTree(v1.ToLVector2(),new CollisionLayerConfig());

    }
    private void Update()
    {
        tree.BuildTree();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (tree == null) return;
        foreach (var item in tree.nodes)
        {

            if (!item.HaveChildren())
            {
                var area = item.area;
                var lt = new LVector2(area.x, area.y).ToVector3XZ();
                var ld = new LVector2(area.x, area.yMax).ToVector3XZ();
                var rt = new LVector2(area.xMax, area.y).ToVector3XZ();
                var rd = new LVector2(area.xMax, area.yMax).ToVector3XZ();

                Gizmos.DrawLine(lt, ld);
                Gizmos.DrawLine(lt, rt);
                Gizmos.DrawLine(rt, rd);
                Gizmos.DrawLine(rd, ld);
                Handles.color = Color.green;
                Handles.Label(lt.ToLVector3().ToVector3(), item.shapes.Count.ToString());
            }
        }
    }
    public static void Add(Shape c)
    {
        ins.tree.AddShape(c);
    }
    public static void Remove(Shape c)
    {
        ins.tree.RemoveShape(c);
    }

}
