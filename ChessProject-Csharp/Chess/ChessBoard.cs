using Gfi.Hiring.Properties;
using System.Drawing;
using System.Windows.Controls;

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

        /// <summary>
        /// Add a piece to the board at the specified coordinate
        /// <summary>
        /// <returns>
        /// ValidationResult containing if addition of piece was successful or not, and an error message if unsuccessful
        /// </returns>
        public ValidationResult Add(BasePiece piece, GridSquare gridSquare)
        {
            if (!this.IsLegalBoardPosition(gridSquare.Coordinate))
            {
                return new ValidationResult(false, Resources.GridSquareCoordinateIsNotValid);
            }
            GridSquare boardSquare = board[gridSquare.Coordinate.X, gridSquare.Coordinate.Y];
            if (boardSquare.ContainsPiece())
            {
                return new ValidationResult(false, Resources.GridSquareAlreadyContainsPiece);
            }
            boardSquare.SetPiece(piece);
            return new ValidationResult(true, string.Empty);
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