using Gfi.Hiring.Piece.Enums;

namespace Gfi.Hiring.Piece.Implementations
{
    public class Knight : BasePiece
    {
        public Knight(PieceColor pieceColor) : base(pieceColor, PieceType.Knight)
        {
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }
    }
}
