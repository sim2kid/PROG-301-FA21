using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency.JPY;

namespace UnitTestsCurrency
{
    [TestClass]
    public class JPYCoinTests
    {
        OneYen one;

        public JPYCoinTests() 
        {
            one = new OneYen();
        }

        [TestMethod]
        public void JPYOneConstructor() 
        {
            one = new OneYen();
            Assert.AreEqual(System.DateTime.Now.Year, one.Year);
        }

        [TestMethod]
        public void JPYOneValue() 
        {
            one = new OneYen();
            Assert.AreEqual(1, one.MonetaryValue);
        }

        [TestMethod]
        public void JPYOneAbout() 
        {
            one = new OneYen();
            Assert.AreEqual($"JPY ¥1 was minted in {System.DateTime.Now.Year}. It is worth ¥1.", one.About());
        }
    }
}
