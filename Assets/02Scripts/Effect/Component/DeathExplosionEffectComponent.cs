using _02Scripts.Common.Component;
using _02Scripts.Effect.Factory;
using UnityEngine;

namespace _02Scripts.Effect.Component
{
    [RequireComponent(typeof(DeathComponent))]
    public class DeathExplosionEffectComponent : MonoBehaviour, IEffectComponent
    {
        public EffectEntity EffectPrefab;

        private DeathComponent _deathComponent;

        private void Awake()
        {
            _deathComponent = GetComponent<DeathComponent>();
        }
        
        private void Start()
        {
            _deathComponent.OnDie += OnDie;
        }

        private void OnDie(GameObject obj)
        {
            PlayEffect(new EffectContext(obj));
        }

        public void PlayEffect(EffectContext context)
        {
            EffectFactory.Instance.Spawn(EffectPrefab, context.SourcePosition, context.SourceRotation);
        }
    }
}