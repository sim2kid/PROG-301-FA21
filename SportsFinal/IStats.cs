using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public interface IStats
    {
        public Dictionary<string, float> AllStats { get; }
        public void SetStat(string statName, float value);
        public void ChangeStat(string statName, float value);
        public float GetStat(string statName);
    }
}
