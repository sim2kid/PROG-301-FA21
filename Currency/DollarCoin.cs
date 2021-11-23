using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class DollarCoin : USCoin
    {
        public DollarCoin()
        {
            _value = 1;
            _name = "DollarCoin";
        }
        public DollarCoin(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
