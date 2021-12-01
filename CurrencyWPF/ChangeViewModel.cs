using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency;
using Currency.US;
using Currency.JPY;

namespace CurrencyWPF
{
    public class ChangeViewModel
    {
        ICurrencyRepo repo;

        public void MakeChange(Currency currency, float value) 
        {
            switch (currency) 
            {
                default:
                case Currency.USD:
                    repo = new USCurrencyRepo();
                    break;
                case Currency.JPY:
                    repo = new JPYCurrencyRepo();
                    break;
            }
            repo = repo.MakeChange(value);
        }

        public List<string> GetCoins() 
        {
            if (repo == null)
                return new List<string>();

            List<string> list = new List<string>();
            foreach (ICoin coin in repo.Coins) 
            {
                list.Add(coin.GetType().ToString());
            }
            return list;
        }

    }


    public enum Currency
    {
        USD,
        JPY
    }
}
