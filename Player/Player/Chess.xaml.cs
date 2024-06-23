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
using CColor = System.Drawing.Color;

namespace Player
{
    /// <summary>
    /// Логика взаимодействия для Chess.xaml
    /// </summary>
    public partial class Chess : Window
    {
        public Chess()
        {
            InitializeComponent();
            PaintCels(3, 10, 3, 11);
        }
        public void PaintCels(int x1, int x2, int y1, int y2)
        {

            int x = -1;
            for (int y = y1; y < y2; y++)
            {
                if (x < x1)
                {
                    x = x1;
                    while (x2 > x)
                    {
                        var cellBlack = new Border
                        {
                            Background = Brushes.Green
                        };
                        var cellWhite = new Border
                        {
                            Background = Brushes.YellowGreen
                        };
                        Grid.SetColumn(cellWhite, x);
                        Grid.SetRow(cellWhite, y);
                        Base.Children.Add(cellWhite);
                        x++;
                        Grid.SetColumn(cellBlack, x);
                        Grid.SetRow(cellBlack, y);
                        Base.Children.Add(cellBlack);
                        x++;
                    }
                }
                else
                {
                    x = x2;
                    while (x1 < x) 
                    {
                        var cellBlack = new Border
                        {
                            Background = Brushes.Green
                        };
                        var cellWhite = new Border
                        {
                            Background = Brushes.YellowGreen
                        };
                        Grid.SetColumn(cellWhite, x);
                        Grid.SetRow(cellWhite, y);
                        Base.Children.Add(cellWhite);
                        x--;
                        Grid.SetColumn(cellBlack, x);
                        Grid.SetRow(cellBlack, y);
                        Base.Children.Add(cellBlack);
                        x--;
                    }
                }
            }
        }
    }
}