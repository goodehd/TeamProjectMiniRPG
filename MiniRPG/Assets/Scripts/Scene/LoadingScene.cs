using UI.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class LoadingScene : BaseScene
    {

        protected override bool Initialized()///
        {
            if (!base.Initialized()) 
            {
                Debug.Log("if");
                return false;
            }
            else
            {
                Debug.Log("else");
                UI.SetSceneUI<Loading_UI>();
                LoadResourcesForNextScene(Main.Scenes.NextScene);
            }
            return true;
        }
       
        private void LoadResourcesForNextScene(string nextSceneLabel)
        {
            Main.Resource.UnloadAllAsync<Object>(Main.Scenes.CurrentScene);
            Main.Resource.AllLoadResource<Object>(Main.Scenes.NextScene, (key, currentCount, totalCount) =>
            {
                //Debug.Log($"Loading....{key}");
                if (currentCount >= totalCount)
                    Main.Scenes.LoadNextSceneObject(); ;
            });
        }
    }
}
