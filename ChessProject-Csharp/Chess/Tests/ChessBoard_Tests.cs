using NUnit.Framework;
using System.Drawing;
using System.Windows.Controls;

namespace Gfi.Hiring
{
    [TestFixture]
    public class ChessBoard_Tests
    {
        private ChessBoard _chessBoard;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
        }

        [Test]
        public void Has_MaxBoardWidth_of_8()
        {
            Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(8));
        }

        [Test]
        public void Has_MaxBoardHeight_of_8()
        {
            Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(8));
        }

        [TestCase(0, 0)]
        [TestCase(0, 7)]
        [TestCase(7, 0)]
        [TestCase(7, 7)]
        public void IsLegalBoardPosition_True_WhenCoordinateIsWithinBoardDimensions(int xCoordinate, int yCoordinate)
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Point(xCoordinate, yCoordinate));
            Assert.That(isValidPosition, Is.True);
        }

        [TestCase(-1, 0)]
        [TestCase(8, 0)]
        [TestCase(-1, 7)]
        [TestCase(8, 7)]
        [TestCase(0, -1)]
        [TestCase(0, 8)]
        [TestCase(7, -1)]
        [TestCase(7, 8)]
        public void IsLegalBoardPosition_False_When_EitherCoordinateIsOutsideBoardDimensions(int xCoordinate, int yCoordinate)
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Point(xCoordinate, yCoordinate));
            Assert.That(isValidPosition, Is.False);
        }


        [Test]
        public void ChessBoard_Add_Sets_Coordinate()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            _chessBoard.Add(pawn, new Point(6, 3));
            Assert.That(pawn.Coordinate, Is.EqualTo(new Point(6, 3)));
        }

        [Test]
        public void ChessBoard_Add_Fails_With_Invalid_Coordinate()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            ValidationResult validationResult = _chessBoard.Add(pawn, new Point(-1,-1));
            Assert.That(validationResult.IsValid, Is.EqualTo(false));
        }

        [Test]
        public void ChessBoard_Add_Succeeds_With_Valid_Coordinate()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            ValidationResult validationResult = _chessBoard.Add(pawn, new Point(6, 3));
            Assert.That(validationResult.IsValid, Is.EqualTo(true));
        }

        [Test]
        public void ChessBoard_Add_Avoids_Duplicate_Positioning()
        {
            Pawn firstPawn = new Pawn(PieceColor.Black);
            Pawn secondPawn = new Pawn(PieceColor.Black);
            _chessBoard.Add(firstPawn, new Point(6, 3));
            ValidationResult validationResult = _chessBoard.Add(secondPawn, new Point(6, 3));
            Assert.That(validationResult.IsValid, Is.EqualTo(false));
        }

        [Test]
        public void Limits_The_Number_Of_Pawns()
        {
            for (int i = 0; i < 10; i++)
            {
                Pawn pawn = new Pawn(PieceColor.Black);
                int row = i / ChessBoard.MaxBoardWidth;
                Point p = new Point(6 + row, i % ChessBoard.MaxBoardWidth);

                _chessBoard.Add(pawn, p);
                if (row < 1)
                {
                    Assert.That(pawn.Coordinate.X, Is.EqualTo(6 + row));
                    Assert.That(pawn.Coordinate.Y, Is.EqualTo(i % ChessBoard.MaxBoardWidth));
                }
                else
                {
                    Assert.That(pawn.Coordinate, Is.EqualTo(new Point(-1,-1)));
                }
            }
        }
    }
}