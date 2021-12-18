using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Tennis: Sport
    {
        public Tennis() :base("Tenis", "Wacking Balls With Rackets")
        {
        
        }

        public override bool HasWin(int home, int away, int round)
        {
            home -= 3;
            away -= 3;
            if (Math.Abs(home - away) >= 2d && (home + away >= 0)) 
            {
                return true;
            }
            return false;
        }

        public override string ScoreToString(int home, int away, int round)
        {
            string h = pointToString(home);
            string a = (home == away) ? "All" : pointToString(away);
            string result = $"{h} - {a}";

            if (home >= 3 && away >= 3) 
            {
                result = $"Deuce";
                if (home > away)
                    result += " - Home Advantage";
                if (home < away)
                    result += " - Away Advantage";
            }

            if (HasWin(home, away, round)) 
            {
                if (home > away)
                    result = "Home Wins!";
                else
                    result = "Away Wins!";
            }

            return result;
        }

        private string pointToString(int point) 
        {
            switch (point)
            { 
                case 0:
                    return "Love";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 4:
                default:
                    return "40";
            }
        }
    }
}
