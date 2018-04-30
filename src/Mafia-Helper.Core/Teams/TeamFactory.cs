using System;
using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class TeamFactory : ITeamFactory
    {
        private static readonly IDictionary<DefaultTeamName, Func<IMafiaTeam>> Defaults = new Dictionary<DefaultTeamName, Func<IMafiaTeam>>()
        {
            {DefaultTeamName.Mafia, () => new MafiaTeam() },
            {DefaultTeamName.Civilian, () => new CivilianTeam() },
            {DefaultTeamName.Doctor, () => new DoctorTeam() },
            {DefaultTeamName.Whore, () => new WhoreTeam() }
        };

        public IMafiaTeam Create(DefaultTeamName defaultTeamName)
        {
            return Defaults[defaultTeamName]();
        }

        public IMafiaTeam Create(string name, string effectName)
        {
            //todo try parse effect name as default
            return new CustomTeam(name, effectName);
        }
    }
}