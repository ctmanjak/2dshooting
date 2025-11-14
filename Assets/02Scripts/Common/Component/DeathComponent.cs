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

        protected virtual void Awake()
        {
            _destroyable = GetComponent<IDestroyable>();
        }
        
        private void Start()
        {
            Init();
        }

        protected virtual void Init() {}
        
        public virtual void Die()
        {
            if (!gameObject || !gameObject.activeSelf) return;
            OnDie?.Invoke(gameObject);
            if (_destroyable != null) _destroyable.DestroySelf();
            else Destroy(gameObject);
        }
    }
}