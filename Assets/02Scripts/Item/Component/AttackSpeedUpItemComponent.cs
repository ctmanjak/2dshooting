using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Item;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class AttackSpeedUpItemComponent : ItemComponent
    {
        public float IncreaseValue = 0.5f;

        protected override void Activate(Collider2D other)
        {
            AttackStatComponent stat = other.GetComponent<AttackStatComponent>();
            if (stat == null) return;

            stat.IncreaseAttackSpeed(IncreaseValue);
        }
    }
}