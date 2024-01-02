using Managers;
using UnityEngine;
using static UI.Binder;
using Object = UnityEngine.Object;

namespace UI
{
    public class BaseUI : MonoBehaviour
    {
        protected UIManager UI;
        protected ResourceManager Resource;
        protected SoundManager Sound;
        private bool _initialized;
        private void Start() => Initialized();

        protected virtual bool Initialized()
        {
            if (_initialized) return false;
            _initialized = true;
            // UI = Main.UI;
            // Resource = Main.Resource;
            // Sound = Main.Sound;
            return _initialized;
        }

        protected void SetUI<T>() where T : Object => Binding<T>(gameObject);
        protected T GetUI<T>(string componentName) where T : Object => Getter<T>(componentName);
    }
}