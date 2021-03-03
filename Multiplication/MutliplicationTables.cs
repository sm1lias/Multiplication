using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiplication
{
    public partial class MutliplicationTables : Form
    {
        public MutliplicationTables()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(0);
            newLearning.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(1);
            newLearning.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(2);
            newLearning.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(3);
            newLearning.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(4);
            newLearning.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(5);
            newLearning.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(6);
            newLearning.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(7);
            newLearning.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(8);
            newLearning.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(9);
            newLearning.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Learning newLearning = new Learning(10);
            newLearning.Show();
            this.Hide();
        }

        private void MutliplicationTables_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Exam newExam = new Exam();
            newExam.Show();
            this.Hide();

        }

        private void resaultsButton_Click(object sender, EventArgs e)
        {
            Results newResults = new Results();
            newResults.Show();
            this.Hide();
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Εδώ μπορείς να διαλέξεις την προπαίδεια που θες να μελετήσεις, \nνα κάνεις επαναληπτικό τεστ και να δεις τα αποτελέσματά σου.");
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Η εφαρμογή δημιουργήθηκε από τους Μηλιαρέση Σπυρίδων\n και Μπούντα Γεώργιο");
        }

        private void MutliplicationTables_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void αΠΟΣΥΝΔΕΣΗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login newLogin = new Login();
            newLogin.Show();
            this.Hide();
        }
    }
}
