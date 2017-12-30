using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		public void Has_MaxBoardWidth_of_7()
		{
			Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
		}

		[Test]
		public void Has_MaxBoardHeight_of_7()
		{
			Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
		}

		[TestCase(0, 0)]
        [TestCase(5, 5)]
        public void IsLegalBoardPosition_True_WhenCoordinateIsWithinBoardDimensions(int xCoordinate, int yCoordinate)
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(xCoordinate, yCoordinate);
			Assert.That(isValidPosition, Is.True);
		}

		[TestCase(11, 5)]
        [TestCase(0, 9)]
        [TestCase(11, 0)]
        [TestCase(-1, 5)]
        [TestCase(5, 1)]
        public void IsLegalBoardPosition_False_When_EitherCoordinateIsOutsideBoardDimensions(int xCoordinate, int yCoordinate)
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(xCoordinate, yCoordinate);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void Avoids_Duplicate_Positioning()
		{
			Pawn firstPawn = new Pawn(PieceColor.Black);
			Pawn secondPawn = new Pawn(PieceColor.Black);
			_chessBoard.Add(firstPawn, 6, 3, PieceColor.Black);
			_chessBoard.Add(secondPawn, 6, 3, PieceColor.Black);
			Assert.That(firstPawn.XCoordinate, Is.EqualTo(6));
			Assert.That(firstPawn.YCoordinate, Is.EqualTo(3));
			Assert.That(secondPawn.XCoordinate, Is.EqualTo(-1));
			Assert.That(secondPawn.YCoordinate, Is.EqualTo(-1));
		}

		[Test]
		public void Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
				Pawn pawn = new Pawn(PieceColor.Black);
				int row = i / ChessBoard.MaxBoardWidth;
				_chessBoard.Add(pawn, 6 + row, i % ChessBoard.MaxBoardWidth, PieceColor.Black);
				if (row < 1)
				{
					Assert.That(pawn.XCoordinate, Is.EqualTo(6 + row));
					Assert.That(pawn.YCoordinate, Is.EqualTo(i % ChessBoard.MaxBoardWidth));
				}
				else
				{
					Assert.That(pawn.XCoordinate, Is.EqualTo(-1));
					Assert.That(pawn.YCoordinate, Is.EqualTo(-1));
				}
			}
		}
	}
}
