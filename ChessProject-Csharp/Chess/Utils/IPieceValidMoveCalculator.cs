using System.Collections.Generic;

namespace Gfi.Hiring.Utils
{
    public interface IPieceValidMoveCalculator
    {
        void CalculateAndSetValidPositions(BasePiece piece, GridSquare[,] currentBoardState);
    }
}
