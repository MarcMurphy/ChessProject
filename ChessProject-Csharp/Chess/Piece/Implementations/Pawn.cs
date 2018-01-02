using System;
using Gfi.Hiring.Piece.Enums;
namespace Gfi.Hiring
{
    public class Pawn : BasePiece
    {
        public Pawn(PieceColor pieceColor) : base(pieceColor, PieceType.Pawn)
        {
        }
        
        public override string ToString()
        {
            return CurrentPositionAsString();
        }
    }
}