using UnityEngine;

namespace _02Scripts.Common.Component.AI.Attack
{
    [RequireComponent(typeof(TargetComponent))]
    public class TargetAttackAIComponent : AttackAIComponent
    {
        private TargetComponent _targetComponent;

        protected override void Awake()
        {
            base.Awake();
            _targetComponent = GetComponent<TargetComponent>();
        }

        protected override void Init()
        {
            base.Init();
            if (!_targetComponent.IsTargetExist())  _targetComponent.SetTarget(GameObject.FindWithTag("Player"));
        }

        private Vector2 GetTargetDirection()
        {
            return _targetComponent.GetTargetDirection();
        }

        protected override Vector2 GetAttackDirection()
        {
            return GetTargetDirection();
        }

        protected void SetTarget(GameObject target)
        {
            _targetComponent.SetTarget(target);
        }
    }
}
