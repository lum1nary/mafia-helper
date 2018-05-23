using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaGame : IMafiaGame
    {
        public TeamCollection Teams { get; }

        private readonly List<IRound> _rounds = new List<IRound>();
        public IReadOnlyList<IRound> Rounds => _rounds;

        public PlayerCollection Players { get; }
        
        public IMafiaRules Rules { get; }

        private readonly RoundRefresher _roundRefresher = new RoundRefresher();

        public MafiaGame(IList<ITeam> teams, IMafiaRules rules)
        {
            Players = new PlayerCollection(teams.SelectMany(i => i.Participants));
            Teams = new TeamCollection(teams);
            Rules = rules;
        }

        public void Initialize()
        {
            Rules.Apply(this);

            foreach (var team in Teams) _roundRefresher.Add(team);
            foreach (var state in Players.Select(i => i.State)) _roundRefresher.Add(state);
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
                Players.Remove(player);
                player.Team.RemoveExcluded(player);
            }

            var teamsToRemove = Teams.Where(i => i.Participants.Count == 0).ToList();

            foreach (var team in teamsToRemove)
            {
                Teams.Remove(team);
            }
        }
    }
}