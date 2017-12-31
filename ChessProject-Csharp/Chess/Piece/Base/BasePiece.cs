using Gfi.Hiring.Properties;
using Gfi.Hiring.Utils;
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

        public string PieceCode { get; set; }

        public BasePiece(PieceColor pieceColor, string pieceCode)
        {
            this.PieceColor = pieceColor;
            this.PieceCode = pieceCode;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format(Resources.CurrentPositionForDebug, Environment.NewLine, this.Coordinate.X, this.Coordinate.Y, this.PieceColor);
        }

        protected string CurrentPositionAsStringForDisplay()
        {
            string column = ChessBoardCoordinateTranslator.TranslateColumn(this.Coordinate.Y);
            string row = ChessBoardCoordinateTranslator.TranslateRow(this.Coordinate.X);
            return string.Format(Resources.CurrentPositionForDisplay, this.PieceCode, column, row);
        }
    }
}