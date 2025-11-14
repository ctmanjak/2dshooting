using UnityEngine;

namespace _02Scripts.Common.Component.Animation
{
    [RequireComponent(typeof(HitboxComponent))]
    public class HitAnimationComponent : AnimationComponent
    {
        private static readonly int Hit = Animator.StringToHash("Hit");
        
        private HitboxComponent _hitboxComponent;

        protected override void Awake()
        {
            base.Awake();
            _hitboxComponent = GetComponent<HitboxComponent>();
        }

        protected override void Init()
        {
            base.Init();
            _hitboxComponent.OnHit += OnHit;
        }

        private void OnHit()
        {
            Animator.SetTrigger(Hit);
        }
    }
}