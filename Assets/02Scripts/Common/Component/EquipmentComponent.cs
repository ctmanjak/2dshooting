using System.Collections.Generic;
using _02Scripts.Gun;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class EquipmentComponent : MonoBehaviour
    {
        public EquipmentOption[] Options;

        public List<BaseGun> Guns { get; } = new();
        
        public void Start()
        {
            foreach (var option in Options)
            {
                if (option.Enabled)
                {
                    BaseGun gun = Instantiate(option.GunPrefab, transform);
                    gun.transform.position += (Vector3)option.Position;
                    if (option.BulletPrefab) gun.SetBulletPrefab(option.BulletPrefab);
                    Guns.Add(gun);
                }
            }
        }
    }
}