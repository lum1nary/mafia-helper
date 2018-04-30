using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core.Game
{
    public class MafiaGame : IMafiaGame
    {
        private readonly List<IMafiaTeam> _teams;
        public IReadOnlyList<IMafiaTeam> Teams => _teams;

        private readonly List<IMafiaRound> _rounds = new List<IMafiaRound>();
        public IReadOnlyList<IMafiaRound> Rounds => _rounds;

        private readonly List<IMafiaPlayer> _players;
        public IReadOnlyList<IMafiaPlayer> Players => _players;
        
        public IMafiaRules Rules { get; }

        public MafiaGame(IList<IMafiaTeam> teams, IMafiaRules rules)
        {
            _players = new List<IMafiaPlayer>(teams.SelectMany(i => i.Participants));
            _teams = new List<IMafiaTeam>(teams);
            Rules = rules;
        }

        public void Initialize()
        {
            Rules.Apply(this);
        }

        public IMafiaRoundResult PlayNextRound(IMafiaRound round)
        {
            _rounds.Add(round);

            var result = Rules.GetCurrentResult(this);

            if(result.IsGameComplete)
                RemoveExcludedPlayers();

            RefreshPlayersState(_players);
            return result;
        }

        private void RemoveExcludedPlayers()
        {
            var playersToRemove = Players.Where(player => !Rules.IsPlayerCanContinue(this, player)).ToList();

            RefreshPlayersState(playersToRemove);
            foreach (var player in playersToRemove)
            {
                _players.Remove(player);
            }
        }

        private void RefreshPlayersState(IList<IMafiaPlayer> players)
        {
            foreach (var player in players)
            {
                player.State.Refresh();
            }
        }
    }
}