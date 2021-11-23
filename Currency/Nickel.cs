using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Nickel : USCoin
    {
        public Nickel()
        {
            _value = 0.05;
            _name = "Nickel";
        }
        public Nickel(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
