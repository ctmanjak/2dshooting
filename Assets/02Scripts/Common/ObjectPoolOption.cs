using System;
using UnityEngine;

namespace _02Scripts.Common
{
    [Serializable]
    public class ObjectPoolOption
    {
        public GameObject Prefab;
        public int DefaultPoolSize = 30;
    }
}