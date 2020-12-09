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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window day1Window = new day1();
            day1Window.Show();
        }
        private void day2_Click(object sender, RoutedEventArgs e)
        {
            Window day2Window = new day2();
            day2Window.Show();
        }

        private void day3_Click(object sender, RoutedEventArgs e)
        {
            Window day3Window = new day3();
            day3Window.Show();
        }

        private void day4_Click(object sender, RoutedEventArgs e)
        {
            Window day4Window = new day4();
            day4Window.Show();
        }

        private void day5Click(object sender, RoutedEventArgs e)
        {
            Window day5Window = new day5();
            day5Window.Show();
        }

        private void day6Click(object sender, RoutedEventArgs e)
        {
            Window day6Window = new day6();
            day6Window.Show();
        }
    }
}
