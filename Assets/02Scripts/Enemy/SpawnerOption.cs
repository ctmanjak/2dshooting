using System;
using _02Scripts.Common.Serializable;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [Serializable]
    public class SpawnerOption : WeightedRandomOption
    {
        public GameObject Prefab;
    }
}