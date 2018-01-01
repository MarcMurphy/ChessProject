using Gfi.Hiring.Piece.Enums;
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

        public PieceType PieceType { get; set; }

        public BasePiece(PieceColor pieceColor, PieceType pieceType)
        {
            this.PieceColor = pieceColor;
            this.PieceType = pieceType;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format(Resources.CurrentPositionForDebug, Environment.NewLine, this.Coordinate.X, this.Coordinate.Y, this.PieceColor);
        }

        protected string CurrentPositionAsStringForDisplay()
        {
            string column = ChessBoardCoordinateTranslator.TranslateColumn(this.Coordinate.Y);
            string row = ChessBoardCoordinateTranslator.TranslateRow(this.Coordinate.X);
            return string.Format(Resources.CurrentPositionForDisplay, this.PieceType, column, row);
        }
    }
}