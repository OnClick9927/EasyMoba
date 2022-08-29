using Box2DSharp.Common;

namespace Box2DSharp.Dynamics.Joints
{
    /// <summary>
    /// Gear joint definition. This definition requires two existing
    /// revolute or prismatic joints (any combination will work).
    /// @warning bodyB on the input joints must both be dynamic
    /// </summary>
    public class GearJointDef : JointDef
    {
        /// The first revolute/prismatic joint attached to the gear joint.
        public Joint Joint1;

        /// The second revolute/prismatic joint attached to the gear joint.
        public Joint Joint2;

        /// The gear ratio.
        /// @see b2GearJoint for explanation.
        public FP Ratio;

        public GearJointDef()
        {
            JointType = JointType.GearJoint;
            Joint1 = null;
            Joint2 = null;
            Ratio = 1.0f;
        }
    }
}