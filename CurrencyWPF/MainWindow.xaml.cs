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
        private static bool IsFloat(string text)
        {
            return _float.IsMatch(text);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PreviewFloatInput(object sender, TextCompositionEventArgs e)
        {
            var box = ((TextBox)(e.Source));
            string full = box.Text.Insert(box.CaretIndex, e.Text);
            e.Handled = !IsFloat(full);
        }
    }
}
