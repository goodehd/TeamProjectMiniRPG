using Managers;
using UnityEngine;

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
            UI = Main.UI;
            return _initialize;
        }
    }
}