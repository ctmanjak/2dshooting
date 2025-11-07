using _02Scripts.Common.Component.AI.Move.Condition;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    [RequireComponent(typeof(MoveComponent), typeof(MoveStatComponent))]
    public abstract class MoveAIComponent : MonoBehaviour
    {
        public MonoBehaviour MoveCondition;
        private MoveComponent _moveComponent;
        protected MoveStatComponent MoveStatComponent;

        private IMoveCondition _moveCondition;

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
            if (_moveCondition != null && !_moveCondition.CanMove()) return;
            _moveComponent.Move(GetMoveDirection(), MoveStatComponent.GetSpeed() * MoveStatComponent.SpeedMultiplier * Time.deltaTime);
        }
        
        protected virtual void BeforeMove()
        {}

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            MoveStatComponent = GetComponent<MoveStatComponent>();
            if (!MoveCondition && MoveCondition is not IMoveCondition) return;
            _moveCondition = MoveCondition as IMoveCondition;
        }
        
        protected abstract Vector2 GetMoveDirection();
    }
}
