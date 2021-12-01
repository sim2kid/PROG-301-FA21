using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public abstract class JPYCoin : Coin
    {
        public override string About()
        {
            return $"JPY {_name} was minted in {_year}. It is worth ¥{_value.ToString("0")}.";
        }
    }
}
