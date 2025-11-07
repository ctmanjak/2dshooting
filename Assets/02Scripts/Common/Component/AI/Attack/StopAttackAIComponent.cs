using UnityEngine;

namespace _02Scripts.Common.Component.AI.Attack
{
    public class StopAttackAIComponent : TargetAttackAIComponent
    {
        private MoveComponent _moveComponent;

        protected override void Init()
        {
            base.Init();
            _moveComponent = GetComponent<MoveComponent>();
        }

        protected override Vector2 GetAttackDirection()
        {
            return GetTargetDirection();
        }

        protected override bool CanAttack()
        {
            return _moveComponent.LastMoveDirection == Vector2.zero;
        }
    }
}
