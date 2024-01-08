using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> Services = new();

    public static T GetService<T>() where T : class
    {
        Type serviceType = typeof(T);
        if (Services.TryGetValue(serviceType, out object service))
        {
            return (T)service;
        }
        return TryCreateService<T>(serviceType);
    }
    private static T TryCreateService<T>(Type serviceType) where T : class
    {
        T serviceInstance = Activator.CreateInstance<T>();
        Debug.Log($"Instantiate : {serviceInstance}");
        Services[serviceType] = serviceInstance;
        return serviceInstance;
    }
}