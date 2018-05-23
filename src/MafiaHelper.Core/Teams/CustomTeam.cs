namespace MafiaHelper.Core
{
    public class CustomTeam : TeamBase
    {
        public override string TeamName { get; }

        public CustomTeam(string teamName, string effect, bool isBlocking) 
            : base(new CustomEffect(effect, isBlocking))
        {
            TeamName = teamName;
        }
    }
}