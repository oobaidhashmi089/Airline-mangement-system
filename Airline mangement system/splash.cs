using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Airline_mangement_system
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

      

        int startpoint = 0;
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            myprogressBar1.Value = startpoint;
            if (myprogressBar1.Value == 100){

                myprogressBar1.Value = 0;
                timer1.Stop();
                login Add = new login();
                Add.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
