using Gfi.Hiring.Piece.Enums;
using Gfi.Hiring.Utils.BoardLegelPositionChecker;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gfi.Hiring.Utils
{
    public class PieceValidMoveCalculator : IPieceValidMoveCalculator
    {
        private readonly IBoardLegalPositionChecker boardLegalPositionChecker;
        private readonly Dictionary<PieceType, Func<BasePiece, GridSquare[,], HashSet<Point>>> pieceTypeToCalculatorFunction;

        public PieceValidMoveCalculator(IBoardLegalPositionChecker boardLegalPositionChecker)
        {
            this.boardLegalPositionChecker = boardLegalPositionChecker;
            pieceTypeToCalculatorFunction = new Dictionary<PieceType, Func<BasePiece, GridSquare[,], HashSet<Point>>>
            {
                { PieceType.Pawn, CalculatePawnValidPositions}
            };
        }

        public void CalculateAndSetValidPositions(BasePiece piece, GridSquare[,] currentBoardState)
        {
            Func<BasePiece, GridSquare[,], HashSet<Point>> calculationFunction;
            if(pieceTypeToCalculatorFunction.TryGetValue(piece.PieceType, out calculationFunction))
            {
                HashSet<Point> validMovements = calculationFunction.Invoke(piece, currentBoardState);
                piece.ValidMovements = validMovements;
            }
        }

        private HashSet<Point> CalculatePawnValidPositions(BasePiece piece, GridSquare[,] currentBoardState)
        {
            var validMovements = new HashSet<Point>();
            var direction = (int)piece.PieceColor;
            var squareOneInFront = SquareInFront(piece.Coordinate, direction);

            if (IsSquareValidAndEmpty(squareOneInFront, currentBoardState))
            {
                validMovements.Add(squareOneInFront);
                var squareTwoInFront = SquareInFront(squareOneInFront, direction);
                if(!piece.HasMoved && IsSquareValidAndEmpty(squareTwoInFront, currentBoardState))
                {
                    validMovements.Add(squareTwoInFront);
                }
            }
            return validMovements;
        }

        private Point SquareInFront(Point currentPosition, int direction)
        {
            var squareInFront = new Point(currentPosition.X + direction, currentPosition.Y);
            return squareInFront;
        }

        private bool IsSquareValidAndEmpty(Point coordinate, GridSquare[,] currentBoardState)
        {
            if (boardLegalPositionChecker.IsLegalBoardPosition(coordinate))
            {
                if (!currentBoardState[coordinate.X, coordinate.Y].ContainsPiece())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
