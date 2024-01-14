using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace AppClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=parola");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM company.department", connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM company.employee", connection);

                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "department");
                dataGridView1.DataSource = ds.Tables["department"];

                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "employee");
                dataGridView2.DataSource = ds2.Tables["employee"];

                connection.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxDepartment.Text))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/employee/");
                string str = "getAllManagersPerDepartment/" + textBoxDepartment.Text;
                HttpResponseMessage response = client.GetAsync(str).Result;
                var emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                dataGridView3.DataSource = emp;
            } 
            else
            {
                MessageBox.Show("Select Department!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxDepartment.Text))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/employee/");
                string str = "getAllEmployeesPerDepartment/" + textBoxDepartment.Text;
                HttpResponseMessage response = client.GetAsync(str).Result;
                var emp = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                dataGridView3.DataSource = emp;
            }
            else
            {
                MessageBox.Show("Select Department!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage("teoccristian2002@yahoo.com", textBox1.Text);
            message.Subject = textBox2.Text;
            message.Body = textBox3.Text;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            NetworkCredential nc = new NetworkCredential("teoccristian2002@yahoo.com", "password");
            smtp.EnableSsl = true;
            smtp.Credentials = nc;
            smtp.Send(message);
        }
    }
}
