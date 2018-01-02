using System;

namespace Gfi.Hiring.Utils
{
    public class ChessBoardRenderer : IChessBoardRenderer
    {
        private readonly int MaxBoardWidth;
        private readonly int MaxBoardHeight;
        private char[] RowCharacters = { '1', '2', '3', '4', '5', '6', '7', '8' };
        private const string ColumnNotation = " a b c d e f g h";

        public ChessBoardRenderer(int MaxBoardWidth, int MaxBoardHeight)
        {
            this.MaxBoardWidth = MaxBoardWidth;
            this.MaxBoardHeight = MaxBoardHeight;
        }

        public void RenderBoard(GridSquare[,] board)
        {
            bool oddCell = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ColumnNotation);
            for (int x = 0; x < MaxBoardWidth; x++)
            {
                oddCell = !oddCell;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(RowCharacters[x]);
                for (int y = 0; y < MaxBoardHeight; y++)
                {
                    oddCell = !oddCell;
                    if (board[x, y].ContainsPiece())
                    {
                        var piece = board[x, y].Piece;
                        Console.ForegroundColor = piece.PieceColor == PieceColor.White ? ConsoleColor.White : ConsoleColor.Black;
                        Console.Write((char)(piece.PieceType) + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = oddCell ? ConsoleColor.White : ConsoleColor.Black;
                        Console.Write("██");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
