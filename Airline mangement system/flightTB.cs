using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airline_mangement_system
{

    public partial class flightTB : Form
    {
        public flightTB()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox_flightcode_TextChanged(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            flightcode.Text = "";
            source.Text = "";
            destination.Text = "";
            dateTimePicker_takeoff.Text= "";
            textBox_no_of_seats.Text ="";


        }
     

        private void but_exit_Click(object sender, EventArgs e)
        {
            Form1 Add = new Form1();
            Add.Show();
            this.Hide();
       
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (flightcode.Text == "" || source.Text == "" || destination.Text == "" || dateTimePicker_takeoff.Text == "" || textBox_no_of_seats.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into flightTbl values(" + flightcode.Text + ",'" + source.SelectedItem.ToString() + "','" + destination.SelectedItem.ToString() + "','" + dateTimePicker_takeoff.Value.ToString() + "','" +textBox_no_of_seats+  "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    ; cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Added Successfully");

                    Con.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }


            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void view_flight_Click(object sender, EventArgs e)
        {
           viewFlight V = new viewFlight();
            V.Show();
            this.Hide();
        }

        private void flightTB_Load(object sender, EventArgs e)
        {

        }
    }
}
