using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
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

}
