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

            Main.Resource.AllLoadResource<Object>("Preload", (key, count, totalCount) =>
            {
                if (count < totalCount) return;
                Initialized();
            });

        }


        protected virtual bool Initialized()
        {
            if (_initialize) return false;
            _initialize = true;

            UI = Main.UI;
            return _initialize;
        }
    }
}