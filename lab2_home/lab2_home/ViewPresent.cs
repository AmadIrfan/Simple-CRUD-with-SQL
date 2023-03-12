using lab_home;
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

namespace lab2_home
{
    public partial class ViewPresent : Form
    {
        public ViewPresent()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Attendances WHERE CourseName=@CourseName AND TimeStamp=@TimeStamp", con);
            cmd.Parameters.AddWithValue("@CourseName", comboBox1.Text);
            cmd.Parameters.AddWithValue("@TimeStamp",DateTime.Parse( dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            try
            {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Attendances WHERE CourseName=@CourseName AND TimeStamp=@TimeStamp", con);
            cmd.Parameters.AddWithValue("@CourseName", comboBox1.Text);
            cmd.Parameters.AddWithValue("@TimeStamp",DateTime.Parse( dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance attendance=new Attendance();
            attendance.Show();
        }

        private void ViewPresent_Load(object sender, EventArgs e)
        {
            try
            {

            dataGridView1.ReadOnly=true;
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT (Name) FROM Course ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            da.Fill(dt);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
