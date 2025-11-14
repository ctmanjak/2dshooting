using System.Linq;
using _02Scripts.Common.Serializable;
using UnityEngine;

namespace _02Scripts.Util
{
    public static class RandomUtil
    {
        public static T PickWeightedRandomIndex<T>(T[] options) where T : WeightedRandomOption
        {
            int totalWeight = options.Sum(option => option.Weight);
            int chance = Random.Range(0, totalWeight);

            for (int i = 0, accumulateWeight = 0; i < options.Length; i++)
            {
                accumulateWeight += options[i].Weight;
                if (chance < accumulateWeight)
                {
                    return options[i];
                }
            }

            return null;
        }
    }
}