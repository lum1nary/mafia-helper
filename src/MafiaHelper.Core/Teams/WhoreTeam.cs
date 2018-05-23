namespace MafiaHelper.Core
{
    public class WhoreTeam : TeamBase
    {
        public override string TeamName => TeamNameConstants.Whore;

        public WhoreTeam() : base(new FuckEffect())
        {
        }
    }
}