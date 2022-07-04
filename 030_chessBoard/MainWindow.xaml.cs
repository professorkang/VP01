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

namespace _030_chessBoard
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      //for(byte i=0; i<64; i++)
      //{
      //  Rectangle r = new Rectangle();
      //  r.Margin = new Thickness(1);
      //  SolidColorBrush brush = new SolidColorBrush();
      //  brush = new SolidColorBrush(Color.FromRgb((byte)(2*i), 0, 0));
      //  r.Fill = brush;
      //  chessBoard.Children.Add(r);
      //}
      for(int i=0; i<64/2; i++)
      {
        if((i/4)%2 ==0)
        {
          Rectangle r1 = new Rectangle();
          r1.Fill = Brushes.Black;
          Rectangle r2 = new Rectangle();
          r2.Fill = Brushes.Red;
          chessBoard.Children.Add(r1);
          chessBoard.Children.Add(r2);
        }
        else
        {
          Rectangle r1 = new Rectangle();
          r1.Fill = Brushes.Red;
          Rectangle r2 = new Rectangle();
          r2.Fill = Brushes.Black;
          chessBoard.Children.Add(r1);
          chessBoard.Children.Add(r2);
        }
      }
    }
  }
}
