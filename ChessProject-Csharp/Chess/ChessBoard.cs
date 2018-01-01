using Gfi.Hiring.Properties;
using Gfi.Hiring.Utils;
using Gfi.Hiring.Utils.BoardLegelPositionChecker;
using System.Drawing;
using System.Windows.Controls;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;

        private GridSquare[,] board;
        private IBoardLegalPositionChecker boardPositionChecker;

        public static void Main()
        {

        }

        public ChessBoard ()
        {
            board = new GridSquare[MaxBoardWidth, MaxBoardHeight];
            boardPositionChecker = new BoardLegalPositionChecker(MaxBoardWidth, MaxBoardHeight);
            for(int x = 0; x < MaxBoardWidth; x++)
            {
                for(int y = 0; y < MaxBoardHeight; y++)
                {
                    board[x, y] = new GridSquare(new Point(x, y));
                }
            }
        }

        public bool IsLegalBoardPosition(Point coordinate)
        {
            return this.boardPositionChecker.IsLegalBoardPosition(coordinate);
        }

        /// <summary>
        /// Add a piece to the board at the specified coordinate
        /// <summary>
        /// <returns>
        /// ValidationResult containing if addition of piece was successful or not, and an error message if unsuccessful
        /// </returns>
        public ValidationResult Add(BasePiece piece, Point coordinate)
        {
            if (!boardPositionChecker.IsLegalBoardPosition(coordinate))
            {
                return new ValidationResult(false, Resources.GridSquareCoordinateIsNotValid);
            }
            GridSquare boardSquare = board[coordinate.X, coordinate.Y];
            if (boardSquare.ContainsPiece())
            {
                return new ValidationResult(false, Resources.GridSquareAlreadyContainsPiece);
            }
            boardSquare.SetPiece(piece);
            return new ValidationResult(true, string.Empty);
        }
        
        public void Move(Point currentPosition, Point destination)
        {
            if(boardPositionChecker.IsLegalBoardPosition(currentPosition) && boardPositionChecker.IsLegalBoardPosition(destination))
            {
                return;
            }
            //get piece
            //move piece through PieceValidMoveCalculator
            //verify destination is in piece.ValidMovementSquares
            //
        }

        public GridSquare[,] CurrentBoardState
        {
            get
            {
                return this.board;
            }
        }

    }
}