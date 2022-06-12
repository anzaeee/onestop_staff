using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    public partial class Director_AddStaff : Form
    {
        public Director_AddStaff()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.Items.Add(new Type("OneStop", "en"));
            comboBox1.Items.Add(new Type("Finance", "en"));
            comboBox1.Items.Add(new Type("FYP", "en"));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Director d = new Director();
            d.ShowDialog();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        class Type
        {
            string text;
            string value;

            public string Text
            {
                get
                {
                    return text;
                }
            }

            public string Value
            {
                get
                {
                    return value;
                }
            }

            public Type(string text, string value)
            {
                this.text = text;
                this.value = value;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out successfully.");
            this.Hide();
            LandingPage lp = new LandingPage();
            lp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DSJ0VD4\\SQLEXPRESS;Initial Catalog=onestop_creation;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string un = textBox1.Text;
            string pass = textBox2.Text;
            string type = comboBox1.Text;
            if (type == "OneStop")
            {
                string query = "Insert into staff(staff_id,password,type) values ('" + un + "','" + pass + "','OS')";
                cm = new SqlCommand(query, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
            }
            if (type == "Finance")
            {
                string query = "Insert into staff(staff_id,password,type) values ('" + un + "','" + pass + "','FIN')";
                cm = new SqlCommand(query, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
            }
            if (type == "FYP")
            {
                string query = "Insert into staff(staff_id,password,type) values ('" + un + "','" + pass + "','FYP')";
                cm = new SqlCommand(query, conn);
                cm.ExecuteNonQuery();
                cm.Dispose();
            }

            conn.Close();

            MessageBox.Show("Staff member has been added");
        }
    }
}
