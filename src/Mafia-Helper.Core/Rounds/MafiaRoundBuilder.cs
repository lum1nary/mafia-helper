using System.Collections.Generic;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public class MafiaRoundBuilder
    {
        private readonly IMafiaGame _game;

        private readonly IList<PlayerChooseEventArgs> _actions = new List<PlayerChooseEventArgs>();
        private readonly IList<PlayerVoteEventArgs> _votes = new List<PlayerVoteEventArgs>();

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
                    team.Choise += OnChoise;

                foreach (var player in _game.Players)
                    player.Vote += OnVote;
            }
            else
            {
                foreach (var team in _game.Teams)
                    team.Choise -= OnChoise;

                foreach (var player in _game.Players)
                    player.Vote -= OnVote;
            }
        }

        private void OnVote(object sender, PlayerVoteEventArgs args)
        {
            _votes.Add(args);
        }

        private void OnChoise(object sender, PlayerChooseEventArgs args)
        {
            _actions.Add(args);
        }

        public IMafiaRound Build()
        {
            var roundNumber = _game.Rounds.Count + 1;
            Subscribe(false);
            return new MafiaRound(roundNumber, _actions, _votes);
        }

        public void Validate()
        {
        }
    }
}