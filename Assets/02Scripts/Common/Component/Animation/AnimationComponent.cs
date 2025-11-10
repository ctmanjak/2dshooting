using UnityEngine;

namespace _02Scripts.Common.Component.Animation
{
    public abstract class AnimationComponent : MonoBehaviour
    {
        protected Animator Animator;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Animator = GetComponent<Animator>();
        }
    }
}