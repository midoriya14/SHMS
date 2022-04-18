using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHMS
{
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM docinfo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridView1.DataSource = dt;

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM docuser", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.JpG; *.png; *.Gif)|*.JpG; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox5.Text == "" || dateTimePicker2.Text == "" || textBox8.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT ID FROM docinfo WHERE (ID = @ID)", con);
                check_User_Name.Parameters.AddWithValue("@ID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {

                    MessageBox.Show("That ID already exist");


                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO docinfo(ID, Picture, Name, Gender, Age, NID, Contact, Address, Specialist, Schedule,  DateOfReg) VALUES (@ID, @Picture, @Name, @Gender, @Age, @NID, @Contact, @Address, @Specialist, @Schedule,  @DateOfReg)", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                        SqlCommand cmd1 = new SqlCommand("INSERT INTO docuser(ID, username, password) VALUES (@ID, @username, @password)", con);
                        cmd1.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                        cmd1.Parameters.AddWithValue("@username", textBox3.Text);
                        cmd1.Parameters.AddWithValue("@password", textBox4.Text);
                        _ = cmd1.ExecuteNonQuery();

                        //cmd.Parameters.AddWithValue("@Picture", pictureBox1.Image);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("Picture", memstr.ToArray());
                        //con.Open();
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@Age", textBox6.Text);
                        cmd.Parameters.AddWithValue("@NID", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox9.Text);
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                        cmd.Parameters.AddWithValue("@DateOfReg", dateTimePicker2.Text);
                        cmd.Parameters.AddWithValue("@Schedule", textBox8.Text);
                        cmd.Parameters.AddWithValue("@Specialist", textBox10.Text);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox2.Text = "";
                        //dateTimePicker1.Text = "";
                        //comboBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        dateTimePicker2.Text = "";
                        //comboBox3.Text = "";

                        MessageBox.Show("New doctor added successfully!");

                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form22 a = new Form22();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
