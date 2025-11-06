using System.Linq;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class HitboxComponent : MonoBehaviour
    {
        public Transform Transform;
        
        private HealthComponent _healthComponent;
        private MoveComponent _moveComponent;
        
        public float DamageMultiplier = 1f;
        public float KnockbackPower = 0f;

        private void Start()
        {
            _healthComponent = GetComponent<HealthComponent>() ?? GetComponentInParent<HealthComponent>();
            _moveComponent = _healthComponent.gameObject.GetComponent<MoveComponent>();
            if (!Transform) throw new MissingComponentException();
        }

        public bool Hit(Vector3 hitDirection, int damage, string[] compareTags)
        {
            if (compareTags.Any(compareTag => !_healthComponent.CompareTag(compareTag))) return false;
            
            _healthComponent.TakeDamage((int)(damage * DamageMultiplier));

            Knockback(hitDirection);

            return true;
        }

        private void Knockback(Vector2 direction)
        {
            if (KnockbackPower <= 0f) return;
            
            _moveComponent.Knockback(direction, KnockbackPower);
        }
    }
}
