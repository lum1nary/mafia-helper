namespace MafiaHelper.Core
{
    public class MafiaTeam : TeamBase
    {
        public MafiaTeam() : base(new KillEffect())
        {
        }

        public override string TeamName => TeamNameConstants.Mafia;
    }
}