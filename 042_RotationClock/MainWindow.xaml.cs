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

namespace _042_RotationClock
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      DrawFace(); // 시계판

      MakeClockHands(); // 시계바늘

      DispatcherTimer dt = new DispatcherTimer();
      dt.Interval = new TimeSpan(0, 0, 0, 0, 10); // 0.01초
      dt.Tick += Dt_Tick;
      dt.Start();
    }

    private void Dt_Tick(object sender, EventArgs e)
    {
      DateTime c =  DateTime.Now;

      double hDeg = c.Hour * 30 + c.Minute * 0.5;
      double mDeg = c.Minute * 6;
      double sDeg = c.Second * 6;

      RotateTransform hRt = new RotateTransform(hDeg);
      hRt.CenterX = hourHand.X1;
      hRt.CenterY = hourHand.Y1;
      hourHand.RenderTransform = hRt;

      RotateTransform mRt = new RotateTransform(mDeg);
      mRt.CenterX = minHand.X1;
      mRt.CenterY = minHand.Y1;
      minHand.RenderTransform = mRt;

      RotateTransform sRt = new RotateTransform(sDeg);
      sRt.CenterX = secHand.X1;
      sRt.CenterY = secHand.Y1;
      secHand.RenderTransform = sRt;
    }

    private void MakeClockHands()
    {
      int W = 300;
      int H = 300;

      secHand.X1 = W / 2;
      secHand.Y1 = H / 2;
      secHand.X2 = W / 2;
      secHand.Y2 = 20;

      minHand.X1 = W / 2;
      minHand.Y1 = H / 2;
      minHand.X2 = W / 2;
      minHand.Y2 = 40;

      hourHand.X1 = W / 2;
      hourHand.Y1 = H / 2;
      hourHand.X2 = W / 2;
      hourHand.Y2 = 60;
    }

    private void DrawFace()
    {
      Line[] marking = new Line[60];
      int W = 300;  // 시계크기

      for(int i=0; i<60; i++)
      {
        marking[i] = new Line();
        marking[i].Stroke = Brushes.LightSteelBlue;
        marking[i].X1 = W / 2;
        marking[i].Y1 = 2;
        marking[i].X2 = W / 2;
        if(i%5 == 0)
        {
          marking[i].Y2 = 20;
          marking[i].StrokeThickness = 5;
        }
        else
        {
          marking[i].Y2 = 10;
          marking[i].StrokeThickness = 2;
        }
        

        RotateTransform rt = new RotateTransform(6*i);
        rt.CenterX = 150;
        rt.CenterY = 150;
        marking[i].RenderTransform = rt;
        aClock.Children.Add(marking[i]);
      }
    }
  }
}
