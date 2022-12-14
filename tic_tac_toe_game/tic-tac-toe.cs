using System;
using System.Collections.Generic;
class Program
// Performed in class as group project.
// Commented and shown understanding by Landon Stucki.
{
    static void Main(string[] args)
    {
        // Checks for the current player.
        List<string> board = GetNewBoard();
        string currentPlayer = "x";

        // For as long as the game is NOT over, keep running until IsGameOver bool is True.
        while (!IsGameOver(board))
        // IF BOOL IS TRUE, END GAME AND DONT RUN ANYTHING IN THE LOOP.
        {
            // Display the board
            DisplayBoard(board);
            // Grabs the players choice of 1-9.
            int choice = GetMoveChoice(currentPlayer);
            // Checks the current player (x or o) and puts his choice (1-9) on the board.
            MakeMove(board, choice, currentPlayer);
            // Gives the next player in line (x or o) priority for next turn.
            currentPlayer = GetNextPlayer(currentPlayer);
        }

        // As soon as the game is over and the boolean is set to true, display the board and give gameover message.
        DisplayBoard(board);
        Console.WriteLine("Good game. Thanks for playing!");
    }

    static List<string> GetNewBoard()
    {
        List<string> board = new List<string>();
        // Creates a list of 9 numbers to be used on the 3x3 board.
        for (int i = 1; i <= 9; i++)
        {
            board.Add(i.ToString());
        }

        return board;
    }

    static void DisplayBoard(List<string> board)
    {
        // Displays the boards numbers in a nice 3x3 grid as so...
        // 1|2|3
        // -+-+-
        // 4|5|6
        // -+-+-
        // 7|8|9
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
    }
    static bool IsGameOver(List<string> board)
    {
        bool isGameOver = false;

        if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
        {
            // Checks if the game is over, if so, set bool to true.
            isGameOver = true;
        }

        return isGameOver;
    }
    static bool IsWinner(List<string> board, string player)
    {
        // Every possible way to win is displayed here in an if statement.
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
            // If one of these 3 indexes line up, set isWinner bool to true.
            isWinner = true;
        }

        return isWinner; 
    }
    static bool IsTie(List<string> board)
    {
        bool foundDigit = false;

        foreach (string value in board)
        {
            if (char.IsDigit(value[0]))
            // Checks if there are any more spaces on the board to make a move.
            // If there are not, it must be a tie.
            {
                foundDigit = true;
                break;
            }
        }

        return !foundDigit;
    }
    static string GetNextPlayer(string currentPlayer)
    {
        // Goes back and forth between X turn and O turn, starting with X.
        string nextPlayer = "x";

        if (currentPlayer == "x")
        {
            nextPlayer = "o";
        }

        return nextPlayer;
    }

    static int GetMoveChoice(string currentPlayer)
    {
        // Gets the players choice of placement on the board (1-9).
        Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
        string? move_string = Console.ReadLine();

        if (move_string is null) {
            return 0;
        }

        int choice = int.Parse(move_string);
        return choice;
    }

    static void MakeMove(List<string> board, int choice, string currentPlayer)
    // Grabs the players mark (x or o) and the spot chosen on the board (1-9)
    // Puts that mark in chosen spot.
    {
        int index = choice - 1;

        board[index] = currentPlayer;
    }
}