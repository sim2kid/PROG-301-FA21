using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class FiveYen : JPYCoin
    {
        public FiveYen()
        {
            _value = 5;
            _name = $"¥{_value}";
        }
    }
}
