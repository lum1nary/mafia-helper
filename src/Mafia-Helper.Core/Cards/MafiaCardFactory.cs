using System;
using System.Collections.Generic;
using MafiaHelper.Core.Effects;

namespace MafiaHelper.Core.Cards
{
    public class MafiaCardFactory : IMafiaCardFactory
    {
        private static readonly IDictionary<string, Func<IMafiaCard>> _presets  = new Dictionary<string, Func<IMafiaCard>>()
        {
            {"mafia", () => new MafiaCard("Mafia", new KillEffect()) },
            {"whore", () => new MafiaCard("Whore", new FuckEffect()) },
            {"doctor", () => new MafiaCard("Doctor", new HealEffect()) }
        };

        public IMafiaCard Create(string presetCardName)
        {
            Func<IMafiaCard> result = null;
            if (_presets.TryGetValue(presetCardName.ToLower(), out result))
            {
                return result.Invoke();
            }

            throw new KeyNotFoundException("Can't find preset");
        }

        public IMafiaCard Create(string cardName, IMafiaCardEffect cardEffect)
        {
            if(string.IsNullOrEmpty(cardName))
                throw new ArgumentNullException("cardName cannot be null");

            if(cardEffect == null)
                throw new ArgumentNullException("cardEffect cannot be null");

            return new MafiaCard(cardName, cardEffect);
        }
    }
}