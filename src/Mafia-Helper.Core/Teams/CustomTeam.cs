namespace MafiaHelper.Core
{
    public class CustomTeam : MafiaTeamBase
    {
        public override string TeamName { get; }
        public override DefaultTeamName? DefTeamName { get; }

        public CustomTeam(string teamName, string effect, DefaultTeamName? defName = null) : base(new CustomEffect(effect))
        {
            TeamName = teamName;
            DefTeamName = defName;
        }
    }
}