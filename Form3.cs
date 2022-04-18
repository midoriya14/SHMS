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

namespace SHMS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
            
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-RLEUU0O;Initial Catalog=USER_TABLEE;User ID=sa;Password=123456;Pooling=False");
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");


            //string query = "Select * from member where ID='" + textBox1.Text.Trim() + "' and Password = '" + textBox3.Text.Trim() + "'";
            string query = "Select * from username where username ='" + textBox1.Text.Trim() + "' and password = '" + textBox3.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (dtbl.Rows.Count == 1)
                {
                    this.Hide();
                    Form4 a = new Form4();
                    a.Show();
                }

                else
                {
                    MessageBox.Show("wrong username or password!");
                }
            }



            /*
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO username (username, password) VALUES(@username, @password)", con);
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        BindData();
             */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "please enter your username!");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider2.SetError(textBox3, "please enter your password!");
            }
            else
            {
                errorProvider2.SetError(textBox3, null);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a = new Form2();
            a.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        /*
                void BindData()
                {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *  FROM username", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                }
        */
    }
}
