using MafiaHelper.Core.Effects;

namespace MafiaHelper.Core
{
    public class MafiaTeam : MafiaTeamBase
    {
        public override DefaultTeamName? DefTeamName => DefaultTeamName.Mafia;

        public MafiaTeam() : base(new KillEffect())
        {
        }
    }
}