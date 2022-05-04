using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\807PC02\Documents\StudentDB.accdb
namespace _033_PhoneBook
{
  public partial class Form1 : Form
  {
    string connStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\807PC02\Documents\StudentDB.accdb";
    OleDbConnection conn = null;
    OleDbCommand comm = null;
    OleDbDataReader reader = null;
    public Form1()
    {
      InitializeComponent();
      DisplayStudents();
    }

    // 교과서 602쪽
    private void DisplayStudents()
    {
      if(conn == null)
      {
        conn = new OleDbConnection(connStr);
        conn.Open();
      }

      string sql = "SELECT * FROM StudentTable";
      comm = new OleDbCommand(sql, conn);
      reader = comm.ExecuteReader();
      while(reader.Read())
      {
        string x = "";
        x += reader["ID"] + "\t";
        x += reader["SId"] + "\t";
        x += reader["SName"] + "\t";
        x += reader["Phone"];
        lstStudent.Items.Add(x);
      }
      reader.Close();
      conn.Close();
      conn = null;
    }

    private void lstStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBox lb = sender as ListBox;
      // ListBox lb = (ListBox)sender;

      if (lb.SelectedItem == null)
        return;
      string[] s = lb.SelectedItem.ToString().Split('\t');
      txtID.Text = s[0];
      txtSId.Text = s[1];
      txtSName.Text = s[2];
      txtPhone.Text = s[3];
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (txtSId.Text == "" ||
        txtSName.Text == "" ||
        txtPhone.Text == "")
        return;

      connOpen();

      // sql 문장 만들기
      string sql = string.Format(
        "INSERT INTO StudentTable(SId,SName,Phone) VALUES({0},'{1}','{2}')",
        txtSId.Text, txtSName.Text, txtPhone.Text);

      //MessageBox.Show(sql);
      comm = new OleDbCommand(sql, conn);
      int x = comm.ExecuteNonQuery();
      if (x == 1)
        MessageBox.Show("삽입 성공!");

      connClose();

    }

    private void connClose()
    {
      conn.Close();
      conn = null;

      lstStudent.Items.Clear();
      DisplayStudents();
    }

    private void connOpen()
    {
      // DB연결
      conn = new OleDbConnection(connStr);
      conn.Open();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      if (txtID.Text == "")
        return;

      connOpen();

      string sql = string.Format(
        "DELETE FROM StudentTable WHERE ID={0}", 
        txtID.Text); 
      comm = new OleDbCommand(sql, conn);
      int x = comm.ExecuteNonQuery();
      if (x == 1)
        MessageBox.Show("삭제 성공!");

      connClose();

    }
  }
}
