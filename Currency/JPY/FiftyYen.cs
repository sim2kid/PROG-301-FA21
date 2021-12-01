using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class FiftyYen : JPYCoin
    {
        public FiftyYen()
        {
            _value = 50;
            _name = $"¥{_value}";
        }
    }
}
