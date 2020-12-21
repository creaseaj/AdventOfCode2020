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
    /// Interaction logic for conwayWindow.xaml
    /// </summary>
    public partial class conwayWindow : Window
    {
        
        List<bool[,,]> conwayCubes = new List<bool[,,]>();
        int viewLayer = 0, viewCube = 0;
        public conwayWindow(bool[,,] conwayCubeIn)
        {
            InitializeComponent();
            addCube(conwayCubeIn);
            layerNum.Text = "Layer: " + Convert.ToString(viewLayer);
        }
        public void addCube(bool[,,] conwayCubeIn)
        {
            cubesList.Items.Add("Iteration " + Convert.ToString(conwayCubes.Count));
            conwayCubes.Add(conwayCubeIn);
        }

        private void drawLayer()
        {
            canvas.Children.Clear();
            int size = conwayCubes[viewCube].GetLength(0);
            int rectSize = (Convert.ToInt32(canvas.Height)  + 10) / size -10;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (conwayCubes[viewCube][viewLayer, j,i])
                    {
                        Rectangle rectangle = new Rectangle
                        {
                            Height = rectSize,
                            Width = rectSize,
                        };
                        rectangle.Fill = Brushes.Red;
                        Canvas.SetLeft(rectangle, i * (rectSize + 10));
                        Canvas.SetTop(rectangle, j * (rectSize + 10));
                        canvas.Children.Add(rectangle);
                    }
                }
            }
        }

        private void lyrUpBtn(object sender, RoutedEventArgs e)
        {
            viewLayer = viewLayer == conwayCubes[viewCube].GetLength(0) - 1 ? conwayCubes[viewCube].GetLength(0) - 1 : viewLayer + 1;
            layerNum.Text = "Layer: " + Convert.ToString(viewLayer);
            drawLayer();
        }

        private void newCubeSelected(object sender, SelectionChangedEventArgs e)
        {
            viewCube = cubesList.SelectedIndex;
            layerNum.Text = "Layer: " + Convert.ToString(viewLayer);
            viewLayer = viewLayer == conwayCubes[viewCube].GetLength(0) - 1 ? conwayCubes[viewCube].GetLength(0) - 1 : viewLayer;
            drawLayer();
        }

        private void lyrDwnBtn(object sender, RoutedEventArgs e)
        {
            viewLayer = viewLayer == 0 ? 0 : viewLayer - 1;
            layerNum.Text = "Layer: " + Convert.ToString(viewLayer);
            drawLayer();
        }
    }
}
