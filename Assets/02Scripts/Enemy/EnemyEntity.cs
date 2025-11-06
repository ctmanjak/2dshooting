using _02Scripts.Common;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent), typeof(MoveComponent))]
    public class EnemyEntity : MonoBehaviour
    {
        private StatComponent _statComponent;
        private HealthComponent _healthComponent;
        private MoveComponent _moveComponent;

        public void Start()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _statComponent = GetComponent<StatComponent>();
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;

            otherHitbox.Hit(transform.position, _statComponent.Damage, new[] { "Player" });
        }
    }
}
