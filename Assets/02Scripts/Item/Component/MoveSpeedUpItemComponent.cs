using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class MoveSpeedUpItemComponent : ItemComponent
    {
        public int IncreaseValue = 5;

        protected override void Activate(Collider2D other)
        {
            MoveStatComponent stat = other.GetComponent<MoveStatComponent>();
            if (stat == null) return;

            stat.IncreaseSpeed(IncreaseValue);
        }
    }
}