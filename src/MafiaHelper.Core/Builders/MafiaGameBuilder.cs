using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaGameBuilder
    {
        private readonly ITeamFactory _teamFactory;

        private IMafiaRules _rules;
        private readonly IList<IMafiaPlayer> _players = new List<IMafiaPlayer>();

        private readonly IDictionary<string, ITeam> _createdTeams = new Dictionary<string, ITeam>();

        public MafiaGameBuilder(ITeamFactory teamFactory)
        {
            _teamFactory = teamFactory;
        }

        public void AddPlayer(int playerNumber, string teamName)
        {
            _players.Add(new MafiaPlayer(playerNumber, _createdTeams[teamName], new PlayerState()));
        }

        public void SetRules(IMafiaRules rules)
        {
            _rules = rules;
            foreach (var defName in _rules.DefaultTeams)
            {
                _createdTeams.Add(defName.ToLower(), _teamFactory.Create(defName));
            }

            foreach (var teamDescription in _rules.CustomTeams)
            {
                _createdTeams.Add(teamDescription.TeamName.ToLower(), 
                    _teamFactory.Create(
                        teamDescription.TeamName, 
                        teamDescription.EffectName, 
                        teamDescription.IsBlockingEffect));
            }
        }

        public void Validate()
        {
            _rules.RulesValidator.ValidateGameStart(_players);
        }

        public IMafiaGame Build()
        {
            foreach (var team in _createdTeams)
            {
                //todo remove team equals => make on name 
                team.Value.Initialize(_players.Where(i => ReferenceEquals(i.Team, team.Value)));
            }

            return new MafiaGame(_createdTeams.Values.ToList(), _rules);
        }
    }
}