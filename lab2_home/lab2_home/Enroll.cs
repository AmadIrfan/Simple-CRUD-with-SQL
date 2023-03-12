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
    public partial class Enroll : Form
    {
        public Enroll()
        {
            InitializeComponent();
        }

        private void Enroll_Load(object sender, EventArgs e)
        {
            try
            {
                courseBox();
                 stuBox();
                nameSearch();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void nameSearch()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from Student WHERE RegistrationNumber = @RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber",comboBox2.Text);
            /*SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            */
            var sdr = cmd.ExecuteScalar();
            textBox1.Text = sdr.ToString();

        }
        private void courseBox()
        {
            label1.Text = "StudentRegNo";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            da.Fill(dt);
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = dt;
        }
        private void stuBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select RegistrationNumber from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Columns.Add("RegistrationNumber", typeof(String));
            da.Fill(dt);
            comboBox2.ValueMember = "RegistrationNumber";
            comboBox2.DataSource = dt;
        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text !="" && comboBox1.Text!="") 
            {

           var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Enrollments values (@StudentRegNo, @CourseName)", con);
            cmd.Parameters.AddWithValue("@StudentRegNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CourseName", (comboBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");

            }
            else
            {

            MessageBox.Show("Field is empty","Error");
            }
        }

        private void btnURwg_Click(object sender, EventArgs e)
        {
            this.Hide();
            UnRoll unRoll= new UnRoll();
            unRoll.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm main=new mainForm
                ();
            main.Show();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            nameSearch();
        }
    }
}
