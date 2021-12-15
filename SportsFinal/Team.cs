using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Team : ITeam
    {
        public SuccessStats Stats { get; private set; }

        public ISport Sport { get; private set; }

        public List<IPlayer> Players { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Team(ISport sport, string name = "My Team", string description = "Awesome Generic Team", params IPlayer[] players) 
        {
            Sport = sport;
            Name = name;
            Description = description;
            Players = players.ToList();
            Stats = new SuccessStats();
        }

        public void NewDescription(string description)
        {
            Description = description;
        }

        public void NewName(string name)
        {
            Name = name;
        }
    }
}
