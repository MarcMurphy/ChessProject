using System;

namespace Gfi.Hiring
{
    public class Pawn : BasePiece
    {
        public Pawn(PieceColor pieceColor)
        {
            this.PieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
            throw new NotImplementedException("Need to implement Pawn.Move()");
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }
    }
}
