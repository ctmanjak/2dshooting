using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component.Item
{
    public class ItemDropComponent : MonoBehaviour
    {
        public ItemDropOption[] Options;
        
        public void Drop()
        {
            GameObject selectedPrefab = RandomUtil.PickWeightedRandomIndex(Options).Prefab;
            if (!selectedPrefab) return;

            Instantiate(selectedPrefab, transform.position, transform.rotation);
        }
    }
}