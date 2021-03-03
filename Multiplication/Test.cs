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
    public partial class Test : Form
    {
        int myvalue;
        int[] myvalue_array = new int[5];
        public Test()
        {
            InitializeComponent();
        }
        public Test(int myvalue2)
        {
            InitializeComponent();
            myvalue = myvalue2;
        }
        private void Test_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> possible = Enumerable.Range(0, 11).ToList();
            List<int> listNumbers = new List<int>();
            Label[] label_array2 = new Label[5] { label1, label2, label3, label4, label5};

            for (int i = 0; i < 5; i++)
            {
                int index = rnd.Next(0, possible.Count);
                listNumbers.Add(possible[index]);
                possible.RemoveAt(index);
            }
            for (int i = 0; i < 5; i++)
            {
                label_array2[i].Text = myvalue.ToString() + " x " + listNumbers[i].ToString() + " =";
                myvalue_array[i] = myvalue * listNumbers[i];
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            int correct = 0, wrong = 0;
            string[] value_array = new string[5] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
            Label[] label_array3 = new Label[5] { label11, label21, label31, label41, label51 };

            for (int i = 0; i < 5; i++)
            {
                if (value_array[i].Equals(myvalue_array[i].ToString()))
                {
                    label_array3[i].Text = "ΣΩΣΤΟ";
                    correct = correct + 1;
                    label_array3[i].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    label_array3[i].Text = "ΛΑΘΟΣ";
                    wrong = wrong + 1;
                    label_array3[i].ForeColor = System.Drawing.Color.Red;
                }
            }
            int score = 100 * correct / (correct + wrong);

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand(m_dbConnection);
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@username", Globals.strUsername);
            cmd.CommandText = $"UPDATE mult{myvalue} SET score=@score WHERE username=@username";
            cmd.ExecuteNonQuery();
            m_dbConnection.Close();

            if (score < 80)
            {
                DialogResult dialog = MessageBox.Show("Έκανες αρκετά λάθη, θα πρέπει να ξαναδιαβάσεις τη θεωρία");
                if (dialog == DialogResult.OK)
                {
                    Learning newLearning = new Learning(myvalue);
                    newLearning.Show();
                    this.Hide();
                }

            }
            else
            {
                DialogResult dialog = MessageBox.Show("ΜΠΡΑΒΟ!Τα πήγες πολύ καλά");
                if (dialog == DialogResult.OK)
                {
                    MutliplicationTables newMutliplicationTables = new MutliplicationTables();
                    newMutliplicationTables.Show();
                    this.Hide();
                }
            }
        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void πΙΣΩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MutliplicationTables newMutliplicationTables = new MutliplicationTables();
            newMutliplicationTables.Show();
            this.Hide();
        }

        private void βΟΗΘΕΙΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Συμπλήρωσε τα κενά με το σωστό αποτέλεσμα και πάτα το κουμπί ΟΚ για να δεις πως τα πήγες.");
        }

        private void σΧΕΤΙΚΑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η εφαρμογή δημιουργήθηκε από τους Μηλιαρέση Σπυρίδων\n και Μπούντα Γεώργιο");
        }
    }
}
