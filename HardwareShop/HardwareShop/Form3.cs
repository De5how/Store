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
    public partial class Form3 : Form
    {
        string a;
        string userID;
        public Form3()
        {
            InitializeComponent();

            Form1 form1 = new Form1();
            int IdUser = Form1.cv;
            label4.Text = Form1.NameUser;
            userID = IdUser.ToString();


            BD db = new BD();
            db.openConnection();
            SqlCommand _getProduct = new SqlCommand("SELECT * FROM Товар");
            SqlDataAdapter _da2 = new SqlDataAdapter(_getProduct);
            _getProduct.Connection = db._con1;
            DataTable _dtb1 = new DataTable();
            DataSet ds1 = new DataSet();
            _da2.Fill(ds1);
            _da2.SelectCommand = _getProduct;
            dataGridView1.DataSource = ds1.Tables[0];
            db.closeConnection();
        }


       

        private void button2_Click(object sender, EventArgs e)
        {
            //int b = int.Parse(textBox1.Text);
            BD db = new BD();
            try
            {

                SqlCommand command = new SqlCommand("INSERT INTO Заказ VALUES(@ID_Товара,@ID_Пользователя,@ID_Места_выдачи)", db.getConnection());
                command.Parameters.AddWithValue("@ID_Товара", textBox1.Text);
                command.Parameters.AddWithValue("@ID_Пользователя", userID);
                command.Parameters.AddWithValue("@ID_Места_выдачи", textBox2.Text);
               

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM [Место_выдачи]");
                        cmd.Connection = db._con1;
                        cmd.ExecuteNonQuery();
                        a = cmd.ToString();

                        int s = int.Parse(textBox2.Text);
                        int sum = s - 1;

                        SqlDataAdapter _da1 = new SqlDataAdapter(cmd);
                        DataTable _dtb1 = new DataTable();
                        _da1.SelectCommand = cmd;
                        _da1.Fill(_dtb1);
                        a = _dtb1.Rows[sum][0].ToString();
                        MessageBox.Show(a.ToString());
                    }

                    catch (Exception)
                    {

                        MessageBox.Show("ошибка место выдачи");
                    }


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

        private void button1_Click(object sender, EventArgs e)
        {
            BD db = new BD();
            
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Товар");
                db.openConnection();
                cmd.Connection = db._con1;
                cmd.ExecuteNonQuery();
                a = cmd.ToString();

                int s = int.Parse(textBox1.Text);
                int sum = s - 1;

                SqlDataAdapter _da1 = new SqlDataAdapter(cmd);
                DataTable _dtb1 = new DataTable();
                _da1.SelectCommand = cmd;
                _da1.Fill(_dtb1);
                a = _dtb1.Rows[sum][6].ToString();
                db.closeConnection();
                pictureBox1.Image = System.Drawing.Image.FromFile(a);
            }
            catch (Exception)
            {

                MessageBox.Show("нет");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }
    }
}
