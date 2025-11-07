using _02Scripts.Player.Component;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class MoveSpeedUpItemComponent : ItemComponent
    {
        public int IncreaseValue = 5;

        protected override void Activate(Collider2D other)
        {
            PlayerStatComponent stat = other.GetComponent<PlayerStatComponent>();
            if (stat == null) return;

            stat.IncreaseSpeed(IncreaseValue);
        }
    }
}