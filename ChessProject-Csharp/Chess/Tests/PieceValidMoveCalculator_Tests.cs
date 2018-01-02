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
        public void White_Pawn_On_Row_One_Should_Have_Moves_To_Row_Two_And_Three()
        {
            Pawn pawn = new Pawn(PieceColor.White);
            Point startingPoint = new Point(6, 1);
            _chessBoard.Add(pawn, startingPoint);
            
            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.IsTrue(pawn.ValidMovements.Contains(new Point(6, 2)));
            Assert.IsTrue(pawn.ValidMovements.Contains(new Point(6, 3)));
        }

        [Test]
        public void Black_Pawn_On_Row_7_Should_Have_Moves_To_Row_Six_And_Five()
        {
            Pawn pawn = new Pawn(PieceColor.Black);
            Point startingPoint = new Point(6, 6);
            _chessBoard.Add(pawn, startingPoint);

            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.That(pawn.ValidMovements.Contains(new Point(6, 5)));
            Assert.That(pawn.ValidMovements.Contains(new Point(6, 4)));
        }

        [Test]
        public void After_Moving_Pawn_Should_Only_Have_One_Valid_Move()
        {
            Pawn pawn = new Pawn(PieceColor.White);
            Point startingPoint = new Point(6, 1);
            _chessBoard.Add(pawn, startingPoint);
            Point initialDestination = new Point(6, 3);
            _chessBoard.Move(pawn.Coordinate, initialDestination);

            this.pieceValidMoveCalculator.CalculateAndSetValidPositions(pawn, _chessBoard.CurrentBoardState);
            Assert.That(pawn.ValidMovements.Count, Is.EqualTo(1));
            Assert.That(pawn.ValidMovements.Contains(new Point(6, 4)));

        }
    }
}
