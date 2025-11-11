using UnityEngine;

namespace _02Scripts.Common.Component.Effect
{
    [RequireComponent(typeof(DeathComponent))]
    public class DeathExplosionEffectComponent : MonoBehaviour
    {
        public GameObject EffectPrefab;

        private DeathComponent _deathComponent;

        private void Start()
        {
            _deathComponent = GetComponent<DeathComponent>();
            _deathComponent.OnDie += OnDie;
        }

        private void OnDie()
        {
            Instantiate(EffectPrefab, transform.position, transform.rotation);
        }
    }
}