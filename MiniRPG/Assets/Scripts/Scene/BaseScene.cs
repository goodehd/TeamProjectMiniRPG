using Managers;
using UnityEngine;
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
            
            // public void AllLoadResource<T>(string label, Action<string,int,int> callback) where T : Object
            UI = Main.UI;
            return _initialize;
        }
    }
}