using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class PitchingMachine : IThing, IStrength, IPlayer
    {
        private OddStats stats;
        public float Strength => stats.ChanceOfSuccess;

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public int Number { get; protected set; }

        public PitchingMachine(int number = 0) 
        {
            stats = new OddStats(2);
            Number = number;
        }

        public void NewName(string name)
        {
            Name = name;
        }

        public void NewDescription(string description)
        {
            Description = description;
        }

        public void NewNumber(int num)
        {
            Number = num;
        }

        public void AddLuck()
        {
            stats.AddLuck();
        }

        public void RemoveLuck()
        {
            stats.RemoveLuck();
        }
    }
}
