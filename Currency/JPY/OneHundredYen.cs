using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class OneHundredYen : JPYCoin
    {
        public OneHundredYen()
        {
            _value = 100;
            _name = $"¥{_value}";
        }
    }
}
