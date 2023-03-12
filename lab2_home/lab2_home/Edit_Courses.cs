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
using System.Configuration;

using lab_home;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography;

namespace lab2_home
{
    public partial class Edit_Courses : Form
    {
        String name="",code="";
        public Edit_Courses(String name,String code)
        {
            this.name = name;
            this.code = code;
            InitializeComponent();
            tBox2.Text =this. code;
            tBox1.Text =this.name;
        }

        private void Edit_Courses_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

            Console.WriteLine(tBox1.Text);
            Console.WriteLine(tBox2.Text);
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Course SET Name=@Name,Code=@Code WHERE Name=@Name or Code=@Code", con);
            cmd.Parameters.AddWithValue("@Name", tBox1.Text);
            cmd.Parameters.AddWithValue("@Code", tBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved update ");
            this.Hide();
            courses c=new courses();
            c.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
