using UI.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class LoadingScene : BaseScene
    {

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            UI.SetSceneUI<Loading_UI>();
            LoadResourcesForNextScene(Main.NextScene);
            return true;
        }
       
        private void LoadResourcesForNextScene(string nextSceneLabel)
        {
            Main.Resource.UnloadAllAsync<Object>(Main.CurrentScene);
            Main.Resource.AllLoadResource<Object>(Main.NextScene, (key, currentCount, totalCount) =>
            {
                Debug.Log($"Loading....{key}");
                if (currentCount < totalCount) return;
                Main.Scenes.LoadNextSceneObject();
            });

        }
    }
}