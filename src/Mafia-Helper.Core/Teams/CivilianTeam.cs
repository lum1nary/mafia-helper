using MafiaHelper.Core.Effects;

namespace MafiaHelper.Core
{
    public class CivilianTeam : MafiaTeamBase
    {
        public override DefaultTeamName? DefTeamName => DefaultTeamName.Civilian;

        public CivilianTeam() : base(new NullEffect())
        {
        }
    }
}