using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdventOfCode2020
{
    /// <summary>
    /// Interaction logic for day4.xaml
    /// </summary>
    public partial class day4 : Window
    {
        public day4()
        {
            InitializeComponent();
        }

        private void checkPassportsClick(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            outputNumber.Text = Convert.ToString(adventOfCode.day4.checkPassports(toChange));
        }

        private void validatePassports(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            outputNumber.Text = Convert.ToString(adventOfCode.day4.validatePassports(toChange));
        }
    }
}
