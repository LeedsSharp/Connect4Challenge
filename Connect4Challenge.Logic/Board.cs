using System;
using System.Collections.Generic;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.Logic
{
	public class Board
	{
		public int Size { get; private set; }

		protected readonly List<List<Char>> BoardPlaces;
		protected const int NumberInARow = 4;


		public Board()
		{
			Size = 8;
			BoardPlaces = new List<List<Char>>();
			for (var i = 0; i < Size; i++)
			{
				BoardPlaces.Add(new List<Char>());
			}
		}

		public Char this [int x, int y]
		{
			get
			{
				if (x < 0 || y < 0 || x >= Size || y >= Size) return ' ';

				return (y >= BoardPlaces[x].Count)
					? ' '
					: BoardPlaces[x][y];
			}
		}

		public Board Clone()
		{
			var clonedBoard = new Board();
			for (var i = 0; i < Size; i++)
			{
				clonedBoard.BoardPlaces[0] = new List<Char>(BoardPlaces[0]);
			}

			return clonedBoard;
		}

		public virtual bool Drop(Player player, int place)
		{
			if (place < 0 || place >= Size || BoardPlaces[place].Count >= Size)
			{
				throw new Exception(String.Format("An {0} was placed outside of the board.", player.DisplayLetter));
			}

			if(BoardPlaces[place].Count >= Size)
			{
				return false;
			}

			BoardPlaces[place].Add(player.DisplayLetter);
			return true;
		}

		public Char? Winner
		{
			get
			{
				for (var x = 0; x < Size; x++)
				{
					for (var y = 0; y < BoardPlaces[x].Count; y++)
					{
						var a = CheckPlace(x, y);
						if (a != null) return a;
					}
				}
				return null;
			}
		}

		protected Char? CheckPlace(int x, int y)
		{
			var worthCheckingLeft = x + NumberInARow < Size;
			if (worthCheckingLeft)
			{
				var a = CheckLeft(x, y);
				if (a != null) return a;
			}

			var worthCheckingUp = y + NumberInARow <= BoardPlaces[x].Count;
			if (worthCheckingUp)
			{
				var a = CheckUp(x, y);
				if (a != null) return a;
			}

			var isUpLeftWin = CheckUpLeft(x, y);
			if (isUpLeftWin != null) return isUpLeftWin;

			var isUpRightWin = CheckUpRight(x, y);
			if (isUpRightWin != null) return isUpRightWin;

			return null;
		}

		protected Char? CheckUpLeft(int x, int y)
		{
			var firstChar = this[x, y];
			if (firstChar == ' ') return null;

			for(var i = 1; i < NumberInARow; i++)
			{
				if(this[x + i, y + i] != firstChar) return null;
			}
			return firstChar;
		}

		protected Char? CheckUpRight(int x, int y)
		{
			var firstChar = this[x, y];
			if (firstChar == ' ') return null;

			for (var i = 1; i < NumberInARow; i++)
			{
				if (this[x + i, y - i] != firstChar) return null;
			}
			return firstChar;
		}

		protected Char? CheckUp(int x, int y)
		{
			var firstChar = this[x, y];
			if (firstChar == ' ') return null;

			for (var i = 1; i < NumberInARow; i++)
			{
				if (this[x, y + i] != firstChar) return null;
			}
			return firstChar;
		}

		protected Char? CheckLeft(int x, int y)
		{
			var firstChar = this[x, y];
			if (firstChar == ' ') return null;

			for (var i = 1; i < NumberInARow; i++)
			{
				var comparePlaceChar = this[x + i, y];
				if (comparePlaceChar != firstChar) return null;
			}
			return firstChar;
		}
	}
}
