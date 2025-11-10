using _02Scripts.Common.Enum;
using _02Scripts.Player.Component;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Condition
{
    [RequireComponent(typeof(PlayerInputTypeComponent))]
    public class AutoInputAICondition : MonoBehaviour, IAICondition
    {
        private PlayerInputTypeComponent _playerInputTypeComponent;

        private void Start()
        {
            _playerInputTypeComponent = GetComponent<PlayerInputTypeComponent>();
        }

        public bool CanAct()
        {
            return _playerInputTypeComponent.GetInputType() == EInputType.Auto;
        }
    }
}