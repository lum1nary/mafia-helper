using System;
using System.Collections.Generic;
using System.Linq;
using MafiaHelper.Core.Exceptions;

namespace MafiaHelper.Core
{
    public class ClassicRulesValidator : IRulesValidator
    {
        private readonly IMafiaRules _rules;

        public ClassicRulesValidator(IMafiaRules rules)
        {
            _rules = rules;
        }

        public void ValidateGameStart(IList<IMafiaPlayer> players)
        {
            var exceptions = new List<Exception>();

            if(players.Count < _rules.MinimumPlayerCount)
                exceptions.Add(new NotEnoughPlayersException(_rules.MinimumPlayerCount, players.Count));

            var mafiaCount = players.Count(p => p.Team.TeamName == TeamNameConstants.Mafia || 
                                                p.Team.TeamName == TeamNameConstants.DonMafia);

            if ((players.Count / 2) <= mafiaCount)
                exceptions.Add(new NoGameReasonException("mafia count must be less then half"));

            if(exceptions.Any())
                throw new StartGameException(exceptions);
        }

        public void ValidateRound(IRound round)
        {
            var teamExceptions = new List<SelfChoiceException<ITeam>>();
            var playerExceptions = new List<SelfChoiceException<IMafiaPlayer>>();

            foreach (var action in round.Actions)
            {
                if (action.Team.Participants.Contains(action.TargetPlayer))
                {
                    teamExceptions.Add(new SelfChoiceException<ITeam>(action.Team));
                }
            }

            foreach (var vote in round.Votes)
            {
                if (vote.SourcePlayer == vote.TargetPlayer)
                {
                    playerExceptions.Add(new SelfChoiceException<IMafiaPlayer>(vote.SourcePlayer));
                }
            }

            var exceptions = teamExceptions.Cast<Exception>().Concat(playerExceptions).ToList();

            if (exceptions.Any())
            {
                throw new RoundException(exceptions);
            }
        }
    }
}