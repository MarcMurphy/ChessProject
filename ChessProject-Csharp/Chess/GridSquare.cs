using System.Drawing;

namespace Gfi.Hiring
{
    public class GridSquare
    {
        public Point Coordinate { get; private set; }

        public GridSquare(Point coordinate)
        {
            this.Coordinate = coordinate;
        }
    }
}