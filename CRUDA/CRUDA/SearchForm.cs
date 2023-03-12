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

namespace CRUDA
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1=new Form1();
            form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && comboBox1.Text!="Select...")
            {
                refresher();
            }
            else
            {
                MessageBox.Show("Please select a value of combo box or enter text in text box","Error");
            }
        }
    private bool refresher()
    {
        dataGridView1.DataSource = null;
        var con = Configuration.getInstance().getConnection();
            Console.WriteLine(comboBox1.Text);
            Console.WriteLine(textBox1.Text);
            Console.WriteLine("Select * from students WHERE " + comboBox1.Text + " = " + textBox1.Text);
        SqlCommand cmd = new SqlCommand("Select * from students WHERE "+ comboBox1.Text +"= @Nt", con);
            cmd.Parameters.AddWithValue("@Nt",textBox1.Text);
           
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dataGridView1.DataSource = dt;

        dataGridView1.Refresh();
        return true;

    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
