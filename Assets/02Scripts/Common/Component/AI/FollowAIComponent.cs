using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class FollowAIComponent : TargetAIComponent
    {
        protected override Vector2 GetMoveDirection()
        {
            Vector2 direction = Target ?
                (Target.transform.position - transform.position).normalized : Vector2.down;

            return direction;
        }
    }
}
