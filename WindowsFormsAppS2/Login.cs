using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppS2
{
    public partial class Login : Form
    {
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //private static extern IntPtr CreateRoundRectRgn
        //(
        //    int nLeft,     // x-coordinate of upper-left corner
        //    int nTop,      // y-coordinate of upper-left corner
        //    int nRight,    // x-coordinate of lower-right corner
        //    int nBottom,   // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        //);

        public string pathFile = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\login.text";

        public Login()
        {
            InitializeComponent();
            int borderRadius = 9; // Adjust this value to control the roundness

            // Round the btnConnect button
            RoundControl(btnConnect, borderRadius);

            // Round the btnFermmer button
            RoundControl(btnFermmer, borderRadius);
        }

        private void connect_Click(object sender, EventArgs e)
        {
            login();
        }

        private void tbUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }

        private void login()
        {

            try
            {
                string u = "", p = "";
                StreamReader r = new StreamReader(pathFile);
                string oldUsers = r.ReadToEnd();
                r.Close();

                string[] all = oldUsers.Split('\n');
                int i = 0;
                while (i < all.Length - 1)
                {
                    if (all[i] == tbUser.Text) { u = all[i]; p = all[i + 1]; break; } else { i += 2; }
                }

                if (tbUser.Text == u && tbPass.Text == p)
                {
                    this.Hide();
                    Home h = new Home();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Le nom d'utilisateur ou le mot de pass est incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        private void btnFermmer_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)

                tbPass.PasswordChar = (char)0;
            else
                tbPass.PasswordChar = (char)'*';

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp s = new SignUp();
            s.Show();
        }

        private void RoundControl(Control control, int borderRadius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle bounds = control.ClientRectangle;
            int radius = borderRadius;
            path.AddArc(bounds.Left, bounds.Top, 2 * radius, 2 * radius, 180, 90);
            path.AddArc(bounds.Right - 2 * radius, bounds.Top, 2 * radius, 2 * radius, 270, 90);
            path.AddArc(bounds.Right - 2 * radius, bounds.Bottom - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        //private void btnConnect_MouseEnter(object sender, EventArgs e)
        //{
        //    // Customize button appearance when the mouse enters
        //    btnConnect.FlatStyle = FlatStyle.Flat;
        //    btnConnect.FlatAppearance.BorderSize = 2;
        //    btnConnect.FlatAppearance.BorderColor = Color.DarkGray;
        //    btnConnect.FlatAppearance.MouseDownBackColor = Color.LightGray;
        //    btnConnect.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        //}

        //private void btnConnect_MouseLeave(object sender, EventArgs e)
        //{
        //    // Restore the default appearance when the mouse leaves
        //    btnConnect.FlatStyle = FlatStyle.Standard;
        //}
    }
}
