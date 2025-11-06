using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    [RequireComponent(typeof(MoveComponent), typeof(AttackComponent))]
    public abstract class AIComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private AttackComponent _attackComponent;

        private Vector2 _previousMoveDirection;
        private Vector2 _previousAttackDirection;

        private void Start()
        {
            Init();
        }
        
        private void Update()
        {
            Move();
            Attack();
        }

        private void Move()
        {
            Vector2 newMoveDirection = GetMoveDirection();
            if (newMoveDirection == _previousMoveDirection) return;
            
            _moveComponent.SetMoveDirection(newMoveDirection);
            _previousMoveDirection = newMoveDirection;
        }

        private void Attack()
        {
            if (!CanAttack()) return;

            Vector2 newAttackDirection = GetAttackDirection();
            if (newAttackDirection == _previousAttackDirection) return;
            
            _attackComponent.SetAttackDirection(newAttackDirection);
            _previousAttackDirection = newAttackDirection;
            
            _attackComponent.Fire();
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

        protected abstract Vector2 GetAttackDirection();

        protected abstract Vector2 GetMoveDirection();
    }
}
