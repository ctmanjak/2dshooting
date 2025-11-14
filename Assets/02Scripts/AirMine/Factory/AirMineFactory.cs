using _02Scripts.Common.Factory;
using UnityEngine;

namespace _02Scripts.AirMine.Factory
{
    public class AirMineFactory : PoolFactory<AirMineEntity>
    {
        public static AirMineFactory Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public override AirMineEntity Spawn(AirMineEntity prefab, Vector3 position, Quaternion rotation)
        {
            AirMineEntity airMineEntity = base.Spawn(prefab, position, rotation);
            airMineEntity.Init();

            return airMineEntity;
        }
    }
}