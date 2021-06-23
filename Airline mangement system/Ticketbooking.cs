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
    public partial class Ticketbooking : Form
    {
        public Ticketbooking()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\airplaneDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void fpass()
        {

            Con.Open();

            SqlCommand cmd = new SqlCommand("select PassID from passengerTbl ",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("passID", typeof(int));
            dt.Load(rdr);
            passenger_ID.ValueMember = "passID";
            passenger_ID.DataSource = dt;

            Con.Close();

        }
        private void fflight()
        {

            Con.Open();

            SqlCommand cmd = new SqlCommand("select code from flightTbl ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            dt.Load(rdr);
            _gender.ValueMember = "code";
            _gender.DataSource = dt;

            Con.Close();

        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            Form1 Add = new Form1();
            Add.Show();
            this.Hide();
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_passenger_Click(object sender, EventArgs e)
        {
            if (ticket_id.Text == "" || t_Pass_name.Text == "" || _passport.Text == "" || textBox1.Text == "" || Amount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into TicketTbl values(" + ticket_id.Text + ",'" + t_Pass_name.Text + "','" + _passport.Text + "','" + textBox1.Text + "','" + _gender.SelectedValue.ToString() + "','" + passenger_ID.SelectedValue.ToString() + "','" + Amount.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    ; cmd.ExecuteNonQuery();
                    MessageBox.Show(" Booked Successfully");
                    pop();
                    Con.Close();
                }
                catch (System.Data.SqlClient.SqlException sqlException)
                {
                    System.Windows.Forms.MessageBox.Show(sqlException.Message);
                }


            }
        }
        private void pop()
        {
            Con.Open();
            string query = "select* from TicketTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView_passengers.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Ticketbooking_Load(object sender, EventArgs e)
        {
            fpass();
            fetch();
            fflight();
            pop();


        }

        string pname, pnat, ppasport;

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 Add = new Form1();
            Add.Show();
            this.Hide();
        }

        private void fetch()
        {
            Con.Open();

            string query = "select * from passengerTbl where passID= "+passenger_ID.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["passName"].ToString();
                ppasport = dr["passport"].ToString();
                pnat = dr["passNat"].ToString();
                t_Pass_name.Text = pname;
                _passport.Text = ppasport;
                textBox1.Text= pnat ;
                


            }

            //cmd.ExecuteNonQuery();
            
            

            Con.Close();


        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void passenger_ID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetch();
            fflight();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
