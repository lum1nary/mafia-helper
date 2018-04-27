namespace MafiaHelper.Core
{
    public interface IMafiaCard
    {
        string CardName { get; }

        int Priority { get; set; }

        IMafiaCardEffect Effect { get; }
    }
}