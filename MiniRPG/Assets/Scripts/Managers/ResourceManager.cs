using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Object = UnityEngine.Object;

namespace Managers
{
    public class ResourceManager
    {
        public Dictionary<string, Object> _resources;
        public bool LoadBase { get; set; }
        public ResourceManager(){
            Debug.Log(_resources);
            _resources = new Dictionary<string,Object>();
    }


        public void AllLoadResource<T>(string label, Action<string,int,int> callback) where T : Object
        {
            AsyncOperationHandle<IList<IResourceLocation>> operation = Addressables.LoadResourceLocationsAsync(label, typeof(T));
            operation.Completed += operationHandle =>
            {
                int loadCount = 0;
                int totalCount = operationHandle.Result.Count;
                foreach (var res in operationHandle.Result)
                {
                    LoadResource<T>(res.PrimaryKey, obj =>
                    {
                        loadCount++;
                        callback?.Invoke(res.PrimaryKey, loadCount, totalCount);
                    });
                }
            };
        }
    
        private void AtlasCallbackFunction<T>(string key, AsyncOperationHandle<IList<T>> handle, Action<IList<T>> callback) where T : Object
        {
            handle.Completed += operationHandle =>
            {
                foreach (var result in operationHandle.Result)
                {
                    string keyIndex = result.ToString().Split("_")[1].Split(" ")[0];
                    string resourceKey = $"{key}[{keyIndex}]";

                    if (!_resources.ContainsKey(resourceKey))
                    {
                        _resources.Add(resourceKey, result);
                    }
                }
                callback?.Invoke(operationHandle.Result);
            };
        }

        private void HandlerCallbackFunction<T>(string key, AsyncOperationHandle<T> handle, Action<T> callback) where T :Object
        {
            handle.Completed += operationHandle =>
            {
                if (!_resources.ContainsKey(key))
                {
                    _resources.Add(key, operationHandle.Result);
                }
               
                callback?.Invoke(operationHandle.Result);
            };
        }

        private void LoadResource<T>(string key, Action<T> callback =null) where T: Object
        {
            string loadKey = key;
            if(_resources.TryGetValue(loadKey, out Object resource))
            {
                callback?.Invoke(resource as T);
                return;
            }

            if (key.Contains(".atlas")) //atlas 
            {
                AsyncOperationHandle<IList<Sprite>> handle = Addressables.LoadAssetAsync<IList<Sprite>>(loadKey);
                AtlasCallbackFunction(key, handle, objs => callback?.Invoke(objs as T));
            }
            else if (key.Contains(".sprite")) //sprite
            {
                //[{key.Replace(".sprite", "")}]
                loadKey = $"{key}";
                AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(loadKey);
                HandlerCallbackFunction(loadKey, handle, callback as Action<Sprite>);

            }
            else // object
            {
                AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(loadKey);
                HandlerCallbackFunction(loadKey, handle, callback);
            }
        }
        public T Load<T>(string path) where T : Object
        {
            if (_resources.TryGetValue(path, out Object resource)) return resource as T;
            Debug.LogError($"Failed to find key : {path}");
            return null;
        }

        public GameObject InstantiatePrefab(string path, Transform transform = null)
        {
            GameObject resource = Load<GameObject>($"{path}.prefab");  
            if (resource == null)
            {
                Debug.LogError($"Failed to load Prefab: {path}");
                return null;
            }
            GameObject go = Object.Instantiate(resource, transform);
            go.name = resource.name;

            return go;
        }


        public void UnloadAllAsync<T>(string label) where T : Object
        {
            var operation = Addressables.LoadResourceLocationsAsync(label, typeof(T));
            operation.Completed += operationHandle =>
            {
                foreach (var result in operationHandle.Result)
                {
                    if (_resources.TryGetValue(result.PrimaryKey, out Object resource))
                    {
                        Debug.Log($"Unload.... {result.PrimaryKey}");
                        Addressables.Release(resource);
                        _resources.Remove(result.PrimaryKey);
                    }
     
                }
            };
        }
    }
}