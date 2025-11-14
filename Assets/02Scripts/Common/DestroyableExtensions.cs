using UnityEngine;

namespace _02Scripts.Common
{
    public static class DestroyableExtensions
    {
        public static void DestroyOrDeactivate(this MonoBehaviour monoBehaviour)
        {
            if (monoBehaviour == null) return;

            if (monoBehaviour.TryGetComponent<PooledMarkerComponent>(out _))
            {
                monoBehaviour.gameObject.SetActive(false);
            }
            else Object.Destroy(monoBehaviour.gameObject);
        }
    }
}