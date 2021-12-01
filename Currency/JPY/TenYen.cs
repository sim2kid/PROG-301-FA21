using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class TenYen : JPYCoin
    {
        public TenYen() 
        {
            _value = 10;
            _name = $"¥{_value}";
        }
    }
}
