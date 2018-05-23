using System.Collections.Generic;
using System.Linq;
using MafiaHelper.Core;
using MafiaHelper.Core.EffectProcessors;

namespace MafiaHelper.Classic
{
    /// <summary>
    /// Classic mafia rules
    /// <see cref="http://englishmafiaclub.com/ru/how-to-play-mafia-by-classic-rules.html"/>
    /// </summary>
    public class ClassicMafiaRules : IMafiaRules
    {
        public const int MafiaPririty = 0;
        public const int SheriffPriority = 1;
        public const int CivilianPriority = -1;

        public int MinimumPlayerCount => 4;

        public string RulesType => "Classic";

        public IEffectProcessor EffectProcessor { get; } = new KillProcessor();

        public IReadOnlyList<string> DefaultTeams { get; } = new List<string>
        {
            TeamNameConstants.DonMafia,
            TeamNameConstants.Mafia,
            TeamNameConstants.Civilian,
            TeamNameConstants.Sheriff
        };

        public IReadOnlyList<CustomTeamDecription> CustomTeams { get; } = new List<CustomTeamDecription>();
        public IRulesValidator RulesValidator { get; }

        public ClassicMafiaRules()
        {
            RulesValidator = new ClassicRulesValidator(this);
        }

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
                    case TeamNameConstants.Sheriff:
                        team.Priority = SheriffPriority;
                        break;
                    default:
                        team.Priority = CivilianPriority;
                        break;
                }
            }
        }
    }
}