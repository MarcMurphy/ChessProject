using Gfi.Hiring.Piece.Enums;
using System;
using System.Collections.Generic;

namespace Gfi.Hiring.Utils
{
    public class PieceValidMoveCalculator : IPieceValidMoveCalculator
    {
        private static readonly Dictionary<PieceType, Func<HashSet<GridSquare>>> pieceTypeToCalculatorFunction 
            = new Dictionary<PieceType, Func<HashSet<GridSquare>>>
        {
            { PieceType.Pawn, CalculatePawnValidPositions}
        };

        public void CalculateAndSetValidPositions(BasePiece piece, GridSquare[,] currentBoardState)
        {
            Func<HashSet<GridSquare>> calculationFunction;
            if(pieceTypeToCalculatorFunction.TryGetValue(piece.PieceType, out calculationFunction))
            {
                HashSet<GridSquare> validMovements = calculationFunction.Invoke();
                piece.ValidMovements = validMovements;
            }
        }

        private static HashSet<GridSquare> CalculatePawnValidPositions()
        {
            return new HashSet<GridSquare>();
        }
    }
}
