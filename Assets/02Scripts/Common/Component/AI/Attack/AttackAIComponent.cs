using UnityEngine;

namespace _02Scripts.Common.Component.AI.Attack
{
    [RequireComponent(typeof(AttackComponent), typeof(StatComponent))]
    public abstract class AttackAIComponent : MonoBehaviour
    {
        private AttackComponent _attackComponent;

        private void Start()
        {
            Init();
        }
        
        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (!CanAttack()) return;

            _attackComponent.Fire(GetAttackDirection());
        }

        protected virtual void Init()
        {
            _attackComponent = GetComponent<AttackComponent>();
        }

        protected virtual bool CanAttack()
        {
            return false;
        }

        protected abstract Vector2 GetAttackDirection();
    }
}
