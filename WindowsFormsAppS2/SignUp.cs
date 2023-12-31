﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsAppS2
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        public string pathFile = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\login.text";

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked)

                tbPass.PasswordChar = (char)0;
            else
                tbPass.PasswordChar = (char)'*';
        }

        private void cb2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2.Checked)

                tbCPass.PasswordChar = (char)0;
            else
                tbCPass.PasswordChar = (char)'*';
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "" || tbPass.Text == "" || tbCPass.Text == "")
            {
                MessageBox.Show("Verifier le remplissage des champs!");
            } else if (tbPass.Text != tbCPass.Text)
            {
                MessageBox.Show("Verifier le mot de passe!");
            } else
            {
                if(!File.Exists(pathFile))
                {
                    try
                    {
                        //StreamWriter w = new StreamWriter(pathFile);
                        //w.WriteLine(tbCPass.Text);
                        //w.WrieLine(tbPass.Text);
                        //w.Close();

                        
                        File.WriteAllText(pathFile, tbUser.Text + "\n" + tbPass.Text);
                        MessageBox.Show("Account has been succesfuly created, you can login now!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } else
                {
                    try
                    {
                        StreamReader r = new StreamReader(pathFile);
                        string oldUsers = r.ReadToEnd();
                        r.Close();  

                        string[] all = oldUsers.Split('\n');
                        int i = 0;
                        Boolean exist = false;
                        while (i < all.Length - 1) {
                            if (all[i] == tbUser.Text) { exist = true; break;} else { i+=2; }
                        }

                        if (exist)
                        {
                            MessageBox.Show("Account already exist! you can got to login");
                        }
                        else
                        {
                            File.WriteAllText(pathFile, oldUsers + "\n" + tbUser.Text + "\n" + tbPass.Text);
                            MessageBox.Show("Account has been succesfuly added, you can login now!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
