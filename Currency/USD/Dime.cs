using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Dime : USCoin
    {
        public Dime()
        {
            _value = 0.1;
            _name = "Dime";
        }
        public Dime(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
