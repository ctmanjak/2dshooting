using _02Scripts.Common;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent))]
    public class EnemyEntity : MonoBehaviour
    {
        private StatComponent _statComponent;
        private HealthComponent _healthComponent;
        private Collider2D _collider2D;

        public void Start()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _statComponent = GetComponent<StatComponent>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;

            otherHitbox.Hit(transform.position, _statComponent.Damage, new[] { "Player" });
        }
    }
}
