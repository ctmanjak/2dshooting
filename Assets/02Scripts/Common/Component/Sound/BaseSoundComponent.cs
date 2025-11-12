using _02Scripts.Audio;
using UnityEngine;

namespace _02Scripts.Common.Component.Sound
{
    public abstract class BaseSoundComponent : MonoBehaviour
    {
        public AudioSource AudioSource;
        
        protected virtual void PlaySound()
        {
            if (!AudioSource?.clip) return;
            AudioManager.Instance.PlayOneShot(AudioSource.clip);
        }
    }
}