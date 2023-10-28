using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppS2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Login log = new Login();
            lblHello.Text = "Welcome " + log.u;
            lblDate1.Text = dateTimePicker1.Value.ToString();
            lblDate2.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            lblDate3.Text = dateTimePicker1.Value.ToShortDateString();
            lblDate4.Text = dateTimePicker1.Value.ToLongDateString();
            lblDate5.Text = dateTimePicker1.Value.ToShortTimeString();
            lblDate6.Text = dateTimePicker1.Value.ToLongTimeString();
            lblDate7.Text = DateTime.Now.ToString();

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void lblHello_Click(object sender, EventArgs e)
        {
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            lblDate1.Text = dateTimePicker1.Value.ToString();
            lblDate2.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            lblDate3.Text = dateTimePicker1.Value.ToShortDateString();
            lblDate4.Text = dateTimePicker1.Value.ToLongDateString();
            lblDate5.Text = dateTimePicker1.Value.ToShortTimeString();
            lblDate6.Text = dateTimePicker1.Value.ToLongTimeString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate7.Text = DateTime.Now.ToString();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings s = new Settings();
            s.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnFermmer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }
    }
}
