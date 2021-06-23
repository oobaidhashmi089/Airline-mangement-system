using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_mangement_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_passengers Add = new Add_passengers();
            Add.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         login Add = new login();
            Add.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ticketbooking Add = new Ticketbooking();
            Add.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           flightTB Add = new flightTB();
            Add.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cancellation Add = new cancellation();
            Add.Show();
            this.Hide();
        }
    }
}
