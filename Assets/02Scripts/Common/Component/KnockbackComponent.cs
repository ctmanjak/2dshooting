using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class KnockbackComponent : MonoBehaviour
    {
        private float _knockbackStartTime;
        private Vector2 _knockbackDestination;

        public float KnockbackTime = 0.2f;

        private void Update()
        {
            KnockbackInternal();
        }
        
        public void Knockback(Vector2 direction, float knockbackPower)
        {
            _knockbackStartTime = Time.time;
            _knockbackDestination = (Vector2)transform.position + direction * knockbackPower;
        }

        private void KnockbackInternal()
        {
            float elapsed = Time.time - _knockbackStartTime;
            if (elapsed > KnockbackTime) return;

            transform.position =
                Vector2.Lerp(transform.position, _knockbackDestination, elapsed / KnockbackTime * Time.deltaTime);
        }
    }
}
