using Gfi.Hiring.Properties;
using System;

namespace Gfi.Hiring
{
    public abstract class BasePiece
    {
        public ChessBoard ChessBoard { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public PieceColor PieceColor { get; set; }

        protected string CurrentPositionAsString()
        {
            return string.Format(Resources.CurrentPosition, Environment.NewLine, this.XCoordinate, this.YCoordinate, this.PieceColor);
        }
    }
}
