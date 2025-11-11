using System;
using _02Scripts.Common.Component.Effect;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class DeathComponent : MonoBehaviour
    {
        public event Action<EffectContext> OnDie;
        
        private void Start()
        {
            Init();
        }

        protected virtual void Init() {}
        
        public virtual void Die()
        {
            OnDie?.Invoke(new EffectContext(gameObject));
            Destroy(gameObject);
        }
    }
}