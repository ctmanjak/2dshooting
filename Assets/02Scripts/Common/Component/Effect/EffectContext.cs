using JetBrains.Annotations;
using UnityEngine;

namespace _02Scripts.Common.Component.Effect
{
    public struct EffectContext
    {
        public EffectContext(GameObject source, [CanBeNull] GameObject target = null)
        {
            Source = source;
            Target = target;
        }
        
        public readonly GameObject Source;
        [CanBeNull] public readonly GameObject Target;
    }
}