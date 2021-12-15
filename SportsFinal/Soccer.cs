using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Soccer : Sport
    {
        public Soccer(): base("Soccer", "It's a Foot and Ball game, but American."){}

        public override bool HasWin(int home, int away, int round)
        {
            return (round >= 6 && home != away);

        }
        public override string ScoreToString(int home, int away, int round)
        {
            return $"Minute {round * 10}: {home}-{away}";
        }
    }
}
