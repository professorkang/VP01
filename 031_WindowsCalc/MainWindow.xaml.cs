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
  }
}