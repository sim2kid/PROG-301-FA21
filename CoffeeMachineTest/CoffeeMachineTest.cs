using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine;
using System;

namespace CoffeeMachineTest
{
    [TestClass]
    public class CoffeeMachineTest
    {
        [TestMethod]
        public void DefaultConstructorTest() 
        {
            //Arrange
            DrinkMachine dm;
            float maxCoffee;
            int maxCream;
            int maxSugar;
            float actualCoffee;
            int actualCream;
            int actualSugar;
            bool isRunning;

            //Act
            dm = new DrinkMachine();
            maxCoffee = 200f;
            maxCream = 100;
            maxSugar = 50;
            actualCoffee = 0;
            actualCream = 0;
            actualSugar = 0;
            isRunning = false;

            //Assert
            Assert.AreEqual(maxCoffee, dm.MaxCoffeeStorage);
            Assert.AreEqual(maxCream, dm.MaxCreamStorage);
            Assert.AreEqual(maxSugar, dm.MaxSugarStorage);
            Assert.AreEqual(actualCoffee, dm.CoffeeStored);
            Assert.AreEqual(actualCream, dm.CreamStored);
            Assert.AreEqual(actualSugar, dm.SugarStored);
            Assert.AreEqual(isRunning, dm.IsRunning);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(500)]
        public void RefillCoffeeTest(int amount) 
        {
            //Arrange
            DrinkMachine dm;
            //Act
            dm = new DrinkMachine();
            dm.RefillCoffee(amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, dm.MaxCoffeeStorage), dm.CoffeeStored);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(500)]
        public void RefillCreamTest(int amount)
        {
            //Arrange
            DrinkMachine dm;
            //Act
            dm = new DrinkMachine();
            dm.RefillCream(amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, dm.MaxCreamStorage), dm.CreamStored);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(500)]
        public void RefillSugarTest(int amount)
        {
            //Arrange
            DrinkMachine dm;
            //Act
            dm = new DrinkMachine();
            dm.RefillSugar(amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, dm.MaxSugarStorage), dm.SugarStored);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(500)]
        public void AddCreamTest(int amount)
        {
            //Arrange
            DrinkMachine dm;
            Coffee c;
            //Act
            c = new Coffee();
            dm = filledMachine();
            c = dm.AddCream(c, amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, dm.MaxCreamStorage), c.Cream);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(500)]
        public void AddSugarTest(int amount)
        {
            //Arrange
            DrinkMachine dm;
            Coffee c;
            //Act
            c = new Coffee();
            dm = filledMachine();
            c = dm.AddSugar(c, amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, dm.MaxSugarStorage), c.Sugar);
        }

        [DataTestMethod]
        [DataRow(-5, 16)]
        [DataRow(1, 16)]
        [DataRow(50, 16)]
        [DataRow(500,16)]
        [DataRow(1, 600)]
        [DataRow(50, 600)]
        [DataRow(500, 600)]
        public void AddCoffeeTest(int amount, int coffeeSize)
        {
            //Arrange
            DrinkMachine dm;
            Coffee c;
            //Act
            c = new Coffee("Coffee", "Coffee", coffeeSize);
            dm = filledMachine();
            c = dm.AddCoffee(c, amount);
            //Assert
            Assert.AreEqual(Math.Clamp(amount, 0, Math.Min(dm.MaxCoffeeStorage, c.Size)), c.Fullness);
            Assert.IsTrue(c.IsHot);
        }

        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(50)]
        [DataRow(500)]
        public void BrewCoffeeTest(int amount) 
        {
            //Arrange
            DrinkMachine dm;
            Coffee c;
            float coffee;
            int cream;
            int sugar;
            //Act
            coffee = amount;
            cream = amount;
            sugar = amount;
            dm = filledMachine();
            c = dm.BrewCoffee(coffee, cream, sugar);
            //Assert
            Assert.AreEqual(Math.Clamp(coffee, 0, Math.Min(dm.MaxCoffeeStorage, c.Size)), c.Fullness);
            Assert.AreEqual(Math.Clamp(sugar, 0, dm.MaxSugarStorage), c.Sugar);
            Assert.AreEqual(Math.Clamp(cream, 0, dm.MaxCreamStorage), c.Cream);
            Assert.IsTrue(c.IsHot);
        }


        private DrinkMachine filledMachine() 
        {
            DrinkMachine dm = new DrinkMachine(200, 200, 200);
            dm.RefillCoffee(200);
            dm.RefillCream(200);
            dm.RefillSugar(200);
            return dm;
        }
    }
}
