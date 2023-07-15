using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/**
    This script is used to control the Tic-Tac-Toe game.
    AI opponent is implemented using the Minimax algorithm:
    The Minimax algorithm is an advanced decision-making algorithm used by the AI opponent in Tic-Tac-Toe. 
    It explores all possible moves and their potential outcomes to determine the optimal move. 
    By assigning scores to each possible game state, Minimax ensures that the AI makes the best move
    to maximize its chances of winning or minimize the player's chances.
    this game is 3x3 board ,one player against AI(computer)
*/
public class TicTacController : MonoBehaviour
{
    [Header("UI")]
    public GameObject startPanel;
    public GameObject gamePanel;
    public TextMeshProUGUI turnText;

    [Header("Gameplay")]

    public Button[] buttons;
    private TextMeshProUGUI[] buttonTexts;
    public TextMeshProUGUI gameOverText;

    private char[] board;
    private bool isPlayerTurn;
    private bool isGameOver;


    public void Restart(){
        InitializeGame();
    }

    void SetTurn(bool isPlayerTurn)
    {
        this.isPlayerTurn = isPlayerTurn;
        turnText.text = isPlayerTurn ? "Your Turn" : "AI's Turn";
    }

    private void InitializeGame()
    {
        // Set up the game board
        board = new char[9];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = ' ';
        }

        // Reset UI
        gameOverText.gameObject.SetActive(false);
        SetTurn(true);
        isGameOver = false;
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        buttonTexts = new TextMeshProUGUI[buttons.Length];
        // Initialize the text of the buttons (for x and o)
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonTexts[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTexts[i].text = "";
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        if (isGameOver)
            return;

        // Player's turn
        if (isPlayerTurn)
        {
            // Check if the cell is empty
            if (board[buttonIndex] == ' ')
            {
                board[buttonIndex] = 'X';
                buttonTexts[buttonIndex].text = "X";
                SetTurn(false);
                CheckGameStatus();
                if (!isGameOver)
                    StartCoroutine(AITurnCoroutine());
            }
        }
    }

    private IEnumerator AITurnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        int bestMoveIndex = GetBestMove();
        board[bestMoveIndex] = 'O';
        buttonTexts[bestMoveIndex].text = "O";
        SetTurn(true);
        CheckGameStatus();
    }

    private int GetBestMove()
    {
        int bestScore = int.MinValue;
        int bestMoveIndex = -1;

        for (int i = 0; i < board.Length; i++)
        {
            // Check if the cell is empty
            if (board[i] == ' ')
            {
                board[i] = 'O';
                int score = Minimax(board, 0, false);
                board[i] = ' ';

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMoveIndex = i;
                }
            }
        }

        return bestMoveIndex;
    }

    private int Minimax(char[] currentBoard, int depth, bool isMaximizingPlayer)
    {
        int score = EvaluateBoard(currentBoard);

        // Terminal states
        if (score == 10 || score == -10 || IsBoardFull(currentBoard))
            return score;

        if (isMaximizingPlayer)
        {
            int bestScore = int.MinValue;

            for (int i = 0; i < currentBoard.Length; i++)
            {
                // Check if the cell is empty
                if (currentBoard[i] == ' ')
                {
                    currentBoard[i] = 'O';
                    int currentScore = Minimax(currentBoard, depth + 1, false);
                    currentBoard[i] = ' ';
                    bestScore = Mathf.Max(bestScore, currentScore);
                }
            }

            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;

            for (int i = 0; i < currentBoard.Length; i++)
            {
                // Check if the cell is empty
                if (currentBoard[i] == ' ')
                {
                    currentBoard[i] = 'X';
                    int currentScore = Minimax(currentBoard, depth + 1, true);
                    currentBoard[i] = ' ';
                    bestScore = Mathf.Min(bestScore, currentScore);
                }
            }

            return bestScore;
        }
    }

    private int EvaluateBoard(char[] currentBoard)
    {
        // Check rows
        for (int i = 0; i < 9; i += 3)
        {
            if (currentBoard[i] != ' ' && currentBoard[i] == currentBoard[i + 1] && currentBoard[i + 1] == currentBoard[i + 2])
            {
                return (currentBoard[i] == 'X') ? -10 : 10;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (currentBoard[i] != ' ' && currentBoard[i] == currentBoard[i + 3] && currentBoard[i + 3] == currentBoard[i + 6])
            {
                return (currentBoard[i] == 'X') ? -10 : 10;
            }
        }

        // Check diagonals
        if (currentBoard[0] != ' ' && currentBoard[0] == currentBoard[4] && currentBoard[4] == currentBoard[8])
        {
            return (currentBoard[0] == 'X') ? -10 : 10;
        }

        if (currentBoard[2] != ' ' && currentBoard[2] == currentBoard[4] && currentBoard[4] == currentBoard[6])
        {
            return (currentBoard[2] == 'X') ? -10 : 10;
        }

        return 0; // No winner
    }

    private bool IsBoardFull(char[] currentBoard)
    {
        for (int i = 0; i < currentBoard.Length; i++)
        {
            if (currentBoard[i] == ' ')
            {
                return false;
            }
        }

        return true;
    }

    private void CheckGameStatus()
    {
        int score = EvaluateBoard(board);
        if (score == 10)
        {
            GameOver("O wins!");
        }
        else if (score == -10)
        {
            GameOver("X wins!");
        }
        else if (IsBoardFull(board))
        {
            GameOver("Draw!");
        }
    }

    private void GameOver(string message)
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = message;
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
    public void GetStarted()
    {
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
        InitializeGame();
    }
    public void ReturnToMenu()
    {
        GameManager.Instance().LoadScene("MenuScene");
    }
}

