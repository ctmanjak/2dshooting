using _02Scripts.Audio;
using UnityEngine;

namespace _02Scripts.Common.Component.Sound
{
    public abstract class BaseSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        
        protected virtual void PlaySound()
        {
            if (!_audioSource?.clip) return;
            AudioManager.Instance.PlayOneShot(_audioSource.clip);
        }
    }
}