using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;

namespace MVC_Site.ViewModels
{
    [Serializable]
    public class Cafe
    {
        public DrinkMachine CoffeeMaker;
        public List<Drink> Drinks;
        private Guid guid;

        public Cafe() 
        {
            CoffeeMaker = new DrinkMachine();
            Drinks = new List<Drink>();
            guid= Guid.NewGuid();
        }

        public override bool Equals(object other)
        {
            var obj = other as Cafe;
            if (obj == null)
                return false;
            bool drinksEqual = Drinks.Count == obj.Drinks.Count;
            if(drinksEqual)
                for (int i = 0; i < Drinks.Count && i < obj.Drinks.Count; i++) 
                {
                    if(!Drinks[i].Equals(obj.Drinks[i]))
                        drinksEqual = false;
                }

            return CoffeeMaker.Equals(obj.CoffeeMaker) && drinksEqual;
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }
}
