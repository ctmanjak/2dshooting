using System.Collections;
using _02Scripts.AirMine.Component;
using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.AirMine
{
    [RequireComponent(typeof(ParticleSystem), typeof(AirMineStatComponent))]
    public class AirMineSplash : MonoBehaviour
    {
        private Collider2D _collider2D;
        private AirMineStatComponent _airMineStatComponent;

        public float TriggerDuration = 0.05f; 
        
        private readonly string[] _enemyTags = { "Enemy" };
        private int _damage;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _airMineStatComponent = GetComponent<AirMineStatComponent>();
        }
        
        private void Start()
        {
            _damage = _airMineStatComponent.Damage;
            
            StartCoroutine(TriggerOnce());
        }
        
        private IEnumerator TriggerOnce()
        {
            _collider2D.enabled = true;
            yield return new WaitForSeconds(TriggerDuration);
            _collider2D.enabled = false;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;
            
            otherHitbox.Hit(transform.up, _damage, _enemyTags);
        }
    }
}