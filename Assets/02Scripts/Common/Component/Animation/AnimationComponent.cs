using UnityEngine;

namespace _02Scripts.Common.Component.Animation
{
    public abstract class AnimationComponent : MonoBehaviour
    {
        protected Animator Animator;

        protected virtual void Awake()
        {
            Animator = GetComponent<Animator>();
        }
        
        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
        }
    }
}