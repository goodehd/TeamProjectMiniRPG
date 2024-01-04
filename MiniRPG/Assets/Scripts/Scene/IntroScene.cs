using UI.Scene;
using UnityEngine;

namespace Scene
{
    public class IntroScene : BaseScene
    {
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            UI.SetSceneUI<Intro_UI>();
            return true;
        }
    }
}