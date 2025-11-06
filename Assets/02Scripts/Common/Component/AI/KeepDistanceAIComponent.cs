using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class KeepDistanceAIComponent : FollowAIComponent
    {
        public float MinDistance = 3f;
        public float MaxDistance = 4f;

        protected override Vector2 GetMoveDirection()
        {
            float distance = Vector2.Distance(Target.transform.position, transform.position);
            if (distance < MinDistance) return -base.GetMoveDirection();
            if (MinDistance <= distance && distance <= MaxDistance) return Vector2.zero;
            
            return base.GetMoveDirection();
        }
    }
}
