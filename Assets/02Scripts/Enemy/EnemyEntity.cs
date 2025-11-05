using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent))]
    public class EnemyEntity : MonoBehaviour
    {
        private StatComponent _statComponent;
        private HealthComponent _healthComponent;

        public void Start()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _statComponent = GetComponent<StatComponent>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            HealthComponent otherHealth = other.gameObject.GetComponent<HealthComponent>();
            if (otherHealth == null) return;

            otherHealth.TakeDamage(_statComponent.Damage);
        }
    }
}
