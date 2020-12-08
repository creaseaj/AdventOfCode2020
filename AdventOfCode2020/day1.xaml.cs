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
    /// Interaction logic for day1.xaml
    /// </summary>
    public partial class day1 : Window
    {
        public day1()
        {
            InitializeComponent();
        }

        private void findNumbersClick(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            outputNumber.Text = Convert.ToString(adventOfCode.day1.findNumbers(toChange));
            
        }

        private void find3Number(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            output3Number.Text = Convert.ToString(adventOfCode.day1.find3Numbers(toChange));
        }
    }
}
