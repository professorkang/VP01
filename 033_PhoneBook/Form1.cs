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

    // 검색
    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (txtSId.Text == "" &&
        txtSName.Text == "" &&
        txtPhone.Text == "")
        return;

      connOpen();

      string sql = string.Format("SELECT * FROM StudentTable WHERE ");
      if (txtSId.Text != "")
        sql += "SId = " + txtSId.Text;
      else if(txtSName.Text != "")
        sql += "SName = '" + txtSName.Text + "'";
      else if(txtPhone.Text != "")
        sql += "Phone = '" + txtPhone.Text + "'";

      comm = new OleDbCommand(sql, conn);
      MessageBox.Show(sql);

      // 리스트박스를 지워주고
      lstStudent.Items.Clear();

      // DisplayStudent() 에서 복사해 온 부분
      reader = comm.ExecuteReader();
      while (reader.Read())
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

    // ViewAll 버튼
    private void btnAll_Click(object sender, EventArgs e)
    {
      lstStudent.Items.Clear(); 
      DisplayStudents();
    }

    // 수정
    private void btnUpdate_Click(object sender, EventArgs e)
    {
      connOpen();

      string sql = string.Format("UPDATE StudentTable SET " 
        + "SId={0}, SName='{1}', Phone='{2}' WHERE ID={3}",
        txtSId.Text, txtSName.Text, txtPhone.Text, txtID.Text);

      comm = new OleDbCommand(sql, conn);
      int x = comm.ExecuteNonQuery();
      if (x == 1)
        MessageBox.Show("수정 성공!");
      connClose();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtID.Text = "";
      txtSId.Text = "";
      txtSName.Text = "";
      txtPhone.Text = "";
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
