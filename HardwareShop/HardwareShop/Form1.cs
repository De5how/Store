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
    public partial class Form1 : Form
    {
        SqlConnection _con1;

        public static int cv { get; set; }
        public static string NameUser { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            BD db = new BD();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Логин = @aL AND Пароль = @aP", db.getConnection());
            //SqlCommand commandID = new SqlCommand("SELECT * FROM Users ID = 4", db.getConnection());
            
            command.Parameters.Add("@aL", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@aP", SqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            try
            {
                if (table.Rows.Count > 0)
                {
                    for (int d = 0; d < table.Rows.Count; ) 
                    {
                        
                        /////////////проверка на простых пользователей/////////////
                        if ((table.Rows[d][4].ToString() == textBox1.Text) && (table.Rows[d][5].ToString() == textBox2.Text))
                        {
                            /////////////проверка на админа/////////////
                            if ((table.Rows[d][0].ToString() == "4"))
                            {
                                this.Hide();
                                MessageBox.Show("Yes");
                                Form4 form4 = new Form4();
                                form4.ShowDialog();
                            }
                            else 
                            {
                                this.Hide();
                                MessageBox.Show("Yes");
                                NameUser = table.Rows[d][2].ToString() + " " + table.Rows[d][3].ToString();
                                cv = int.Parse(table.Rows[d][0].ToString());
                                NameUser = table.Rows[d][2].ToString() + " " + table.Rows[d][3].ToString();
                                Form3 form3 = new Form3();
                                form3.ShowDialog();
                            }
                        }

                        ///////////ошибка///////////
                       /* else 
                        {
                            MessageBox.Show("No");
                        }*/
                    }
                    
                    //if (table.Rows[0][4].ToString() == "1")
                    //{
                    //    this.Hide();
                    //    Form3 form3 = new Form3();
                    //    form3.ShowDialog();
                    //}

                }
            }
            catch (Exception)
            {

                MessageBox.Show("No");
            }
            /*if (table.Rows.Count > 0)
            {
                if (table.Rows[0][2].ToString() == "0")
                {
                    this.Hide();
                    MessageBox.Show("Yes");
                    Form3 form3 = new Form3();
                    form3.ShowDialog();
                }
                //if (table.Rows[0][4].ToString() == "1")
                //{
                //    this.Hide();
                //    Form3 form3 = new Form3();
                //    form3.ShowDialog();
                //}

            }
            else
                MessageBox.Show("No");
        }*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
