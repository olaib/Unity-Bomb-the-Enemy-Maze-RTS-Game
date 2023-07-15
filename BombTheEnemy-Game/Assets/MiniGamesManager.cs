using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{
    public string ticTacToeSceneName;
    // public string snakeSceneName;
    // public string bombItSceneName;
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
