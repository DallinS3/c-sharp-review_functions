﻿using System;
using System.Collections.Generic;

// Tic Tac Toe
// Dallin Scott

namespace review_functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"
This is the game Tic-Tac-Toe!
        created by: Dallin Scott
        ");

            // Console.WriteLine();
            
            List<string> board = GetNewBoard();
            string currentPlayer = "O";

            {
                while (!GameOver(board, currentPlayer))
                {
                    currentPlayer = NextPlayer(currentPlayer);

                    DrawBoard(board);

                    int choice = MoveChoice(board, currentPlayer);
                    board[choice - 1] = currentPlayer;
                }
            }
        }

        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();
            for (int i = 1; i < 10; i++)
            {
                board.Add(Convert.ToString(i));
                // if 
            }
            return board;
        }

        static void DrawBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("==|===|==");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("==|===|==");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}\n");
        }

        static bool GameOver(List<string> board, string currentPlayer)
        {
            string message = TheWinner(board, currentPlayer);
            if (message == $"{currentPlayer} has won!!" || message == "This is a Cat Game! Nice game") 
            {
                DrawBoard(board);
                Console.WriteLine(message);
                return true;
            }
            return false;
        }
        
        static string NextPlayer(string currentPlayer)
        {
            string nextPlayer = "X";

            if (currentPlayer == "X")
            {
                nextPlayer = "O";
            }

            return nextPlayer;
        }

        static int MoveChoice(List<string> board, string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            int change_string = Convert.ToInt32(Console.ReadLine() ?? "5");

            bool availableSpace = notFilled(board, change_string);
            if (!availableSpace)
            {
                Console.WriteLine("Oops! This is not an available space. Try again");
                return MoveChoice(board, currentPlayer);
            }
            else
            {
                return Convert.ToInt32(change_string);
            }
        }

        static string TheWinner(List<string> board, string currentPlayer)
        {
            string CatGameMessage = "This is a Cat Game! Nice game";
            string WinGameMessage = $"{currentPlayer} has won!!";
            string msg = "";
            for (int i = 1; i < 4; i++)
            {
                int c = 0;
                for (int j = i; j < 10; j += 3)
                {
                    if ((board[j - 1]) != currentPlayer)
                    {
                        break;
                    }
                    else
                    {
                        c++;
                    }
                }
                if (c == 3)
                {
                    return WinGameMessage;
                }
            }

            for (int i = 1; i < 10; i += 3)
            {
                int c = 0;
                for (int j = i; j < (i + 3); j++)
                {
                    if ((board[j - 1]) != currentPlayer)
                    {
                        break;
                    }
                    else {
                        c++;
                    }
                }
                if (c == 3)
                {
                    return WinGameMessage;
                }
            }

            if ((board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]))
            {
                return WinGameMessage;
            }
            // cat game checker
            for (int i = 1; i < 10; i++)
            {
                if (!(board[i-1] == "X" || board[i-1] == "O"))
                {
                    break;
                }
                
                if (i == 9) 
                {
                    return CatGameMessage;
                }
            }
            
            return msg;
        }

        static bool notFilled(List<string> board, int user_input)
        {
            bool openSpace = true;
            // specify that the space the user is selecting is not taken
            // Console.WriteLine(board[user_input - 1]);
            if (board[user_input - 1] == "X")
            {
                openSpace = false;
            }
            else if (board[user_input - 1] == "O")
            {
                openSpace = false;
            }
            return openSpace;
        }
    }
}