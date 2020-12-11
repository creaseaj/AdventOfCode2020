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
    /// Interaction logic for day8.xaml
    /// </summary>
    public partial class day8 : Window
    {
        public day8()
        {
            InitializeComponent();
        }

        private void RunCodeBtnClk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day8.runCode(InputTxt.Text));
        }

        private void ChangeCodeBtnClk(object sender, RoutedEventArgs e)
        {
            OutputChangeTxt.Text = Convert.ToString(adventOfCode.day8.runCodeEnd(InputTxt.Text));
        }
    }
}
