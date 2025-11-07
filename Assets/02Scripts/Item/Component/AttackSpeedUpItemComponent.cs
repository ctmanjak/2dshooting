using _02Scripts.Player.Component;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class AttackSpeedUpItemComponent : ItemComponent
    {
        public float IncreaseValue = 0.5f;

        protected override void Activate(Collider2D other)
        {
            PlayerStatComponent stat = other.GetComponent<PlayerStatComponent>();
            if (stat == null) return;

            stat.IncreaseAttackSpeed(IncreaseValue);
        }
    }
}