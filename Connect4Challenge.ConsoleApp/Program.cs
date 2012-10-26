using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Connect4Challenge.Logic;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			PlaySingleGame();
			//PlayTournament();
		}

		private static void PlaySingleGame()
		{
			var game = new Game();

			AsciiPainter.Draw(game.Board);

			Player winner = null;
			while (winner == null)
			{
				Thread.Sleep(800);
				winner = game.NextTurn();
				AsciiPainter.Draw(game.Board);
			}

			Console.WriteLine("The winner was {0}.", winner);
			Console.WriteLine("Press any key.");
			Console.ReadKey();
		}

		private static void PlayTournament()
		{
			var players = GetTournamentPlayers();
			var tournament = new Tournament(players);

			Console.WriteLine("And the players are:");
			AsciiPainter.Draw(players);

			int roundWinnerCount;
			do
			{
				var finishedRound = tournament.NextRound();
				roundWinnerCount = finishedRound.Winners.Count();
				Thread.Sleep(800);
				Console.WriteLine("\nThen there were {0}", roundWinnerCount);
				AsciiPainter.Draw(finishedRound.Winners);
			}
			while (roundWinnerCount > 1);
			Console.ReadKey();
		}
		

		private static IList<Player> GetTournamentPlayers()
		{
			return new List<Player>
			{
				new StupidPlayer("Richard"),
				new StupidPlayer("Tim"),
				new StupidPlayer("Jess"),
				new StupidPlayer("Becky")
			};
		}
	}
}
