using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public abstract class Stats: IStats
    {
        public Stats() 
        {
            AllStats = new Dictionary<string, float>();
        }

        public Dictionary<string, float> AllStats { get; private set; }

        public void ChangeStat(string statName, float value)
        {
            if (AllStats.TryGetValue(statName, out float statValue))
            {
                AllStats[statName] = statValue + value;
            }
            else 
            {
                AllStats.Add(statName, value);
            }
        }

        public float GetStat(string statName) 
        {
            float value = 0;
            if(!AllStats.TryGetValue(statName, out value))
                SetStat(statName, value);
            return value;
        }

        public void SetStat(string statName, float value)
        {
            if (AllStats.TryGetValue(statName, out float statValue))
            {
                AllStats[statName] = value;
            }
            else
            {
                AllStats.Add(statName, value);
            }
        }
    }
}
