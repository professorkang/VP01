using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _043_SnakeBite
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    Random r = new Random();
    Ellipse[] snake = new Ellipse[30];
    Ellipse egg;
    int W = 10; // 뱀과 알의 크기
    int visibleCount = 5; // 눈에 보이는 뱀의 길이
    DispatcherTimer dt = new DispatcherTimer();
    Stopwatch sw = new Stopwatch();
    string move = ""; // 이동방향
    public Game()
    {
      InitializeComponent();

      InitEgg();
      InitSnake();
      dt.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초
      dt.Tick += Dt_Tick;
    }

    private void Dt_Tick(object sender, EventArgs e)
    {
      for (int i = visibleCount; i > 0; i--)
        snake[i].Tag = snake[i - 1].Tag;

      Point q = (Point)snake[0].Tag;

      if (move == "U")
        snake[0].Tag = new Point(q.X, q.Y - W);
      else if(move == "D")
        snake[0].Tag = new Point(q.X, q.Y + W);
      else if (move == "L")
        snake[0].Tag = new Point(q.X - W, q.Y);
      else if (move == "R")
        snake[0].Tag = new Point(q.X + W, q.Y);

      EatEgg();
      DrawSnake();

      TimeSpan ts = sw.Elapsed;
      txtTime.Text = ts.ToString();
    }

    // 뱀이 알을 먹었는지를 처리
    private void EatEgg()
    {
      Point pE = (Point)(egg.Tag);
      Point pS = (Point)(snake[0].Tag);

      if(pE.X == pS.X && pE.Y == pS.Y)
      {
        egg.Visibility = Visibility.Hidden;
        visibleCount++;
        if(visibleCount > 12)
        {
          MessageBox.Show("Game End!");
          Close();
        }
        snake[visibleCount - 1].Visibility = 
          Visibility.Visible;
        txtScore.Text = "Eggs = " + (visibleCount - 5);
        //txtTime.Text = "visibleCount = " + visibleCount;
        InitEgg();
      }
    }

    private void DrawSnake()
    {
      for(int i=0; i<visibleCount; i++)
      {
        Point p = (Point)snake[i].Tag;
        Canvas.SetLeft(snake[i], p.X);
        Canvas.SetTop(snake[i], p.Y);
      }
    }

    private void InitSnake()
    {
      // 뱀의 머리 위치
      int x = r.Next((int)(field.Width) / W); // 40
      int y = r.Next((int)(field.Height) / W); // 30

      for(int i = 0; i < 30; i++)
      {
        snake[i] = new Ellipse();
        snake[i].Width = W;
        snake[i].Height = W;
        snake[i].Stroke = Brushes.Black;
        if (i == 0) // 머리
          snake[i].Fill = Brushes.Chocolate;
        else if (i % 5 == 0)
          snake[i].Fill = Brushes.Green;
        else
          snake[i].Fill = Brushes.Gold;

        snake[i].Tag = new Point(x * W, (y + i) * W);
        field.Children.Add(snake[i]);
        Canvas.SetLeft(snake[i], x * W);
        Canvas.SetTop(snake[i], (y + i) * W);
      }

      for (int i = visibleCount; i < 30; i++)
        snake[i].Visibility = Visibility.Hidden;

    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = W;
      egg.Height = W;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      int x = r.Next((int)(field.Width) / W); // 40
      int y = r.Next((int)(field.Height) / W); // 30
      egg.Tag = new Point(x*W, y*W);

      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * W);
      Canvas.SetTop(egg, y * W);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      dt.Start();
      sw.Start();
      if (e.Key == Key.Left)
        move = "L";
      else if (e.Key == Key.Right)
        move = "R";
      else if (e.Key == Key.Up)
        move = "U";
      else if (e.Key == Key.Down)
        move = "D";
      else if(e.Key == Key.Escape)
      {
        move = "";
        dt.Stop();
      }
    }
  }
}
