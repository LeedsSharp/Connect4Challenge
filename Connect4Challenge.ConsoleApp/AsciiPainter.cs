using System;
using System.Collections.Generic;
using Connect4Challenge.Logic;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.ConsoleApp
{
	internal class AsciiPainter
	{
		public static void Draw(Board board)
		{
			var boardSize = board.Size;

			Console.Clear();

			for (var y = boardSize - 1; y >= 0; y--)
			{
				Console.Write('|');
				for (var x = 0; x < boardSize; x++)
				{
					Console.Write(board[x, y]);
				}
				Console.WriteLine('|');
			}
		}

		public static void Draw(IEnumerable<Player> players)
		{
			foreach (var player in players)
			{
				Console.WriteLine("* {0}", player);
			}
		}
	}
}