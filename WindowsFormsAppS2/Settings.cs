using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppS2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        public string pathFile = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\login.text";

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
                MessageBox.Show("Text file has been created successfuly");
            } else MessageBox.Show("Text file already exist!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                    MessageBox.Show("Text file has been delete successfuly");
                }
                else MessageBox.Show("Text file doesn't exist!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                /////////
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
    }
}
