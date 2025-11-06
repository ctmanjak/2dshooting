using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class StraightAIComponent : AIComponent
    {
        protected override Vector2 GetAttackDirection()
        {
            return Vector2.down;
        }

        protected override Vector2 GetMoveDirection()
        {
            return Vector2.down;
        }
    }
}
