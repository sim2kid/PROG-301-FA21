using System;
using System.Collections.Generic;
using System.Text;

namespace Currency.JPY
{
    public class JPYCurrencyRepo : CurrencyRepo
    {
        public override string About()
        {
            return $"This repo has {GetCoinCount()} coins worth a total of ¥{TotalValue().ToString("0")}.";
        }

        public static ICurrencyRepo CreateChange(double Amount)
        {
            JPYCurrencyRepo repo = new JPYCurrencyRepo();
            if (Amount <= 0)
                return repo;

            int change = (int)(Amount);

            repo.AddCoins(new FiveHundredYen(), (int)Math.Round((double)(change / 500)));
            change = change % 500;
            repo.AddCoins(new OneHundredYen(), (int)Math.Round((double)(change / 100)));
            change = change % 100;
            repo.AddCoins(new FiftyYen(), (int)Math.Round((double)(change / 50)));
            change = change % 50;
            repo.AddCoins(new TenYen(), (int)Math.Round((double)(change / 10)));
            change = change % 10;
            repo.AddCoins(new FiveYen(), (int)Math.Round((double)(change / 5)));
            change = change % 5;
            repo.AddCoins(new OneYen(), change);
            return repo;
        }

        public static ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            return CreateChange(Math.Max(AmountTendered - TotalCost, 0));
        }

        public override ICurrencyRepo MakeChange(double Amount)
        {
            return CreateChange(Amount);
        }

        public override ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return CreateChange(AmountTendered, TotalCost);
        }
    }
}
