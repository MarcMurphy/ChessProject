using System.Drawing;

namespace Gfi.Hiring.Utils.BoardLegelPositionChecker
{
    public interface IBoardLegalPositionChecker
    {
        bool IsLegalBoardPosition(Point coordinate);
    }
}
