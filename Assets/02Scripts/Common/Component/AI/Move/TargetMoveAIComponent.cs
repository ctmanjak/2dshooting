using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    [RequireComponent(typeof(TargetComponent))]
    public abstract class TargetMoveAIComponent : MoveAIComponent
    {
        private TargetComponent _targetComponent;

        protected override void Init()
        {
            base.Init();
            _targetComponent = GetComponent<TargetComponent>();
            if (!_targetComponent.IsTargetExist()) _targetComponent.SetTarget(GameObject.FindWithTag("Player"));
        }

        protected Vector2 GetTargetDirection()
        {
            return _targetComponent.GetTargetDirection();
        }

        protected Vector2 GetTargetPosition()
        {
            return _targetComponent.GetTargetPosition();
        }

        protected bool IsTargetExist()
        {
            return _targetComponent.IsTargetExist();
        }

        public void SetTarget(GameObject target)
        {
            _targetComponent.SetTarget(target);
        }

        protected GameObject GetTarget()
        {
            return _targetComponent.GetTarget();
        }

        protected override Vector2 GetMoveDirection()
        {
            return GetTargetDirection();
        }
    }
}
