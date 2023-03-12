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
using System.Xml.Linq;

namespace lab2_home
{
    public partial class UnRoll : Form
    {
        public UnRoll()
        {
            InitializeComponent();
            dataGridView1.Visible=false;
            btnUnRegister.Visible=false;
            dataGridView1.ReadOnly = true;
            label2.Visible=false;
            textBox2.Visible=false;
            textBox2.ReadOnly=true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {

            search();
            dataGridView1.Visible = true;
            btnUnRegister.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Enroll enroll= new Enroll();
            enroll.Show();
        }
       private void search()
        {
            try
            {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select (CourseName) from Enrollments WHERE StudentRegNo=@StudentRegNo", con);
            cmd.Parameters.AddWithValue("@StudentRegNo", textBox1.Text);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells["CourseName"].Value.ToString();

        }

        private void btnUnRegister_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!="")
            {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Enrollments WHERE CourseName=@CourseName", con);
            cmd.Parameters.AddWithValue("@CourseName", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("UnRoll Successfully...","Delete");
            search();
            }
            else{

            MessageBox.Show("Please Select Course...","Error");
            }

        }

        private void UnRoll_Load(object sender, EventArgs e)
        {

        }
    }
}
