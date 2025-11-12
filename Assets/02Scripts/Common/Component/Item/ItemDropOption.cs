using System;
using _02Scripts.Common.Serializable;
using UnityEngine;

namespace _02Scripts.Common.Component.Item
{
    [Serializable]
    public class ItemDropOption : WeightedRandomOption
    {
        public GameObject Prefab;
    }
}