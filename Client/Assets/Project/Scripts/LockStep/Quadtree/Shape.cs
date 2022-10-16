using LMath;


namespace LCollision2D
{
    public abstract class Shape
    {
        public LFloat angle;
        public LVector2 position;
        public abstract LFloat maxRadius { get; }
    }
    public class CircleShape : Shape
    {
        public LFloat radius;
        public override LFloat maxRadius => radius;
    }
}


