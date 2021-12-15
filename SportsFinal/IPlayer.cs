using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IPlayer: IThing, IStrength
    {
        public int Number { get; }

        public void NewNumber(int num);

        public void AddLuck();
        public void RemoveLuck();
    }
}
