using System;
using Connect4Challenge.Logic;
using Connect4Challenge.Logic.Players;
using NUnit.Framework;

namespace Connect4Challenge.Tests
{
	public class BoardTests
	{
		private Board _board;
		private Player _player1;
		private Player _player2;

		[SetUp]
		public void Setup()
		{
			_board = new Board();
			_player1 = new StupidPlayer("Player 1");
			_player1.NewBoard(_board, 'x');
			_player2 = new StupidPlayer("Player 2");
			_player2.NewBoard(_board, 'o');
		}

		[Test]
		public void TestThreeAcrossNotWin()
		{
			_board.Drop(_player1, 1);
			_board.Drop(_player1, 2);
			_board.Drop(_player1, 3);

			Assert.IsNull(_board.Winner);
		}

		[Test]
		public void TestFourAcrossIsWin()
		{
			_board.Drop(_player2, 1);
			_board.Drop(_player2, 2);
			_board.Drop(_player2, 3);
			_board.Drop(_player2, 4);

			Assert.AreEqual('o', _board.Winner);
		}

		[Test]
		public void TestThreeUpNotWin()
		{
			_board.Drop(_player1, 7);
			_board.Drop(_player1, 7);
			_board.Drop(_player1, 7);

			Assert.IsNull(_board.Winner);
		}

		[Test]
		public void TestFourUpIsWin()
		{
			_board.Drop(_player2, 6);
			_board.Drop(_player2, 6);
			_board.Drop(_player2, 6);
			_board.Drop(_player2, 6);

			Assert.AreEqual('o', _board.Winner);
		}

		[Test]
		public void TestIsUpLeftWin()
		{
			_board.Drop(_player1, 0);

			_board.Drop(_player2, 1);
			_board.Drop(_player1, 1);

			_board.Drop(_player2, 2);
			_board.Drop(_player2, 2);
			_board.Drop(_player1, 2);

			_board.Drop(_player2, 3);
			_board.Drop(_player2, 3);
			_board.Drop(_player2, 3);
			_board.Drop(_player1, 3);

			Assert.AreEqual('x', _board.Winner);
		}

		[Test]
		public void TestIsUpRightWin()
		{
			_board.Drop(_player1, 7);

			_board.Drop(_player2, 6);
			_board.Drop(_player1, 6);

			_board.Drop(_player2, 5);
			_board.Drop(_player2, 5);
			_board.Drop(_player1, 5);

			_board.Drop(_player2, 4);
			_board.Drop(_player2, 4);
			_board.Drop(_player2, 4);
			_board.Drop(_player1, 4);

			Assert.AreEqual('x', _board.Winner);
		}
	}
}
