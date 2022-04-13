using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _010_HelloWorld
{
  public partial class Form1 : Form
  {
    bool flag = false;
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (flag == false)
      {
        label1.Text
          = "Hello! Windows Forms Application!";
        flag = true;
      }
      else
      {
        label1.Text = "";
        flag= false;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
