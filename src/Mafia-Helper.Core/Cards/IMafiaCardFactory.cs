namespace MafiaHelper.Core.Cards
{
    public interface IMafiaCardFactory
    {
        IMafiaCard Create(string presetCardName);

        IMafiaCard Create(string cardName, IMafiaCardEffect cardEffect);
    }
}