﻿using LockStep.Math;

namespace LockStep.LCollision2D
{
    /// <summary>
    /// 射线击中的shape
    /// </summary>
    public struct RayHit
    {
        public LVector2 point;
        public LFloat distance;
        public Shape shape;
        public LVector2 normal;
    }

}


