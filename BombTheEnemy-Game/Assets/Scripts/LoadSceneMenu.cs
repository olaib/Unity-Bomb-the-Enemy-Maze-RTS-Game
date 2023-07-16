using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneMenu : MonoBehaviour
{
    //public CanvasGroup canvasGroup;
    public float changeTime;
    public string sceneName;

    // Start is called before the first frame update
    private void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
