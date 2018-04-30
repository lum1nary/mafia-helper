using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core.Rules
{
    public class ClassicMafiaRules : IMafiaRules
    {
        private const int MafiaPririty = 0;
        private const int DoctorPriority = 1;
        private const int WhorePriority = 2;
        private const int CivilianPriority = 3;
        private const int OthersPriority = 4;

        public int MinimumPlayerCount => 4;

        public string RulesType => "Classic";

        public IMafiaRoundResult GetCurrentResult(IMafiaGame game)
        {
            var noMafia = game.Teams.Where(t => t.DefTeamName == DefaultTeamName.Mafia).All(t => t.Participants.Count == 0);
            var allMafia = game.Teams.Where(i => i.DefTeamName != DefaultTeamName.Mafia).All(t => t.Participants.Count == 0);

            if (noMafia)
                return new MafiaRoundResult(true, game.Rounds.Last(), DefaultTeamName.Civilian.ToString());

            if(allMafia)
                return new MafiaRoundResult(true, game.Rounds.Last(), DefaultTeamName.Mafia.ToString());

            return new MafiaRoundResult(false, game.Rounds.Last());
        }

        public bool IsPlayerCanContinue(IMafiaGame game, IMafiaPlayer player)
        {
            //1 killed
            //2 voted more than half of playersCount
            var killed = player.State.Effects.Any(i => i.DefaultEffectName == ActionEffectName.Killed);
            var votedCount = player.State.Effects.Count(i => i.DefaultEffectName == ActionEffectName.Voted) ;

            var voted = votedCount > ((game.Players.Count - 1) / 2);

            return killed || voted;
        }

        public void Apply(IMafiaGame game)
        {
            foreach (var team in game.Teams)
            {
                switch (team.DefTeamName)
                {
                    case DefaultTeamName.Mafia: team.Priority = MafiaPririty;
                        break;
                    case DefaultTeamName.Whore: team.Priority = WhorePriority;
                        break;
                    case DefaultTeamName.Doctor: team.Priority = DoctorPriority;
                        break;
                    case DefaultTeamName.Civilian: team.Priority = CivilianPriority;
                        break;
                    case null: team.Priority = OthersPriority;
                        break;
                }
            }
        }

        public IReadOnlyList<DefaultTeamName> DefaultTeams { get; } = new List<DefaultTeamName>()
        {
            DefaultTeamName.Mafia,
            DefaultTeamName.Doctor,
            DefaultTeamName.Whore,
            DefaultTeamName.Civilian
        };

        public IReadOnlyList<CustomTeamDecription> CustomTeams { get; } = new List<CustomTeamDecription>();
    }
}