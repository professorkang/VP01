using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _019_listbox
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();


    }

    private void Form1_Load(object sender, EventArgs e)
    {
      listBox2.Items.Add("오클랜드(뉴질랜드)");
      listBox2.Items.Add("오사카(일본)");
      listBox2.Items.Add("아델레이드(호주)");
      listBox2.Items.Add("웰링턴(뉴질랜드)");
      listBox2.Items.Add("도쿄(일본)");
      listBox2.Items.Add("퍼스(호주)");
      listBox2.Items.Add("취리히(스위스)");
      listBox2.Items.Add("제네바(스위스)");
      listBox2.Items.Add("멜버른(호주)");
      listBox2.Items.Add("브리즈번(호주)");

      // (3) DataSource 사용법
      List<string> happiness = new List<string>()
      {
        "핀란드", "덴마크", "아이슬란드", "스위스", "네덜란드",
        "룩셈부르크", "스웨덴", "노르웨이", "이스라엘", "뉴질랜드"
      };
      listBox3.DataSource = happiness;
    }

    private void listBox1_SelectedIndexChanged
      (object sender, EventArgs e)
    {
      //ListBox l = (ListBox)sender;
      ListBox l = sender as ListBox;
      txtSIndex1.Text = l.SelectedIndex.ToString();
      txtSItem1.Text = l.SelectedItem.ToString();
    }

    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
