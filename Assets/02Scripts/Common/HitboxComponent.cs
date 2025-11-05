using System;
using System.Linq;
using UnityEngine;

namespace _02Scripts.Common
{
    public class HitboxComponent : MonoBehaviour
    {
        public Transform Transform;
        public HealthComponent HealthComponent;
        
        public float DamageMultiplier = 1.0f;
        public float KnockbackPower = 5.0f;

        private void Start()
        {
            if (!HealthComponent) HealthComponent = GetComponent<HealthComponent>() ?? GetComponentInParent<HealthComponent>();
            if (!Transform) throw new MissingComponentException();
        }

        public bool Hit(Vector3 hitterPosition, int damage, string[] compareTags)
        {
            if (compareTags.Any(compareTag => !HealthComponent.CompareTag(compareTag))) return false;
            
            HealthComponent.TakeDamage((int)(damage * DamageMultiplier));

            if (DamageMultiplier > 1.0f)
            {
                Vector2 knockbackDirection = (Transform.position - hitterPosition).normalized;
                Vector2 newPosition = (Vector2)Transform.position + knockbackDirection * KnockbackPower;
                Transform.position = newPosition;
            }

            return true;
        }
    }
}
