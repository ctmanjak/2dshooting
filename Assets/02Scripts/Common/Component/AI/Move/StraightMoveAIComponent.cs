using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class StraightMoveAIComponent : MoveAIComponent
    {
        protected override Vector2 GetMoveDirection()
        {
            return Vector2.down;
        }
    }
}
