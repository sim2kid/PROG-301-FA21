using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IMatch: IThing
    {
        public ITeam HomeTeam { get; set; }
        public ITeam AwayTeam { get; set; }
        public Score Score { get; }
        public bool InMatch { get; }

        public void PlayRound();
    }
}
