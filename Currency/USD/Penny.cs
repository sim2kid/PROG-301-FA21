using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class Penny : USCoin
    {
        public Penny() 
        {
            _value = 0.01;
            _name = "Penny";
        }
        public Penny(USCoinMintMark mintMark) : this()
        {
            _mintMark = mintMark;
        }
    }
}
