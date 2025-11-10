using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using _02Scripts.Common.Enum;
using _02Scripts.Player.Component;
using _02Scripts.Player.Component.AI;
using UnityEngine;

namespace _02Scripts.Player
{
    [RequireComponent(typeof(AttackComponent), typeof(PlayerStatComponent), typeof(PlayerMoveComponent))]
    [RequireComponent(typeof(MoveStatComponent), typeof(PlayerInputTypeComponent))]
    [RequireComponent(typeof(PlayerMoveAIComponent))]
    public class PlayerInputController : MonoBehaviour
    {
        private AttackComponent _attackComponent;
        private PlayerStatComponent _playerStatComponent;
        private MoveStatComponent _moveStatComponent;
        private PlayerMoveComponent _playerMoveComponent;
        private PlayerInputTypeComponent _playerInputTypeComponent;
        private PlayerMoveAIComponent _playerMoveAIComponent;

        private readonly Vector2 _attackDirection = Vector2.up;

        private void Start()
        {
            _attackComponent = GetComponent<AttackComponent>();
            _playerStatComponent = GetComponent<PlayerStatComponent>();
            _moveStatComponent = GetComponent<MoveStatComponent>();
            _playerMoveComponent = GetComponent<PlayerMoveComponent>();
            _playerInputTypeComponent = GetComponent<PlayerInputTypeComponent>();
            _playerMoveAIComponent = GetComponent<PlayerMoveAIComponent>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetInputType(EInputType.Auto);
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetInputType(EInputType.Manual);
            }

            if (_playerInputTypeComponent.GetInputType() == EInputType.Auto) return;
            
            if (Input.GetKey(KeyCode.Space)) _attackComponent.Fire(_attackDirection);
            
            if (Input.GetKeyDown(KeyCode.Q)) _moveStatComponent.IncreaseSpeed(_playerStatComponent.SpeedChangeAmount);
            if (Input.GetKeyDown(KeyCode.E)) _moveStatComponent.DecreaseSpeed(_playerStatComponent.SpeedChangeAmount);
            
            float speed = _moveStatComponent.GetSpeed() * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift)) speed *= _moveStatComponent.SpeedMultiplier;

            if (Input.GetKey(KeyCode.R))
            {
                GoToOrigin(speed);
                return;
            }
            
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            
            Vector2 direction = new Vector2(h, v).normalized;
            _playerMoveComponent.Move(direction, speed);
        }

        private void GoToOrigin(float speed)
        {
            Vector2 direction = (_playerStatComponent.InitialPosition - (Vector2)transform.position).normalized;
            _playerMoveComponent.Move(direction, speed);
        }

        private void SetInputType(EInputType inputType)
        {
            _playerInputTypeComponent.SetInputType(inputType);
        }
    }
}