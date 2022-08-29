using Box2DSharp.Common;

namespace Box2DSharp.Dynamics.Joints
{
    /// Motor joint definition.
    public class MotorJointDef : JointDef
    {
        /// The bodyB angle minus bodyA angle in radians.
        public FP AngularOffset;

        /// Position correction factor in the range [0,1].
        public FP CorrectionFactor;

        /// Position of bodyB minus the position of bodyA, in bodyA's frame, in meters.
        public FVector2 LinearOffset;

        /// The maximum motor force in N.
        public FP MaxForce;

        /// The maximum motor torque in N-m.
        public FP MaxTorque;

        public MotorJointDef()
        {
            JointType = JointType.MotorJoint;
            LinearOffset.SetZero();
            AngularOffset = 0.0f;
            MaxForce = 1.0f;
            MaxTorque = 1.0f;
            CorrectionFactor = 0.3f;
        }

        /// Initialize the bodies and offsets using the current transforms.
        public void Initialize(Body bA, Body bB)
        {
            BodyA = bA;
            BodyB = bB;
            var xB = BodyB.GetPosition();
            LinearOffset = BodyA.GetLocalPoint(xB);

            var angleA = BodyA.GetAngle();
            var angleB = BodyB.GetAngle();
            AngularOffset = angleB - angleA;
        }
    }
}