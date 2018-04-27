namespace MafiaHelper.Core
{
    public interface IMafiaRules
    {
        bool IsGameComplete(IMafiaGame game);

        bool IsPlayerCanContinue(IMafiaPlayer player);

        void Initialize(IMafiaGame game);
    }
}