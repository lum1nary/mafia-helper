using System.Collections.Generic;
using System.Linq;
using MafiaHelper.Core.ActionEffectResolver;

namespace MafiaHelper.Core
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

        public IEffectProcessor EffectProcessor { get; } = new KillProcessor();

        public IReadOnlyList<string> DefaultTeams { get; } = new List<string>
        {
            TeamNameConstants.Mafia,
            TeamNameConstants.Doctor,
            TeamNameConstants.Whore,
            TeamNameConstants.Civilian
        };

        public IReadOnlyList<CustomTeamDecription> CustomTeams { get; } = new List<CustomTeamDecription>();

        public IRoundResult GetCurrentResult(IMafiaGame game)
        {
            var noMafia = game.Teams.Where(t => t.TeamName == TeamNameConstants.Mafia)
                .All(t => t.Participants.Count == 0);
            var allMafia = game.Teams.Where(i => i.TeamName != TeamNameConstants.Mafia)
                .All(t => t.Participants.Count == 0);

            var lastRound = game.Rounds[game.Rounds.Count - 1];

            if (noMafia)
                return new MafiaRoundResult(true, lastRound, TeamNameConstants.Civilian);

            if (allMafia)
                return new MafiaRoundResult(true, lastRound, TeamNameConstants.Mafia);

            return new MafiaRoundResult(false, lastRound);
        }

        public bool IsPlayerCanContinue(IMafiaGame game, IMafiaPlayer player)
        {
            //1 killed
            //2 voted more than half of playersCount
            var killed = player.State.Effects.ContainsActualEffect(ActionEffectConstants.Killed);
            var votedCount = player.State.Effects.CountEffects(ActionEffectConstants.Voted);

            var voted = votedCount > (game.Players.Count - 1) / 2;

            return !killed && !voted;
        }

        public void Apply(IMafiaGame game)
        {
            foreach (var team in game.Teams)
            {
                switch (team.TeamName)
                {
                    case TeamNameConstants.Mafia:
                        team.Priority = MafiaPririty;
                        break;
                    case TeamNameConstants.Whore:
                        team.Priority = WhorePriority;
                        break;
                    case TeamNameConstants.Doctor:
                        team.Priority = DoctorPriority;
                        break;
                    case TeamNameConstants.Civilian:
                        team.Priority = CivilianPriority;
                        break;
                    default:
                        team.Priority = OthersPriority;
                        break;
                }
            }
        }
    }
}