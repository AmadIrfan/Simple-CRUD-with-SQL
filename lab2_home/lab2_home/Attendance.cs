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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            mainForm main =new mainForm();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT into Attendances values (@StudentRegNo, @CourseName ,@TimeStamp ,@Status)", con);
                cmd.Parameters.AddWithValue("@StudentRegNo", textBox2.Text);
                cmd.Parameters.AddWithValue("@CourseName", comboBox1.Text);
                cmd.Parameters.AddWithValue("@TimeStamp",DateTime.Parse( dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Status", 1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(), "Error");

            }
        }

            private void button3_Click(object sender, EventArgs e)
        {
            try
            {

           var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT into Attendances values(@StudentRegNo, @CourseName ,@TimeStamp ,@Status)", con);
                cmd.Parameters.AddWithValue("@StudentRegNo", textBox2.Text);
            cmd.Parameters.AddWithValue("@CourseName", comboBox1.Text);
            cmd.Parameters.AddWithValue("@TimeStamp",DateTime.Parse( dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Status", 0);
            cmd.ExecuteNonQuery();
            }
            catch(Exception error) { 
            MessageBox.Show(error.Message.ToString(),"Error");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

            textBox2.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT StudentRegNo FROM Enrollments WHERE CourseName=@CourseName", con);
            cmd.Parameters.AddWithValue("@CourseName",comboBox1.Text );
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


        private void Attendance_Load(object sender, EventArgs e)
        {
            try
            {

            dataGridView1.ReadOnly = true;
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT (Name) FROM Course ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            da.Fill(dt);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;
            textBox2.ReadOnly=true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            String rollNo = dataGridView1.CurrentRow.Cells["StudentRegNo"].Value.ToString();
            textBox2.Text = rollNo;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPresent viewPresent=new ViewPresent();
            viewPresent.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            String rollNo = dataGridView1.CurrentRow.Cells["StudentRegNo"].Value.ToString();
            textBox2.Text = rollNo;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
