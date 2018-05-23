using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IMafiaRules
    {
        int MinimumPlayerCount { get; }

        string RulesType { get; }

        IEffectProcessor EffectProcessor { get; }

        IReadOnlyList<string> DefaultTeams { get; }

        IReadOnlyList<CustomTeamDecription> CustomTeams { get; }

        IRulesValidator RulesValidator { get; }

        IRoundResult GetCurrentResult(IMafiaGame game);

        bool IsPlayerCanContinue(IMafiaGame game, IMafiaPlayer player);

        void Apply(IMafiaGame game);
    }
}