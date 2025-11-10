using _02Scripts.Common.Component.AI.Attack;
using _02Scripts.Player.Enum;
using UnityEngine;

namespace _02Scripts.Player.Component.AI
{
    public class PlayerAttackAIComponent : TargetAttackAIComponent
    {
        private EAttackAIState _state;
        
        private ETargetType _targetType;

        private readonly Vector2 _attackDirection = Vector2.up;
        
        protected override Vector2 GetAttackDirection()
        {
            return _attackDirection;
        }
        
        protected override void Init()
        {
            base.Init();

            _state = EAttackAIState.Idle;
            SetTarget(null);
        }
    }
}
