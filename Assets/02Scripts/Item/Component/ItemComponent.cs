using UnityEngine;

namespace _02Scripts.Item.Component
{
    public abstract class ItemComponent : MonoBehaviour
    {
        protected abstract void Activate(Collider2D other);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            Activate(other);
        
            Destroy(gameObject);
        }
    }
}