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
            _itemComponent.OnActivate += PlayEffect;
        }

        public void PlayEffect(EffectContext context)
        {
            if (context.Target == null) return;
            Instantiate(EffectPrefab, context.Target.transform);
        }
    }
}