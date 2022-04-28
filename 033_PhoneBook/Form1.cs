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
  }
}
