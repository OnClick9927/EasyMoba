using LockStep.Math;

namespace LockStep.LCollision2D
{
    /// <summary>
    /// 点的集合
    /// </summary>
    [System.Serializable]
    public struct Bound
    {
        /// <summary>
        /// 世界坐标
        /// </summary>
        public LVector2[] points;
        public LVector2 center;
        public Bound(LVector2[] points)
        {
            this.points = points;
            LVector2 sum = LVector2.zero;
            for (int i = 0; i < points.Length; i++)
            {
                sum += points[i];
            }
            center = sum / points.Length;

        }

        public bool FindLine(LVector2 start, LVector2 end)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == start)
                {
                    int last = (int)CollisionHelper.Repeat(i - 1, points.Length);
                    int next = (int)CollisionHelper.Repeat(i + 1, points.Length);
                    if (points[last] == end || points[next] == end)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}


