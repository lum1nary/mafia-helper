using MafiaHelper.Core.Effects;

namespace MafiaHelper.Core
{
    public class WhoreTeam : MafiaTeamBase
    {
        public override DefaultTeamName? DefTeamName => DefaultTeamName.Whore;

        public WhoreTeam() : base(new FuckEffect())
        {
        }
    }
}