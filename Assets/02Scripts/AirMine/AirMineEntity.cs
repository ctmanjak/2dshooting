using System;
using _02Scripts.AirMine.Component;
using _02Scripts.Common.Component.Effect;
using UnityEngine;

namespace _02Scripts.AirMine
{
    [RequireComponent(typeof(AirMineStatComponent))]
    public class AirMineEntity : MonoBehaviour
    {
        public event Action OnSpawn;
        public event Action<EffectContext> AfterHit;

        private float _birthTime;

        public float LifeTime = 3f;

        private bool _activated;

        public void Start()
        {
            _birthTime = Time.time;
            OnSpawn?.Invoke();
        }

        private void Update()
        {
            if (Time.time - _birthTime > LifeTime) Activate();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy")) Activate();
        }

        private void Activate()
        {
            if (_activated) return;
            _activated = true;
            AfterHit?.Invoke(new EffectContext(gameObject));
            Destroy(gameObject);
        }
    }
}