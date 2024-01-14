using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.Equals(textBoxName.Text, "admin") && String.Equals(textBoxPassword.Text, "1234"))
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();
            } else
            {
                MessageBox.Show("Wrong password or user!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Text = "";
                textBoxPassword.Text = "";
            }
        }
    }
}
