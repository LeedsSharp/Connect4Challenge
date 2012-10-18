using System;
using System.Collections.Generic;
using System.Linq;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.Logic
{
	public class Tournament
	{
		private readonly IList<Player> _allPlayers;
		private readonly IList<TournamentRound> _allRounds; 

		public Tournament(IList<Player> players)
		{
			_allPlayers = players;
			_allRounds = new List<TournamentRound> {new TournamentRound(_allPlayers)};
		}


		public TournamentRound NextRound()
		{
			var currentRound = _allRounds.Last();
			currentRound.PlayAllGames();

			if (currentRound.Winners.Count() > 1)
			{
				var nextRound = new TournamentRound(currentRound.Winners.ToList());
				_allRounds.Add(nextRound);
			}

			return currentRound;
		}
	}

	public class TournamentRound
	{
		public IList<Game> Games;

		/// <summary>
		/// Start a new tournament using a list of players
		/// </summary>
		/// <param name="players"></param>
		public TournamentRound(IList<Player> players)
		{
			if(!IsPowerOfTwo(players.Count)) throw new Exception("Total players must be power of two to play in tournament.");
			SetupPlayerGames(players);
		}

		public IEnumerable<Player> Winners
		{
			get { return Games.Select(g => g.Winner); }
		}

		private static bool IsPowerOfTwo(int x)
		{
			return (x != 0) && ((x & (x - 1)) == 0);
		}

		public void PlayAllGames()
		{
			foreach (var game in Games)
			{
				game.PlayTillEnd();
			}
		}

		private void SetupPlayerGames(IList<Player> players)
		{
			Games = new List<Game>();
			for (var i = 0; i < players.Count; i += 2)
			{
				var game = new Game(players[i], players[i + 1]);
				Games.Add(game);
			}
		}
	}
}
