using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_home
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnAddCourses_Click_1(object sender, EventArgs e)
        {
            courses c = new courses();
            this.Hide();
            c.Show();

        }

        private void btnFegisterStudent_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();

        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendance attendance = new Attendance();
            attendance.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Enroll enroll = new Enroll();
            enroll.Show();


        }
    }
}
