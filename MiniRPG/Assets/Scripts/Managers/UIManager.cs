using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager
    {
        private GameObject UIBase
        {
            get
            {
                GameObject uiBase = GameObject.Find("@UI_Base");
                if (uiBase == null)
                {
                    uiBase = new GameObject { name = "@UI_Base" };
                }
                return uiBase;
            }
        }

        
        public T SetSceneUI<T>() where T : BaseUI
        {
            string sceneUIName = typeof(T).Name;
            Debug.Log(sceneUIName);
            return SetUI<T>(sceneUIName, UIBase.transform);
        }

        private T SetUI<T>(string uiName, Transform parent = null) where T : Component
        {
            GameObject uiObject = Main.Resource.InstantiatePrefab(uiName, parent);
            T ui = Utility.GetAddComponent<T>(uiObject);
            return ui;
        }

        
    }
}