using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

/**
    MAIN MENU SCRIPT
    This script is responsible for the main menu functionality
    It is attached to the Main Menu GameObject
    display settings menu, game panel, volume panel, minigames ...
    start game, exit game
*/
public class MenuScript : MonoBehaviour
{
    // ================================= SCENES =========================================
    private const string GAME_SCENE_NAME = "Level-01";
    private const string MINI_GAMES_SCENE_NAME = "MiniGames";
    // ================================= MENUS =========================================
    [Header("Menus")] 
    public GameObject mainMenu;
    [Tooltip("holding the Main Menu GameObject")]
    public GameObject miniGamesPanel;
    [Tooltip("holding the Mini Games Panel GameObject")]
    public GameObject settingsMenu;
    [Tooltip("holding the Settings Menu GameObject")]
    public GameObject gamePanel;
    [Tooltip("holding the Game Panel GameObject")]
    public GameObject volumePanel;
    [Tooltip("holding the Volume Panel GameObject")]
    public GameObject bombItPanel;
    [Tooltip("holding the Bomb It Panel GameObject")]
    public GameObject gameTwoPanel;
    [Tooltip("holding the Game #2 Panel GameObject")]

    // ================================= Audios ========================================
    [Header("SFX")]
    public AudioSource audioSource;
    public AudioSource hoverSound;
    [Tooltip("holding the Audio Source component for the HOVER SOUND")]
    public AudioSource swooshAudio;
    [Tooltip("holding the Audio Source component for the SWOOSH SOUND before displaying settings")]
    public AudioSource selectSound;
    [Tooltip("holding the Audio Source component for the SELECT BUTTON SOUND")]

    //========================================== FUNCTIONS =====================================
    public void displayMainMenu()
    {
        displayCanvas(true, false, false);
    } 
    private void displayCanvas(bool isMainMenu, bool isMiniGamesPanel, bool isSettingsMenu)
    {
        mainMenu.SetActive(isMainMenu);
        miniGamesPanel.SetActive(isMiniGamesPanel && !isMainMenu);
        settingsMenu.SetActive(isSettingsMenu);
    }
    public void displaySettings()
    {
        displayCanvas(false, false, true);
    } 
    void displayPanel(bool isGamePanel, bool isVolumePanel){
        gamePanel.SetActive(isGamePanel);
        volumePanel.SetActive(isVolumePanel);
    }
    void displayGamesPanels(bool isBombItPanel, bool isGameTwoPanel){
        bombItPanel.SetActive(isBombItPanel);
        gameTwoPanel.SetActive(isGameTwoPanel);
    }
    public void displayBombItPanel()
    {
        displayGamesPanels(true, false);
    }
    public void displayGameTwoPanel()
    {
        displayGamesPanels(false, true);
    }
    public void displayGamePanel()
    {
        displayPanel(true, false);
    }

    public void displayVolumePanel()
    {
        displayPanel(false,true);
    }
    public void startGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(GAME_SCENE_NAME, LoadSceneMode.Single);

    }

    public void exitGame()
    {
        #if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
    }

    void Start()
    {
        audioSource.Play();
        displayMainMenu();
    }

    // Play Click Sound
    public void PlayHover()
    {
		hoverSound.Play();
	}
    // Play Swoosh Sound before displaying settings menu
    public void PlaySwoosh()
    {
		swooshAudio.Play();
	}
    // Play Select Sound when select a button
    public void PlaySelect()
    {
        selectSound.Play();
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void displayMiniGamesPanel()
    {
        displayCanvas(false, true, false);
    }
}

