using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;
using System;

namespace CoffeeMachineTest
{
    [TestClass]
    public class CoffeeTest
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            //Arrange
            Coffee d;
            string defaultName = "Coffee";
            string defaultContent = "Coffee";
            float defaultSize = 16;
            float defaultFullness = 0;
            bool defaultHotness = false;
            int defaultCream = 0;
            int defaultSugar = 0;

            //Act
            d = new Coffee();

            //Assert
            Assert.AreEqual(defaultName, d.Name);
            Assert.AreEqual(defaultContent, d.Contents);
            Assert.AreEqual(defaultSize, d.Size);
            Assert.AreEqual(defaultFullness, d.Fullness);
            Assert.AreEqual(defaultHotness, d.IsHot);
            Assert.AreEqual(defaultCream, d.Cream);
            Assert.AreEqual(defaultSugar, d.Sugar);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(500)]
        public void AddSugarTest(int amount) 
        {
            //Arrange
            Coffee c;
            //Act
            c = new Coffee();
            c.AddSugar(amount);
            //Assert
            Assert.AreEqual(amount, c.Sugar);
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(500)]
        public void AddCreamTest(int amount)
        {
            //Arrange
            Coffee c;
            //Act
            c = new Coffee();
            c.AddCream(amount);
            //Assert
            Assert.AreEqual(amount, c.Cream);
        }
    }
}
