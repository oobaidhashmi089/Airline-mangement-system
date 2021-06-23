using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Airline_mangement_system
{
    public partial class viewpassengers : Form
    {
        public viewpassengers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void pop()
        {
            Con.Open();
            string query = "select* from passengerTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            ViewpassengersDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void viewpassengers_Load(object sender, EventArgs e)
        {
            pop();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Add_passengers Add = new Add_passengers();
            Add.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login Add = new login();
            Add.Show();
            this.Hide();
        }

        private void btn_delete_passenger_Click(object sender, EventArgs e)
        {
            if (p_id.Text == "")
            {
                MessageBox.Show("Enter The Passenger To Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from passengerTbl where passID = " + p_id.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    ; cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Successfully");

                    Con.Close();
                    pop();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }

            }
        }



        private void btn_reset_passenger_Click(object sender, EventArgs e)
        {
            p_id.Text = "";
            P_name.Text = "";
            pass_port.Text = "";
            p_address.Text = "";
            p_nat.SelectedItem = "";
            p_gender.SelectedItem = "";
            p_ph.Text = "";
        }

        private void btn_update_passenger_Click(object sender, EventArgs e)
        {

            if (p_id.Text == "" || P_name.Text == "" || pass_port.Text == "" || p_address.Text == "" || p_ph.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                try
                {

                    string query = "update passengerTbl set passName= '" + P_name.Text + "' ,passport'" + pass_port.Text + "',passAd='" + p_address.Text + "',passNat'" + p_nat.SelectedItem.ToString() + "',passGen'" + p_gender.SelectedItem.ToString() + "',passPh'" + p_ph.Text + "' where passID='" + p_id + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Updated Successfully");


                    pop();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {

                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }
                finally { Con.Close(); }
            }
        }
        int key = 0;

        private void ViewpassengersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            ////p_id.Text = ViewpassengersDGV.SelectedRows[0].Cells[1].Value.ToString();
            ////P_name.Text = ViewpassengersDGV.SelectedRows[0].Cells[2].Value.ToString();
            ////pass_port.Text = ViewpassengersDGV.SelectedRows[0].Cells[3].Value.ToString();
            ////p_nat.SelectedItem = ViewpassengersDGV.SelectedRows[0].Cells[4].Value.ToString();
            ////p_gender.SelectedItem = ViewpassengersDGV.SelectedRows[0].Cells[5].Value.ToString();
            ////p_address.Text = ViewpassengersDGV.SelectedRows[0].Cells[6].Value.ToString();
            ////p_ph.Text = ViewpassengersDGV.SelectedRows[0].Cells[7].Value.ToString();

            //if (p_id.Text == "")
            //{ key = 0; }
            //else { key = Convert.ToInt32(  ViewpassengersDGV.SelectedRows[0].Cells[0].Value.ToString()); }
            }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

