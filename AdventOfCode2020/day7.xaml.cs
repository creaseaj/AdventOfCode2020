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
    /// Interaction logic for day7.xaml
    /// </summary>
    public partial class day7 : Window
    {
        public day7()
        {
            InitializeComponent();
        }

        private void checkBagsBtnClick(object sender, RoutedEventArgs e)
        {
            OutputTextBx.Text = Convert.ToString(adventOfCode.day7.checkBags(InputTextBx.Text));
        }

        private void checkInBagsBtnClick(object sender, RoutedEventArgs e)
        {
            OutputTextBxNew.Text = Convert.ToString(adventOfCode.day7.createBagDictionary(InputTextBx.Text));
        }
    }
}
