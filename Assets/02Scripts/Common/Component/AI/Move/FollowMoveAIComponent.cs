using _02Scripts.Util;

namespace _02Scripts.Common.Component.AI.Move
{
    public class FollowMoveAIComponent : TargetMoveAIComponent
    {
        private const float AngleOffset = 90f;
        protected override void BeforeMove()
        {
            Rotate(MathUtil.DirectionToQuaternion(GetTargetDirection(), AngleOffset));
        }
    }
}
