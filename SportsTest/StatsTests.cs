using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsFinal;
using System.Collections.Generic;

namespace SportsTest
{
    [TestClass]
    public class StatsTests
    {
        [TestMethod]
        public void OddStatsWithinRange()
        {
            // Arrange
            List<OddStats> stats = new List<OddStats>();
            List<float> outputs = new List<float>();
            for (int i = 0; i < 10; i++)
                stats.Add(new OddStats(i));
            // Act
            foreach (OddStats o in stats)
                for (int j = 0; j < 20; j++)
                    outputs.Add(o.ChanceOfSuccess);
            
            bool success = true;
            foreach(var thing in outputs)
                if(thing < 0 || thing > 1)
                    success = false;

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void OddStatsLuckChangeRange()
        {
            // Arrange
            List<OddStats> stats = new List<OddStats>();
            for (int i = 0; i < 10; i++)
                stats.Add(new OddStats(i));

            // Act
            bool AddSuccess = true;
            foreach (OddStats o in stats)
            {
                for (int j = 0; j < 20; j++)
                {
                    float originalLuck = o.GetStat("Luck");
                    o.AddLuck();
                    if (o.GetStat("Luck") < originalLuck || o.GetStat("Luck") > o.MaxLuck)
                        AddSuccess = false;
                }
            }

            bool RemoveSuccess = true;
            foreach (OddStats o in stats)
            {
                for (int j = 0; j < 20; j++)
                {
                    float originalLuck = o.GetStat("Luck");
                    o.RemoveLuck();
                    if (o.GetStat("Luck") < 0 || o.GetStat("Luck") > originalLuck)
                        RemoveSuccess = false;
                }
            }

            // Assert
            Assert.IsTrue(AddSuccess);
            Assert.IsTrue(RemoveSuccess);
        }

        [TestMethod]
        public void AddStat() 
        {
            // Arrange
            SuccessStats s = new SuccessStats();
            
            // Act
            s.SetStat("Boo", 212);
            s.SetStat("Boo2", 212);
            s.ChangeStat("Boo2", 100);

            // Assert
            Assert.AreEqual(212, s.GetStat("Boo"));
            Assert.AreEqual(312, s.GetStat("Boo2"));
            Assert.AreEqual(0, s.GetStat("B003"));

        }

        [TestMethod]
        public void WinLoseStats() 
        {
            // Arrange
            SuccessStats s = new SuccessStats();

            // Act
            s.Wins = 20;
            s.Loses = -20;

            s.SetStat("Loses", 20);

            // Assert
            Assert.AreEqual(20, s.Wins);
            Assert.AreEqual(20, s.GetStat("Wins"));
            Assert.AreEqual(20, s.Loses);
            Assert.AreEqual(20, s.GetStat("Loses"));
        }
    }
}
