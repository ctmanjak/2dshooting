using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Item;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class HealItemComponent : ItemComponent
    {
        public int IncreaseValue = 10;

        protected override void Activate(Collider2D other)
        {
            HealthComponent health = other.GetComponent<HealthComponent>();
            if (health == null) return;

            health.Heal(IncreaseValue);
        }
    }
}