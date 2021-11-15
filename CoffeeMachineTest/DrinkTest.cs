using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;
using System;

namespace CoffeeMachineTest
{
    [TestClass]
    public class DrinkTest
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            //Arrange
            Drink d;
            string defaultName = "Unknown Drink";
            string defaultContent = "Unknown Contents";
            float defaultSize = 16;
            float defaultFullness = 0;
            bool defaultHotness = false;

            //Act
            d = new Drink();

            //Assert
            Assert.AreEqual(defaultName, d.Name);
            Assert.AreEqual(defaultContent, d.Contents);
            Assert.AreEqual(defaultSize, d.Size);
            Assert.AreEqual(defaultFullness, d.Fullness);
            Assert.AreEqual(defaultHotness, d.IsHot);
        }
        [TestMethod]
        public void DefaultSipTest()
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 16);
            d.Sip();
            //Assert
            Assert.AreEqual(d.defaultSipAmount, d.Size - d.Fullness);
        }
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(200)]
        public void SipTest(int amount)
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 16);
            d.Sip(amount);

            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, d.Size), d.Size - d.Fullness);
        }
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(200)]
        public void FillTest(int amount)
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 0);
            d.Fill(amount);

            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, d.Size), d.Fullness);
        }
        [TestMethod]
        public void CoolTest() 
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 10,true);
            d.Cool();

            //Assert
            Assert.IsFalse(d.IsHot);
        }
        [TestMethod]
        public void HeatTest()
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 10, false);
            d.Heat();

            //Assert
            Assert.IsTrue(d.IsHot);
        }
        [TestMethod]
        public void ContentsAboutTest()
        {
            //Arrange
            Drink d;

            //Act
            d = new Drink("", "", 16, 10, false);

            //Assert
            Assert.AreEqual(d.ListContents(), d.About());
        }
    }
}
