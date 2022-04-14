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

namespace _031_WindowsCalc
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private bool opFlag = false;
    private bool memFlag = false;
    private double saved;
    private string op;  // + - * /
    private bool afterCalc;
    public MainWindow()
    {
      InitializeComponent();
      btnMC.IsEnabled = false;
      btnMR.IsEnabled = false;
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
      Button btn = (Button)sender;  // sender as Button
      string s = btn.Content.ToString();

      // 출력창이 0이거나 연산자 버튼이 눌린 후, 메모리 버튼이 눌린 후에
      if (txtResult.Text == "0" || opFlag == true ||
        afterCalc == true || memFlag == true)
      {
        if (afterCalc == true)
          txtExp.Text = "";
        txtResult.Text = s;
        opFlag = false;
        memFlag = false;
        afterCalc = false;
      }
      else
        txtResult.Text += s;
    }

    private void op_Click(object sender, RoutedEventArgs e)
    {
      Button btn = (Button)sender;

      saved = double.Parse(txtResult.Text);
      txtExp.Text = txtResult.Text + btn.Content.ToString();
      op = btn.Content.ToString();
      opFlag = true;
    }

    private void btnEqual_Click(object sender, RoutedEventArgs e)
    {
      double v = double.Parse(txtResult.Text);
      txtExp.Text += txtResult.Text + "=";
      switch (op)
      {
        case "+":
          txtResult.Text = (saved + v).ToString();
          break;
        case "-":
          txtResult.Text = (saved - v).ToString();
          break;
        case "×":
          txtResult.Text = (saved * v).ToString();
          break;
        case "÷":
          txtResult.Text = (saved / v).ToString();
          break;
        default:
          MessageBox.Show("Error in Equal");
          break;
      }
      afterCalc = true;
    }
    private void btnDot_Click(object sender, RoutedEventArgs e)
    {
      if (txtResult.Text.Contains("."))
        return;
      else
        txtResult.Text += ".";
    }

    // +- 버튼
    private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = 
        (-1 * double.Parse(txtResult.Text)).ToString();
    }

    // %버튼
    private void btnPercent_Click(object sender, RoutedEventArgs e)
    {
      double p = Double.Parse(txtResult.Text);
      p = saved * p / 100;
      txtResult.Text = p.ToString();
      //txtExp.Text += txtResult.Text; 
    }

    // 제곱근
    private void btnSqrt_Click(object sender, RoutedEventArgs e)
    {
      if(txtExp.Text == "")
        txtExp.Text = "√(" + txtResult.Text + ")";
      else
        txtExp.Text = "√(" + txtExp.Text + ")";
      txtResult.Text 
        = (Math.Sqrt(double.Parse(txtResult.Text))).ToString(); 
    }

    // 제곱
    private void btnSqr_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "sqr(" + txtResult.Text + ")";
      else
        txtExp.Text = "sqr(" + txtExp.Text + ")";

      double v = Double.Parse(txtResult.Text);
      txtResult.Text= (v*v).ToString();
    }

    // 역수
    private void btnRecip_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "1/(" + txtResult.Text + ")";
      else
        txtExp.Text = "1/(" + txtExp.Text + ")";

      double v = Double.Parse(txtResult.Text);
      txtResult.Text = (1/v).ToString();
    }

    // CE
    private void btnCE_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "0";
    }

    // C
    private void btnC_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "0";
      txtExp.Text = "";
      saved = 0;
      op = "";
      opFlag = false;
    }

    // Delete 버튼
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text 
        = txtResult.Text.Remove(txtResult.Text.Length - 1);
      if (txtResult.Text.Length == 0)
        txtResult.Text = "0";
    }
  }
}