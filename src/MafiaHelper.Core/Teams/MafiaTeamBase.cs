using System;
using System.Collections.Generic;
using System.Linq;

namespace MafiaHelper.Core
{
    public abstract class TeamBase : ITeam
    {
        public event EventHandler<IChooseAction> Choice;

        public int Priority { get; set; }
        public bool IsCanChoose => Participants.IsCanChoose;

        public abstract string TeamName { get; }
        public PlayerCollection Participants { get; private set; }

        public IActionEffect Effect { get; }

        protected TeamBase(IActionEffect effect)
        {
            Effect = effect;
        }

        public void Initialize(IEnumerable<IMafiaPlayer> participants)
        {
            Participants = new PlayerCollection(participants);
        }

        public void DoChoose(IMafiaPlayer player)
        {
            player.State.Apply(Effect);
            Choice?.Invoke(this, new PlayerChooseEventArgs(this, player));
        }

        public void RemoveExcluded(IMafiaPlayer participant)
        {
            Participants.Remove(participant);
        }

        public override string ToString()
        {
            return $"[{TeamName}]({string.Join(" ", Participants.Select(i =>$"Player #{i.PlayerNumber}"))})";
        }

        public void Refresh()
        {
            Effect.IsNeutralized = false;
        }
    }
}