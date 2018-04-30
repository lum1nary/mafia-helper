using System.Collections.Generic;
using MafiaHelper.Core.Rules;

namespace MafiaHelper.Core
{
    public interface IMafiaRules
    {
        int MinimumPlayerCount { get; }

        string RulesType { get; }

        IMafiaRoundResult GetCurrentResult(IMafiaGame game);

        bool IsPlayerCanContinue(IMafiaGame game, IMafiaPlayer player);

        void Apply(IMafiaGame game);

        IReadOnlyList<DefaultTeamName> DefaultTeams { get; }

        IReadOnlyList<CustomTeamDecription> CustomTeams { get; }
    }
}