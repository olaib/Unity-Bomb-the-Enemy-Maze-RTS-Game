using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    [Tooltip("Drag the loading screen game object here")]
    public Image loadingBarFill;
    [Tooltip("Drag the loading bar fill image here")]
    private static Loader instance;
    public enum Scene {
        IntroScene,
        MenuScene,
        LoadingScene,
        GameScene,
    }

    public static Loader Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<Loader>();
            }
            return instance;
        }
    }

    public void LoadScene(Scene scene, MonoBehaviour sceneController) 
    {    
        sceneController.StartCoroutine(LoadSceneAsync(scene));
    }

    IEnumerator LoadSceneAsync(Scene scene) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Single);
        loadingScreen.SetActive(true);
        while(!asyncLoad.isDone) {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingBarFill.fillAmount = progress;
            yield return null;
        }
    }
}
