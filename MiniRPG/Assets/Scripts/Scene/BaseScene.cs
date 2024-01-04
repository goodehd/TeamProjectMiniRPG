using Managers;
using UI.Scene;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Scene
{
    public class BaseScene : MonoBehaviour
    {
        private bool _initialize;
        protected UIManager UI;
        private void Start()
        {
            Initialized();
        }

        protected virtual bool Initialized()
        {
            if (_initialize) return false;
            _initialize = true;

            Object eventSystem = FindObjectOfType<EventSystem>();
            Main.Resource.AllLoadResource<Object>("Preload", (key, loadCount, totalCount) => {
                if (loadCount == totalCount)
                {
                    if (eventSystem == null) Main.Resource.InstantiatePrefab("EventSystem");
                }
            });
            UI = Main.UI;
            return _initialize;
        }
    }

    /*
     private void Awake()
        {
            if (Main.Resource.LoadBase) Initialized();
            else
            {
                Main.Resource.AllLoadAsync<Object>("Preload", (key, count, totalCount) =>
                {
                    Debug.Log($"[BaseScene] Load asset {key} ({count}/{totalCount})");
                    if (count < totalCount) return;
                    Main.Resource.LoadBase = true;
                    Initialized();
                });
            }
        }*/
}