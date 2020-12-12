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
    /// Interaction logic for day9.xaml
    /// </summary>
    public partial class day9 : Window
    {
        public day9()
        {
            InitializeComponent();
        }

        private void chkNumBtnClk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day9.runXmas(InputTxt.Text));
        }

        private void brkNumBtnClk(object sender, RoutedEventArgs e)
        {
            BrkTxt.Text = Convert.ToString(adventOfCode.day9.breakXmas(InputTxt.Text));
        }
    }
}
