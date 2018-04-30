using MafiaHelper.Core.Effects;

namespace MafiaHelper.Core
{
    public class DoctorTeam : MafiaTeamBase
    {
        public override DefaultTeamName? DefTeamName => DefaultTeamName.Doctor;

        public DoctorTeam() : base(new HealEffect())
        {
        }
    }
}