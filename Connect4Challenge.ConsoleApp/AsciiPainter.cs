using System;
using System.Collections.Generic;
using Connect4Challenge.Logic;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.ConsoleApp
{
	internal class AsciiPainter
	{
		public static void Draw(Game game)
		{
			Console.Clear();
			Console.WriteLine("Player {0}: {1}", game.Player1.DisplayLetter, game.Player1.Name);
			Console.WriteLine("Player {0}: {1}", game.Player2.DisplayLetter, game.Player2.Name);
			Console.WriteLine();

			var board = game.Board;
			var boardSize = board.Size;

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