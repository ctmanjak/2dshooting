using UnityEngine;

namespace _02Scripts.Common.Factory
{
    public abstract class PoolFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        public virtual T Spawn(T prefab, Vector3 position, Quaternion rotation)
        {
            return ObjectPool.Instance.InstantiateObject<T>(prefab.gameObject, position, rotation);
        }
        public virtual T Spawn(T prefab, Transform parent)
        {
            return ObjectPool.Instance.InstantiateObject<T>(prefab.gameObject, parent);
        }
    }
}