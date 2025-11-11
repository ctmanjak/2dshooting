using System;
using _02Scripts.Common.Component.Effect;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public abstract class ItemComponent : MonoBehaviour
    {
        public event Action<EffectContext> OnActivate;
        
        protected abstract void Activate(Collider2D other);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            Activate(other);
            OnActivate?.Invoke(new EffectContext(gameObject, other.gameObject));
        
            Destroy(gameObject);
        }
    }
}