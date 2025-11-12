using UnityEngine;

namespace _02Scripts.Common.Component.Sound
{
    [RequireComponent(typeof(DeathComponent))]
    public class DeathSoundComponent : BaseSoundComponent
    {
        private DeathComponent _deathComponent;

        private void Start()
        {
            _deathComponent = GetComponent<DeathComponent>();
            _deathComponent.OnDie += _ => PlaySound();
        }
    }
}