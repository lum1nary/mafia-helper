using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public interface IRulesValidator
    {
        void ValidateGameStart(IList<IMafiaPlayer> players);

        void ValidateRound(IRound round);
    }
}