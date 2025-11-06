using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    [RequireComponent(typeof(MoveComponent), typeof(AttackComponent))]
    public abstract class AIComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private AttackComponent _attackComponent;

        private Vector2 _previousMoveDirection;

        private void Start()
        {
            Init();
        }
        
        private void Update()
        {
            Vector2 newMoveDirection = GetMoveDirection();
            if (newMoveDirection != _previousMoveDirection)
            {
                _moveComponent.SetMoveDirection(newMoveDirection);
                _previousMoveDirection = newMoveDirection;
            }

            if (CanAttack())
            {
                _attackComponent.SetAttackDirection(GetAttackDirection());
                _attackComponent.Fire();
            }
        }

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _attackComponent = GetComponent<AttackComponent>();
        }

        protected virtual bool CanAttack()
        {
            return false;
        }

        protected virtual Vector2 GetAttackDirection()
        {
            return Vector2.down;
        }
        
        protected abstract Vector2 GetMoveDirection();
    }
}
