using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Airline_mangement_system
{
    public partial class login :Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void usrlabel_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox1.Text == "" || bunifuCustomTextbox2.Text == "")
            {
                MessageBox.Show("Please Enter The Username and Password");
            }
            else if (bunifuCustomTextbox1.Text == "admin" && bunifuCustomTextbox2.Text == "admin")
            {
                Form1 Add = new Form1();
                Add.Show();
                this.Hide();
            }
            else { MessageBox.Show("Wrong username or password"); }
        }

        private void button1exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
