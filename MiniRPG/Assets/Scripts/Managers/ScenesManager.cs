using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager
    {
       public string nextScenelabel { get; set; }
        public void LoadNextSceneObject()
        {
            AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(nextScenelabel);
            sceneLoadOperation.allowSceneActivation = true;
        }
    }
}