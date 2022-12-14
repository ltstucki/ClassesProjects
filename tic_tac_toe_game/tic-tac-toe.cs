// Program: CSE 210 Tic Tac Toe Example
// Author: Brother Burton

using System;
using System.Collections.Generic;

/// <summary>
/// This is a sample solution of the Tic Tac Toe program. It is not a
/// particularly sophisticated or elegant solution to the problem, but
/// rather it highlights a straightforward way to solve the problem
/// for a 3x3 game.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        List<string> board = GetNewBoard();
        string currentPlayer = "x";

        while (!IsGameOver(board))
        {
            DisplayBoard(board);

            int choice = GetMoveChoice(currentPlayer);
            MakeMove(board, choice, currentPlayer);

            currentPlayer = GetNextPlayer(currentPlayer);
        }

        DisplayBoard(board);
        Console.WriteLine("Good game. Thanks for playing!");
    }

    /// <summary>
    /// Gets a new instance of the board with the numbers 1-9 in place.
    /// </summary>
    /// <returns>A list of 9 strings representing each square.</returns>
    static List<string> GetNewBoard()
    {
        List<string> board = new List<string>();

        for (int i = 1; i <= 9; i++)
        {
            board.Add(i.ToString());
        }

        return board;
    }

    /// <summary>
    /// Displays the board in a 3x3 grid.
    /// </summary>
    /// <param name="board">The board</param>
    static void DisplayBoard(List<string> board)
    {
        // This could be done more elegantly using loops and if statements
        // especially if something besides 3x3 was ever anticipated.
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
    }

    /// <summary>
    /// Determines if the game is over because of a win or a tie.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the game is over</returns>
    static bool IsGameOver(List<string> board)
    {
        bool isGameOver = false;

        if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
        {
            isGameOver = true;
        }

        return isGameOver;
    }

    /// <summary>
    /// Determines if the provided player has a tic tac toe.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="player">The player to check for a win</param>
    /// <returns></returns>
    static bool IsWinner(List<string> board, string player)
    {
        // There are more elegant ways to check for a win, especially if
        // something besides a 3x3 board were anticipated. This brute force
        // approach is sufficient to check for the possibilities.

        bool isWinner = false;

        if ((board[0] == player && board[1] == player && board[2] == player)
            || (board[3] == player && board[4] == player && board[5] == player)
            || (board[6] == player && board[7] == player && board[8] == player)
            || (board[0] == player && board[3] == player && board[6] == player)
            || (board[1] == player && board[4] == player && board[7] == player)
            || (board[2] == player && board[5] == player && board[8] == player)
            || (board[0] == player && board[4] == player && board[8] == player)
            || (board[2] == player && board[4] == player && board[6] == player)
            )
        {
            isWinner = true;
        }

        return isWinner; 
    }

    /// <summary>
    /// Determines if the board is full with no more moves possible.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the board is full.</returns>
    static bool IsTie(List<string> board)
    {
        // If there is a digit, there are still moves to be made.
        bool foundDigit = false;

        foreach (string value in board)
        {
            if (char.IsDigit(value[0]))
            {
                foundDigit = true;
                break;
            }
        }

        return !foundDigit;
    }

    /// <summary>
    /// Cycles through the players (from x to o and o to x)
    /// </summary>
    /// <param name="currentPlayer">The current players sign (x or o)</param>
    /// <returns>The next players sign (x or o)</returns>
    static string GetNextPlayer(string currentPlayer)
    {
        string nextPlayer = "x";

        if (currentPlayer == "x")
        {
            nextPlayer = "o";
        }

        return nextPlayer;
    }

    /// <summary>
    /// Gets the 1-based spot number associated with the user's choice.
    /// </summary>
    /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
    /// <returns>A 1-based spot number (not a 0-based index)</returns>
    static int GetMoveChoice(string currentPlayer)
    {
        Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
        string? move_string = Console.ReadLine();

        if (move_string is null) {
            return 0;
        }

        int choice = int.Parse(move_string);
        return choice;
    }

    /// <summary>
    /// Places the current players mark on the board at the desired spot.
    /// This method does NOT check to ensure the spot is available.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="choice">The 1-based spot number (not a 0-based index).</param>
    /// <param name="currentPlayer">The current player's sign (x or o)</param>
    static void MakeMove(List<string> board, int choice, string currentPlayer)
    {
        // Convert the 1-based spot number to a 0-based index.
        int index = choice - 1;

        // It would be good to include an additional check here to ensure that
        // the spot is available.
        board[index] = currentPlayer;
    }
}