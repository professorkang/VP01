using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _015_checkbox
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string checkStates = "";
      CheckBox[] cBox = { checkBox1, checkBox2, checkBox3,
        checkBox4, checkBox5};

      foreach (var c in cBox)
      {
        checkStates += string.Format("{0} : {1}\n",
          c.Text, c.Checked);        
      }
      MessageBox.Show(checkStates);

      string summary = "";
      foreach(CheckBox c in cBox)
      {
        if(c.Checked)
          summary += c.Text + " ";
      }
      MessageBox.Show(summary, "summary");
    }
  }
}
