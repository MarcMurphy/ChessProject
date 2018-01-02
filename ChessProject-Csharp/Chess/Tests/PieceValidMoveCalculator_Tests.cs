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
        private Mock<IPieceValidMoveCalculator> pieceValidMoveCalculator;
        private Mock<IBoardLegalPositionChecker> boardLegalPositionChecker;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            pieceValidMoveCalculator = new Mock<IPieceValidMoveCalculator>();
            boardLegalPositionChecker = new Mock<IBoardLegalPositionChecker>();
            boardLegalPositionChecker.Setup(x => x.IsLegalBoardPosition(It.IsAny<Point>())).Returns(true);
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
    }
}
