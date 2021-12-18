using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsFinal;
using System.Collections.Generic;

namespace SportsTest
{
    [TestClass]
    public class ScoringTest
    {
        List<IPlayer> players;

        public ScoringTest()
        {
            players = new List<IPlayer>();
            for (int i = 0; i < 10; i++)
                players.Add(new HumanPlayer(i, $"Mr Human #{i}"));
        }

        private Team makeTeam(ISport sport) 
        {
            return new Team(sport, "Team B", "B Team", players.ToArray());
        }

        [TestMethod]
        public void TennisStringTest() 
        {
            Match m = new Match(makeTeam(new Tennis()), makeTeam(new Tennis()));

            m.Score.HomePoints = 0;
            m.Score.AwayPoints = 1;

            Assert.AreEqual($"Love - 15", m.Score.ToString());

            m.Score.HomePoints = 1;
            m.Score.AwayPoints = 1;

            Assert.AreEqual($"15 - All", m.Score.ToString());

            m.Score.HomePoints = 3;
            m.Score.AwayPoints = 3;

            Assert.AreEqual($"Deuce", m.Score.ToString());

            m.Score.HomePoints = 3;
            m.Score.AwayPoints = 4;

            Assert.AreEqual($"Deuce - Away Advantage", m.Score.ToString());

            m.Score.HomePoints = 5;
            m.Score.AwayPoints = 4;

            Assert.AreEqual($"Deuce - Home Advantage", m.Score.ToString());
        }

        [TestMethod]
        public void TennisHasWin() 
        {
            Match m = new Match(makeTeam(new Tennis()), makeTeam(new Tennis()));

            m.Score.HomePoints = 5;
            m.Score.AwayPoints = 4;

            Assert.IsTrue(m.Score.Winner == null);

            m.Score.HomePoints = 6;
            m.Score.AwayPoints = 4;

            Assert.IsTrue(m.Score.Winner == m.HomeTeam);

            m.Score.HomePoints = 2;
            m.Score.AwayPoints = 0;

            Assert.IsTrue(m.Score.Winner == null);
        }

        [TestMethod]
        public void SoccorStringTest() 
        {
            Match m = new Match(makeTeam(new Soccer()), makeTeam(new Soccer()));

            m.Score.HomePoints = 4;
            m.Score.AwayPoints = 1;
            m.Score.Round = 5;

            Assert.AreEqual($"Minute 50: 4-1", m.Score.ToString());
        }

        [TestMethod]
        public void SoccorHasWinTest() 
        {
            Match m = new Match(makeTeam(new Soccer()), makeTeam(new Soccer()));

            m.Score.HomePoints = 4;
            m.Score.AwayPoints = 1;
            m.Score.Round = 6;

            Assert.AreEqual(m.HomeTeam, m.Score.Winner);

            m.Score.HomePoints = 4;
            m.Score.AwayPoints = 1;
            m.Score.Round = 3;

            Assert.AreEqual(null, m.Score.Winner);

            m.Score.HomePoints = 8;
            m.Score.AwayPoints = 1;
            m.Score.Round = 7;

            Assert.AreEqual(m.HomeTeam, m.Score.Winner);

            m.Score.HomePoints = 1;
            m.Score.AwayPoints = 1;
            m.Score.Round = 56;

            Assert.AreEqual(null, m.Score.Winner);

            m.Score.HomePoints = 4;
            m.Score.AwayPoints = 7;
            m.Score.Round = 9;

            Assert.AreEqual(m.AwayTeam, m.Score.Winner);
        }

    }
}
