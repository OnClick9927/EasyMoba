using LockStep.Math;
using UnityEngine;

namespace EasyMoba.GameLogic.Mono
{
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
