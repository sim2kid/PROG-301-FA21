using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    [Serializable]
    public class Drink
    {
        private float fullness;
        private float size;
        public string Name { get; protected set; }
        public string Contents { get; protected set; }
        public float Size { get { return size; } protected set { size = Math.Max(value, 0); } } // ounces
        public float Fullness { get { return fullness; } protected set { fullness = Math.Clamp(value,0,Size);} } // ounces
        public bool IsHot { get; protected set; } 

        public float defaultSipAmount; //ounces

        protected Guid guid;

        public Drink(string name = "Unknown Drink", string contents = "Unknown Contents", float size = 16.0f,
            float fullness = 0.0f, bool hotness = false) 
        {
            this.Name = name;
            this.Contents = contents;
            this.Size = size;
            this.Fullness = fullness;
            this.IsHot = hotness;
            defaultSipAmount = 2;
            this.guid = Guid.NewGuid();
        }

        public string Sip() 
        {
            return Sip(defaultSipAmount);
        }

        public string Sip(float amount) 
        {
            Fullness -= amount;
            return $"The {Name} has been sipped {amount} ounces and now has {Fullness} ounces of {Contents} left.";
        }

        public string Fill(float amount) 
        {
            Fullness += amount;
            return $"The {Name} has been filled {amount} ounces and now has {Fullness} ounces of {Contents} left.";
        }

        public string Cool() 
        {
            IsHot = false;
            return $"The {Name} is now Cool.";
        }
        public string Heat()
        {
            IsHot = true;
            return $"The {Name} is now Hot.";
        }

        public virtual string ListContents() 
        {
            return $"The {Name} consists of ${Contents}.";
        }

        public string About() 
        {
            return ListContents();
        }

        public override bool Equals(object other)
        {
            Drink obj = other as Drink;
            if (obj == null)
                return false;
            return Name == obj.Name &&
                Contents == obj.Contents &&
                Size == obj.Size &&
                Fullness == obj.Fullness &&
                IsHot == obj.IsHot &&
                defaultSipAmount == obj.defaultSipAmount;
        }

        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }
    }
}
