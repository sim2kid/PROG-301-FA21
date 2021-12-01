using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class OneYen : JPYCoin
    {
        public OneYen() 
        {
            _value = 1;
            _name = $"¥{_value}";
        }
    }
}
