﻿using System;
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
    public partial class OneStop : Form
    {
        public OneStop()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OneStop_Load(object sender, EventArgs e)
        {
            // Chnage sqlquery and table name
            //stringsql = “Select Employeeid, FirstName, LastName from Employees”;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DSJ0VD4\\SQLEXPRESS;Initial Catalog=onestop_creation;Integrated Security=True");
            conn.Open();
            string query = "Select * FROM request";
            SqlCommand cmd = new SqlCommand(query, conn);
            // try
            // {
            //cmd = new MySqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["request_id"].ToString());
                listitem.SubItems.Add(dr["request_id"].ToString());
                listitem.SubItems.Add(dr["status_fyp"].ToString());
                listitem.SubItems.Add(dr["status_fin"].ToString());
                //listView2.Items.Add(listitem);
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            listView2.Clear();
            listView2.Items.Add("Student ID");
            listView2.Items.Add("Request ID");
            listView2.Items.Add("Status FYP");
            listView2.Items.Add("Status Finance");
            */
            listView2.Items.Clear();

            // Chnage sqlquery and table name
            //stringsql = “Select Employeeid, FirstName, LastName from Employees”;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DSJ0VD4\\SQLEXPRESS;Initial Catalog=onestop_creation;Integrated Security=True");
            conn.Open();
            string query = "Select * FROM request";
            SqlCommand cmd = new SqlCommand(query, conn);
            // try
            // {
            //cmd = new MySqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["request_id"].ToString());
                listitem.SubItems.Add(dr["request_id"].ToString());
                listitem.SubItems.Add(dr["status_fyp"].ToString());
                listitem.SubItems.Add(dr["status_fin"].ToString());
                listView2.Items.Add(listitem);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This retrieves the selected row 
            ListViewItem item1;
            item1 = listView2.SelectedItems[0];
            string id = listView2.SelectedItems[0].SubItems[1].Text.ToString();
            //MessageBox.Show(id);

            string statusfyp, statusfin;
            statusfyp = listView2.SelectedItems[0].SubItems[2].Text.ToString();
            statusfin = listView2.SelectedItems[0].SubItems[3].Text.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DSJ0VD4\\SQLEXPRESS;Initial Catalog=onestop_creation;Integrated Security=True");
            conn.Open();
            if (statusfin == "accepted" && statusfyp == "accepted")
            {
                string query = "update request set status = 'approved' where request_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Token generated for student " + id + ".");
            }
            else
            {
                conn.Close();
                MessageBox.Show("Status to notify is incorrect.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out successfully.");
            this.Hide();
            LandingPage lp = new LandingPage();
            lp.ShowDialog();
        }
    }
}
