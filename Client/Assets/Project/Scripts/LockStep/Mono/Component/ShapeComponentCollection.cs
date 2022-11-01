using LockStep.Math;
using UnityEngine;

namespace LockStep.LCollision2D
{
    [System.Serializable]
    public class UnitShapes
    {
        public class UnitShapeData<T> where T : Shape
        {
            public LVector2 position;
            public LFloat angle;
            public LFloat scale;
            public T shape;
        }
        [System.Serializable]
        public class PolygonData : UnitShapeData<PolygonShape> { }
        [System.Serializable]
        public class CircleData : UnitShapeData<CircleShape> { }

        public PolygonData[] ps = new PolygonData[0];
        public CircleData[] cs = new CircleData[0];
    }
    public class ShapeComponentCollection : MonoBehaviour
    {
        public UnitShapes shapes = new UnitShapes();
        [ContextMenu("Build")]
        private void Build()
        {
            var ps = GetComponentsInChildren<PolygonShapeComponent>();
            var cs = GetComponentsInChildren<CircleShapeComponent>();
            shapes.ps = new UnitShapes.PolygonData[ps.Length];
            for (int i = 0; i < shapes.ps.Length; i++)
            {
                shapes.ps[i] = new UnitShapes.PolygonData()
                {
                    position = ps[i].transform.position.ToLVector2XZ(),
                    angle = LFloat.zero,
                    scale = LFloat.one,
                    shape = ps[i].Build()
                };
            }
            shapes.cs = new UnitShapes.CircleData[cs.Length];
            for (int i = 0; i < shapes.cs.Length; i++)
            {
                shapes.cs[i] = new UnitShapes.CircleData()
                {
                    position = ps[i].transform.position.ToLVector2XZ(),
                    angle = LFloat.zero,
                    scale = LFloat.one,
                    shape = cs[i].Build()
                };
            }
        }

    }

}
