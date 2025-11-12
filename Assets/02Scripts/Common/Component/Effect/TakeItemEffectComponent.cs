using _02Scripts.Common.Component.Item;
using UnityEngine;

namespace _02Scripts.Common.Component.Effect
{
    public class TakeItemEffectComponent : MonoBehaviour, IEffectComponent
    {
        public GameObject EffectPrefab;

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
            Instantiate(EffectPrefab, context.TargetTransform);
        }
    }
}