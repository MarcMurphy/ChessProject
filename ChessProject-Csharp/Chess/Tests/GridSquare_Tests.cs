using NUnit.Framework;
using System.Drawing;

namespace Gfi.Hiring.Tests
{
    [TestFixture]
    public class GridSquare_Tests
    {
        private readonly Point initialPosition = new Point(6, 3);
        private GridSquare gridSquare;

        [SetUp]
        public void SetUp()
        {
            gridSquare = new GridSquare(initialPosition);
        }

        [Test]
        public void GridSquare_Coordinate_Is_Set_When_Constructing()
        {
            Assert.That(this.gridSquare.Coordinate, Is.EqualTo(initialPosition));
        }
        [Test]
        public void GridSquare_Set_Piece_Successfully_Sets_Piece()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            this.gridSquare.SetPiece(new Pawn(PieceColor.Black));
            Assert.That(this.gridSquare.Piece, Is.EqualTo(pawn));
        }

        [Test]
        public void GridSquare_RemovePiece_Sets_Piece_To_Null()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            this.gridSquare.SetPiece(new Pawn(PieceColor.Black));
            this.gridSquare.RemovePiece();

            Assert.That(this.gridSquare.Piece, Is.EqualTo(null));
        }
    }
}
