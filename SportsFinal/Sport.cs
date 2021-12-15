using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public abstract class Sport : ISport, IScoring
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Score> MatchHistory { get; private set; }


        public Sport(string name = "Sport", string description = "SportsBall") 
        {
            Name = name;
            Description = description;
            MatchHistory = new List<Score>();
        }

        public void NewDescription(string description)
        {
            Description = description;
        }

        public void NewName(string name)
        {
            Name = name;
        }


        public virtual bool HasWin(int home, int away, int round)
        {
            if((home >= 10 || away >= 10) && home != away)
                return true;
            return false;
        }

        public virtual string ScoreToString(int home, int away, int round)
        {
            return $"Round: {round} | Home: {home}pts | Away: {away}pts";
        }

        public virtual ITeam WhoWon(int home, int away, int round, ITeam homeTeam, ITeam awayTeam)
        {
            if(!HasWin(home, away, round))
                return null;
            if (home > away)
                return homeTeam;
            return awayTeam;
        }
    }
}
