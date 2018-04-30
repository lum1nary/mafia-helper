namespace MafiaHelper.Core
{
    public class DoctorTeam : TeamBase
    {
        public override string TeamName => TeamNameConstants.Doctor;
        public DoctorTeam() : base(new HealEffect())
        {
        }
    }
}