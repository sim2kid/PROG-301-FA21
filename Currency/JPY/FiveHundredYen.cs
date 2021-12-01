using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class FiveHundredYen : JPYCoin
    {
        public FiveHundredYen()
        {
            _value = 500;
            _name = $"¥{_value}";
        }
    }
}
