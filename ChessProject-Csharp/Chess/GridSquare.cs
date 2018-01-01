using System.Drawing;

namespace Gfi.Hiring
{
    public class GridSquare
    {
        public Point Coordinate { get; private set; }

        public BasePiece Piece { get; private set; }

        public GridSquare(Point coordinate)
        {
            this.Coordinate = coordinate;
        }

        public void RemovePiece()
        {
            this.Piece = null;
        }

        public void SetPiece(BasePiece piece)
        {
            this.Piece = piece;
            this.Piece.Coordinate = this.Coordinate;
        }
    }
}