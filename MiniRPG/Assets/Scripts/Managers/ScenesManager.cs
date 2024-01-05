using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager
    {
        private static string nextSceneLabel;
        public  string NextScene { get; set; }
        public  string CurrentScene { get; set; }
        public  void LoadLoadingScene()
        {
            nextSceneLabel = NextScene;
            Debug.Log("load loading scene");
           SceneManager. LoadScene("LoadingScene"); //로딩씬 출력 

        }
        public void LoadNextSceneObject()
        {
            Debug.Log("load next scene object");
            AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync($"{nextSceneLabel}Scene");
            sceneLoadOperation.allowSceneActivation = true;
        }
    }
}