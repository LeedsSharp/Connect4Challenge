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

		private void SetNewRandomColumn()
		{
			_dropRow = Rand.Next(0, Board.Size - 1);
		}

		public override void Go()
		{
			try
			{
				Board.Drop(this, _dropRow);
			}
			catch (Exception)
			{
				SetNewRandomColumn();
				Go(); // Stupid player could get stuck in infinite loop
			}
		}

		public override void NewBoard(Board board, char displayLetter)
		{
			base.NewBoard(board, displayLetter);
			SetNewRandomColumn();
		}
	}
}
