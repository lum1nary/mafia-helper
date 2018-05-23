using System;
using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class TeamFactory : ITeamFactory
    {
        private static readonly IDictionary<string, Func<ITeam>> Defaults = new Dictionary<string, Func<ITeam>>()
        {
            {TeamNameConstants.Mafia, () => new MafiaTeam() },
            {TeamNameConstants.Civilian, () => new CivilianTeam() },
            {TeamNameConstants.Doctor, () => new DoctorTeam() },
            {TeamNameConstants.Whore, () => new WhoreTeam() }
        };

        public ITeam Create(string defaultTeamName)
        {
            return Defaults[defaultTeamName]();
        }

        public ITeam Create(string name, string effectName, bool isEffectBlocking)
        {
            return new CustomTeam(name, effectName, isEffectBlocking);
        }
    }
}