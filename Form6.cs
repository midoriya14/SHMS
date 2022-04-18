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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 a = new Form5();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //try()
            //{
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM student order by ID", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridView1.RowTemplate.Height = 75;
                dataGridView1.DataSource = dt;
                DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                pic1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
                pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //}

            /*catch(Exception ex)
            {
                ex.Message = "Enter Id";
            }*/
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a student id for search.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT ID FROM student WHERE (ID = @ID)", con);
                check_User_Name.Parameters.AddWithValue("@ID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    reader.Dispose();



                    SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("Student NOT Exists.");
                }
            }
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
                errorProvider1.SetError(textBox1, "please enter a student ID for search!");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
