using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sprint_6_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex _numbers = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsNumberAllowed(string text)
        {
            return !_numbers.IsMatch(text);
        }

        CoffeeView cv;
        public MainWindow()
        {
            InitializeComponent();
            cv = new CoffeeView();
            UpdateCoffeeMachine();
        }

        public void UpdateCoffeeMachine() 
        {
            Label CoffeeLevels = (Label)this.FindName("labelCoffeeAmout");
            Label SugarLevels = (Label)this.FindName("labelSugarAmout");
            Label CreamLevels = (Label)this.FindName("labelCreamAmout");

            CoffeeLevels.Content = cv.GetCoffeeLevels();
            SugarLevels.Content = cv.GetSugarLevels();
            CreamLevels.Content = cv.GetCreamLevels();
        }

        private void RefillMachine(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Tag.ToString();
            switch (value) 
            {
                case "Coffee":
                    cv.RefillMachine(float.MaxValue, 0, 0);
                    break;
                case "Sugar":
                    cv.RefillMachine(0, int.MaxValue, 0);
                    break;
                case "Cream":
                    cv.RefillMachine(0, 0, int.MaxValue);
                    break;
            }
            UpdateCoffeeMachine();
        }

        private void BrewCoffee(object sender, RoutedEventArgs e)
        {
            float size = StringToInt(((TextBox)this.FindName("txtBoxCoffee")).Text);
            int sugar = StringToInt(((TextBox)this.FindName("txtBoxSugar")).Text);
            int cream = StringToInt(((TextBox)this.FindName("txtBoxCream")).Text);

            ((TextBox)this.FindName("txtBoxCoffee")).Text = "0";
            ((TextBox)this.FindName("txtBoxSugar")).Text = "0";
            ((TextBox)this.FindName("txtBoxCream")).Text = "0";

            cv.BrewCoffee(size, cream, sugar);
            AddCoffee();
            UpdateCoffeeMachine();
        }

        private void RenderCoffees() 
        {
            StackPanel coffeeList = (StackPanel)this.FindName("panelCoffeeList");
            coffeeList.Children.Clear();
            for (int i = 0; i < cv.DrinkCount; i++)
                AddCoffee(i);
        }

        private void AddCoffee(int i = -1) 
        {
            StackPanel coffeeList = (StackPanel)this.FindName("panelCoffeeList");
            StackPanel coffee = new StackPanel();
            coffeeList.Children.Add(coffee);

            Label name = new Label();
            name.Content = cv.LastDrinkName(i);
            coffee.Children.Add(name);

            Label content = new Label();
            content.Content = cv.LastDrinkContent(i);
            coffee.Children.Add(content);

            Label size = new Label();
            size.Content = cv.LastDrinkSize(i);
            coffee.Children.Add(size);

            Label sugar = new Label();
            sugar.Content = cv.LastDrinkSugar(i);
            coffee.Children.Add(sugar);

            Label cream = new Label();
            cream.Content = cv.LastDrinkCream(i);
            coffee.Children.Add(cream);
        }

        private void PreviewNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumberAllowed(e.Text);
        }

        private int StringToInt(string str) 
        {
            try
            {
                return Int32.Parse(str);
            }
            catch 
            {
                return 0;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            cv.LoadCafe("./Cafe.cafe");
            RenderCoffees();
            UpdateCoffeeMachine();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            cv.SaveCafe("./Cafe.cafe");
        }
    }
}
