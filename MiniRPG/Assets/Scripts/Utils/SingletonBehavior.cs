
using UnityEngine;

public class SingletonBehavior<T> : SingletonBase where T : MonoBehaviour
{
    private static T _instance;



    #region Properties

    public static T Instance
    {
        get
        {
            if (_isDisabled)
            {
                Debug.LogError(("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning Null Instance"));
                return null;
            }

            lock (_Locked)
            {
                return GetInstance();
            }
        }
    }

    #endregion
    
    
    
    #region Properties Util Methods

    private static T GetInstance()
    {
        if (_instance != null) return _instance;
        
        _instance = (T)FindFirstObjectByType(typeof(T));

        if (_instance == null)
        {
            var singletonObject = new GameObject { name = "[Singleton] " + typeof(T) };
                
            _instance = singletonObject.AddComponent<T>();

            DontDestroyOnLoad(singletonObject);

            Debug.Log("[Singleton] An instance of '" + typeof(T) + "' created with DontDestroyOnLoad");
        }
        else
        {
            DontDestroyOnLoad(_instance);
                
            Debug.Log("[Singleton] Using instance already created. '" + typeof(T) + "' so Update DontDestroyOnLoad");
        }

        return _instance;
    }

    #endregion
    
    
    
    #region Destroy Singleton

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _isDisabled = true;
        }
    }

    #endregion
}
