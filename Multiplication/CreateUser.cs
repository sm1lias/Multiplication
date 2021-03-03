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
    public partial class CreateUser : Form
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

        public CreateUser()
        {
            InitializeComponent();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            string strName = newName.Text;
            string strPassword = uPassword.Text;
            string strRPassword = uRPassword.Text;

            m_dbConnection.Open();
            cmd.CommandText = "SELECT count(*) FROM users WHERE username=@username";
            cmd.Parameters.AddWithValue("@username", strName);
            cmd.Parameters.AddWithValue("@password", strPassword);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            
            if (string.IsNullOrEmpty(strName))
                MessageBox.Show("Το όνομα χρήστη είναι κενό");
            else if(count!=0)
                MessageBox.Show("Το όνομα χρήστη υπάρχει");
            else if(string.IsNullOrEmpty(strPassword))
                MessageBox.Show("Ο κωδικός είναι κενός");
            else if(!strPassword.Equals(strRPassword))
                MessageBox.Show("Ο κωδικός είναι διαφορετικός");
            else
            {
                cmd.CommandText = "INSERT INTO users(username,password) VALUES(@username,@password)";
                cmd.ExecuteNonQuery();
                for (int i = 0; i < 11; i++)
                {
                    cmd.CommandText = $"INSERT INTO mult{i}(username,score) VALUES(@username,200)";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "INSERT INTO exams(username, exscore1,exscore2, exscore3, exscore4, exscore5) VALUES (@username,200, 200, 200, 200, 200)";
                cmd.ExecuteNonQuery();
                Login newLogin = new Login();
                newLogin.Show();
                this.Hide();
            }
            m_dbConnection.Close();

        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void bACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login newLogin = new Login();
            newLogin.Show();
            this.Hide();
        }

        private void CreateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Συμπλήρωσε το όνομα,τον κωδικό και πάτα το κουμπί για να \nγίνει η εγγραφή.\nΜπορείς να χρησιμοποιήσεις όποιοδήποτε όνομα χρήστη και \nκωδικό επιθυμείς!");
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η εφαρμογή δημιουργήθηκε από τους Μηλιαρέση Σπυρίδων\n και Μπούντα Γεώργιο");
        }
    }
}
