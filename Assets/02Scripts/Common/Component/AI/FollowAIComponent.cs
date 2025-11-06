using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class FollowAIComponent : TargetAIComponent
    {
        protected override Vector2 GetMoveDirection()
        {
            return GetTargetDirection();
        }
    }
}
