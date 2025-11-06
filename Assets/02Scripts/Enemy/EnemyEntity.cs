using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent), typeof(MoveComponent))]
    [RequireComponent(typeof(EquipmentComponent))]
    public class EnemyEntity : MonoBehaviour
    {
        private StatComponent _statComponent;
        private MoveComponent _moveComponent;

        private void Start()
        {
            _statComponent = GetComponent<StatComponent>();
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;

            Vector2 hitDirection = _moveComponent.LastMoveDirection;
            if (hitDirection == Vector2.zero) otherHitbox.Hit(transform, _statComponent.Damage, new[] { "Player" });
            else otherHitbox.Hit(hitDirection, _statComponent.Damage, new[] { "Player" });
        }
    }
}
