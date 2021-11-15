using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    [Serializable]
    public class Coffee : Drink
    {
        public int Sugar { get; protected set; }
        public int Cream { get; protected set; }
        public Coffee(string name = "Coffee", string contents = "Coffee", float size = 16.0f,
            float fullness = 0.0f, bool hotness = false)
        {
            this.Name = name;
            this.Contents = contents;
            this.Size = size;
            this.Fullness = fullness;
            this.IsHot = hotness;
            defaultSipAmount = 2;
            Sugar = 0;
            Cream = 0;
        }

        public string AddSugar(int amount) 
        {
            Sugar += amount;
            return $"The ${Name} now has ${Sugar} sugar packets in it.";
        }
        public string AddCream(int amount)
        {
            Cream += amount;
            return $"The ${Name} now has ${Cream} creamers in it.";
        }

        public override string ListContents()
        {
            return $"The {Name} consists of {Contents} with {Sugar} sugar packets and {Cream} creamers.";
        }

        public override bool Equals(object other)
        {
            Coffee obj = other as Coffee;
            if (obj == null)
                return false;
            return base.Equals(other) && 
                Sugar == obj.Sugar &&
                Cream == obj.Cream;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
