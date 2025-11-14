using _02Scripts.Effect;
using _02Scripts.Effect.Component;
using _02Scripts.Effect.Factory;
using UnityEngine;

namespace _02Scripts.AirMine.Component.Effect
{
    [RequireComponent(typeof(AirMineEntity))]
    public class AirMineExplosionEffectComponent : MonoBehaviour, IEffectComponent
    {
        public EffectEntity EffectPrefab;

        private AirMineEntity _airMineEntity;

        private void Awake()
        {
            _airMineEntity = GetComponent<AirMineEntity>();
            _airMineEntity.AfterHit += PlayEffect;
        }

        public void PlayEffect(EffectContext context)
        {
            if (!EffectPrefab) return;
            EffectFactory.Instance.Spawn(EffectPrefab, context.SourcePosition, context.SourceRotation);
        }
    }
}