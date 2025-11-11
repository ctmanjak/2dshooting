using _02Scripts.Common.Component.Effect;
using UnityEngine;

namespace _02Scripts.AirMine.Component.Effect
{
    [RequireComponent(typeof(AirMineEntity))]
    public class AirMineExplosionEffectComponent : MonoBehaviour, IEffectComponent
    {
        public GameObject EffectPrefab;

        private AirMineEntity _airMineEntity;

        private void Start()
        {
            _airMineEntity = GetComponent<AirMineEntity>();
            _airMineEntity.AfterHit += PlayEffect;
        }

        public void PlayEffect(EffectContext context)
        {
            Instantiate(EffectPrefab, context.SourcePosition, context.SourceRotation);
        }
    }
}