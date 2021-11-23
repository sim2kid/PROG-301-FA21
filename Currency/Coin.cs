using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public abstract class Coin : ICoin
    {
        protected int _year;
        protected double _value;
        protected string _name;

        public int Year { get => _year; }
        public double MonetaryValue { get => _value; }
        public string Name { get => _name; }


        public virtual string About()
        {
            return $"{_name} is from {_year}. It is worth {_value}.";
        }

        public Coin() 
        {
            _name = string.Empty;
            _year = DateTime.Now.Year;
            _value = 0;
        }
    }
}
