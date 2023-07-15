using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameScript : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    // Start is called before the first frame update
    public void Start()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        // updateVolume();
    }

    // ================================== UPDATE ========================================\\
	public void UpdateVolume (){
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
    public void StartGame()
    {
        
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void displayMenu()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
    }
    public void updateVolume()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
