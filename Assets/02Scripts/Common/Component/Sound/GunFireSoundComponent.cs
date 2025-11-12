using _02Scripts.Gun;
using UnityEngine;

namespace _02Scripts.Common.Component.Sound
{
    [RequireComponent(typeof(BaseGun))]
    public class GunFireSoundComponent : BaseSoundComponent
    {
        private BaseGun _baseGun;

        private void Start()
        {
            _baseGun = GetComponent<BaseGun>();
            _baseGun.OnFire += PlaySound;
        }
    }
}