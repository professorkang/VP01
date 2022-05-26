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

namespace _039_EcgPpg
{
  public partial class Form1 : Form
  {
    double[] ecg = new double[100000];
    double[] ppg = new double[100000];
    private int ecgCount;

    public Form1()
    {
      InitializeComponent();
      this.Text = "ECG/PPG";
      this.WindowState = FormWindowState.Maximized;

      EcgRead();
      PpgRead();
    }

    private void PpgRead()
    {
      
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
        ecg[i] = double.Parse(line);
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
  }
}
