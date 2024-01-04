using UI.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class LoadingScene : BaseScene
    {

        public string nextSceneLabel { get; set; }
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            LoadResourcesForNextScene(nextSceneLabel);
            return true;
        }
       
        private void LoadResourcesForNextScene(string nextSceneLabel)
        {
            Main.Resource.AllLoadResource<Object>(nextSceneLabel, (key, currentCount, totalCount) =>
            {
                Debug.Log("Loading....");
                if (currentCount < totalCount) return;
                Main.Scenes.LoadNextSceneObject();
            });

        }
    }
}
