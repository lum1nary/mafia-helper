using System;
using System.Collections.Generic;
using System.Linq;
using MafiaHelper.Core.Exceptions;

namespace MafiaHelper.Core
{
    public class MafiaRoundBuilder
    {
        private readonly IMafiaGame _game;

        private readonly IList<IChooseAction> _actions = new List<IChooseAction>();
        private readonly IList<IVoteAction> _votes = new List<IVoteAction>();
        private readonly IList<INeutralizeAction> _neutralizedEffects = new List<INeutralizeAction>();

        public MafiaRoundBuilder(IMafiaGame game)
        {
            _game = game;
        }

        public void Initialize()
        {
            Subscribe(true);
        }

        private void Subscribe(bool value)
        {
            if (value)
            {
                foreach (var team in _game.Teams)
                    team.Choice += OnChoice;

                foreach (var player in _game.Players)
                    player.Vote += OnVote;

                _game.Rules.EffectProcessor.EffectNeutralized += OnEffectNeutralized;

            }
            else
            {
                foreach (var team in _game.Teams)
                    team.Choice -= OnChoice;

                foreach (var player in _game.Players)
                    player.Vote -= OnVote;

                _game.Rules.EffectProcessor.EffectNeutralized += OnEffectNeutralized;
            }
        }

        private void OnEffectNeutralized(object sender, INeutralizeAction action)
        {
            _neutralizedEffects.Add(action);
        }

        private void OnVote(object sender, IVoteAction action)
        {
            _votes.Add(action);
        }

        private void OnChoice(object sender, IChooseAction action)
        {
            _actions.Add(action);
        }

        public IRound Build()
        {
            var roundNumber = _game.Rounds.Count + 1;
            var round = new MafiaRound(roundNumber, _actions, _votes, _neutralizedEffects);

            _game.Rules.EffectProcessor.Process(round);

            Subscribe(false);
            return round;
        }

        public void Validate()
        {
            var teamExceptions = new List<SelfChoiceException<ITeam>>();
            var playerExceptions = new List<SelfChoiceException<IMafiaPlayer>>();

            foreach (var action in _actions)
            {
                if (action.Team.Participants.Contains(action.TargetPlayer))
                {
                    teamExceptions.Add(new SelfChoiceException<ITeam>(action.Team));
                }
            }

            foreach (var vote in _votes)
            {
                if (vote.SourcePlayer == vote.TargetPlayer)
                {
                    playerExceptions.Add(new SelfChoiceException<IMafiaPlayer>(vote.SourcePlayer));
                }
            }

            var exceptions = teamExceptions.Cast<Exception>().Concat(playerExceptions).ToList();

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}