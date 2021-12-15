using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ISport: IThing, IScoring
    {
        public List<Score> MatchHistory { get; }
    }
}
