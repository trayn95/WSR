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

namespace WSR
{
    public partial class registr : Form
    {
        private SqlConnection conn;
        Form mainForm = new Form();
        public registr(SqlConnection ConnectionString)
        {
            InitializeComponent();
            conn = ConnectionString;
        }

        private void registr_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = name.Text;
            string login = log.Text;
            string pas = pass.Text;
            if (login == "")
            {
                MessageBox.Show("Введите ФИО!");
            }
            else if (login == "")
            {
                MessageBox.Show("Введите логин!");
            }
            else if (pas == "")
            {
                MessageBox.Show("Введите пароль!");
            }
            else
            {

                SqlCommand result = new SqlCommand();
                result.Connection = conn;
                conn.Open();
                var query = new SqlCommand(string.Format("SELECT login FROM users WHERE login = '" + login + "'"), conn);
                var res = query.ExecuteScalar();

                conn.Close();
                if (res != null)
                {
                    MessageBox.Show("Введенный логин уже используется!");
                }
                else
                {
                    conn.Open();
                    result.CommandType = CommandType.Text;
                    result.CommandText = "INSERT INTO users (name, login, password,role) VALUES (N'" + fio + "', N'" + login + "', N'" + pas + "', N'User')";
                    result.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрированы!");
                    conn.Close();
                    mainForm = new Form1();
                    mainForm.Owner = this.Owner;
                    mainForm.Show();
                    this.Hide();
                    this.Close();
                }

            }
        }
    }
}
