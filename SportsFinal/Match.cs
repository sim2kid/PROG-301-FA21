using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Match : IMatch
    {
        public int Round { get => Score.Round; set => Score.Round = value; }

        public ITeam HomeTeam { get; set; }
        public ITeam AwayTeam { get; set; }

        public Score Score { get; protected set; }

        public bool InMatch { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public Match(ITeam home, ITeam away, string name = "Match", string description = "Awesome Generic Match")
        {
            HomeTeam = home;
            AwayTeam = away;
            Score = new Score(home, away, home.Sport);
            Name = name;
            Description = description;
            InMatch = true;
            Round = 0;
        }

        public void NewDescription(string description)
        {
            Description = description;
        }

        public void NewName(string name)
        {
            Name = name;
        }

        public virtual void PlayRound()
        {
            if (InMatch == false)
            {
                return;
            }

            Random ran = new Random();

            float homeStrength = 0;
            float awayStrength = 0;

            foreach (IPlayer p in HomeTeam.Players)
                homeStrength += p.Strength;
            homeStrength /= HomeTeam.Players.Count;
            homeStrength += (float)(ran.NextDouble() * 0.5);

            foreach (IPlayer p in AwayTeam.Players)
                awayStrength += p.Strength;
            awayStrength /= AwayTeam.Players.Count;
            awayStrength += (float)(ran.NextDouble() * 0.5);

            bool homeWin = homeStrength >= awayStrength;

            if (homeWin)
                Score.HomePoints++;
            else 
                Score.AwayPoints++;

            
            ITeam winteam = homeWin ? HomeTeam : AwayTeam;
            ITeam loseteam = !homeWin ? HomeTeam : AwayTeam;
            foreach (IPlayer p in winteam.Players)
                if (ran.NextDouble() < 0.1)
                    p.AddLuck();
            foreach (IPlayer p in loseteam.Players)
                if (ran.NextDouble() < 0.1)
                    p.RemoveLuck();

            Round++;
            if (Score.Winner != null)
            {
                InMatch = false;
                Score.Winner.Stats.Wins++;
                Score.Loser.Stats.Loses++;
            }
        }
    }
}
