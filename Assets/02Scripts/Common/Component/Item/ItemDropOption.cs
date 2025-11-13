using System;
using _02Scripts.Common.Serializable;
using _02Scripts.Item;
using UnityEngine;

namespace _02Scripts.Common.Component.Item
{
    [Serializable]
    public class ItemDropOption : WeightedRandomOption
    {
        public ItemEntity Prefab;
    }
}