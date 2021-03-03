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
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            Label[] label_array = new Label[6] { labelExams, label1, label2, label3, label4, label5 };
            Label[] label_array2 = new Label[11] { labelr0, labelr1, labelr2, labelr3, labelr4, labelr5, labelr6, labelr7, labelr8, labelr9, labelr10 };
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            cmd.Parameters.AddWithValue("@username", Globals.strUsername);
            for (int i = 1; i < 6; i++)
            {
                cmd.CommandText = $"SELECT exscore{i} FROM exams WHERE username=@username";
                label_array[i].Text = cmd.ExecuteScalar().ToString() + " %";
                if (label_array[i].Text == "200 %")
                    label_array[i].Text = "-";
            }
            for (int i=0; i<11; i++)
            {
                cmd.CommandText = $"SELECT score FROM mult{i} WHERE username=@username";
                label_array2[i].Text = cmd.ExecuteScalar().ToString() + " %";
                if (label_array2[i].Text == "200 %")
                    label_array2[i].Text = "-";
            }
        }

        private void Results_FormClosed(object sender, FormClosedEventArgs e)
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
            Login newLogin = new Login();
            newLogin.Show();
            this.Hide();
        }

        private void βΟΗΘΕΙΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Εδώ βλέπεις το τελευταίο αποτέλεσμα απο τα τεστ για κάθε προπαίδεια \nκαι τα 5 τελευταία αποτελέσματα από τα επαναληπτικά τεστ.");

        }

        private void σΧΕΤΙΚΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η εφαρμογή δημιουργήθηκε από τους Μηλιαρέση Σπυρίδων\n και Μπούντα Γεώργιο");
        }
    }
}
