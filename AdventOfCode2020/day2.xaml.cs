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
    /// Interaction logic for day2.xaml
    /// </summary>
    public partial class day2 : Window
    {
        public day2()
        {
            InitializeComponent();
        }

        private void findNumbersClick(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            outputNumber.Text = Convert.ToString(adventOfCode.day2.tobogganCorp(toChange));

        }

        private void FindNewNumbersClick(object sender, RoutedEventArgs e)
        {
            string toChange = inputBox.Text;
            outputNewNumber.Text = Convert.ToString(adventOfCode.day2.tobogganCorpIndex(toChange));
        }
    }
}
