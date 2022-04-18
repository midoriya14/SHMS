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
//using System.IO;

namespace SHMS
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 b = new Form5();
            b.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            if (textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please fill required fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT ID FROM student WHERE (ID = @ID)", con);
                check_User_Name.Parameters.AddWithValue("@ID", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {

                    MessageBox.Show("That ID already exixt");


                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                    try
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO student(ID, Picture, Name, Gender, DateOfBirth, BloodGroup, Institution, Contact, DateOfReg, RoomNo) VALUES (@ID,@Picture,@Name,@Gender,@DateOFBirth, @BloodGroup, @Institution, @Contact, @DateOfReg, @RoomNo)", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                        //cmd.Parameters.AddWithValue("@Picture", pictureBox1.Image);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("Picture", memstr.ToArray());
                        //con.Open();
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@BloodGroup", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@Institution", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                        cmd.Parameters.AddWithValue("@DateOfReg", dateTimePicker2.Text);
                        cmd.Parameters.AddWithValue("@RoomNo", textBox4.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox2.Text = "";
                        dateTimePicker1.Text = "";
                        comboBox1.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        dateTimePicker2.Text = "";
                        textBox4.Text = "";

                        MessageBox.Show("New student added successfully!");

                        this.Hide();
                        Form8 b = new Form8();
                        b.Show();

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 b = new Form8();
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Seleccione una imagen";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
            }*/

            openFileDialog1.Filter = "Select image(*.JpG; *.png; *.Gif)|*.JpG; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }
    }
}
