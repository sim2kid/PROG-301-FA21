using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFinal
{
    public class OddStats : Stats
    {
        public float ChanceOfSuccess => getSuccess();
        public float MaxLuck;

        private List<float> successMultiplier;
        private Random ran;

        public OddStats(float maxLuck = 1) 
        {
            MaxLuck = maxLuck;

            ran = new Random();
            SetStat("Strangeness", RandomNumber());
            SetStat("Reading Comp", RandomNumber());
            SetStat("Candle%", RandomNumber());
            SetStat("Holiday Spirit", RandomNumber());

            SetStat("Luck", RandomNumber() * MaxLuck);

            ChangeMultipliers();
        }

        public void AddLuck() 
        {
            float luck = GetStat("Luck");
            ChangeStat("Luck", (MaxLuck - luck) * RandomNumber());
        }

        public void RemoveLuck()
        {
            float luck = GetStat("Luck");
            ChangeStat("Luck", -luck * RandomNumber());
        }

        private void ChangeMultipliers() 
        {
            if(successMultiplier == null)
                successMultiplier = new List<float>();
            for (int i = 0; i < 4; i++)
            {
                successMultiplier.Add(RandomNumber());
            }
        }

        private float RandomNumber() 
        {
            return (float)ran.NextDouble();
        }

        private float getSuccess() 
        {
            float value = 0;
            var stats = AllStats.ToArray();

            for (int i = 0; i < stats.Length - 1; i++) 
            {
                value += stats[i].Value * successMultiplier[i] + (GetStat("Luck") * RandomNumber());
            }

            value /= stats.Length - 1;

            return Math.Clamp(value, 0, 1);
        }
    }
}
