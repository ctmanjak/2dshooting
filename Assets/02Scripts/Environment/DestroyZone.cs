using UnityEngine;

namespace _02Scripts.Environment
{
    public class DestroyZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
