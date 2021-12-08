using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency;
using Currency.US;
using Currency.JPY;

namespace CurrencyMVC
{
    public class ChangeViewModel
    {
        ICurrencyRepo repo;

        public double Value => repo.TotalValue();

        public ChangeViewModel()
        {
            repo = new USCurrencyRepo();
        }

        public List<string> CoinNames 
        {
            get 
            {
                List<string> list = new List<string>();
                if (repo == null)
                    return list;
                foreach (ICoin coin in repo.ValidCoins) 
                {
                    list.Add(coin.Name);
                }
                return list;
            }
        }

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
                list.Add($"{coin.Name} {repo.Symbol}{coin.MonetaryValue}");
            }
            return list;
        }

        /// <summary>
        /// Adds a coind based on the CoinName index
        /// </summary>
        /// <param name="index"></param>
        public void AddCoin(int index) 
        {
            if(index < 0 || index >= CoinNames.Count)
                return;
            repo.AddCoin(repo.ValidCoins[index]);
        }

    }


    public enum Currency
    {
        USD,
        JPY
    }
}
