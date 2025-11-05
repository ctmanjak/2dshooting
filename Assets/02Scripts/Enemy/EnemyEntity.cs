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

        private void OnTriggerStay2D(Collider2D other)
        {
            HealthComponent otherHealth = other.GetComponentInParent<HealthComponent>();
            if (otherHealth == null) return;
            
            if (!otherHealth.CompareTag("Player")) return;

            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            float damageMultiplier = otherHitbox?.DamageMultiplier ?? 1.0f; 

            otherHealth.TakeDamage((int)(_statComponent.Damage * damageMultiplier));
        }
    }
}
