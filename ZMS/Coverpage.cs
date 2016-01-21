using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZMS
{
    public partial class Coverpage : Form
    {
        public Coverpage()
        {
            InitializeComponent();
            textBoxPass.PasswordChar = '●';
            textBoxPass.MaxLength = 8;
        }

        private void loginTextClear()
        {
            textBoxName.Text="";
            textBoxPass.Text="";
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelPass_Click(object sender, EventArgs e)
        {

        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminWork go = new AdminWork();
            go.ShowDialog();
            //try
            //{
            //    string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ZMS_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            //    SqlConnection connection = new SqlConnection(connectionString);
            //    string commandString = "SELECT * FROM login where username='" + textBoxName.Text + "'and password='" + textBoxPass.Text + "'";
            //    SqlCommand SelectCommand = new SqlCommand(commandString, connection);
            //    SqlDataReader sqlReader;
            //    connection.Open();
            //    sqlReader = SelectCommand.ExecuteReader();
            //    int count = 0;
            //    while (sqlReader.Read())
            //    {
            //        count = count + 1;
            //    }
            //    if (count == 1)
            //    {
            //        loginTextClear();
            //        MessageBox.Show("Username and password is Correct");
            //        this.Hide();
            //        AdminWork go = new AdminWork();
            //        go.ShowDialog();
            //    }
            //    else if (count > 1)
            //    {
            //        MessageBox.Show("Duplicate username and password exists", "Error");
            //        loginTextClear();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username and password is not correct", "Error");
            //        loginTextClear();
            //    }
            //    connection.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
