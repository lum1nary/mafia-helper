using System.Collections.Generic;

namespace MafiaHelper.Core.Game
{
    public class MafiaGame : IMafiaGame
    {
        private readonly List<IMafiaRound> _rounds = new List<IMafiaRound>();
        public IReadOnlyList<IMafiaRound> Rounds => _rounds;

        private readonly List<IMafiaPlayer> _players;
        public IReadOnlyList<IMafiaPlayer> Players => _players;
        
        public IMafiaRules Rules { get; }

        public MafiaGame(IList<IMafiaPlayer> players, IMafiaRules rules)
        {
            _players = new List<IMafiaPlayer>(players);
            Rules = rules;

            Rules.Initialize(this);
        }

        public IMafiaRoundResult PlayNextRound(IMafiaRound round)
        {
            _rounds.Add(round);
            if (Rules.IsGameComplete(this))
            {
                return null; //complete;
            }
            else
            {
                RemoveExcludedPlayers();
                return null; //non complete
            }
        }

        private void RemoveExcludedPlayers()
        {
            var playersToRemove = new List<IMafiaPlayer>();
            foreach (var player in Players)
            {
                if (!Rules.IsPlayerCanContinue(player))
                {
                    playersToRemove.Add(player);
                }
            }

            foreach (var player in playersToRemove)
            {
                _players.Remove(player);
            }
        }
    }
}