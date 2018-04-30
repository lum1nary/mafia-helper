using System;
using System.Collections.Generic;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public abstract class MafiaTeamBase : IMafiaTeam
    {
        public event EventHandler<PlayerChooseEventArgs> Choise;

        public int Priority { get; set; }

        public virtual string TeamName => DefTeamName != null ? DefTeamName.ToString() : "None";
        public abstract DefaultTeamName? DefTeamName { get; }

        public IReadOnlyList<IMafiaPlayer> Participants { get; private set; }

        public IActionEffect Effect { get; }

        protected MafiaTeamBase(IActionEffect effect)
        {
            Effect = effect;
        }

        public void Initialize(IEnumerable<IMafiaPlayer> participants)
        {
            Participants = new List<IMafiaPlayer>(participants);
        }

        public void DoChoose(IMafiaPlayer player)
        {
            player.State.ApplyEffect(Effect);
            Choise?.Invoke(this, new PlayerChooseEventArgs(this, player));
        }
    }
}