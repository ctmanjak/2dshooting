using _02Scripts.Common;
using UnityEngine;

namespace _02Scripts.Environment
{
    public class DestroyZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            IDestroyable destroyable = other.GetComponent<IDestroyable>();
            if (destroyable != null) destroyable.DestroySelf();
            else Destroy(other.gameObject);
        }
    }
}
