using Gfi.Hiring.Piece.Implementations;
using NUnit.Framework;
using System.Drawing;

namespace Gfi.Hiring.Tests
{
    [TestFixture]
    public class Knight_Tests
    {
        private ChessBoard _chessBoard;
        private Knight _knight;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _knight = new Knight(PieceColor.Black);
        }

        [Test]
        public void Knight_Is_BasePiece()
        {
            Assert.That(typeof(Knight).IsSubclassOf(typeof(BasePiece)));
        }

        [Test]
        public void Knight_Move_LegalCoordinates_Update_Coordinates()
        {
            _chessBoard.Add(_knight, new Point(4, 4));
            _chessBoard.Move(_knight.Coordinate, new Point(6, 3));
            Assert.That(_knight.Coordinate, Is.EqualTo(new Point(6, 3)));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Does_Not_Update_Coordinates()
        {
            _chessBoard.Add(_knight, new Point(4, 4));
            _chessBoard.Move(_knight.Coordinate, new Point(5, 5));
            Assert.That(_knight.Coordinate, Is.EqualTo(new Point(4, 4)));
        }
    }
}
