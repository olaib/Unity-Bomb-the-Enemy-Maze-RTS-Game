using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum LevelType
{
    Level1 = 1,
    Level2,
    Level3,
    None
}
/***
* LevelController
* 
* This class is responsible for loading levels and keeping track of the current level.
*/
public class LevelController : MonoBehaviour
{
    public const string PREFEX = "Level-0";
    // ====================== PARAMETERS ======================
    private static LevelController instance;
    const int MAX_LEVEL = 3;
    LevelType currentLevel = LevelType.Level1;

    // ====================== METHODS ======================
    public static LevelController Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<LevelController>();

            if (instance == null)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<LevelController>();
                singleton.name = typeof(LevelController).ToString();
                DontDestroyOnLoad(singleton);
            }
        }

        return instance;
    }
    private LevelController()
    {
        currentLevel = LevelType.Level1;
    }

    public void NextLevel()
    {
        LoadLevel(currentLevel < LevelType.None ? ++currentLevel : currentLevel);
    }
    public int getCurrentLevel()
    {
        return (int)currentLevel;
    }

    public void LoadLevel(LevelType level)
    {
        int levelNum = (int)level;
        Debug.Log("LoadLevel: " + PREFEX + levelNum);
        SceneManager.LoadScene(PREFEX + levelNum);
    }
}
