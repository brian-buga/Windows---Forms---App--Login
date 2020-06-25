using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Connection;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog();

        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PasswordCheckBox.Checked == true)
            {
                PaswordTextBox.UseSystemPasswordChar = false;

            }
            else
            {
                PaswordTextBox.UseSystemPasswordChar = true;
            }

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&
              !string.IsNullOrEmpty(PaswordTextBox.Text))
            {
                string mySQL = string.Empty;

                mySQL += "SELECT * FROM LoginTbl";
                mySQL += "WHERE Username = '" + textBox1.Text + "' ";
                mySQL += "AND Password = '" + PaswordTextBox.Text + "'";

                DataTable userData = ServerConnection.executeSQL(mySQL);

                if (userData.Rows.Count > 0)
                {
                    textBox1.Clear();
                    PasswordCheckBox.Checked = false;

                    this.Hide();

                    MainForm formMain = new MainForm();
                    formMain.ShowDialog();
                    formMain = null;

                    this.Show();
                    this.textBox1.Select();

                }

                else
                {
                    MessageBox.Show("Please enter username and password.","C# and SQL Server| Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox1.Focus();
                    textBox1.SelectAll();
                }

            }
        }
    }
}


