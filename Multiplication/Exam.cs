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

    public partial class Exam : Form
    {

        int[] myvalue_array = new int[22];
        public Exam()
        {
            InitializeComponent();
        }



        private void Exam_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> possible = Enumerable.Range(0, 11).ToList();
            List<int> listNumbers = new List<int>();
            List<int> listNumbers2 = new List<int>();
            Label[] label_array2 = new Label[22] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label22, label23, label35, label36, label37, label38, label39, label40, label41, label42, label43, label44 };
            for (int i = 0; i < 11; i++)
            {
                int index = rnd.Next(0, possible.Count);
                int index2 = rnd.Next(0, possible.Count);
                listNumbers.Add(possible[index]);
                listNumbers2.Add(possible[index2]);
                possible.RemoveAt(index);
            }
            for(int i=11; i < 22; i++)
            {
                int z = rnd.Next(0, 10);
                int l = rnd.Next(0, 10);
                myvalue_array[i] = z * l;
                label_array2[i].Text = z.ToString() + "x" + l.ToString() + " =";
            }
            for (int i = 0; i < 11; i++)
            {

                label_array2[i].Text = listNumbers2[i].ToString() + " x " + listNumbers[i].ToString() + " =";
                myvalue_array[i] = listNumbers2[i] * listNumbers[i];
            }
        }



        private void okButton_Click(object sender, EventArgs e)
        {
            int correct = 0, wrong = 0;
            string[] value_array = new string[22] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox20.Text, textBox21.Text, textBox22.Text };
            Label[] label_array3 = new Label[22] { label11, label12, label13, label14, label15, label16, label17, label18, label19, label20, label21, label24, label25, label26, label27, label28, label29, label30, label31, label32, label33, label34 };

            for (int i = 0; i < 22; i++)
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
            for (int y = 1; y < 5; y++)
            {
                cmd.CommandText = $"UPDATE exams SET exscore{y}=exscore{y + 1} WHERE username=@username";
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = $"UPDATE exams SET exscore5=@score WHERE username=@username";
            cmd.ExecuteNonQuery();
            m_dbConnection.Close();
            DialogResult dialog = MessageBox.Show("Το σκορ σου είναι: "+score.ToString()+" % ");
            if (dialog == DialogResult.OK)
            {
                MutliplicationTables newMutliplicationTables = new MutliplicationTables();
                newMutliplicationTables.Show();
                this.Hide();
            }
        }

        private void Exam_FormClosed(object sender, FormClosedEventArgs e)
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
