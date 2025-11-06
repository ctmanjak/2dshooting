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
            if (MinDistance <= _distance && _distance <= MaxDistance) return Vector2.zero;
            
            return GetTargetDirection();
        }

        protected override bool CanAttack()
        {
            return IsSafe();
        }

        private bool IsSafe()
        {
            if (MinDistance <= _distance && _distance <= MaxDistance) return true;
            return false;
        }

        protected override Vector2 GetAttackDirection()
        {
            return GetTargetDirection();
        }
    }
}
