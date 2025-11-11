using UnityEngine;

namespace _02Scripts.Common.Component.Effect
{
    [RequireComponent(typeof(DeathComponent))]
    public class DeathExplosionEffectComponent : MonoBehaviour, IEffectComponent
    {
        public GameObject EffectPrefab;

        private DeathComponent _deathComponent;

        private void Start()
        {
            _deathComponent = GetComponent<DeathComponent>();
            _deathComponent.OnDie += PlayEffect;
        }

        public void PlayEffect(EffectContext context)
        {
            Instantiate(EffectPrefab, context.Source.transform.position, context.Source.transform.rotation);
        }
    }
}