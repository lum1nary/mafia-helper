using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaRules
    {
        int MinimumPlayerCount { get; }

        string RulesType { get; }

        IRoundResult GetCurrentResult(IMafiaGame game);

        bool IsPlayerCanContinue(IMafiaGame game, IMafiaPlayer player);

        void Apply(IMafiaGame game);

        IEffectProcessor EffectProcessor { get; }

        IReadOnlyList<string> DefaultTeams { get; }

        IReadOnlyList<CustomTeamDecription> CustomTeams { get; }
    }
}