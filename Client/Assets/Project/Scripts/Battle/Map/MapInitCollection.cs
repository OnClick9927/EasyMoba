using LockStep.LCollision2D;
using LockStep.Math;
using UnityEngine;

namespace EasyMoba
{
    [System.Serializable]
    public class MapInitData
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
        public LVector2[] bornPos = new LVector2[0];
    }
    public class MapInitCollection : MonoBehaviour
    {
        public MapInitData data = new MapInitData();
        [ContextMenu("Build")]
        private void Build()
        {
            var ps = GetComponentsInChildren<PolygonShapeComponent>();
            var cs = GetComponentsInChildren<CircleShapeComponent>();
            var bs = GetComponentsInChildren<PlayerBornPlace>();

            data.ps = new MapInitData.PolygonData[ps.Length];
            for (int i = 0; i < data.ps.Length; i++)
            {
                data.ps[i] = new MapInitData.PolygonData()
                {
                    position = ps[i].transform.position.ToLVector2XZ(),
                    angle = LFloat.zero,
                    scale = LFloat.one,
                    shape = ps[i].Build()
                };
            }
            data.cs = new MapInitData.CircleData[cs.Length];
            for (int i = 0; i < data.cs.Length; i++)
            {
                data.cs[i] = new MapInitData.CircleData()
                {
                    position = ps[i].transform.position.ToLVector2XZ(),
                    angle = LFloat.zero,
                    scale = LFloat.one,
                    shape = cs[i].Build()
                };
            }
            data.bornPos = new LVector2[bs.Length];
            for (int i = 0; i < data.bornPos.Length; i++)
            {
                data.bornPos[i] = bs[i].transform.position.ToLVector2XZ();
            }
        }

    }

}
