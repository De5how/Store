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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            BD db = new BD();
            db.openConnection();
            SqlCommand _getUsers = new SqlCommand("SELECT * FROM Users");
            SqlDataAdapter _da2 = new SqlDataAdapter(_getUsers);
            _getUsers.Connection = db._con1;
            DataTable _dtb1 = new DataTable();
            DataSet ds1 = new DataSet();
            _da2.Fill(ds1);
            _da2.SelectCommand = _getUsers;
            dataGridView1.DataSource = ds1.Tables[0];
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD db = new BD();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Users VALUES(@Mail,@Имя,@Фамилия,@Логин,@Пароль)", db.getConnection());
                command.Parameters.AddWithValue("@Mail", textBox1.Text);
                command.Parameters.AddWithValue("@Имя", textBox2.Text);
                command.Parameters.AddWithValue("@Фамилия", textBox3.Text);
                command.Parameters.AddWithValue("@Логин", textBox4.Text);
                command.Parameters.AddWithValue("@Пароль", textBox5.Text);

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ok");
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

        private void button3_Click(object sender, EventArgs e)
        {
            BD db = new BD();
            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE ID_Пользователя = " + textBox6.Text);
            db.openConnection();
            cmd.Connection = db._con1;
            cmd.ExecuteNonQuery();
            db.closeConnection();
        }
    }
}
