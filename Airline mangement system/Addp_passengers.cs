using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Airline_mangement_system
{
    public partial class Add_passengers : Form
    {
        public Add_passengers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");
    

        private void btn_record_Click(object sender, EventArgs e)
        {
            if (passID.Text == "" || PassName.Text == "" ||  passport.Text == "" || passAd.Text == ""|| passPh.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query= "insert into passengerTbl values(" + passID.Text + ",'" + PassName.Text + "','" + passport.Text + "','" + passAd.Text + "','" + passNat.SelectedItem.ToString() + "','" + passGen.SelectedItem.ToString() + "','" + passPh.Text + "')";
                    SqlCommand cmd = new SqlCommand(query,Con);
;                   cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Added Successfully");
                    
                    Con.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }
                

            }
        }

        private void view_passengers_Click(object sender, EventArgs e)
        {
            viewpassengers V = new viewpassengers();
           V.Show();
            this.Hide();
        }

        private void Add_passengers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1  Add  = new Form1();
            Add.Show();
            this.Hide();
            

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            passID.Text = "";
            PassName.Text = "";
            passport.Text = "";
            passAd.Text = "";
            passPh.Text = "";

        }
    }
}
