using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class ResourceManager
    {
        public Dictionary<string, Object> resources;

        public ResourceManager()
        {
            resources = new Dictionary<string, Object>();
        }
        public T Load<T>(string key) where T : Object
        {
            return Resources.Load<T>(key);
        }

        public GameObject InstantiatePrefab(string path, Transform transform = null)
        {
            GameObject resource = Load<GameObject>($"Prefabs/{path}");
            if (resource == null)
            {
                Debug.LogError($"Failed to load Prefab: {path}");
                return null;
            }
            return Object.Instantiate(resource, transform);
        }


        public void Destroy(GameObject obj)
        {
            if (obj == null) return;
            Object.Destroy(obj);
        }

    }
}