using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager
    {
        private static string nextSceneLabel; 
        public  void LoadLoadingScene()
        {
            nextSceneLabel = Main.NextScene;
           SceneManager. LoadScene("LoadingScene"); //로딩씬 출력 

        }
        public void LoadNextSceneObject()
        {
            AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(nextSceneLabel);
            sceneLoadOperation.allowSceneActivation = true;
        }
    }
}