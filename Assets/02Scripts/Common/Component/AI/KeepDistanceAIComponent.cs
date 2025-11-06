using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class KeepDistanceAIComponent : TargetAIComponent
    {
        public float MinDistance = 3f;
        public float MaxDistance = 4f;

        private float _distance;

        protected override Vector2 GetMoveDirection()
        {
            _distance = Vector2.Distance(Target.transform.position, transform.position);
            if (_distance < MinDistance) return -GetTargetDirection();
            
            return IsSafe() ? Vector2.zero : GetTargetDirection();
        }

        protected override bool CanAttack()
        {
            return IsSafe();
        }

        private bool IsSafe()
        {
            return MinDistance <= _distance && _distance <= MaxDistance;
        }

        protected override Vector2 GetAttackDirection()
        {
            return GetTargetDirection();
        }
    }
}
