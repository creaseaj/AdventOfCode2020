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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdventOfCode2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void d1p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day1.findNumbers(InputTxt.Text));
        }

        private void d1p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day1.find3Numbers(InputTxt.Text));
        }

        private void d2p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day2.tobogganCorp(InputTxt.Text));
        }

        private void d2p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day2.tobogganCorpIndex(InputTxt.Text));
        }

        private void d3p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day3.firstPathTrees(InputTxt.Text));
        }

        private void d3p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day3.secondPathTrees(InputTxt.Text));
        }

        private void d4p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day4.checkPassports(InputTxt.Text));
        }
        private void d4p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day4.validatePassports(InputTxt.Text));
        }
        private void d5p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day5.getHighestID(InputTxt.Text));
        }
        private void d5p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day5.findEmptySeat(InputTxt.Text));
        }
        private void d6p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day6.countAnswers(InputTxt.Text));
        }
        private void d6p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day6.countAllAnswers(InputTxt.Text));
        }
        private void d7p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day7.checkBags(InputTxt.Text));
        }
        private void d7p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day7.createBagDictionary(InputTxt.Text));
        }
        private void d8p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day8.runCode(InputTxt.Text));
        }
        private void d8p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day8.runCodeEnd(InputTxt.Text));
        }
        private void d9p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day9.runXmas(InputTxt.Text));
        }
        private void d9p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day9.breakXmas(InputTxt.Text));
        }
        private void d10p1Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day10.countJolts(InputTxt.Text));
        }
        private void d10p2Clk(object sender, RoutedEventArgs e)
        {
            OutputTxt.Text = Convert.ToString(adventOfCode.day10.checkJoltVarieties(InputTxt.Text));
        }
    }
}
