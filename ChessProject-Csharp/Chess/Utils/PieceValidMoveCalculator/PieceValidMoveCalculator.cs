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

        private HashSet<Point> KnightMovementPossibilities = new HashSet<Point>
        {
            new Point(2,1),
            new Point(2,-1),
            new Point(-2,1),
            new Point(-2,-1),
            new Point(1,2),
            new Point(1,-2),
            new Point(-1,2),
            new Point(-1,-2),
        };

        public PieceValidMoveCalculator(IBoardLegalPositionChecker boardLegalPositionChecker)
        {
            this.boardLegalPositionChecker = boardLegalPositionChecker;
            pieceTypeToCalculatorFunction = new Dictionary<PieceType, Func<BasePiece, GridSquare[,], HashSet<Point>>>
            {
                { PieceType.Pawn, CalculatePawnValidPositions},
                { PieceType.Knight, CalculateKnightValidPositions }

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
            var direction = new Point((int)piece.PieceColor,0);
            var squareOneInFront = SquareInDirection(piece.Coordinate, direction);

            if (IsSquareValidAndEmpty(squareOneInFront, currentBoardState))
            {
                validMovements.Add(squareOneInFront);
                var squareTwoInFront = SquareInDirection(squareOneInFront, direction);
                if(!piece.HasMoved && IsSquareValidAndEmpty(squareTwoInFront, currentBoardState))
                {
                    validMovements.Add(squareTwoInFront);
                }
            }
            return validMovements;
        }

        private HashSet<Point> CalculateKnightValidPositions(BasePiece piece, GridSquare[,] currentBoardState)
        {
            var validMovements = new HashSet<Point>();
            foreach(var possiblity in this.KnightMovementPossibilities)
            {
                var squareInDirection = this.SquareInDirection(piece.Coordinate, possiblity);
                if(IsSquareValidAndEmpty(squareInDirection, currentBoardState))
                {
                    validMovements.Add(squareInDirection);
                }
            }
            return validMovements;
        }

        private Point SquareInDirection(Point currentPosition, Point direction)
        {
            var squareInFront = new Point(currentPosition.X + direction.X, currentPosition.Y + direction.Y);
            return squareInFront;
        }

        private bool IsSquareValidAndEmpty(Point coordinate, GridSquare[,] currentBoardState)
        {
            bool result = false;
            try
            {
                if (boardLegalPositionChecker.IsLegalBoardPosition(coordinate))
                {
                    if (!currentBoardState[coordinate.X, coordinate.Y].ContainsPiece())
                    {
                        result = true;
                    }
                }
            }
            catch(Exception e)
            {
                result = false;
            }
            
            return result;
        }
    }
}
