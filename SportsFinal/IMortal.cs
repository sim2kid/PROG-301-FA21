using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IMortal
    {
        public float Age { get; }
        public bool IsAlive { get; }

        public void NewAge(float age);
        public void AddAge(float age);
        public void Kill();
        public void Ressurect();
    }
}
