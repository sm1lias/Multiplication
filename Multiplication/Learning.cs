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
    public partial class Learning : Form
    {
        int mvalue;
        public Learning()
        {
            InitializeComponent();
        }

        public Learning(int mvalue2)
        {
            InitializeComponent();
            mvalue = mvalue2; 
        }

        private void Learning_Load(object sender, EventArgs e)
        {
            Label[] label_array = new Label[11] { label0, label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
            for(int i=0; i<11; i++)
            label_array[i].Text = mvalue.ToString() + " x " + i.ToString() + " =" + (mvalue * i).ToString();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            cmd.Parameters.AddWithValue("@username", Globals.strUsername);
            cmd.CommandText = $"SELECT score FROM mult{mvalue} WHERE username=@username";
            int score = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
            if (score < 80)
            {
                TestBad newTestBad = new TestBad(mvalue);
                newTestBad.Show();
                this.Hide();
            }
            else
            {
                Test newTest = new Test(mvalue);
                newTest.Show();
                this.Hide();
            }
        }

        private void Learning_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void πΙΣΩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MutliplicationTables newMutliplicationTables = new MutliplicationTables();
            newMutliplicationTables.Show();
            this.Hide();
        }

        private void αΠΟΣΥΝΔΕΣΗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.strUsername = "";
            Login newLogin = new Login();
            newLogin.Show();
            this.Hide();
        }

        private void βΟΗΘΕΙΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Αφού μελετήσεις την προπαίδεια, κάνε το τεστ.");
        }

        private void σΧΕΤΙΚΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η εφαρμογή δημιουργήθηκε από τους Μηλιαρέση Σπυρίδων\n και Μπούντα Γεώργιο");
        }
    }
}
