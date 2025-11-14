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
    
        private int _health;
    
        private void Awake()
        {
            _statComponent = GetComponent<StatComponent>();
            _deathComponent = GetComponent<DeathComponent>();
            _invincibleComponent = GetComponent<InvincibleComponent>();
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _health = _statComponent.MaxHealth;
        }

        public void Heal(int amount)
        {
            _health = Mathf.Min(_statComponent.MaxHealth, _health + amount);
        }

        public void TakeDamage(int damage)
        {
            if (_invincibleComponent.IsInvincible()) return;
            
            _health -= damage;

            _invincibleComponent.Activate(_statComponent.InvincibleAfterHitSeconds);

            if (_health <= 0) _deathComponent.Die();
        }
    }
}