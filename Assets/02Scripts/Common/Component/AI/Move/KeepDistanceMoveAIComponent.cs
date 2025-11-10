using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class KeepDistanceMoveAIComponent : TargetMoveAIComponent
    {
        public float MinDistance = 3f;
        public float MaxDistance = 4f;

        private float _distance;

        protected override Vector2 GetMoveDirection()
        {
            if (!IsTargetExist()) return Vector2.zero;
            
            _distance = Vector2.Distance(GetTargetPosition(), transform.position);
            if (_distance < MinDistance) return -GetTargetDirection();
            
            return IsSafe() ? Vector2.zero : GetTargetDirection();
        }

        private bool IsSafe()
        {
            return MinDistance <= _distance && _distance <= MaxDistance;
        }
    }
}
