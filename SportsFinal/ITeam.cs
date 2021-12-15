using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface ITeam: IThing
    {
        public SuccessStats Stats { get; }
        public ISport Sport { get; }
        public List<IPlayer> Players { get; set; }
    }
}
