using _02Scripts.Item;
using _02Scripts.Item.Factory;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component.Item
{
    public class ItemDropComponent : MonoBehaviour
    {
        public ItemDropOption[] Options;
        
        public void Drop()
        {
            ItemEntity selectedPrefab = RandomUtil.PickWeightedRandomIndex(Options).Prefab;
            if (!selectedPrefab) return;

            ItemFactory.Instance.Spawn(selectedPrefab, transform.position, transform.rotation);
        }
    }
}