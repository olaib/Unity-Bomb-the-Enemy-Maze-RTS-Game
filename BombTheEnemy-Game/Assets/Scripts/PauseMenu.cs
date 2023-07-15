using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // ======================== Members ========================
    public bool isCursorLocked = true;
    [SerializeField]
    [Tooltip("The panel that will be activated when the game is paused")]
    public GameObject panelBehaviour;
    [SerializeField]
    [Tooltip("The panel that will be activated when the game is paused")]
    public GameObject settingsPanel;
    // ======================== Methods ========================
    public void Pause()
    {
        pauseResume(true);
    }

    public void Resume()
    {
        pauseResume(false);
    }
    private void pauseResume(bool isPanelActive)
    {
        panelBehaviour.SetActive(isPanelActive);

        settingsPanel.SetActive(settingsPanel.activeSelf && isPanelActive);
        Time.timeScale = isPanelActive ? 0 : 1;
        if(isCursorLocked)
        {   Cursor.lockState = isPanelActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isPanelActive;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseResume(!panelBehaviour.activeSelf);
        }
    }
    public void returnToMainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
    public void settings()
    {
        panels(false, true);
    }

    public void back()
    {
        panels(true, false);
    }

    public void panels(bool isPanelActive, bool isSettingsPanelActive)
    {
        panelBehaviour.SetActive(isPanelActive);
        settingsPanel.SetActive(isSettingsPanelActive);
    }
}
