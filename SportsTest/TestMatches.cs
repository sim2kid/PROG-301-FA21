using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsFinal;
using System.Collections.Generic;

namespace SportsTest
{
    [TestClass]
    public class TestMatches
    {
        Team a;
        Team b;
        List<IPlayer> players;

        public TestMatches() 
        {
            players = new List<IPlayer>();
            for (int i = 0; i < 10; i++)
                players.Add(new HumanPlayer(i, $"Mr Human #{i}"));
            a = new Team(new Tennis(), "Team A", "A Team", players.ToArray());
            b = new Team(new Tennis(), "Team B", "B Team", players.ToArray());
        }

        [TestMethod]
        public void ConstructorValues() 
        {
            Match m = new Match(a, b);

            Assert.AreEqual(a, m.HomeTeam);
            Assert.AreEqual(b, m.AwayTeam);

            Assert.AreEqual(true, m.InMatch);
        }

        [TestMethod]
        public void PointOnRound() 
        {
            for (int y = 0; y < 100; y++)
            {
                Match m = new Match(a, b);

                int i;
                for (i = 0; i < 10; i++)
                {
                    m.PlayRound();
                    if (!m.InMatch)
                    {
                        i++;
                        break;
                    }
                }

                Assert.AreEqual(i, m.Round);
                Assert.AreEqual(i, m.Score.HomePoints + m.Score.AwayPoints);
            }
        }
    }
}
