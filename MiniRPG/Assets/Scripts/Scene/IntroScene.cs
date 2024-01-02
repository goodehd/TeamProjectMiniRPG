using UI.Scene;
using UnityEngine;

namespace Scene
{
    public class IntroScene : BaseScene
    {
        [SerializeField] private GameObject introUI_Prefab;
        
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            UI.SetSceneUI<Intro_UI>(introUI_Prefab);
            return true;
        }
    }
}