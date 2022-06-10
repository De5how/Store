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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            BD db = new BD();
            db.openConnection();
            SqlCommand _getDeliveries = new SqlCommand("SELECT * FROM Поставки");
            SqlDataAdapter _da2 = new SqlDataAdapter(_getDeliveries);
            _getDeliveries.Connection = db._con1;
            DataTable _dtb1 = new DataTable();
            DataSet ds1 = new DataSet();
            _da2.Fill(ds1);
            _da2.SelectCommand = _getDeliveries;
            dataGridView1.DataSource = ds1.Tables[0];
            db.closeConnection();

            //BD db1 = new BD();
            //db1.openConnection();
            SqlCommand _getProducts = new SqlCommand("SELECT * FROM Товар");
            SqlDataAdapter _da = new SqlDataAdapter(_getProducts);
            _getProducts.Connection = db._con1;
            DataTable _dtb = new DataTable();
            DataSet ds2 = new DataSet();
            _da.Fill(ds2);
            _da.SelectCommand = _getProducts;
            dataGridView2.DataSource = ds2.Tables[0];
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD db = new BD();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Поставки VALUES(@ID_Поставки,@ID_Товара,@ID_Партнера,@Стоимость_поставки)", db.getConnection());
                command.Parameters.AddWithValue("@ID_Поставки", textBox1.Text);
                command.Parameters.AddWithValue("@ID_Товара", textBox2.Text);
                command.Parameters.AddWithValue("@ID_Партнера", textBox3.Text);
                command.Parameters.AddWithValue("@Стоимость_поставки", textBox4.Text);


                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ok");
                    this.Hide();
                    Form5 form = new Form5();
                    form.ShowDialog();
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
            try
            {

                SqlCommand command = new SqlCommand("INSERT INTO Товар VALUES(@ID_Товара,@ID_Склада,@Наименование_товара,@Цена_товара,@Количество, @Отдел_склада, @Pics)", db.getConnection());
                command.Parameters.AddWithValue("@ID_Товара", textBox8.Text);
                command.Parameters.AddWithValue("@ID_Склада", textBox9.Text);
                command.Parameters.AddWithValue("@Наименование_товара", textBox10.Text);
                command.Parameters.AddWithValue("@Цена_товара", textBox11.Text);
                command.Parameters.AddWithValue("@Количество", textBox12.Text);
                command.Parameters.AddWithValue("@Отдел_склада", textBox13.Text);
                command.Parameters.AddWithValue("@Pics", textBox15.Text);

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("ok");
                    this.Hide();
                    Form5 form = new Form5();
                    form.ShowDialog();
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
            BD db = new BD();
            SqlCommand cmd = new SqlCommand("DELETE FROM Поставки WHERE ID_Поставки = " + textBox7.Text);
            db.openConnection();
            cmd.Connection = db._con1;
            cmd.ExecuteNonQuery();
            db.closeConnection();
            this.Hide();
            Form5 form = new Form5();
            form.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BD db = new BD();
            SqlCommand cmd = new SqlCommand("DELETE FROM Товар WHERE ID_Товара = " + textBox14.Text);
            db.openConnection();
            cmd.Connection = db._con1;
            cmd.ExecuteNonQuery();
            db.closeConnection();
            this.Hide();
            Form5 form = new Form5();
            form.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent; 
            label13.BackColor = Color.Transparent;
        }
    }
}
