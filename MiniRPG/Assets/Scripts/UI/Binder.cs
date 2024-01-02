using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public static class Binder
    {       
        private static readonly Dictionary<Type, Dictionary<string, Object>> Objects = new();

        public static void Binding<T>(GameObject parentObject) where T : Object
        {
            T[] components = parentObject.GetComponentsInChildren<T>(true);
            Dictionary<string, Object> objectDict = components.ToDictionary(comp => comp.name, comp => comp as Object);
            Objects[typeof(T)] = AssignmentComponent<T>(parentObject, objectDict);
        }

        private static Dictionary<string, Object> AssignmentComponent<T>(GameObject parentObject, Dictionary<string, Object> objectDict) where T : Object
        {
            foreach (var key in objectDict.Keys.ToList())
            {
                if (objectDict[key] != null) continue;
                Object component = FindComponent<T>(parentObject, key);
                if (component != null) objectDict[key] = component;
                else  Debug.Log($"Binding failed for Object : {key}");
            }
            return objectDict;
        }

        private static T FindComponent<T>(GameObject parentObject, string name) where T : Object
        {
            foreach (Transform child in parentObject.transform)
            {
                if (child.name == name) return child.GetComponent<T>();
            }
            return null;
        }

        public static T Getter<T>(string componentName) where T : Object
        {
            if (!Objects.TryGetValue(typeof(T), out var components)) return null;
            if (components.TryGetValue(componentName, out var component)) return component as T;
            return null;
        }
    }
}