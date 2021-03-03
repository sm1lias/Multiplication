using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Multiplication
{
    public partial class Login : Form
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
        public Login()
        {
            InitializeComponent();
        }

        private void newUser_Click(object sender, EventArgs e)
        {
            CreateUser newCreateUser = new CreateUser();
            newCreateUser.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            m_dbConnection.Open();
            cmd.CommandText = "create table if not exists users (username TEXT(20), password TEXT(20))";
            cmd.ExecuteNonQuery();
            for (int i=0; i<11; i++)
            {
                cmd.CommandText = $"create table if not exists mult{i} (username TEXT(20), score INT)";
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "create table if not exists exams (username TEXT(20), exscore1 INT,exscore2 INT, exscore3 INT, exscore4 INT, exscore5 INT)";
            cmd.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            Globals.strUsername = username.Text;
            string strPassword = password.Text;
            m_dbConnection.Open();
            cmd.Parameters.AddWithValue("@username", Globals.strUsername);
            cmd.Parameters.AddWithValue("@password", strPassword);
            cmd.CommandText = "SELECT count(*) FROM users WHERE username=@username and password=@password";
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                MutliplicationTables newMutliplicationTables = new MutliplicationTables();
                newMutliplicationTables.Show();
                this.Hide(); 
            }
            else
                MessageBox.Show("Ο χρήστης δεν υπάρχει ή ο κωδικός είναι λανθασμένος");
            cmd.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
