using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    [Header("display")]
    public GameObject bombCutScene;
    [Tooltip("holding the bomb cut scene")]
    public GameObject introScene;
    [Tooltip("holding the the intro scene")]
    public float countDown = 13f;

    // Start is called before the first frame update
    void Start()
    {
        introScene.SetActive(false);
        Debug.Log("Start");
        bombCutScene.SetActive(true);
    }
    private void playIntro()
    {
        bombCutScene.SetActive(false);
        introScene.SetActive(true);
    }
    void Update()
    {
        Debug.Log("countDown: " + countDown);
        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            playIntro();
        }
    }
}
