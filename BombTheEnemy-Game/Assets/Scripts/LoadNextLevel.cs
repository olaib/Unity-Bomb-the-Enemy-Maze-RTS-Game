using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public class LoadNextLevel : MonoBehaviour
{
    // [SerializeField] private GameObject animatiedObject;
    private bool pressed = false;
    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private GameObject loadNextLevelText;
     public void Update()
    {
        //enter key - next level
        if (pressed)
        {
            // loadNextLevelText.GetComponent<TextMeshProUGUI>().text = LevelController.PREFEX + LevelController.Instance.getCurrentLevel();
            // pause for 1 second
            // Thread.Sleep(1000);
            LevelController.Instance().NextLevel();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return) && !pressed)
        {
            pressed = true;
            // levelCompletedPanel.SetActive(false);
            // loadNextLevelText.SetActive(true);
        }
    }
}
