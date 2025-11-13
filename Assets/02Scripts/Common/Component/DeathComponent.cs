using System;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class DeathComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDie;
        private IDestroyable _destroyable;
        
        private void Start()
        {
            _destroyable = GetComponent<IDestroyable>();
            
            Init();
        }

        protected virtual void Init() {}
        
        public virtual void Die()
        {
            OnDie?.Invoke(gameObject);
            if (_destroyable != null) _destroyable.DestroySelf();
            else Destroy(gameObject);
        }
    }
}