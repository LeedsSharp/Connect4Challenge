using System;

namespace Connect4Challenge.Logic.Players
{
	public abstract class Player
	{
		protected Board Board;

		public String Name { get; private set; }

		public char DisplayLetter { get; private set; }

		protected Player(String name)
		{
			Name = name;
		}

		public virtual void NewBoard(Board board, Char displayLetter)
		{
			DisplayLetter = displayLetter;
			Board = board;
		}

		public abstract void Go();

		public override string ToString()
		{
			return String.Format("{0} ({1})", Name, DisplayLetter);
		}
	}
}
