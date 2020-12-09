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
    /// Interaction logic for day6.xaml
    /// </summary>
    public partial class day6 : Window
    {
        public day6()
        {
            InitializeComponent();
        }

        private void scanSeatsClick(object sender, RoutedEventArgs e)
        {
            OutputText.Text = Convert.ToString(adventOfCode.day6.countAnswers(InputText.Text));
        }

        private void findEmptySeatClick(object sender, RoutedEventArgs e)
        {
            NewOutputText.Text = Convert.ToString(adventOfCode.day6.countAllAnswers(InputText.Text));

        }
    }
}
