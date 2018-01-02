﻿using System;

namespace Gfi.Hiring
{
    public class Game
    {
        public static void Main()
        {
            ChessBoard chessBoard = new ChessBoard();
            for(int i =0; i < 8; i++)
            {
                chessBoard.Add(new Pawn(PieceColor.Black), new System.Drawing.Point(6, i));
                chessBoard.Add(new Pawn(PieceColor.White), new System.Drawing.Point(1, i));
            }
            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            
            while (true)
            {
                Console.Clear();
                chessBoard.Draw();
                string input = Console.ReadLine();
                if (input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
                chessBoard.HandleInput(input);
            }
        }
    }
}
