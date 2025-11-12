using _02Scripts.Common.Component.Sound;
using UnityEngine;

namespace _02Scripts.AirMine.Component.Sound
{
    [RequireComponent(typeof(AirMineEntity))]
    public class AirMineSpawnSoundComponent : BaseSoundComponent
    {
        private AirMineEntity _airMineEntity;

        private void Awake()
        {
            _airMineEntity = GetComponent<AirMineEntity>();
            
            _airMineEntity.OnSpawn += PlaySound;
        }
    }
}