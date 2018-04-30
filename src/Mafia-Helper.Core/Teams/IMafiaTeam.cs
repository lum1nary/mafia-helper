using System;
using System.Collections.Generic;
using MafiaHelper.Core.EventArgs;

namespace MafiaHelper.Core
{
    public interface IMafiaTeam
    {
        event EventHandler<PlayerChooseEventArgs> Choise;

        int Priority { get; set; }

        string TeamName { get; }

        DefaultTeamName? DefTeamName { get; }

        IReadOnlyList<IMafiaPlayer> Participants { get; }

        IActionEffect Effect { get; }

        void Initialize(IEnumerable<IMafiaPlayer> participants);

        void DoChoose(IMafiaPlayer player);
    }
}