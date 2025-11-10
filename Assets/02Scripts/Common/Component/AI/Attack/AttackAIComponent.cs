using System.Linq;
using _02Scripts.Common.Component.AI.Condition;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Attack
{
    [RequireComponent(typeof(AttackComponent), typeof(StatComponent))]
    public abstract class AttackAIComponent : MonoBehaviour
    {
        public MonoBehaviour[] AICondition;
        
        private AttackComponent _attackComponent;
        private IAICondition[] _aiCondition;

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
            if (_aiCondition != null && _aiCondition.Any(aiCondition => !aiCondition.CanAct())) return;

            _attackComponent.Fire(GetAttackDirection());
        }

        protected virtual void Init()
        {
            _attackComponent = GetComponent<AttackComponent>();
            if (AICondition == null || AICondition.Any(monoBehaviour => monoBehaviour is not IAICondition)) return;

            _aiCondition = new IAICondition[AICondition.Length];
            for (int i = 0; i < AICondition.Length; i++)
            {
                _aiCondition[i] = AICondition[i] as IAICondition;
            }
        }

        protected abstract Vector2 GetAttackDirection();
    }
}
