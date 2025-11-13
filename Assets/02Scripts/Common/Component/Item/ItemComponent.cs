using System;
using _02Scripts.Effect.Component;
using UnityEngine;

namespace _02Scripts.Common.Component.Item
{
    public abstract class ItemComponent : MonoBehaviour, IDestroyable
    {
        public event Action<EffectContext> OnActivate;
        
        protected abstract void Activate(Collider2D other);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            Activate(other);
            OnActivate?.Invoke(new EffectContext(gameObject, other.gameObject));
            
            DestroySelf();
        }

        public void DestroySelf()
        {
            if (TryGetComponent<PooledMarkerComponent>(out _))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}