using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent), typeof(MoveComponent))]
    [RequireComponent(typeof(EquipmentComponent))]
    public class EnemyEntity : MonoBehaviour
    {
        private StatComponent _statComponent;

        private void Start()
        {
            _statComponent = GetComponent<StatComponent>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;

            otherHitbox.Hit(transform.position, _statComponent.Damage, new[] { "Player" });
        }
    }
}
