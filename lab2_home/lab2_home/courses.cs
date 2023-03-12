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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using lab_home;

namespace lab2_home
{
    public partial class courses : Form
    {
        public courses()
        {
            InitializeComponent();
            refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            mainForm form = new mainForm();
            this.Hide();
            form.Show();

        }

        private void addCourse() {
         
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Course values (@Name, @Code)", con);
            cmd.Parameters.AddWithValue("@Name", txtBoxCourseName.Text);
            cmd.Parameters.AddWithValue("@Code", (txtBoxCourseCode.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                addCourse();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void refresh()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            viewData();
        }

       private void viewData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxCourseCode.Clear();
            txtBoxCourseName.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["btnDelete"].Index)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to Delete ?","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dialog == DialogResult.OK) {
                    String code = dataGridView2.CurrentRow.Cells["Code"].Value.ToString(); ;
                    String  name=dataGridView2.CurrentRow.Cells["Name"].Value.ToString(); ;
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("delete from Course where Code=@Code", con);
                            cmd.Parameters.AddWithValue("@Code", code);
                             cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    refresh();

                }
                   else
                {
                  MessageBox.Show("Cancel","",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

                }
            }else if (e.ColumnIndex == dataGridView2.Columns["btnEdit"].Index)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to update ??","Update",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dialog==DialogResult.OK)
                {
                   
                 String name= dataGridView2.CurrentRow.Cells["Name"].Value.ToString();
                 String code= dataGridView2.CurrentRow.Cells["Code"].Value.ToString();
                 Edit_Courses edit_Courses= new Edit_Courses(name,code);
                    this.Hide();
                    edit_Courses.Show();

                }
                else
                {
                    MessageBox.Show("Cancel", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void courses_Load(object sender, EventArgs e)
        {

        }
    }
}
