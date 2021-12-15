using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IScoring
    {
        public string ScoreToString(int home, int away, int round);
        public bool HasWin(int home, int away, int round);
        public ITeam WhoWon(int home, int away, int round, ITeam homeTeam, ITeam awayTeam);
    }
}
