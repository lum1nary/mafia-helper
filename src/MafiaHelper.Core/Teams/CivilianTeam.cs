namespace MafiaHelper.Core
{
    public class CivilianTeam : TeamBase
    {
        public override string TeamName => TeamNameConstants.Civilian;

        public CivilianTeam() : base(new NullEffect())
        {
        }
    }
}