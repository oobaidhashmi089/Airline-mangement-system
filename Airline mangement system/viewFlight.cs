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
    public partial class viewFlight : Form
    {
        public viewFlight()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void pop()
        {
            Con.Open();
            string query = "select* from flightTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView_flight.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_usrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewFlight_Load(object sender, EventArgs e)
        {
            pop();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            flightTB Add = new flightTB();
            Add.Show();
            this.Hide();
        }

        private void btn_delete_flight_Click(object sender, EventArgs e)
        {
            if (textBox_code.Text == "")
            {
                MessageBox.Show("Enter The flight To Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from flightTbl where code = " + textBox_code.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    ; cmd.ExecuteNonQuery();
                    MessageBox.Show(" Deleted Successfully");

                    Con.Close();
                    pop();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }
            }
        }
        private void clear()
        {
            textBox_code.Text = "";
            source_btn.Text = "";
            des_btn.Text = "";
            seats.Text = "";
            dateTimePicker1.Text = "";

        }
        private void btn_reset_flight_Click(object sender, EventArgs e)
        {

            clear();
            
        }

        private void dataGridView_flight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_code.Text = dataGridView_flight.SelectedRows[0].Cells[0].Value.ToString();
            source_btn.SelectedItem = dataGridView_flight.SelectedRows[0].Cells[1].Value.ToString();
            seats.Text = dataGridView_flight.SelectedRows[0].Cells[2].Value.ToString();
            des_btn.SelectedItem = dataGridView_flight.SelectedRows[0].Cells[3].Value.ToString();
            
           // dateTimePicker1.Value= dataGridView_flight.SelectedRows[0].Cells[5].Value.ToString();


     
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
