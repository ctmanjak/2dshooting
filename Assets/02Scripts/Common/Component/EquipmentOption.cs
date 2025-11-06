using System;
using _02Scripts.Bullet;
using _02Scripts.Gun;
using JetBrains.Annotations;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [Serializable]
    public class EquipmentOption
    {
        public bool Enabled = true;
        public Vector2 Position;
        public BaseGun GunPrefab;
        [CanBeNull] public BaseBullet BulletPrefab;
    }
}