using UnityEngine;

namespace _02Scripts.Common
{
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