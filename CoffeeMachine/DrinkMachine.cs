using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    [Serializable]
    public class DrinkMachine
    {
        private float coffee;
        private int cream;
        private int sugar;

        public float MaxCoffeeStorage { get; protected set; }
        public int MaxCreamStorage { get; protected set; }
        public int MaxSugarStorage { get; protected set; }
        public float CoffeeStored { get => coffee; protected set { coffee = Math.Clamp(value, 0, MaxCoffeeStorage); } }
        public int CreamStored { get => cream; protected set { cream = Math.Clamp(value, 0, MaxCreamStorage); } }
        public int SugarStored { get => sugar; protected set { sugar = Math.Clamp(value, 0, MaxSugarStorage); } }
        public bool IsRunning { get; protected set; }

        protected Guid guid;

        public override bool Equals(object other)
        {
            var obj = other as DrinkMachine;
            if (obj == null)
                return false;
            return MaxCoffeeStorage == obj.MaxCoffeeStorage &&
                MaxCreamStorage == obj.MaxCreamStorage &&
                MaxSugarStorage == obj.MaxSugarStorage &&
                CoffeeStored == obj.CoffeeStored &&
                CreamStored == obj.CreamStored &&
                SugarStored == obj.SugarStored &&
                IsRunning == obj.IsRunning;
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }

        public DrinkMachine(float maxCoffee = 200f, int maxCream = 100, int maxSugar = 50) 
        {
            this.MaxCoffeeStorage = maxCoffee;
            this.MaxCreamStorage = maxCream;
            this.MaxSugarStorage = maxSugar;
            CoffeeStored = 0;
            CreamStored = 0;
            SugarStored = 0;
            IsRunning = false;
            guid = Guid.NewGuid();
        }

        public string RefillCoffee(float amount) 
        {
            CoffeeStored += amount;
            return $"This Coffee Machine now has {CoffeeStored}/{MaxCoffeeStorage} oz of Coffee in it.";
        }
        public string RefillSugar(int amount)
        {
            SugarStored += amount;
            return $"This Coffee Machine now has {SugarStored}/{MaxSugarStorage} oz of Coffee in it.";
        }
        public string RefillCream(int amount)
        {
            CreamStored += amount;
            return $"This Coffee Machine now has {CreamStored}/{MaxCreamStorage} oz of Coffee in it.";
        }
        public Coffee AddCream(Coffee c, int amount) 
        {
            amount = Math.Clamp(amount, 0, CreamStored);
            CreamStored -= amount;
            c.AddCream(amount);
            return c;
        }
        public Coffee AddSugar(Coffee c, int amount) 
        {
            amount = Math.Clamp(amount, 0, SugarStored);
            SugarStored -= amount;
            c.AddSugar(amount);
            return c;
        }
        public Coffee AddCoffee(Coffee c, float amount) 
        {
            amount = Math.Clamp(amount, 0, Math.Min(c.Size, CoffeeStored));
            CoffeeStored -= amount;
            c.Fill(amount);
            c.Heat();
            return c;
        }
        public Coffee BrewCoffee(float size, int cream, int sugar)
        {
            Coffee c = new Coffee("Coffee", "Coffee", size);
            c = AddCoffee(c, size);
            c = AddCream(c, cream);
            c = AddSugar(c, sugar);
            return c;
        }
    }
}
