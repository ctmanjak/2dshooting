using UnityEngine;

namespace _02Scripts.Common.Component.AI.Condition
{
    [RequireComponent(typeof(TargetComponent))]
    public class UnderTargetAICondition : MonoBehaviour, IAICondition
    {
        private TargetComponent _targetComponent;

        public float AvailableDistance = 0.5f;

        private void Awake()
        {
            _targetComponent = GetComponent<TargetComponent>();
        }

        public bool CanAct()
        {
            if (!_targetComponent.IsTargetExist()) return false;
            Vector2 targetPosition = _targetComponent.GetTargetPosition();
            return Mathf.Abs(targetPosition.x - transform.position.x) <= AvailableDistance;
        }
    }
}