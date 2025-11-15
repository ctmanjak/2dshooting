using System;
using _02Scripts.Common;
using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [RequireComponent(typeof(HealthComponent), typeof(AttackStatComponent), typeof(MoveComponent))]
    [RequireComponent(typeof(EquipmentComponent), typeof(StatComponent))]
    public class EnemyEntity : MonoBehaviour, IDestroyable
    {
        private AttackStatComponent _attackStatComponent;
        private MoveComponent _moveComponent;
        private HealthComponent _healthComponent;
        private StatComponent _statComponent;

        private void Awake()
        {
            _attackStatComponent = GetComponent<AttackStatComponent>();
            _moveComponent = GetComponent<MoveComponent>();
            _healthComponent = GetComponent<HealthComponent>();
            _statComponent = GetComponent<StatComponent>();
        }

        public void Init(float healthMultiplier = 1f)
        {
            _statComponent.Init(healthMultiplier);
            _healthComponent.Init();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;

            Vector2 hitDirection = _moveComponent.LastMoveDirection;
            if (hitDirection == Vector2.zero) otherHitbox.Hit(transform, _attackStatComponent.Damage, new[] { "Player" });
            else otherHitbox.Hit(hitDirection, _attackStatComponent.Damage, new[] { "Player" });
        }

        public void DestroySelf()
        {
            this.DestroyOrDeactivate();
        }
    }
}
