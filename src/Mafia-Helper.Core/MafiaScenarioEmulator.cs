﻿using System;
using System.Linq;

namespace MafiaHelper.Core
{
    public class MafiaScenarioEmulator
    {
        public IMafiaRules Rules { get; set; }

        public IMafiaGame Game { get; private set; }

        public ITeamFactory TeamFactory { get; set; }

        private MafiaGameBuilder _gameBuilder;

        private MafiaRoundBuilder _roundBuilder;

        public void CreateGame()
        {
            if(TeamFactory == null)
                throw new InvalidOperationException("card factory is null");

            _gameBuilder = new MafiaGameBuilder(TeamFactory);
            _gameBuilder.SetRules(Rules);
        }

        public void AddPlayer(int playerNumber, string cardName)
        {
            _gameBuilder.AddPlayer(playerNumber, cardName);
        }

        public TeamEnumerator StartRound()
        {
            if (_roundBuilder != null)
            {
                _roundBuilder.Build();
                _roundBuilder = null;
            }

            _roundBuilder = new MafiaRoundBuilder(Game);
            _roundBuilder.Initialize();
            return new TeamEnumerator(Game.Teams);
        }

        public void AddChoice(IMafiaTeam team, int target)
        {
            var choosenPlayer = Game.Players.First(i => i.PlayerNumber == target);
            team.DoChoose(choosenPlayer);
        }

        public void AddVote(int source, int target)
        {
            var player = Game.Players.First(i => i.PlayerNumber == source);
            var choosenPlayer = Game.Players.First(i => i.PlayerNumber == target);
            player.DoVote(choosenPlayer);
        }

        public IMafiaRoundResult ApplyRound(TeamEnumerator enumerator)
        {
            enumerator.Dispose();
            _roundBuilder.Validate();
            var roundResult = Game.PlayNextRound(_roundBuilder.Build());
            _roundBuilder = null;
            return roundResult;
        }

        public void StartGame()
        {
            _gameBuilder.Validate();

            Game = _gameBuilder.Build();
            Game.Initialize();
        }
    }
}