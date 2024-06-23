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
using System.Windows.Resources;
using System.Windows.Shapes;
using CColor = System.Drawing.Color;

namespace Player
{
    /// <summary>
    /// Логика взаимодействия для Chess.xaml
    /// </summary>
    public partial class Chess : Window
    {
        public string[,] field = new string[8, 8];
        public Chess()
        {
            InitializeComponent();
            PaintCels(3, 10, 3, 11);
            PlaceFigures(3,3);
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
        public void PlaceFigures(int x,int y)
        {
            placePawns(x);
            placeRooks(x);
            placeKnights(x);
            placeBishops(x);
            placeQueens(x);
            placeKings(x);
            MoveFigures moveFigures = new MoveFigures(field);
        }
        private void placePawns(int x)
        {
            for (int i = x; i < x + 8; i++)
            { 
                Button Pawn = new Button();
                Pawn.Name = "BlackPawn" + i;
                Pawn.Content = "Pawn";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 4);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 1]=Pawn.Name;
            }
            for (int i = x; i < x + 8; i++)
            {
                Button Pawn = new Button();
                Pawn.Name = "WhitePawn" + i;
                Pawn.Content = "Pawn";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 9);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 6] = Pawn.Name;
            }
        }
        private void placeRooks(int x)
        {
            for (int i = x; i < x + 8; i+=7)
            {
                Button Pawn = new Button();
                Pawn.Name = "BlackRook" + i;
                Pawn.Content = "Rook";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 3);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 0] = Pawn.Name;
            }
            for (int i = x; i < x + 8; i += 7)
            {
                Button Pawn = new Button();
                Pawn.Name = "WhiteRook" + i;
                Pawn.Content = "Rook";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 10);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 7] = Pawn.Name;
            }
        }
        private void placeKnights(int x)
        {
            for (int i = x+1; i < x + 8; i += 5)
            {
                Button Pawn = new Button();
                Pawn.Name = "BlackKnight" + i;
                Pawn.Content = "Knight";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 3);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 0] = Pawn.Name;
            }
            for (int i = x+1; i < x + 8; i += 5)
            {
                Button Pawn = new Button();
                Pawn.Name = "WhiteKnight" + i;
                Pawn.Content = "Knight";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 10);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 7] = Pawn.Name;
            }
        }
        private void placeBishops(int x)
        {
            for (int i = x + 2; i < x + 8; i += 3)
            {
                Button Pawn = new Button();
                Pawn.Name = "BlackBishop" + i;
                Pawn.Content = "Bishop";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 3);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i- 3, 0] = Pawn.Name;
            }
            for (int i = x + 2; i < x + 8; i += 3)
            {
                Button Pawn = new Button();
                Pawn.Name = "WhiteBishop" + i;
                Pawn.Content = "Bishop";
                Grid.SetColumn(Pawn, i);
                Grid.SetRow(Pawn, 10);
                Pawn.Click += Figure_Click;
                Base.Children.Add(Pawn);
                field[i - 3, 7] = Pawn.Name;
            }
        }
        private void placeQueens(int x)
        {
            Button BlackQueen = new Button();
            BlackQueen.Name = "BlackQueen";
            BlackQueen.Content = "Queen";
            Grid.SetColumn(BlackQueen, x + 3);
            Grid.SetRow(BlackQueen, 3);
            BlackQueen.Click += Figure_Click;
            Base.Children.Add(BlackQueen);
            field[x+3 - 3, 0] = BlackQueen.Name;

            Button Pawn = new Button();
            Pawn.Name = "WhiteQueen";
            Pawn.Content = "Queen";
            Grid.SetColumn(Pawn, x + 3);
            Grid.SetRow(Pawn, 10);
            Pawn.Click += Figure_Click;
            Base.Children.Add(Pawn);
            field[x+3 - 3, 7] = Pawn.Name;
        }
        private void placeKings(int x)
        {
            Button Pawn = new Button();
            Pawn.Name = "BlackKing";
            Pawn.Content = "King";
            Grid.SetColumn(Pawn, x + 4);
            Grid.SetRow(Pawn, 3);
            Pawn.Click += Figure_Click;
            Base.Children.Add(Pawn);
            field[x+4 - 3, 0] = Pawn.Name;


            Button WhiteKing = new Button();
            WhiteKing.Name = "WhiteKing";
            WhiteKing.Content = "King";
            Grid.SetColumn(WhiteKing, x + 4);
            Grid.SetRow(WhiteKing, 10);
            WhiteKing.Click += Figure_Click;
            Base.Children.Add(WhiteKing);
            field[x + 4 - 3, 7] = WhiteKing.Name;
        }
        private void Figure_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string name = button.Name;
                MessageBox.Show(name);
            }
        }
    }
}