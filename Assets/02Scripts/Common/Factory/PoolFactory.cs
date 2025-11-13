using System.Collections.Generic;
using UnityEngine;

namespace _02Scripts.Common.Factory
{
    public abstract class PoolFactory : MonoBehaviour
    {
        public GameObject Prefab;

        public int PoolSize = 30;
        private List<GameObject> _pool;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            _pool = new List<GameObject>();
            
            for (int i = 0; i < PoolSize; i++)
            {
                AddPool();
            }
        }

        private void AddPool()
        {
            GameObject obj = Instantiate(Prefab, transform);
            obj.AddComponent<PooledMarkerComponent>();
            obj.SetActive(false);
            _pool.Add(obj);
        }

        private void IncreasePoolSize(int size)
        {
            for (int i = 0; i < size; i++)
            {
                AddPool();
            }
            PoolSize += size;
        }

        public T InstantiateObject<T>(Vector3 position, Quaternion rotation)
        {
            T obj = FindInactiveObject<T>(position, rotation);
            if (obj != null) return obj;
            
            IncreasePoolSize(PoolSize / 2);
            obj = FindInactiveObject<T>(position, rotation);

            return obj;
        }

        public T InstantiateObject<T>(Transform parent)
        {
            T obj = FindInactiveObject<T>(parent.position, parent.rotation);
            if (obj != null) return obj;
            
            IncreasePoolSize(PoolSize / 2);
            obj = FindInactiveObject<T>(parent.position, parent.rotation);

            return obj;
        }

        private GameObject FindInactiveObject()
        {
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = _pool[i];

                if (!obj.gameObject.activeInHierarchy) return obj;
            }

            return null;
        }

        private T FindInactiveObject<T>(Vector3 position, Quaternion rotation)
        {
            GameObject obj = FindInactiveObject();

            if (!obj) return default;
            
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj.GetComponent<T>();
        }
    }
}