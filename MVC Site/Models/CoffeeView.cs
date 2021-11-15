using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine;

namespace MVC_Site.ViewModels
{
    public class CoffeeView
    {
        Cafe _cafe;

        DrinkMachine CoffeeMaker { get => _cafe.CoffeeMaker; }
        List<Drink> Drinks { get => _cafe.Drinks; }

        public int DrinkCount { get=> Drinks.Count; }
        public CoffeeView(Cafe cafe = null) 
        {
            if(cafe == null)
                cafe = new Cafe();
            _cafe = cafe;
        }

        public string GetCoffeeLevels() 
        {
            return $"{CoffeeMaker.CoffeeStored}/{CoffeeMaker.MaxCoffeeStorage}";
        }
        public string GetSugarLevels() 
        {
            return $"{CoffeeMaker.SugarStored}/{CoffeeMaker.MaxSugarStorage}";
        }
        public string GetCreamLevels() 
        {
            return $"{CoffeeMaker.CreamStored}/{CoffeeMaker.MaxCreamStorage}";
        }
        public void RefillMachine(float Coffee, int Sugar, int Cream) 
        {
            CoffeeMaker.RefillCoffee(Coffee);
            CoffeeMaker.RefillSugar(Sugar);
            CoffeeMaker.RefillCream(Cream);
        }
        public void BrewCoffee(float size, int cream, int sugar) 
        {
            Coffee c = CoffeeMaker.BrewCoffee(size, cream, sugar);
            Drinks.Add(c);
        }


        public string LastDrinkName(int i = -1) 
        {
            if (i == -1)
                i = Drinks.Count - 1;
            return DrinkName(Drinks[i]);
        }
        public string LastDrinkContent(int i = -1)
        {
            if (i == -1)
                i = Drinks.Count - 1;
            return DrinkContent(Drinks[i]);
        }
        public string LastDrinkSize(int i = -1)
        {
            if (i == -1)
                i = Drinks.Count - 1;
            return DrinkSize(Drinks[i]);
        }
        public string LastDrinkSugar(int i = -1)
        {
            if (i == -1)
                i = Drinks.Count - 1;
            return CoffeeSugar((Coffee)Drinks[i]);
        }
        public string LastDrinkCream(int i = -1)
        {
            if (i == -1)
                i = Drinks.Count - 1;
            return CoffeeCream((Coffee)Drinks[i]);
        }


        private string DrinkName(Drink c) 
        {
            return c.Name;
        }
        private string DrinkContent(Drink c) 
        {
            return c.Contents;
        }
        private string DrinkSize(Drink c) 
        {
            return $"{c.Fullness}/{c.Size} oz";
        }
        private string CoffeeSugar(Coffee c) 
        {
            return $"{c.Sugar} Sugar{(c.Sugar > 1 ? "s" : "")}";
        }
        private string CoffeeCream(Coffee c) 
        {
            return $"{c.Cream} Cream{(c.Cream > 1 ? "s" : "")}";
        }


        public void SaveCafe(string saveLocation) 
        {
            IFormatter formatter = new BinaryFormatter();
            Stream wStream;

            using (wStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(wStream, _cafe);
            }
        }

        public void LoadCafe(string fileLocation) 
        {
            IFormatter formatter = new BinaryFormatter();
            Stream rStream;
            Cafe cafe;
            using (rStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                cafe = (Cafe)formatter.Deserialize(rStream);
            }
            _cafe = cafe;
        }
    }
}
