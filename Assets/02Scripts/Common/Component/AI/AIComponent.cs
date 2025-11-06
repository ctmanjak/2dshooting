using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    [RequireComponent(typeof(MoveComponent), typeof(AttackComponent), typeof(StatComponent))]
    public abstract class AIComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private AttackComponent _attackComponent;
        private StatComponent _statComponent;

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
            _moveComponent.Move(GetMoveDirection(), _statComponent.Speed * _statComponent.SpeedMultiplier * Time.deltaTime);
        }

        private void Attack()
        {
            if (!CanAttack()) return;

            _attackComponent.Fire(GetAttackDirection());
        }

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _attackComponent = GetComponent<AttackComponent>();
            _statComponent = GetComponent<StatComponent>();
        }

        protected virtual bool CanAttack()
        {
            return false;
        }

        protected abstract Vector2 GetAttackDirection();

        protected abstract Vector2 GetMoveDirection();
    }
}
