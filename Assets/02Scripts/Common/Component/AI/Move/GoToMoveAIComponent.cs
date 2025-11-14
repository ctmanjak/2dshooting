using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    [RequireComponent(typeof(TargetComponent))]
    public class GoToMoveAIComponent : MoveAIComponent
    {
        public Vector2 Position;

        protected override Vector2 GetMoveDirection()
        {
            return (Position - (Vector2)transform.position).normalized;
        }
    }
}
