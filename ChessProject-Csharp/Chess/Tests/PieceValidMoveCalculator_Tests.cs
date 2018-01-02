using Gfi.Hiring.Piece.Implementations;
using Gfi.Hiring.Utils;
using Gfi.Hiring.Utils.BoardLegelPositionChecker;
using Moq;
using NUnit.Framework;
using System.Drawing;

namespace Gfi.Hiring.Tests
{
    [TestFixture]
    public class PieceValidMoveCalculator_Tests
    {
        private ChessBoard _chessBoard;
        private PieceValidMoveCalculator pieceValidMoveCalculator;
        private Mock<IBoardLegalPositionChecker> boardLegalPositionChecker;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            
            boardLegalPositionChecker = new Mock<IBoardLegalPositionChecker>();
            boardLegalPositionChecker.Setup(x => x.IsLegalBoardPosition(It.IsAny<Point>())).Returns(true);
            boardLegalPositionChecker.Setup(x => x.IsLegalBoardPosition(It.IsAny<Point[]>())).Returns(true);
            pieceValidMoveCalculator = new PieceValidMoveCalculator(boardLegalPositionChecker.Object);
            _chessBoard.BoardPositionChecker = boardLegalPositionChecker.Object;
        }

        [Test]
        public void CalculatePawnValidPositions_Is_Called_When_BasePiece_Is_Pawn()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            Point currentPoint = new Point(6, 3);
            Point validDestination = new Point(6, 4);

            _chessBoard.Add(pawn, currentPoint);
            pawn.ValidMovements = null;

            _chessBoard.Move(currentPoint, validDestination);

            Assert.That(pawn.ValidMovements, Is.Not.Null);
        }

        [Test]
        public void Pawn_Should_Have_Two_Avialable_Moves_On_Empty_Board_For_Initial_Move()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            Point startingPoint = new Point(6, 3);
            _chessBoard.Add(pawn, startingPoint);

            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);

            Assert.That(pawn.ValidMovements.Count, Is.EqualTo(2));
        }

        [Test]
        public void White_Pawn_On_Row_Two_Should_Have_Moves_To_Row_Three_And_Four()
        {
            Pawn pawn = new Pawn(PieceColor.White);
            Point startingPoint = new Point(1, 1);
            _chessBoard.Add(pawn, startingPoint);
            
            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.IsTrue(pawn.ValidMovements.Contains(new Point(2, 1)));
            Assert.IsTrue(pawn.ValidMovements.Contains(new Point(3, 1)));
        }

        [Test]
        public void Black_Pawn_On_Row_7_Should_Have_Moves_To_Row_Six_And_Five()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            Point startingPoint = new Point(6, 6);
            _chessBoard.Add(pawn, startingPoint);

            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.That(pawn.ValidMovements.Contains(new Point(5, 6)));
            Assert.That(pawn.ValidMovements.Contains(new Point(4, 6)));
        }

        [Test]
        public void After_Moving_Pawn_Should_Only_Have_One_Valid_Move()
        {
            Pawn pawn = new Pawn(PieceColor.White);
            Point startingPoint = new Point(1, 1);
            _chessBoard.Add(pawn, startingPoint);
            Point initialDestination = new Point(3, 1);
            _chessBoard.Move(pawn.Coordinate, initialDestination);

            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.That(pawn.ValidMovements.Count, Is.EqualTo(1));
            Assert.That(pawn.ValidMovements.Contains(new Point(4, 1)));
        }

        [TestCase(0,0,2)] //corner
        [TestCase(4, 0, 4)] //side of board
        [TestCase(4, 4, 8)] //center of board
        public void Knight_Should_Have_X_Available_Moves_FromPosition(int xCoordinate, int yCoordinate, int expectedResult)
        {
            Knight knight = new Knight(PieceColor.Black);
            Point startingPoint = new Point(xCoordinate, yCoordinate);
            _chessBoard.Add(knight, startingPoint);
            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(knight, _chessBoard.CurrentBoardState);
            Assert.That(knight.ValidMovements.Count, Is.EqualTo(expectedResult));
        }
    }
}
