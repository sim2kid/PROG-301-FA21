using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class SuccessStats: Stats
    {
        public int Wins { get => (int)GetStat("Wins"); set => SetStat("Wins", Math.Max(0, value)); }
        public int Loses { get => (int)GetStat("Loses"); set => SetStat("Loses", Math.Max(0, value)); }
    }
}
