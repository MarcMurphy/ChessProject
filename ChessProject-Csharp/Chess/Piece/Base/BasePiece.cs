using Gfi.Hiring.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gfi.Hiring
{
    public abstract class BasePiece
    {
        public PieceColor PieceColor { get; set; }

        public Point Coordinate { get; set; }

        public List<Point> ValidMovements { get; set; }

        public BasePiece(PieceColor pieceColor)
        {
            this.PieceColor = pieceColor;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format(Resources.CurrentPosition, Environment.NewLine, this.Coordinate.X, this.Coordinate.Y, this.PieceColor);
        }
    }
}