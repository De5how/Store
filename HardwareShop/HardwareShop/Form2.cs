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

namespace HardwareShop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD db = new BD();
            SqlCommand command = new SqlCommand("INSERT INTO Users VALUES(@Mail,@Логин,@Пароль,@Имя,@Фамилия)", db.getConnection());
            command.Parameters.AddWithValue("@Mail", textBox1.Text);
            command.Parameters.AddWithValue("@Логин", textBox2.Text);
            command.Parameters.AddWithValue("@Пароль", textBox3.Text);
            command.Parameters.AddWithValue("@Имя", textBox4.Text);
            command.Parameters.AddWithValue("@Фамилия", textBox5.Text);

            try
            {

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ok");
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                else
                    MessageBox.Show("not ok");
            }
            catch (SqlException exec)
            {
                MessageBox.Show(exec.Message);
            }
            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
        }
    }
}
