using JetBrains.Annotations;
using UnityEngine;

namespace _02Scripts.Common.Component.Effect
{
    public struct EffectContext
    {
        public EffectContext(GameObject source, [CanBeNull] GameObject target = null)
        {
            SourceTransform = source.transform;
            TargetTransform = target?.transform;
            
            SourcePosition = source.transform.position;
            SourceRotation = source.transform.rotation;
            TargetPosition = target?.transform.position;
            TargetRotation = target?.transform.rotation;
        }

        public readonly Transform SourceTransform;
        [CanBeNull] public readonly Transform TargetTransform;
        
        public readonly Vector3 SourcePosition;
        public readonly Quaternion SourceRotation;
        public readonly Vector3? TargetPosition;
        public readonly Quaternion? TargetRotation;

    }
}