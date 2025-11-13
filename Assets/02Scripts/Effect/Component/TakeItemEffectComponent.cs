using _02Scripts.Common.Component.Item;
using _02Scripts.Effect.Factory;
using UnityEngine;

namespace _02Scripts.Effect.Component
{
    public class TakeItemEffectComponent : MonoBehaviour, IEffectComponent
    {
        public EffectEntity EffectPrefab;

        private ItemComponent _itemComponent;

        private void Start()
        {
            _itemComponent = GetComponent<ItemComponent>();
            if (!_itemComponent) return;
            _itemComponent.OnActivate += PlayEffect;
        }

        public void PlayEffect(EffectContext context)
        {
            if (context.TargetTransform == null) return;
            EffectFactory.Instance.Spawn(EffectPrefab, context.TargetTransform);
        }
    }
}