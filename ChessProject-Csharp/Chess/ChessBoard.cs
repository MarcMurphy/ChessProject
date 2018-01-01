using System;
using System.Drawing;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private GridSquare[,] board;

        public static void Main()
        {

        }

        public ChessBoard ()
        {
            board = new GridSquare[MaxBoardWidth, MaxBoardHeight];
            for(int x = 0; x < MaxBoardWidth; x++)
            {
                for(int y = 0; y < MaxBoardHeight; y++)
                {
                    board[x, y] = new GridSquare(new Point(x, y));
                }
            }
        }

        public void Add(BasePiece piece, GridSquare coordinate, PieceColor pieceColor)
        {
            board[coordinate.Coordinate.X, coordinate.Coordinate.Y].SetPiece(piece);
        }

        public bool IsLegalBoardPosition(Point coordinate)
        {
            if( (coordinate == null) ||
                (coordinate.X < 0 || coordinate.X > MaxBoardWidth) ||
                (coordinate.Y < 0 || coordinate.Y > MaxBoardHeight))
            {
                return false;
            }
            return true;
        }

    }
}