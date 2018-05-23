using System;
using System.Collections.Generic;
using System.Linq;
using MafiaHelper.Core.Exceptions;

namespace MafiaHelper.Core
{
    /// <summary>
    /// Mafia round builder
    /// When builder created, starts listen all actions and votes in the game
    /// To stop listen, build the round with actions and votes
    /// </summary>
    public class MafiaRoundBuilder
    {
        private readonly IMafiaGame _game;

        private readonly IList<IChooseAction> _actions = new List<IChooseAction>();
        private readonly IList<IVoteAction> _votes = new List<IVoteAction>();
        private readonly IList<INeutralizeAction> _neutralizedEffects = new List<INeutralizeAction>();

        public MafiaRoundBuilder(IMafiaGame game)
        {
            _game = game;
            Initialize();
        }

        private void Initialize()
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
    }
}