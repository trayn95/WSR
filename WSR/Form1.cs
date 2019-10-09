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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        Form mainForm = new Form();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Comp0714\Documents\WSR.mdf;Integrated Security=True;Connect Timeout=30;";
            conn = new SqlConnection(ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = log.Text;
            string pas = pass.Text;
            if (login == "")
            {
                MessageBox.Show("Введите логин!");
            }
            else if (pas == "")
            {
                MessageBox.Show("Введите пароль!");
            }
            else
            {
                try
                {
                    conn.Open();
                    var query = new SqlCommand(string.Format("SELECT role FROM users WHERE login = '" + login + "' and password='" + pas + "'"), conn);
                    var result = query.ExecuteReader();
                    result.Read();
                    string role = result.GetString(0);
                    switch (role.ToString())
                    {
                        case "Admin":
                            mainForm = new admin(conn);
                            break;
                        case "Manager":
                            mainForm = new manager(conn);
                            break;
                        case "User":
                            mainForm = new manager(conn);
                            break;
                    }
                    mainForm.Owner = this.Owner;
                    mainForm.Show();
                    this.Hide();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Такого пользователя не существует!!!");
                    Application.Restart();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm = new registr(conn);
            mainForm.Owner = this.Owner;
            mainForm.Show();
            this.Hide();
        }
    }
}
