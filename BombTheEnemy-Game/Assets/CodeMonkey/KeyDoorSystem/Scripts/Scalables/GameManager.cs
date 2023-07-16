using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* mini game scene enum list
*/
public enum MiniGameScene
{
    BullsCowsGame,
    MainGame,
    Level2,
    GamOver,
    LevelUp,
    None
}
/**
* Game manager class - singleton.
* Manages the game state and scene loading.
*/
public class GameManager : MonoBehaviour
{
    // ================================ MEMBERS =================================== //
    private static GameManager instance;
    private bool isPaused = false;
    private bool isGameFinished = false;
    private Camera gameCamera;
    // hashmap of scenece name of mini games
    private Dictionary<MiniGameScene, string> sceneList = new Dictionary<MiniGameScene, string>()
    {
        { MiniGameScene.BullsCowsGame, "BullsAndCowsGame" },
        { MiniGameScene.MainGame, "Level-01" },
        { MiniGameScene.Level2, "Level-02" },
        { MiniGameScene.GamOver, "GameOverScene" },
        { MiniGameScene.LevelUp, "LevelUpScene" },
        { MiniGameScene.None, ""}
    };

    /**
    * Get the instance of the game manager
    * @return the instance of the game manager
    */
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
    /**
    * Awake method - called before start
    */
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
    /**
    * Pause the game - set the time scale to 0
    */
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    /**
    * Resume the game - set the time scale to 1
    */

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    /**
    * play mini game - load the mini game scene
    * @param miniGame - the mini game scene to load
    */
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
    /**
    * Load scene async - load the scene async
    * @param sceneName - the scene name to load
    */
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    /**
    * Load scene - load the scene
    * @param sceneName - the scene name to load
    */
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    /**
    * Resume main game - resume the main game
    */
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
    /**
    * Update method - called once per frame
    */
    private void Update()
    {
        if (isGameFinished && gameCamera.gameObject.activeSelf)
        {
            // Disable the game camera
            gameCamera.gameObject.SetActive(false);
        }
    }
    /**
    * load the game over scene
    */
    public void GameOver()
    {
        SceneManager.LoadScene(sceneList[MiniGameScene.GamOver]);
    }
    /**
    * load the level up scene
    */
    public void LevelCompleted()
    {
        SceneManager.LoadScene(sceneList[MiniGameScene.LevelUp], LoadSceneMode.Single);
    }
    /**
    * load the main game scene
    */
    public void ReloadLevel()
    {
        LoadScene(sceneList[MiniGameScene.Level2]);
    }
} 