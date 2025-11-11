using System;
using System.Linq;
using _02Scripts.Common.Component.Effect;
using UnityEngine;

namespace _02Scripts.AirMine
{
    public class AirMineEntity : MonoBehaviour
    {
        public event Action<EffectContext> AfterHit;
        
        private readonly string[] _enemyTags = { "Enemy" };

        private float _lifeTime;
        private float _birthTime;

        public void Init(float lifeTime)
        {
            _lifeTime = lifeTime;
            _birthTime = Time.time;
        }

        private void Update()
        {
            if (Time.time - _birthTime > _lifeTime) Activate();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_enemyTags.Any(other.CompareTag)) Activate();
        }

        private void Activate()
        {
            AfterHit?.Invoke(new EffectContext(gameObject));
            Destroy(gameObject);
        }
    }
}