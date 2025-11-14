using UnityEngine;

namespace _02Scripts.Common.Factory
{
    public abstract class SinglePoolFactory<T> : PoolFactory<T> where T : MonoBehaviour
    {
        public T Prefab;
        
        public T Spawn(Vector3 position, Quaternion rotation)
        {
            return Spawn(Prefab, position, rotation);
        }
    }
}