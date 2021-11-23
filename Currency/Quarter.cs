using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Quarter : USCoin
    {
        public Quarter()
        {
            _value = 0.25;
            _name = "Quarter";
        }
        public Quarter(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
