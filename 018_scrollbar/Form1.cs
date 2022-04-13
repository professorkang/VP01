using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018_scrollbar
{
  public partial class Form1 : Form
  {
    public Form1()  // 생성자
    {
      InitializeComponent();

      this.BackColor = Color.LightSteelBlue;
      panel1.BackColor = Color.FromArgb(0, 0, 0); //Color.Black;

      txtR.Text = "0";
      txtG.Text = "0";
      txtB.Text = "0";

      scrR.Maximum = 255 + 9;
      scrG.Maximum = 255 + 9;
      scrB.Maximum = 255 + 9;
    }

    private void scr_Scroll(object sender, ScrollEventArgs e)
    {
      txtR.Text = scrR.Value.ToString();
      txtG.Text = scrG.Value.ToString();
      txtB.Text = scrB.Value.ToString();
      panel1.BackColor 
        = Color.FromArgb(scrR.Value, scrG.Value, scrB.Value);
    }

    private void txt_TextChanged(object sender, EventArgs e)
    {
      if (txtR.Text != "" && txtG.Text != "" && txtB.Text != "")
      {
        scrR.Value = int.Parse(txtR.Text);
        scrG.Value = int.Parse(txtG.Text);
        scrB.Value = int.Parse(txtB.Text);
        panel1.BackColor
          = Color.FromArgb(scrR.Value, scrG.Value, scrB.Value);
      }
    }
  }
}
