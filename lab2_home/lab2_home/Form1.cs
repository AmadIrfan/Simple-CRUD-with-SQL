using lab_home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_home
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            View();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
            mainForm form = new mainForm();
            form.Show();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                try
                {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("insert into Student values (@RegistrationNumber, @Name ,@Department,@Session,@Address)", con);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Department", textBox3.Text);
                cmd.Parameters.AddWithValue("@Session", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                View();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Field is Empty....");

            }
        }

        private void View()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            textBox1.Text = dataGridView1.CurrentRow.Cells["RegistrationNumber"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            textBox3.Text = dataGridView1.CurrentRow.Cells["Department"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Session"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            String registrationNumber = textBox1.Text.ToString();
            String name = textBox2.Text.ToString();
            String dep = textBox3.Text.ToString();
            String session = textBox4.Text.ToString();
            String addr  = textBox5.Text.ToString();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("delete from Student where RegistrationNumber=@RegistrationNumber", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            View();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            String registrationNumber = textBox1.Text.ToString();
            String name = textBox2.Text.ToString();
            String dep = textBox3.Text.ToString();
            String session = textBox4.Text.ToString();
            String addr = textBox5.Text.ToString();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Student SET RegistrationNumber=@RegistrationNumber ,Name=@Name, Address=@Address,Session=@Session,Department=@Department WHERE RegistrationNumber=@RegistrationNumber ", con);
            cmd.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
            cmd.Parameters.AddWithValue("@Department", dep);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Session", session);
            cmd.Parameters.AddWithValue("@Address", addr);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated", "Done", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            View();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
