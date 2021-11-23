using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public abstract class USCoin : Coin
    {
        protected USCoinMintMark _mintMark;
        public USCoinMintMark MintMark { get => _mintMark; }

        public USCoin() 
        {
            _mintMark = USCoinMintMark.D;
        }
        public override string About() 
        {
            return $"US {_name} is from {_year}. It is worth ${_value.ToString("0.00")}. It was made in {GetMintNameFromMark(_mintMark)}";
        }
        public static string GetMintNameFromMark(USCoinMintMark mark) 
        {
            switch (mark) 
            {
                case USCoinMintMark.D:
                    return "Denver";
                case USCoinMintMark.P:
                    return "Philadephia";
                case USCoinMintMark.S:
                    return "San Francisco";
                case USCoinMintMark.W:
                    return "West Point";
                default:
                    return "Unknown";
            }
        }
    }
}
