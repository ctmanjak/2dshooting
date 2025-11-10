using _02Scripts.Common.Component.AI.Condition;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    [RequireComponent(typeof(MoveComponent), typeof(MoveStatComponent))]
    public abstract class MoveAIComponent : MonoBehaviour
    {
        public MonoBehaviour AICondition;
        private MoveComponent _moveComponent;
        protected MoveStatComponent MoveStatComponent;

        private IAICondition _aiCondition;

        private void Start()
        {
            Init();
        }
        
        private void FixedUpdate()
        {
            BeforeMove();
            Move();
        }

        private void Move()
        {
            if (_aiCondition != null && !_aiCondition.CanAct()) return;
            _moveComponent.Move(GetMoveDirection(), MoveStatComponent.GetSpeed() * MoveStatComponent.SpeedMultiplier * Time.deltaTime);
        }
        
        protected virtual void BeforeMove()
        {}

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            MoveStatComponent = GetComponent<MoveStatComponent>();
            if (!AICondition && AICondition is not IAICondition) return;
            _aiCondition = AICondition as IAICondition;
        }
        
        protected abstract Vector2 GetMoveDirection();
    }
}
