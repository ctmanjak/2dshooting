using Unity.Mathematics.Geometry;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class HealthComponent : MonoBehaviour
    {
        private StatComponent _statComponent;
    
        private int _health;
        private float _invincibleSeconds;
        private float _lastInvincibleTime;
    
        private void Start()
        {
            _statComponent = GetComponent<StatComponent>();
            _health = _statComponent.MaxHealth;
            _invincibleSeconds = _statComponent.InvincibleSeconds;
        }

        public void Heal(int amount)
        {
            _health = Mathf.Min(_statComponent.MaxHealth, _health + amount);
        }

        public void TakeDamage(int damage)
        {
            float currentTime = Time.time;
            if (currentTime - _lastInvincibleTime > _invincibleSeconds)
            {
                _health -= damage;

                _lastInvincibleTime = currentTime;
            }

            if (_health <= 0) Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}