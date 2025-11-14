using System;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent), typeof(DeathComponent), typeof(InvincibleComponent))]
    public class HealthComponent : MonoBehaviour
    {
        private StatComponent _statComponent;
        private DeathComponent _deathComponent;
        private InvincibleComponent _invincibleComponent;

        public int Health { get; private set; }

        public event Action<int> ChangeHealth;
    
        private void Awake()
        {
            _statComponent = GetComponent<StatComponent>();
            _deathComponent = GetComponent<DeathComponent>();
            _invincibleComponent = GetComponent<InvincibleComponent>();
        }

        private void OnEnable()
        {
            Init();
        }

        public void Init(float healthMultiplier = 1f)
        {
            SetHealth(Mathf.CeilToInt(_statComponent.MaxHealth * healthMultiplier));
        }

        public void Heal(int amount)
        {
            SetHealth(Mathf.Min(_statComponent.MaxHealth, Health + amount));
        }

        public void TakeDamage(int damage)
        {
            if (_invincibleComponent.IsInvincible()) return;
            
            SetHealth(Health - damage);

            _invincibleComponent.Activate(_statComponent.InvincibleAfterHitSeconds);

            if (Health <= 0) _deathComponent.Die();
        }

        public void SetHealth(int health)
        {
            Health = health;
            ChangeHealth?.Invoke(Health);
        }
    }
}