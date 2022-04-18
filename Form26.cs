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
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent();
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

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM docinfo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM docinfo order by ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.RowTemplate.Height = 75;
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM docinfo WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-40HQ0BH;Initial Catalog=username;Persist Security Info=True;User ID=sa;Password=AsDf13@2");
            con.Open();

            if (textBox2.Text == "" || comboBox2.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox5.Text == "" || textBox3.Text == "" || dateTimePicker2.Text == "" || textBox4.Text == "" || textBox6.Text == "")
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

                        //UPDATE member SET Name = @Name, Age = @Age WHERE ID = @ID", con

                        SqlCommand cmd = new SqlCommand("UPDATE docinfo SET Picture = @Picture, Name = @Name, Gender = @Gender, Age = @Age, NID = @NID, Contact = @Contact, Address = @Address, Specialist = @Specialist, Schedule = @Schedule,  DateOfReg = @DateOfReg WHERE ID = @ID", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("Picture", memstr.ToArray());

                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);//2
                        cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);//3
                        cmd.Parameters.AddWithValue("@Age", textBox7.Text);//4
                        cmd.Parameters.AddWithValue("@Specialist", textBox8.Text);//8
                        cmd.Parameters.AddWithValue("@NID", textBox3.Text);//5
                        cmd.Parameters.AddWithValue("@Contact", textBox5.Text);//6
                        cmd.Parameters.AddWithValue("@DateOfReg", dateTimePicker2.Text);//10
                        cmd.Parameters.AddWithValue("@Address", textBox4.Text);//7
                        cmd.Parameters.AddWithValue("@Schedule", textBox6.Text);//9

                        cmd.ExecuteNonQuery();

                        con.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";//2
                        textBox3.Text = "";//5
                        textBox4.Text = "";//7
                        textBox5.Text = "";//6
                        textBox6.Text = "";//9
                        textBox7.Text = "";//4
                        textBox8.Text = "";//8
                        comboBox2.Text = "";//3
                        dateTimePicker2.Text = "";//10
                                                  
                        MessageBox.Show("Doctor updated successfully!");

                        /*this.Hide();
                        Form8 b = new Form8();
                        b.Show();*/

                        BindData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[1].Value);
            pictureBox1.Image = Image.FromStream(ms);
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            //textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.JpG; *.png; *.Gif)|*.JpG; *.png; *.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
