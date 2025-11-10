using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerAnimationComponent : MonoBehaviour
    {
        private static readonly int Direction = Animator.StringToHash("Direction");
        
        private Animator _animator;
        private MoveComponent _moveComponent;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void Update()
        {
            _animator.SetInteger(Direction, (int)_moveComponent.LastMoveDirection.x);
        }
    }
}