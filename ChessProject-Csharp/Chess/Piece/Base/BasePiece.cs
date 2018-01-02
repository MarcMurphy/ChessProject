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
        public PieceColor PieceColor { get; private set; }

        public Point Coordinate { get; set; }

        public HashSet<Point> ValidMovements { get; set; }

        public PieceType PieceType { get; private set; }

        public bool HasMoved { get; private set; }

        public BasePiece(PieceColor pieceColor, PieceType pieceType)
        {
            this.PieceColor = pieceColor;
            this.PieceType = pieceType;
            this.HasMoved = false;
        }

        public void Move(Point newPosition)
        {
            this.Coordinate = newPosition;
            this.HasMoved = true;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format(Resources.CurrentPositionForDebug, Environment.NewLine, this.Coordinate.X, this.Coordinate.Y, this.PieceColor);
        }

        protected string CurrentPositionAsStringForDisplay()
        {
            string column = ChessBoardCoordinateTranslator.TranslateRowIndexToDisplay(this.Coordinate.Y);
            string row = ChessBoardCoordinateTranslator.TranslateRowIndexToDisplay(this.Coordinate.X);
            return string.Format(Resources.CurrentPositionForDisplay, this.PieceType, column, row);
        }
    }
}