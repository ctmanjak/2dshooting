using System;
using _02Scripts.Bullet;
using _02Scripts.Gun;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [Serializable]
    public class EquipmentOption
    {
        public bool Enabled = true;
        public Vector2 Position;
        public BaseGun GunPrefab;
        public BaseBullet BulletPrefab;
    }
}