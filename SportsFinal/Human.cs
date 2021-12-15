using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class Human : IThing, IMortal, IStrength
    {
        protected OddStats stats;

        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public float Age { get; protected set; }

        public bool IsAlive { get; protected set; }

        public float Strength => stats.ChanceOfSuccess;

        public Human(string name = "No Name", string description = "A Human", float age = 10, bool living = true) 
        {
            stats = new OddStats();
            Name = name;
            Description = description;
            Age = age;
            IsAlive = living;
        }

        public void AddAge(float age)
        {
            Age += Math.Max(age,0);
        }

        public void Kill()
        {
            IsAlive = false;
        }

        public void NewAge(float age)
        {
            IsAlive = true;
        }

        public void NewDescription(string description)
        {
            Description = description;
        }

        public void NewName(string name)
        {
            Name = name;
        }

        public void Ressurect()
        {
            IsAlive = true;
        }
    }
}
