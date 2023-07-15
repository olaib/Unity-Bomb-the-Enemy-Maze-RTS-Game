using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum MiniGameScene
{
    BullsCowsGame,
    MainGame,
    GamOver,
    LevelUp,
    None
}
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isPaused = false;
    private bool isGameFinished = false;
    private Camera gameCamera;
    // hashmap of scenece name of mini games
    private Dictionary<MiniGameScene, string> sceneList = new Dictionary<MiniGameScene, string>()
    {
        { MiniGameScene.BullsCowsGame, "BullsAndCowsGame" },
        { MiniGameScene.MainGame, "Level-01" },
        { MiniGameScene.GamOver, "GameOverScene" },
        { MiniGameScene.LevelUp, "LevelUpScene" },
        { MiniGameScene.None, ""}
    };


    public static GameManager Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();

            if (instance == null)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<GameManager>();
                singleton.name = typeof(GameManager).ToString();
                DontDestroyOnLoad(singleton);
            }
        }

        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        gameCamera = Camera.main;
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PlayMiniGame(MiniGameScene miniGame)
    {
        isGameFinished = true;
        PauseGame();

        // Disable the main game camera
        gameCamera.gameObject.SetActive(false);

        // Load mini game scene
        StartCoroutine(LoadSceneAsync(sceneList[miniGame]));
        // Enable the mini game camera
        Camera miniGameCamera = GameObject.FindWithTag("Main Camera").GetComponent<Camera>();
        if (miniGameCamera != null)
        {
            Debug.Log("Mini game camera found");
            miniGameCamera.gameObject.SetActive(true);
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ResumeMainGame()
    {
        // Disable the mini game camera
        Camera miniGameCamera = GameObject.FindObjectOfType<Camera>();
        if (miniGameCamera != null)
        {
            miniGameCamera.gameObject.SetActive(false);
        }

        // Unload mini game scene and resume game
       StartCoroutine(LoadSceneAsync(sceneList[MiniGameScene.MainGame]));

        ResumeGame();

        // Enable the main game camera again
        gameCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isGameFinished && gameCamera.gameObject.activeSelf)
        {
            // Disable the game camera
            gameCamera.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(sceneList[MiniGameScene.GamOver]);
    }
    public void LevelCompleted()
    {
        SceneManager.LoadScene(sceneList[MiniGameScene.LevelUp], LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(sceneList[MiniGameScene.MainGame], LoadSceneMode.Single);
    }
}