using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* Mini Games Manager - for mini games
*/
public class MiniGamesManager : MonoBehaviour
{
    // ============================== Variables ==============================
    public string ticTacToeSceneName;
    // ============================== Methods ==============================
    public void LoadTicTacToe()
    {
        GameManager.Instance().LoadScene(ticTacToeSceneName);
    }

    public void LoadSnake()
    {
        // GameManager.Instance.LoadMiniGame("Snake");
    }

    public void LoadBombIt()
    {
        // GameManager.Instance.LoadMiniGame("BombIt");
    }
}
