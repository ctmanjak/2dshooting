using System;
using _02Scripts.AirMine.Component;
using _02Scripts.Common;
using _02Scripts.Effect.Component;
using UnityEngine;

namespace _02Scripts.AirMine
{
    [RequireComponent(typeof(AirMineStatComponent))]
    public class AirMineEntity : MonoBehaviour, IDestroyable
    {
        public event Action OnSpawn;
        public event Action<EffectContext> AfterHit;

        private AirMineSplash _airMineSplash;
        private AirMineStatComponent _airMineStatComponent;

        private float _birthTime;

        public float LifeTime = 3f;

        private bool _activated;

        private void Awake()
        {
            _airMineSplash = GetComponentInChildren<AirMineSplash>();
            _airMineStatComponent = GetComponent<AirMineStatComponent>();
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _birthTime = Time.time;
            OnSpawn?.Invoke();
            _activated = false;
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
            _airMineSplash.Init(_airMineStatComponent.Damage);
            DestroySelf();
        }

        public void DestroySelf()
        {
            this.DestroyOrDeactivate();
        }
    }
}