using UnityEngine;

namespace _02Scripts.Common
{
    public class HealthComponent : MonoBehaviour
    {
        public StatComponent StatComponent;
    
        private int _health;
        private float _invincibleSeconds;
        private float _lastInvincibleTime;
    
        private void Start()
        {
            if (!StatComponent) StatComponent = GetComponent<StatComponent>();
            _health = StatComponent.MaxHealth;
            _invincibleSeconds = StatComponent.InvincibleSeconds;
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