using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _037_TwoCharts
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.Text = "Two Charts";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      chart1.Titles.Add("성적");
      chart1.Series.Add("Series2");
      chart1.Series["Series1"].LegendText = "수학";
      chart1.Series["Series2"].LegendText = "영어";

      chart1.ChartAreas.Add("ChartArea2");
      chart1.Series["Series2"].ChartArea = "ChartArea2";

      Random r = new Random();
      for(int i=0; i<10; i++)
      {
        chart1.Series["Series1"].Points.AddXY(i, r.Next(101));
        chart1.Series["Series2"].Points.AddXY(i, r.Next(101));
      }
    }

    private void btnOneChart_Click(object sender, EventArgs e)
    {
      chart1.Series["Series2"].ChartArea = "ChartArea1";
      chart1.ChartAreas.RemoveAt(1);
      // chart1.ChartAreas.RemoveAt(chart1.ChartAreas.IndexOf("ChartArea2"));
    }

    private void btnTwoCharts_Click(object sender, EventArgs e)
    {
      chart1.ChartAreas.Add("수학영역");
      chart1.Series["Series2"].ChartArea = "수학영역";
    }
  }
}
