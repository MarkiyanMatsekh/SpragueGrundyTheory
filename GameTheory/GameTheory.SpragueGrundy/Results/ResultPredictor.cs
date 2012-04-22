using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.SpragueGrundy.Games;

namespace GameTheory.SpragueGrundy.Results
{
    public static class ResultPredictor
    {
        public static Player PredictWinner(GrundyGameBase game, uint n, Player currentPlayer)
        {
            var grundyValue = game.Grundy(n);
            Player winner = grundyValue == 0
                          ? currentPlayer.Other
                          : currentPlayer;
            return winner;
        }

        public static Player PredictWinner<T>(T game, uint n) where T : GrundyGameBase
        {
            return PredictWinner(game, n, Player.First);
        }

        public static PredictionResult FindPNPositions(GrundyGameBase game, uint upTo)
        {
            var sb = new StringBuilder();

            for (uint i = 0; i < upTo; i++)
                sb.Append(game.Grundy(i) == 0 ? 'P' : 'N');

            return new PredictionResult(sb.ToString());
        }

        public static string GetFullPredictionResult<T>(T game, uint n, Player currentPlayer) where T : GrundyGameBase
        {
            return PredictionResultTemplate(
                "If {0} should make a move, given state {1}, following optimal strategy, {2} wins the {3} game",
                game, n, currentPlayer);
        }

        public static string GetShortPredictionResult<T>(T game, uint n, Player currentPlayer) where T : GrundyGameBase
        {
            return PredictionResultTemplate("player:{0},n:{1},winner:{2},game:{3}",
                game, n, currentPlayer);
        }

        private static string PredictionResultTemplate<T>(string message, T game, uint state, Player currentPlayer, bool playerShorName = true) where T : GrundyGameBase
        {
            var winner = PredictWinner(game, state, currentPlayer);
            return string.Format(message,
                GetPlayerName(currentPlayer, playerShorName),
                state,
                GetPlayerName(winner, playerShorName),
                GetGameName(game));
        }

        private static string GetPlayerName(Player player, bool shortName)
        {
            if (shortName)
                return player.Number.ToString();
            else
                return player.ToString();

        }

        private static string GetGameName<T>(T game)
        {
            var fullName = game.GetType().Name;
            var gameWordIndex = fullName.ToLower().IndexOf("game", System.StringComparison.Ordinal);
            if (gameWordIndex < 1)
                throw new InvalidOperationException("All games should follow convention of Game suffix after its name");
            return fullName.Remove(gameWordIndex);
        }

        public class PredictionResult
        {
            // first parameter is just an indexer
            public List<uint> PPositions { get; private set; }
            public List<uint> NPositions { get; private set; }
            public string BinaryView { get; private set; }

            public PredictionResult(string binaryView)
            {
                BinaryView = binaryView;

                PPositions = binaryView.Select((char c, int i) => c == 'P' ? i : -1).Where((int i) => i >= 0).Select((int i) => (uint)i).ToList();
                NPositions = binaryView.Select((char c, int i) => c == 'N' ? i : -1).Where((int i) => i >= 0).Select((int i) => (uint)i).ToList();
            }
        }
    }
}

