using System;

namespace Connect4Challenge.Logic.Players
{
	public class StupidPlayer : Player
	{
		private int _dropRow;
		private static Random _random;

		public StupidPlayer(String name) : base(name)
		{
		}

		private static Random Rand
		{
			get
			{
				if (_random == null)
				{
					_random = new Random();
				}
				return _random;
			}
		}

		public override void Go()
		{
			Board.Drop(this, _dropRow);
		}

		public override void NewBoard(Board board, char displayLetter)
		{
			base.NewBoard(board, displayLetter);
			_dropRow = Rand.Next(0, board.Size - 1);
		}
	}
}
