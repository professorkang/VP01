using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011_forms
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      this.ClientSize = new System.Drawing.Size(500, 500);
      button1.Location = new System.Drawing.Point(
        500/2 - button1.Width/2, 500/2 - button1.Height/2);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form2 f2 = new Form2();
      this.AddOwnedForm(f2);
      f2.Show();
    }
  }
}
