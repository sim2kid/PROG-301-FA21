using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class HalfDollar : USCoin
    {
        public HalfDollar()
        {
            _value = 0.5;
            _name = "HalfDollar";
        }
        public HalfDollar(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
