using _02Scripts.Common.Component.AI.Condition;
using _02Scripts.Common.Component.Stat;
using _02Scripts.Util;
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

        private void Awake()
        {
            Init();
        }
        
        private void FixedUpdate()
        {
            if (_aiCondition != null && !_aiCondition.CanAct()) return;
            BeforeMove();
            Move();
        }

        private void Move()
        {
            _moveComponent.Move(GetMoveDirection(), MoveStatComponent.GetSpeed() * MoveStatComponent.SpeedMultiplier * Time.deltaTime);
        }

        protected void Rotate(Quaternion rotation)
        {
            _moveComponent.Rotate(rotation);
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
