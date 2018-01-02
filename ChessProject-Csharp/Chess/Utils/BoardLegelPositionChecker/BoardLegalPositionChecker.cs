using Gfi.Hiring.Utils.BoardLegelPositionChecker;
using System.Drawing;

namespace Gfi.Hiring.Utils
{
    public class BoardLegalPositionChecker : IBoardLegalPositionChecker
    {
        private readonly int maxHeight;
        private readonly int maxWidth;

        public BoardLegalPositionChecker()
        {
            //for unit testing only
        }

        public BoardLegalPositionChecker(int maxWidth, int maxHeight)
        {
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }

        public bool IsLegalBoardPosition(params Point[] coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if ((coordinate == null) ||
                    (coordinate.X < 0 || coordinate.X >= ChessBoard.MaxBoardWidth) ||
                    (coordinate.Y < 0 || coordinate.Y >= ChessBoard.MaxBoardHeight))
                    {
                        return false;
                    }
            }
            
            return true;
        }
    }
}
