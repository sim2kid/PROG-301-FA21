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
using System.Diagnostics;

namespace CurrencyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex _float = new Regex(@"^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$");
        private static readonly Regex _int = new Regex(@"^[0-9]+$");

        ChangeViewModel model;
        private static bool IsFloat(string text)
        {
            return _float.IsMatch(text);
        }
        private static bool IsInt(string text)
        {
            return _int.IsMatch(text);
        }

        bool useFloat, handle;
        Currency currentCurrency;

        

        public MainWindow()
        {
            model = new ChangeViewModel();
            useFloat = true;
            currentCurrency = Currency.USD;
            InitializeComponent();
        }

        private void PreviewFloatInput(object sender, TextCompositionEventArgs e)
        {
            var box = ((TextBox)(e.Source));
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            if(useFloat)
                e.Handled = !IsFloat(full);
            else
                e.Handled = !IsInt(full);
        }

        private void Currency_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void Currency_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void NewCurrency(bool usesFloat, Currency currency)
        {
            currentCurrency = currency;
            if (!usesFloat) 
            {
                txtChange.Text = txtChange.Text.ToString().Split('.')[0];
            }
            useFloat = usesFloat;
        }

        private void Handle() 
        {
            switch (currency.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "$USD":
                    NewCurrency(true, Currency.USD);
                    break;
                case "¥JPY":
                    NewCurrency(false, Currency.JPY);
                    break;
            }
        }

        private void MakeChange(object sender, RoutedEventArgs e) 
        {
            float.TryParse(txtChange.Text, out float f);
            model.MakeChange(currentCurrency, f);
            ClearScreen();
            FillScreen(model.GetCoins());
        }

        private void FillScreen(List<string> things) 
        {
            foreach (string s in things) 
            {
                lstContent.Items.Add(s);
            }
        }

        private void ClearScreen() 
        {
            lstContent.Items.Clear();
        }
    }
}
