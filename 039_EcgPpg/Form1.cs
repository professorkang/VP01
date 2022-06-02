using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _039_EcgPpg
{
  public partial class Form1 : Form
  {
    double[] ecg = new double[100000];
    double[] ppg = new double[100000];
    private int ecgCount;
    private int ppgCount;
    Timer t = new Timer();

    public Form1()
    {
      InitializeComponent();
      this.Text = "ECG/PPG";
      this.WindowState = FormWindowState.Maximized;

      EcgRead();
      PpgRead();
      ChartSetting();

      t.Interval = 10;  // 0.01초
      t.Tick += T_Tick;
    }

    private int cursorX = 0;  // 차트에 표시되는 첫번째 데이터
    private bool scrolling = false; // true: 스크롤, false이면 정지
    private int dataCount = 500;  // 한 화면에 표시되는 데이터
    private int speed = 2; // 데이터 표시 속도

    private void T_Tick(object sender, EventArgs e)
    {
      if (cursorX + dataCount <= ecgCount)
        c.ChartAreas[0].AxisX.ScaleView.Zoom(
          cursorX, cursorX + dataCount);
      else
        t.Stop();
      cursorX += speed;
    }

    private void ChartSetting()
    {
      c.ChartAreas[0].CursorX.IsUserEnabled = true; // 커서 사용가능
      c.ChartAreas[0].CursorX.IsUserSelectionEnabled = true; // zoom

      c.ChartAreas[0].BackColor = Color.Black;
      c.ChartAreas[0].AxisX.Minimum = 0;
      c.ChartAreas[0].AxisX.Maximum = ecgCount;
      c.ChartAreas[0].AxisX.Interval = 50;
      c.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
      c.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

      c.ChartAreas[0].AxisY.Minimum = -2;
      c.ChartAreas[0].AxisY.Maximum = 6;
      c.ChartAreas[0].AxisY.Interval = 0.5;
      c.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
      c.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

      c.Series.Clear(); // 시리즈를 다 지운다
      c.Series.Add("ECG");
      c.Series.Add("PPG");

      c.Series[0].ChartType = SeriesChartType.Line;
      c.Series[0].Color = Color.LightGreen;
      c.Series[0].BorderWidth = 2;
      c.Series[0].LegendText = "ECG";

      c.Series[1].ChartType = SeriesChartType.Line;
      c.Series[1].Color = Color.Orange;
      c.Series[1].BorderWidth = 2;
      c.Series[1].LegendText = "PGG";

      // 데이터를 시리즈에 넣는 작업
      foreach(var v in ecg)
      {
        c.Series["ECG"].Points.Add(v);
      }

      foreach (var v in ppg)
      {
        c.Series["PPG"].Points.Add(v);
      }
    }

    private void PpgRead()
    {
      string fileName = "../../Data/ppg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;

      int i = 0;
      foreach (var line in lines)
      {
        ppg[i] = double.Parse(line);
        if (min > ppg[i])
          min = ppg[i];
        if (max < ppg[i])
          max = ppg[i];
        i++;
      }
      ppgCount = i;
      string s =
        string.Format("PPG: count={0}, min={1}, max={2}",
        ppgCount, min, max);
      MessageBox.Show(s);
    }

    private void EcgRead()
    {
      string fileName = "../../Data/ecg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;

      int i = 0;
      foreach(var line in lines)
      {
        ecg[i] = double.Parse(line) + 3;
        if(min > ecg[i])
          min = ecg[i];
        if(max < ecg[i])
          max = ecg[i];
        i++;
      }
      ecgCount = i;
      string s =
        string.Format("ECG: count={0}, min={1}, max={2}",
        ecgCount, min, max);
      MessageBox.Show(s);
    }

    private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
    {
      t.Start();
      scrolling = true;
    }

    bool scrollFlag = true;
    // 차트를 클릭했을 때 처리 메소드
    private void c_Click(object sender, EventArgs e)
    {
      if(scrollFlag == true)
      {
        t.Stop();
        scrollFlag = false;
      }
      else
      {
        t.Start();
        scrollFlag = true;
      }
    }

    private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      c.ChartAreas[0].AxisX.ScaleView.Zoom(0, ecgCount);
      t.Stop();
      scrolling = false;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void c_SelectionRangeChanged(object sender, CursorEventArgs e)
    {
      int min = (int)(c.ChartAreas[0].AxisX.ScaleView.ViewMinimum);
      int max = (int)(c.ChartAreas[0].AxisX.ScaleView.ViewMaximum);
      cursorX = min;
      dataCount = max - min;
    }

    private void dataCountToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      dataCount *= 2;
    }

    private void dataCountToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      dataCount /= 2;
    }

    private void speedUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
      speed *= 2;
    }

    private void speedDownToolStripMenuItem_Click(object sender, 
      EventArgs e)
    {
      speed /= 2;
    }

    // 클릭하는 곳의 데이터 값을 표시
    private void c_MouseClick(object sender, 
      MouseEventArgs e)
    {
      HitTestResult htr = c.HitTest(e.X, e.Y);
      if(htr.ChartElementType == ChartElementType.DataPoint)
      {
        t.Stop();
        string s = string.Format(
          "Count : {0}, ECG : {1}, PPG : {2}",
          htr.PointIndex,
          c.Series["ECG"].Points[htr.PointIndex].YValues[0],
          c.Series["PPG"].Points[htr.PointIndex].YValues[0]);
        MessageBox.Show(s);
      }
    }
  }
}
