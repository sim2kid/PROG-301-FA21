using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Score
    {
        public int Round;
        public int HomePoints;
        public int AwayPoints;

        public ITeam Winner => winTeam();
        public ITeam Loser => loseTeam();

        private ITeam homeTeam;
        private ITeam awayTeam;
        private IScoring ScoreConditions;

        public Score(ITeam Home, ITeam Away, IScoring sport) 
        {
            Round = 0;
            homeTeam = Home;
            awayTeam = Away;
            ScoreConditions = sport;
        }

        private ITeam loseTeam() 
        {
            if (ScoreConditions.HasWin(HomePoints, AwayPoints, Round))
            {
                return ScoreConditions.WhoWon(HomePoints, AwayPoints, Round, awayTeam, homeTeam);
            }
            return null;
        }

        private ITeam winTeam() 
        {
            if (ScoreConditions.HasWin(HomePoints, AwayPoints, Round)) 
            {
                return ScoreConditions.WhoWon(HomePoints, AwayPoints, Round, homeTeam, awayTeam);
            }
            return null;
        }

        public override string ToString()
        {
            return ScoreConditions.ScoreToString(HomePoints, AwayPoints, Round);
        }
    }
}
