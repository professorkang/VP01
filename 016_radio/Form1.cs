using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _016_radio
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      RadioButton[] rbNaion = {radioButton1, radioButton2,
         radioButton3, radioButton4 };
      RadioButton[] rbSex = { radioButton5, radioButton6 };

      string result = "";
      foreach(RadioButton rb in rbNaion)
      {
        if (rb.Checked)
        {
          result += "국적 : " + rb.Text + "\n";
          break;
        }
      }

      foreach(RadioButton rb in rbSex)
      {
        if (rb.Checked)
          result += "성별 : " + rb.Text + "성";
      }

      MessageBox.Show(result, "Result");
    }
  }
}
