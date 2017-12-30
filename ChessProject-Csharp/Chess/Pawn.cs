using System;

namespace Gfi.Hiring
{
    public class Pawn
    {
        public ChessBoard ChessBoard { get; set; }

        public int XCoordinate { get; set; }
        
        public int YCoordinate { get; set; }

        public PieceColor PieceColor { get; set; }

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

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, this.XCoordinate, this.YCoordinate, this.PieceColor);
        }

    }
}
