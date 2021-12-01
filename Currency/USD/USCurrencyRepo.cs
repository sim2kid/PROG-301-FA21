using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class USCurrencyRepo : CurrencyRepo
    {
        public override string About()
        {
            return $"This repo has {GetCoinCount()} coins worth a total of ${TotalValue().ToString("0.00")}.";
        }

        public static ICurrencyRepo CreateChange(double Amount)
        {
            USCurrencyRepo repo = new USCurrencyRepo();
            if (Amount <= 0)
                return repo;

            int change = (int)(Amount * 100);

            repo.AddCoins(new DollarCoin(), (int)Math.Round((double)(change / 100)));
            change = change % 100;
            repo.AddCoins(new HalfDollar(), (int)Math.Round((double)(change / 50)));
            change = change % 50;
            repo.AddCoins(new Quarter(), (int)Math.Round((double)(change / 25)));
            change = change % 25;
            repo.AddCoins(new Dime(), (int)Math.Round((double)(change / 10)));
            change = change % 10;
            repo.AddCoins(new Nickel(), (int)Math.Round((double)(change / 5)));
            change = change % 5;
            repo.AddCoins(new Penny(), change);
            return repo;
        }
        public static ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            return CreateChange(Math.Max(AmountTendered - TotalCost, 0));
        }

        public override ICurrencyRepo MakeChange(double Amount)
        {
            return USCurrencyRepo.CreateChange(Amount);
        }

        public override ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return USCurrencyRepo.CreateChange(AmountTendered, TotalCost);
        }
    }
}
