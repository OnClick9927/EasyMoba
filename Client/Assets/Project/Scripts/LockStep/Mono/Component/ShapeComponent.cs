﻿using UnityEngine;
namespace LockStep.LCollision2D
{
    public abstract class ShapeComponent<T> : MonoBehaviour where T : Shape
    {
        public Color color = Color.black;
        public CollisionLayer layer = CollisionLayer._1;
        public bool logic;
        public bool rigid = true;
        public abstract T Build();
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = color;
        }
    }
}

