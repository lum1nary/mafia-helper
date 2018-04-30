using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaGame : IMafiaGame
    {
        private readonly List<ITeam> _teams;
        public IReadOnlyList<ITeam> Teams => _teams;

        private readonly List<IRound> _rounds = new List<IRound>();
        public IReadOnlyList<IRound> Rounds => _rounds;

        private readonly List<IMafiaPlayer> _players;
        public IReadOnlyList<IMafiaPlayer> Players => _players;
        
        public IMafiaRules Rules { get; }

        private readonly RoundRefresher _roundRefresher = new RoundRefresher();

        public MafiaGame(IList<ITeam> teams, IMafiaRules rules)
        {
            _players = new List<IMafiaPlayer>(teams.SelectMany(i => i.Participants));
            _teams = new List<ITeam>(teams);
            Rules = rules;
        }

        public void Initialize()
        {
            Rules.Apply(this);

            foreach (var team in Teams) _roundRefresher.Add(team);
            foreach (var state in _players.Select(i => i.State)) _roundRefresher.Add(state);
        }

        public IRoundResult PlayNextRound(IRound round)
        {
            _rounds.Add(round);

            RemoveKilledAndExcluded();

            var result = Rules.GetCurrentResult(this);

            _roundRefresher.Refresh();

            return result;
        }

        private void RemoveKilledAndExcluded()
        {
            var playersToRemove = Players.Where(player => !Rules.IsPlayerCanContinue(this, player)).ToList();

            foreach (var player in playersToRemove)
            {
                _players.Remove(player);
                player.Team.RemoveExcluded(player);
            }

            var teamsToRemove = Teams.Where(i => i.Participants.Count == 0).ToList();

            foreach (var team in teamsToRemove)
            {
                _teams.Remove(team);
            }
        }
    }
}