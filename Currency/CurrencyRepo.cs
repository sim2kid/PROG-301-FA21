using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo() 
        {
            Coins = new List<ICoin>();
        }

        public virtual string About()
        {
            return $"This repo has {GetCoinCount()} coins worth a total of {TotalValue()}.";
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public virtual ICurrencyRepo MakeChange(double Amount)
        {
            throw new Exception("Can't make change with an Unknown Currency.");
        }

        public virtual ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            throw new Exception("Can't make change with an Unknown Currency.");
        }

        public ICoin RemoveCoin(ICoin c)
        {
            if (Coins.Remove(c))
                return c;
            else
                return null;
        }

        public double TotalValue()
        {
            double amount = 0;
            foreach (ICoin coin in Coins) 
            {
                amount += coin.MonetaryValue;
            }
            return amount;
        }

        public void AddCoins(ICoin coin, int amount) 
        {
            for (int i = 0; i < amount; i++)
                AddCoin(coin);
        } 
    }
}
