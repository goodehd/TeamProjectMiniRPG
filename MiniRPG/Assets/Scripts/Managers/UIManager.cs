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

        public T SetSceneUI<T>(GameObject uiPrefab) where T : BaseUI
        {
            return SetUI<T>(uiPrefab, UIBase.transform);
        }

        private T SetUI<T>(GameObject uiPrefab, Transform parent = null) where T : Component
        {
            GameObject uiObject = Object.Instantiate(uiPrefab, UIBase.transform);
            T ui = Utility.GetAddComponent<T>(uiObject);
            return ui;
        }
    }
}