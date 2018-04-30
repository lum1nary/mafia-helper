namespace MafiaHelper.Core
{
    public interface ITeamFactory
    {
        IMafiaTeam Create(DefaultTeamName defaultTeamName);
        IMafiaTeam Create(string teamName, string effect);
    }
}