using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Director : Form
    {
        public Director()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage lp = new LandingPage();
            lp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Director_AddStaff das = new Director_AddStaff();
            das.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
