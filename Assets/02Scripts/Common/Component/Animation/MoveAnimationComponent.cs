using UnityEngine;

namespace _02Scripts.Common.Component.Animation
{
    [RequireComponent(typeof(MoveComponent))]
    public class MoveAnimationComponent : AnimationComponent
    {
        private static readonly int Direction = Animator.StringToHash("Direction");

        private MoveComponent _moveComponent;

        protected override void Init()
        {
            base.Init();
            _moveComponent = GetComponent<MoveComponent>();
        }
        
        private void Update()
        {
            Animator.SetInteger(Direction, (int)_moveComponent.LastMoveDirection.x);
        }
    }
}