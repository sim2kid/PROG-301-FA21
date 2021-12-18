using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsFinal;
using System.Collections.Generic;

namespace SportsTest
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void NewDescriptionTest() 
        {
            Team t = new Team(new Tennis());
            
            t.NewDescription("boo");

            Assert.AreEqual("boo", t.Description);
        }

        [TestMethod]
        public void NewNameTest()
        {
            Team t = new Team(new Tennis());

            t.NewName("boo");

            Assert.AreEqual("boo", t.Name);
        }

        [TestMethod]
        public void CheckStatsTests()
        {
            Team t = new Team(new Tennis());

            t.Stats.Wins = 10;

            Assert.AreEqual(10, t.Stats.Wins);
            Assert.AreEqual(0, t.Stats.Loses);
        }

        [TestMethod]
        public void NoNegitiveSucess() 
        {
            SuccessStats stats = new SuccessStats();
            stats.Loses = -10;
            stats.Wins = -10;

            Assert.AreEqual(0, stats.Loses);
            Assert.AreEqual(0, stats.Wins);
        }
    }
}
