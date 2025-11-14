using System;
using System.Collections.Generic;
using UnityEngine;

namespace _02Scripts.Common
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance { get; private set; }
        public ObjectPoolOption[] Options;
        
        private Dictionary<GameObject, int> _poolSize;
        private Dictionary<GameObject, List<GameObject>> _pool;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _poolSize = new Dictionary<GameObject, int>();
            _pool = new Dictionary<GameObject, List<GameObject>>();
            
            foreach (ObjectPoolOption option in Options)
            {
                GameObject prefab = option.Prefab;
                _poolSize[prefab] = option.DefaultPoolSize;
                _pool[prefab] = new List<GameObject>();
                
                for (int j = 0; j < _poolSize[prefab]; j++)
                {
                    AddPool(prefab);
                }
            }
        }

        private void AddPool(GameObject prefab)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.AddComponent<PooledMarkerComponent>();
            obj.SetActive(false);
            _pool[prefab].Add(obj);
        }

        private void IncreasePoolSize(GameObject prefab, int size)
        {
            for (int i = 0; i < size; i++)
            {
                AddPool(prefab);
            }
            _poolSize[prefab] += size;
        }

        public T InstantiateObject<T>(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!IsPooledPrefab(prefab)) return default;
            
            T obj = FindInactiveObject<T>(prefab, position, rotation);
            if (obj != null) return obj;
            
            IncreasePoolSize(prefab, _poolSize[prefab] / 2);
            obj = FindInactiveObject<T>(prefab, position, rotation);

            return obj;
        }

        public T InstantiateObject<T>(GameObject prefab, Transform parent)
        {
            if (!IsPooledPrefab(prefab)) return default;
            
            T obj = FindInactiveObject<T>(prefab, parent);
            if (obj != null) return obj;
            
            IncreasePoolSize(prefab, _poolSize[prefab] / 2);
            obj = FindInactiveObject<T>(prefab, parent);

            return obj;
        }

        private bool IsPooledPrefab(GameObject prefab)
        {
            return _pool.ContainsKey(prefab);
        }

        private GameObject FindInactiveObject(GameObject prefab)
        {
            for (int i = 0; i < _poolSize[prefab]; i++)
            {
                GameObject obj = _pool[prefab][i];

                if (!obj.gameObject.activeInHierarchy) return obj;
            }

            return null;
        }

        private T FindInactiveObject<T>(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject obj = FindInactiveObject(prefab);

            if (!obj) return default;
            
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj.GetComponent<T>();
        }

        private T FindInactiveObject<T>(GameObject prefab, Transform parent)
        {
            GameObject obj = FindInactiveObject(prefab);

            if (!obj) return default;
            
            obj.transform.SetParent(parent, false);
            obj.SetActive(true);
            return obj.GetComponent<T>();
        }
    }
}