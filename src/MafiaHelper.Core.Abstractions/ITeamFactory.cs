namespace MafiaHelper.Core
{
    public interface ITeamFactory
    {
        ITeam Create(string defaultTeamName);
        ITeam Create(string teamName, string effect, bool isEffectBlocking);
    }
}