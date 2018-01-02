using Gfi.Hiring.Properties;
using Gfi.Hiring.Utils;
using Gfi.Hiring.Utils.BoardLegelPositionChecker;
using System;
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
        private IPieceValidMoveCalculator pieceValidMoveCalculator;
        private ChessBoardRenderer chessBoardRenderer;

        public ChessBoard ()
        {
            board = new GridSquare[MaxBoardWidth, MaxBoardHeight];
            boardPositionChecker = new BoardLegalPositionChecker(MaxBoardWidth, MaxBoardHeight);
            pieceValidMoveCalculator = new PieceValidMoveCalculator(boardPositionChecker);
            chessBoardRenderer = new ChessBoardRenderer(MaxBoardWidth, MaxBoardHeight);
            for (int x = 0; x < MaxBoardWidth; x++)
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
            if(!boardPositionChecker.IsLegalBoardPosition(currentPosition, destination))
            {
                return;
            }
            GridSquare currentSquare = board[currentPosition.X, currentPosition.Y];
            if (currentSquare.ContainsPiece())
            {
                BasePiece piece = currentSquare.Piece;
                pieceValidMoveCalculator.CalculateAndSetValidPositions(piece, board);
                if (piece.ValidMovements.Contains(destination))
                {
                    currentSquare.RemovePiece();
                    GridSquare destinationSquare = board[destination.X, destination.Y];
                    destinationSquare.SetPiece(piece);
                    piece.Move(destination);
                }
            }
            //get piece
            //move piece through PieceValidMoveCalculator
            //verify destination is in piece.ValidMovementSquares
            //
        }

        public void HandleInput(string input)
        {
            if (input.Length != 5)
            {
                Console.WriteLine("To move a piece, format input as 'a1 a4'");
                return;
            }

            char firstColumnRaw = input[0];
            char firstRowRaw = input[1];
            char secondColumnRaw = input[3];
            char secondRowRaw = input[4];

            int firstRow = ChessBoardCoordinateTranslator.TranslateRowDisplayToIndex(firstRowRaw);
            int firstColumn = ChessBoardCoordinateTranslator.TranslateColumnDisplayToIndex(firstColumnRaw);
            int secondRow = ChessBoardCoordinateTranslator.TranslateRowDisplayToIndex(secondRowRaw);
            int secondColumn = ChessBoardCoordinateTranslator.TranslateColumnDisplayToIndex(secondColumnRaw);
            this.Move(new Point(firstRow, firstColumn), new Point(secondRow, secondColumn));
        }

        public void Draw()
        {
            chessBoardRenderer.RenderBoard(board);
        }
        public GridSquare[,] CurrentBoardState
        {
            get
            {
                return this.board;
            }
        }

        public IBoardLegalPositionChecker BoardPositionChecker
        {
            get
            {
                return this.boardPositionChecker;   
            }
            set
            {
                //only making this public for unit testing
                this.boardPositionChecker = value;
            }
        }

    }
}