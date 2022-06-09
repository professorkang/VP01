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
using System.Windows.Threading;

namespace _041_WPFClock
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    bool aClock_Flag = true;
    Point center; // 중심점
    double radius;  // 반지름
    int hourHand;   // 시침의 길이
    int minHand;    // 분침
    int secHand;    // 초침
    DispatcherTimer timer;
    private bool ms_flag = false;

    public MainWindow()
    {
      InitializeComponent();

      aClockSetting();
      timerSetting();
    }

    private void timerSetting()
    {
      timer = new DispatcherTimer();
      timer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;

      canvas1.Children.Clear(); // 현재 화면 지우기

      if (aClock_Flag == true)
      {
        DrawClockFace();

        // 시계바늘 그리기
        double radHr
          = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
        double radMin
          = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
        double radSec
          = (c.Second * 6 + c.Millisecond * 6.0 / 1000)
          * Math.PI / 180;

        DrawHands(radHr, radMin, radSec);
      } 
      else // 디지털 시계
      {
        txtDate.Text = DateTime.Today.ToString("D");
        if(ms_flag == false)
          txtTime.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
            c.Hour, c.Minute, c.Second);
        else
          txtTime.Text = 
            string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
            c.Hour, c.Minute, c.Second, c.Millisecond);
      }
    }

    // 시계바늘 그리는 부분
    private void DrawHands(double radHr, double radMin, double radSec)
    {
      // 시침(현재 시간의 좌표를 각도를 이용하여 구하자)
      DrawLine(0, 0,
        (int)(hourHand * Math.Sin(radHr)),
        (int)(hourHand * Math.Cos(radHr)),
        Brushes.RoyalBlue, 8);

      // 분침(현재 시간의 좌표를 각도를 이용하여 구하자)
      DrawLine(0, 0,
        (int)(minHand * Math.Sin(radMin)),
        (int)(minHand * Math.Cos(radMin)),
        Brushes.SkyBlue, 6);

      // 초침(현재 시간의 좌표를 각도를 이용하여 구하자)
      DrawLine(0, 0,
        (int)(secHand * Math.Sin(radSec)),
        (int)(secHand * Math.Cos(radSec)),
        Brushes.OrangeRed, 4);

      // 배꼽
      int coreSize = 16;
      Ellipse core = new Ellipse();
      core.Margin = new Thickness(
        center.X - coreSize/2,  center.Y - coreSize/2, 0, 0);
      core.Stroke = Brushes.Green;
      core.StrokeThickness = 3;
      core.Fill = Brushes.Gold;
      core.Width = coreSize;
      core.Height = coreSize;
      canvas1.Children.Add(core);
    }

    private void DrawLine(int x1, int y1, int x2, int y2,
      Brush brush, int thick)
    {
      Line line = new Line();
      line.X1 = x1;
      line.Y1 = y1;
      line.X2 = x2;
      line.Y2 = -y2;
      line.Stroke = brush;
      line.StrokeThickness = thick;
      line.Margin = new Thickness(center.X, center.Y, 0, 0);
      line.StrokeEndLineCap = PenLineCap.Round;
      canvas1.Children.Add(line);
    }

    private void DrawClockFace()
    {
      Ellipse aClock = new Ellipse();
      aClock.Width = 250;
      aClock.Height = 250;
      aClock.Stroke = Brushes.LightSteelBlue;
      aClock.StrokeThickness = 30;
      canvas1.Children.Add(aClock);
    }

    private void aClockSetting()
    {
      center = new Point(canvas1.Width / 2, canvas1.Height / 2);
      radius = canvas1.Width / 2;

      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }

    private void Analog_Click(object sender, RoutedEventArgs e)
    {
      aClock_Flag = true;
      txtDate.Text = "";
      txtTime.Text = "";
    }

    private void Digital_Click(object sender, RoutedEventArgs e)
    {
      aClock_Flag = false;
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    // 초단위
    private void Sec_Click(object sender, RoutedEventArgs e)
    {
      ms_flag = false;
      timer.Interval = new TimeSpan(0, 0, 0, 1); // 1초
    }

    // 밀리초 단위
    private void MS_Click(object sender, RoutedEventArgs e)
    {
      ms_flag = true;
      timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // 0.01초
    }
  }
}
