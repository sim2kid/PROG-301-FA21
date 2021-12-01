using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Currency;
using Currency.JPY;

namespace UnitTestsCurrency
{
    [TestClass]
    public class JPYRepoTests
    {
        ICurrencyRepo repo;
        OneYen one;
        FiveYen five;
        TenYen ten;
        FiftyYen fifty;
        OneHundredYen hundred;
        FiveHundredYen fiveHundred;


        public JPYRepoTests()
        {
            repo = new JPYCurrencyRepo();
            one = new OneYen();
            five = new FiveYen();
            ten = new TenYen();
            fifty = new FiftyYen();
            hundred = new OneHundredYen();
            fiveHundred = new FiveHundredYen();
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterOne, coinCountAfterFiveMoreOnes;
            int numOnes = 5;


            Double valueOrig, valueAfterOne, valueAfterFiveMoreOnes;
            Double valueAfterFive, valueAfterTen, valueAfterFifty, valueAfterHundred, valueAfterFiveHundred;
            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();

            repo.AddCoin(one);
            coinCountAfterOne = repo.GetCoinCount();
            valueAfterOne = repo.TotalValue();

            for (int i = 0; i < numOnes; i++)
            {
                repo.AddCoin(one);
            }
            coinCountAfterFiveMoreOnes = repo.GetCoinCount();
            valueAfterFiveMoreOnes = repo.TotalValue();

            repo.AddCoin(five);
            valueAfterFive = repo.TotalValue();
            repo.AddCoin(ten);
            valueAfterTen = repo.TotalValue();
            repo.AddCoin(fifty);
            valueAfterFifty = repo.TotalValue();
            repo.AddCoin(hundred);
            valueAfterHundred = repo.TotalValue();
            repo.AddCoin(fiveHundred);
            valueAfterFiveHundred = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterOne);
            Assert.AreEqual(coinCountAfterOne + numOnes, coinCountAfterFiveMoreOnes);

            Assert.AreEqual(valueOrig + one.MonetaryValue, valueAfterOne);
            Assert.AreEqual(valueAfterOne + (numOnes * one.MonetaryValue), valueAfterFiveMoreOnes);

            Assert.AreEqual(valueAfterFiveMoreOnes + five.MonetaryValue, valueAfterFive);
            Assert.AreEqual(valueAfterFive + ten.MonetaryValue, valueAfterTen);
            Assert.AreEqual(valueAfterTen + fifty.MonetaryValue, valueAfterFifty);
            Assert.AreEqual(valueAfterFifty + hundred.MonetaryValue, valueAfterHundred);
            Assert.AreEqual(valueAfterHundred + fiveHundred.MonetaryValue, valueAfterFiveHundred);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterOne, coinCountAfterFiveMoreOnes;
            int numOnes = 5;


            Double valueOrig, valueAfterOne, valueAfterFiveMoreOnes;
            Double valueAfterFive, valueAfterTen, valueAfterFifty, valueAfterHundred, valueAfterFiveHundred;

            repo = new JPYCurrencyRepo();  //reset repo

            //add some coins
            repo.AddCoin(one);

            for (int i = 0; i < numOnes; i++)
            {
                repo.AddCoin(one);
            }
            repo.AddCoin(five);
            repo.AddCoin(ten);
            repo.AddCoin(fifty);
            repo.AddCoin(hundred);
            repo.AddCoin(fiveHundred);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCoin(one);
            coinCountAfterOne = repo.GetCoinCount();
            valueAfterOne = repo.TotalValue();

            for (int i = 0; i < numOnes; i++)
            {
                repo.RemoveCoin(one);
            }
            coinCountAfterFiveMoreOnes = repo.GetCoinCount();
            valueAfterFiveMoreOnes = repo.TotalValue();

            repo.RemoveCoin(five);
            valueAfterFive = repo.TotalValue();
            repo.RemoveCoin(ten);
            valueAfterTen = repo.TotalValue();
            repo.RemoveCoin(fifty);
            valueAfterFifty = repo.TotalValue();
            repo.RemoveCoin(hundred);
            valueAfterHundred = repo.TotalValue();
            repo.RemoveCoin(fiveHundred);
            valueAfterFiveHundred = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterOne);
            Assert.AreEqual(coinCountAfterOne - numOnes, coinCountAfterFiveMoreOnes);

            Assert.AreEqual(valueOrig - one.MonetaryValue, valueAfterOne);
            Assert.AreEqual(valueAfterOne - (numOnes * one.MonetaryValue), valueAfterFiveMoreOnes);

            Assert.AreEqual(valueAfterFiveMoreOnes - five.MonetaryValue, valueAfterFive);
            Assert.AreEqual(valueAfterFive - ten.MonetaryValue, valueAfterTen);
            Assert.AreEqual(valueAfterTen - fifty.MonetaryValue, valueAfterFifty);
            Assert.AreEqual(valueAfterFifty - hundred.MonetaryValue, valueAfterHundred);
            Assert.AreEqual(valueAfterHundred - fiveHundred.MonetaryValue, valueAfterFiveHundred);
        }

        [TestMethod]
        public void MakeChangeTest() 
        {
            // Arrange
            JPYCurrencyRepo OneOne, SixHundrend, SixSixSix, SixTeen;

            // Act
            OneOne = (JPYCurrencyRepo)JPYCurrencyRepo.CreateChange(2);
            SixHundrend = (JPYCurrencyRepo)JPYCurrencyRepo.CreateChange(600);
            SixSixSix = (JPYCurrencyRepo)JPYCurrencyRepo.CreateChange(666);
            SixTeen = (JPYCurrencyRepo)JPYCurrencyRepo.CreateChange(16);

            // Assert

            Assert.AreEqual(OneOne.Coins.Count, 2);
            Assert.AreEqual(OneOne.Coins[0].GetType(), typeof(OneYen));
            Assert.AreEqual(OneOne.Coins[1].GetType(), typeof(OneYen));

            Assert.AreEqual(SixHundrend.Coins.Count, 2);
            Assert.AreEqual(SixHundrend.Coins[0].GetType(), typeof(FiveHundredYen));
            Assert.AreEqual(SixHundrend.Coins[1].GetType(), typeof(OneHundredYen));

            Assert.AreEqual(SixSixSix.Coins.Count, 6);
            Assert.AreEqual(SixSixSix.Coins[0].GetType(), typeof(FiveHundredYen));
            Assert.AreEqual(SixSixSix.Coins[1].GetType(), typeof(OneHundredYen));
            Assert.AreEqual(SixSixSix.Coins[2].GetType(), typeof(FiftyYen));
            Assert.AreEqual(SixSixSix.Coins[3].GetType(), typeof(TenYen));
            Assert.AreEqual(SixSixSix.Coins[4].GetType(), typeof(FiveYen));
            Assert.AreEqual(SixSixSix.Coins[5].GetType(), typeof(OneYen));

            Assert.AreEqual(SixTeen.Coins.Count, 3);
            Assert.AreEqual(SixTeen.Coins[0].GetType(), typeof(TenYen));
            Assert.AreEqual(SixTeen.Coins[1].GetType(), typeof(FiveYen));
            Assert.AreEqual(SixTeen.Coins[2].GetType(), typeof(OneYen));
        }
    }
}