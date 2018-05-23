using System;
using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface ITeam : IRefreshable
    {
        event EventHandler<IChooseAction> Choice;

        int Priority { get; set; }

        bool IsCanChoose { get; }

        string TeamName { get; }

        PlayerCollection Participants { get; }

        IActionEffect Effect { get; }

        void Initialize(IEnumerable<IMafiaPlayer> participants);

        void DoChoose(IMafiaPlayer player);

        void RemoveExcluded(IMafiaPlayer participant);
    }
}