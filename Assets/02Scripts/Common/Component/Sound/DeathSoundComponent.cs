using UnityEngine;

namespace _02Scripts.Common.Component.Sound
{
    [RequireComponent(typeof(DeathComponent))]
    public class DeathSoundComponent : BaseSoundComponent
    {
        private DeathComponent _deathComponent;

        private void Awake()
        {
            _deathComponent = GetComponent<DeathComponent>();
        }
        
        private void Start()
        {
            _deathComponent.OnDie += _ => PlaySound();
        }
    }
}