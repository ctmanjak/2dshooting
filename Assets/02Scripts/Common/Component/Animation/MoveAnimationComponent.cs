using UnityEngine;

namespace _02Scripts.Common.Component.Animation
{
    [RequireComponent(typeof(MoveComponent))]
    public class MoveAnimationComponent : AnimationComponent
    {
        private static readonly int Direction = Animator.StringToHash("Direction");

        private MoveComponent _moveComponent;

        protected override void Awake()
        {
            base.Awake();
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void Update()
        {
            Animator.SetInteger(Direction, Mathf.RoundToInt(_moveComponent.LastMoveDirection.x));
        }
    }
}