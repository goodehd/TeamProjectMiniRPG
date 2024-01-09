using UI.Scene;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scene
{
    public class IntroScene : BaseScene
    {

        
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;

            Object eventSystem = FindObjectOfType<EventSystem>();
            
            Main.Resource.AllLoadResource<Object>("Intro", (key, loadCount, totalCount) =>
            {
                if (loadCount == totalCount)
                {
                    if (eventSystem == null) Main.Resource.InstantiatePrefab("EventSystem");

                    UI.SetSceneUI<Intro_UI>();
  

                }
            });
   

            return true;
        }
    }
}