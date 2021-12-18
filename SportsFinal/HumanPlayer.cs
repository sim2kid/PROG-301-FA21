using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class HumanPlayer : Human, IPlayer
    {
        public int Number { get; private set; }

        public HumanPlayer(int number = 0,
            string name = "No Name", string description = "A Human", float age = 10, bool living = true) 
            : base(name, description, age, living)
        {
            Number = number;
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
