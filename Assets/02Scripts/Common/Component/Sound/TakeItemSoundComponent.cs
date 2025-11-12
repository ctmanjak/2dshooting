using _02Scripts.Common.Component.Item;

namespace _02Scripts.Common.Component.Sound
{
    public class TakeItemSoundComponent : BaseSoundComponent
    {
        private ItemComponent _itemComponent;

        private void Start()
        {
            _itemComponent = GetComponent<ItemComponent>();
            if (!_itemComponent) return;
            
            // TODO: EffectContext SfxContext 통합
            _itemComponent.OnActivate += _ => PlaySound();
        }
    }
}