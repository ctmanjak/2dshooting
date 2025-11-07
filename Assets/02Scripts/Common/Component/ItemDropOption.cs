using System;
using _02Scripts.Common.Serializable;
using UnityEngine;

[Serializable]
public class ItemDropOption : WeightedRandomOption
{
    public GameObject Prefab;
}