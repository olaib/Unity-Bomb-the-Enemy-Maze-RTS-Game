using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * This script is used to control the Tic-Tac-Toe game.
 * AI opponent is implemented using the Minimax algorithm.
 * This game is a 3x3 board, with one player against AI (computer).
 */
public class TicTacController : MonoBehaviour
{
    // Constants members
    const int OPPONENT_SCORE = -10;
    const int DRAW_SCORE = 0;
    const int MY_SCORE = 10;
    const char EMPTY_CELL = ' ';
    const char AI_SYMPOL = 'O';
    const char PLAYER_SYMPOL = 'X';
    const string YOUR_TURN_TEXT = "Your Turn";
    const string AI_TURN_TEXT = "AI Turn";
    const string WIN_MESSAGE = " Win!";
    const string DRAW_MESSAGE = "Draw!";

    // UI elements
    public GameObject startPanel;
    public GameObject gamePanel;
    public TextMeshProUGUI turnText;
    public Button[] buttons;
    private TextMeshProUGUI[] buttonTexts;
    public TextMeshProUGUI gameOverText;

    private char[] board;
    private bool isPlayerTurn;
    private bool isGameOver;

    /**
     * Restart the game.
     */
    public void Restart()
    {
        InitializeGame();
    }

    /**
     * Set the turn text and isPlayerTurn.
     * @param isPlayerTurn - True if it's the player's turn, false otherwise.
     */
    void SetTurn(bool isPlayerTurn)
    {
        this.isPlayerTurn = isPlayerTurn;
        turnText.text = isPlayerTurn ? YOUR_TURN_TEXT : AI_TURN_TEXT;
    }

    /**
     * Initialize the game:
     * 1. Set up the game board (empty cells).
     * 2. Reset UI.
     * 3. Reset values.
     */
    private void InitializeGame()
    {
        // Set up the game board
        board = new char[9];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = EMPTY_CELL;
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
        // Initialize the text of the buttons (for X and O)
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonTexts[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTexts[i].text = EMPTY_CELL.ToString();
        }
    }

    /**
     * Handle button click event.
     * @param buttonIndex - The index of the clicked button (cell index).
     *                     For example, the buttons of the board (3x3):
     *                     0 1 2
     *                     3 4 5
     *                     6 7 8
     */
    public void OnButtonClick(int buttonIndex)
    {
        if (isGameOver)
            return;

        // Player's turn
        if (isPlayerTurn)
        {
            // Check if the cell is empty
            if (board[buttonIndex] == EMPTY_CELL)
            {
                board[buttonIndex] = PLAYER_SYMPOL;
                buttonTexts[buttonIndex].text = PLAYER_SYMPOL.ToString();
                SetTurn(false);
                CheckGameStatus();
                if (!isGameOver)
                    StartCoroutine(AITurnCoroutine());
            }
        }
    }

    /**
     * AI turn coroutine - wait 1 second before making a move.
     * Then call the Minimax algorithm to determine the best move.
     * @return IEnumerator - The coroutine (Yield).
     */
   private IEnumerator AITurnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        int bestMoveIndex = GetBestMove();
        board[bestMoveIndex] = AI_SYMPOL;
        buttonTexts[bestMoveIndex].text = AI_SYMPOL.ToString();
        SetTurn(true);
        CheckGameStatus();
    }


    /**
     * Get the best move for AI using the Minimax algorithm.
     * This method traverses all the board and checks the best move for AI.
     * @return int - The index of the best move.
     */
    private int GetBestMove()
    {
        int bestScore = int.MinValue;
        int bestMoveIndex = -1;

        for (int i = 0; i < board.Length; i++)
        {
            // Check if the cell is empty
            if (board[i] == EMPTY_CELL)
            {
                board[i] = AI_SYMPOL;
                int score = Minimax(board, 0, false);
                board[i] = EMPTY_CELL;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMoveIndex = i;
                }
            }
        }

        return bestMoveIndex;
    }

    /**
     * Minimax algorithm - using recursion with a depth-first search (DFS).
     * @param currentBoard - The current board.
     * @param depth - The depth of the current move.
     * @param isMaximizingPlayer - True if the current player is the maximizing player, false otherwise.
     * @return int - The score of the current board.
     */
    private int Minimax(char[] currentBoard, int depth, bool isMaximizingPlayer)
    {
        int score = EvaluateBoard(currentBoard);

        // Terminal states
        if (score == MY_SCORE || score == OPPONENT_SCORE || IsBoardFull(currentBoard))
            return score;

        int bestScore = isMaximizingPlayer ? int.MinValue : int.MaxValue;
        char currentPlayerSymbol = isMaximizingPlayer ? AI_SYMPOL : PLAYER_SYMPOL;

        for (int i = 0; i < currentBoard.Length; i++)
        {
            // Check if the cell is empty
            if (currentBoard[i] == EMPTY_CELL)
            {
                currentBoard[i] = currentPlayerSymbol;
                int currentScore = Minimax(currentBoard, depth + 1, !isMaximizingPlayer);
                currentBoard[i] = EMPTY_CELL;

                if (isMaximizingPlayer)
                    bestScore = Mathf.Max(bestScore, currentScore);
                else
                    bestScore = Mathf.Min(bestScore, currentScore);
            }
        }

        return bestScore;
    }

    /**
     * Evaluate the board and return the score.
     * @param currentBoard - The current board.
     * @return int - The score of the current board.
     */
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

    /**
     * Check if there is a winning line in the specified direction on the current board.
     * @param currentBoard - The current board state.
     * @param start - The start index of the line.
     * @param step - The step size between cells in the line.
     * @return bool - True if there is a winning line, false otherwise.
     */
    bool CheckLine(char[] currentBoard, int start, int step)
    {
        char firstCell = currentBoard[start];
        return firstCell != EMPTY_CELL && firstCell == currentBoard[start + step] && firstCell == currentBoard[start + 2 * step];
    }

    /**
     * Check rows for a winner on the current board.
     * @param currentBoard - The current board state.
     * @return bool - True if there is a winner in any row, false otherwise.
     */
    bool CheckRows(char[] currentBoard)
    {
        for (int i = 0; i < 9; i += 3)
        {
            if (CheckLine(currentBoard, i, 1))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * Check columns for a winner on the current board.
     * @param currentBoard - The current board state.
     * @return bool - True if there is a winner in any column, false otherwise.
     */
    bool CheckColumns(char[] currentBoard)
    {
        for (int i = 0; i < 3; i++)
        {
            if (CheckLine(currentBoard, i, 3))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * Check diagonals for a winner on the current board.
     * @param currentBoard - The current board state.
     * @return bool - True if there is a winner in any diagonal, false otherwise.
     */
    bool CheckDiagonals(char[] currentBoard)
    {
        return CheckLine(currentBoard, 0, 4) || CheckLine(currentBoard, 2, 2);
    }

    /**
     * Check if the board is full.
     * @param currentBoard - The current board.
     * @return bool - True if the board is full, false otherwise.
     */
    private bool IsBoardFull(char[] currentBoard)
    {
        for (int i = 0; i < currentBoard.Length; i++)
        {
            if (currentBoard[i] == EMPTY_CELL)
            {
                return false;
            }
        }

        return true;
    }

    /**
     * Check the game status and determine if the game is over.
     * If the game is over, display the winner or a draw message.
     */
    private void CheckGameStatus()
    {
        int score = EvaluateBoard(board);
        // Check if the player won
        if (score == MY_SCORE)
        {
            GameOver(AI_SYMPOL + " you" + WIN_MESSAGE);
        }
        // Check if the AI won
        else if (score == OPPONENT_SCORE)
        {
            GameOver(PLAYER_SYMPOL + " AI" + WIN_MESSAGE);
        }
        // Check if it's a draw - no one won
        else if (IsBoardFull(board))
        {
            GameOver(DRAW_MESSAGE);
        }
    }

    /**
     * Display the game over message and disable the buttons.
     * @param message - The game over message.
     */
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

    /**
     * Start the game and initialize the board.
     */
    public void GetStarted()
    {
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
        InitializeGame();
    }

    /**
     * Load the menu scene.
     */
    public void ReturnToMenu()
    {
        GameManager.Instance().LoadScene("MenuScene");
    }
}
