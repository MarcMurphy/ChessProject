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
        }

        public void Add(Pawn pawn, Point coordinate, PieceColor pieceColor)
        {
            throw new NotImplementedException("Need to implement ChessBoard.Add()");
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