﻿using NUnit.Framework;
using System.Drawing;

namespace Gfi.Hiring
{
    [TestFixture]
    public class Pawn_Tests
    {
        private ChessBoard _chessBoard;
        private Pawn _pawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _pawn = new Pawn(PieceColor.Black);
        }

        [Test]
        public void Pawn_Is_BasePiece()
        {
            Assert.That(typeof(Pawn).IsSubclassOf(typeof(BasePiece)));
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            _chessBoard.Add(_pawn, new Point(6, 3));
            _chessBoard.Move(_pawn.Coordinate, new Point(7, 3));
            Assert.That(_pawn.Coordinate, Is.EqualTo(new Point(6, 3)));
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            _chessBoard.Add(_pawn, new Point(6, 3));
            _chessBoard.Move(_pawn.Coordinate, new Point(6, 2));
            Assert.That(_pawn.Coordinate, Is.EqualTo(new Point(6, 3)));
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
        {
            _chessBoard.Add(_pawn, new Point(6, 3));
            _chessBoard.Move(_pawn.Coordinate, new Point(5, 3));
            Assert.That(_pawn.Coordinate, Is.EqualTo(new Point(5, 3)));
        }
    }
}