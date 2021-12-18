using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsFinal;
using System.Collections.Generic;

namespace SportsTest
{
    [TestClass]
    public class PlayerTests
    {
        List<IPlayer> _players;
        public PlayerTests() 
        {
            setUp();
        }

        void setUp() 
        {
            _players = new List<IPlayer>();
            for (int i = 0; i < 10; i++)
                _players.Add(new HumanPlayer(i));
            for (int i = 0; i < 10; i++)
                _players.Add(new PitchingMachine(10 + i));
        }

        [TestMethod]
        public void CheckNumber() 
        {
            // Arrange
            // Act
            setUp();
            // Assert
            for (int i = 0; i < _players.Count; i++)
                Assert.AreEqual(i, _players[i].Number);
        }

        [TestMethod]
        public void StrengthInBounds() 
        {
            // Arrange
            // Act
            setUp();
            // Assert
            for (int i = 0; i < _players.Count; i++)
                Assert.IsTrue(_players[i].Strength >= 0 && _players[i].Strength <= 1);
        }
    }
}
