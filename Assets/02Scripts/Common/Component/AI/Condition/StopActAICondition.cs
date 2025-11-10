using UnityEngine;

namespace _02Scripts.Common.Component.AI.Condition
{
    public class StopActAICondition : MonoBehaviour, IAICondition
    {
        private MoveComponent _moveComponent;

        private void Start()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        public bool CanAct()
        {
            if (!_moveComponent) return true;
            return _moveComponent.LastMoveDirection == Vector2.zero;
        }
    }
}
