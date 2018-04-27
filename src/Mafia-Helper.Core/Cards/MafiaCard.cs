namespace MafiaHelper.Core.Cards
{
    public class MafiaCard : IMafiaCard
    {
        public string CardName { get; }

        public int Priority { get; set; }

        public IMafiaCardEffect Effect { get; }

        public MafiaCard(string cardName, IMafiaCardEffect effect)
        {
            CardName = cardName;
            Effect = effect;
        }
    }
}