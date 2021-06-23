using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airline_mangement_system
{
    public partial class cancellation : Form
    {
        public cancellation()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");

        

        private void fticket()
        {
            try
            {

                Con.Open();

                SqlCommand cmd = new SqlCommand("select TicketId from TicketTbl ", Con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("TicketId", typeof(int));
                dt.Load(rdr);
                comboBox_gender.ValueMember = "TicketId";
                comboBox_gender.DataSource = dt;
            }
            catch
            {
                Con.Close();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Ticketbooking Add = new Ticketbooking();
            Add.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void ffetch()
        {
            try
            {
                Con.Open();

                string query = "select * from TicketTbl where TicketId= " + comboBox_gender.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cod_id.Text = dr["codef"].ToString();

                }
            }
            catch
            {
                Con.Close();
            }
        }
        private void pop()
        {
            try
            {
                Con.Open();
                string query = "select* from Table";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                dView_passengers.DataSource = ds.Tables[0];
            }
            catch
            {
                Con.Close();
            }
        }

        private void cancellation_Load(object sender, EventArgs e)
        {
            fticket();
            pop();
            ffetch();
        }

        private void comboBox_gender_SelectedValueChanged(object sender, EventArgs e)
        {
            ffetch();
        }

        private void btn_update_passenger_Click(object sender, EventArgs e)
        {
            if (cod_id.Text == "" || textBox1.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into TicketTbl values(" + cod_id.Text + ",'" + textBox1.Text + "','" + comboBox_gender.SelectedValue.ToString() + "','" + dateTimePicker1.Value.Date+  "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    ; cmd.ExecuteNonQuery();
                    MessageBox.Show(" Cancel Successfully");
                    pop();
                    Con.Close();
                    //Con.Dispose();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }


            }
        }

        private void dView_passengers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pop();
            ffetch();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

