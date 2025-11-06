using System;
using UnityEngine;

namespace _02Scripts.Enemy
{
    [Serializable]
    public class SpawnerOption
    {
        public GameObject Prefab;
        public int Weight;
    }
}