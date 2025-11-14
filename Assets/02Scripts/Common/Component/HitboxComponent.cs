using System;
using System.Linq;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class HitboxComponent : MonoBehaviour
    {
        public Transform Transform;
        
        private HealthComponent _healthComponent;
        private KnockbackComponent _knockbackComponent;
        
        public float DamageMultiplier = 1f;
        public float KnockbackPower;

        public event Action OnHit;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>() ?? GetComponentInParent<HealthComponent>();
            _knockbackComponent = _healthComponent.gameObject.GetComponent<KnockbackComponent>();
            if (!Transform) throw new MissingComponentException();
        }

        public bool Hit(Vector2 hitDirection, int damage, string[] compareTags)
        {
            if (compareTags.Any(compareTag => !_healthComponent.CompareTag(compareTag))) return false;

            _healthComponent.TakeDamage((int)(damage * DamageMultiplier));

            if (_knockbackComponent) Knockback(hitDirection);
            
            OnHit?.Invoke();

            return true;
        }

        public bool Hit(Transform hitter, int damage, string[] compareTags)
        {
            return Hit((transform.position - hitter.position).normalized, damage, compareTags);
        }

        private void Knockback(Vector2 direction)
        {
            if (KnockbackPower <= 0f) return;
            
            _knockbackComponent.Knockback(direction, KnockbackPower);
        }
    }
}
