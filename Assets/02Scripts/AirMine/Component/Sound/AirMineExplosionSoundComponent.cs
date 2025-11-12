using _02Scripts.Common.Component.Sound;
using UnityEngine;

namespace _02Scripts.AirMine.Component.Sound
{
    [RequireComponent(typeof(AirMineEntity))]
    public class AirMineExplosionSoundComponent : BaseSoundComponent
    {
        private AirMineEntity _airMineEntity;

        private void Start()
        {
            _airMineEntity = GetComponent<AirMineEntity>();
            
            // TODO: EffectContext SfxContext 통합
            _airMineEntity.AfterHit += _ => PlaySound();
        }
    }
}