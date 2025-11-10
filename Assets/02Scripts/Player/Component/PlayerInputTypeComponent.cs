using _02Scripts.Common.Enum;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    public class PlayerInputTypeComponent : MonoBehaviour
    {
        private EInputType _inputType;

        public void SetInputType(EInputType inputType)
        {
            _inputType = inputType;
        }

        public EInputType GetInputType()
        {
            return _inputType;
        }
    }
}