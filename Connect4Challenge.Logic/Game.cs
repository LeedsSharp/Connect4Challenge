using System;
using System.Collections.Generic;
using System.Linq;
using Connect4Challenge.Logic.Players;

namespace Connect4Challenge.Logic
{
	public class Game
	{
		private readonly IList<Player> _players;
		private int _currentPlayer;

		public Game()
		{
			var player1 = new StupidPlayer("Richard");
			var player2 = new StupidPlayer("Tim");
			_players = new List<Player> {player1, player2};
			SetupPlayersOnNewBoard();
		}

		public Game(Player player1, Player player2)
		{
			_players = new List<Player> { player1, player2 };
			SetupPlayersOnNewBoard();
		}

		public Player Player1 { get { return _players[0]; } }
		public Player Player2 { get { return _players[1]; } }

		public Player Winner { get; private set; }

		public Player NextTurn()
		{
			_players[_currentPlayer].Go();
			_currentPlayer = (_currentPlayer + 1) % 2;

			var winnerSymbol = Board.Winner;
			Winner = (winnerSymbol == null)
				? null
				: PlayerForSymbol(winnerSymbol.Value);

			return Winner;
		}

		public Player PlayTillEnd()
		{
			Player winner = null;
			while (winner == null)
			{
				winner = NextTurn();
			}
			return winner;
		}

		private void SetupPlayersOnNewBoard()
		{
			Board = new Board();
			_players[0].NewBoard(Board, 'x');
			_players[1].NewBoard(Board, 'o');
		}

		private Player PlayerForSymbol(Char symbol)
		{
			return _players.FirstOrDefault(player => player.DisplayLetter == symbol);
		}

		public Board Board { get; private set; }
	}
}
