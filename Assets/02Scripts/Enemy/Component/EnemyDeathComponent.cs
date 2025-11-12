using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Item;
using UnityEngine;

namespace _02Scripts.Enemy.Component
{
    [RequireComponent(typeof(ItemDropComponent))]
    public class EnemyDeathComponent : DeathComponent
    {
        private ItemDropComponent _itemDropComponent;
        protected override void Init()
        {
            _itemDropComponent = GetComponent<ItemDropComponent>();
        }

        public override void Die()
        {
            _itemDropComponent.Drop();
            base.Die();
        }
    }
}