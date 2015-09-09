using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace cirkus
{
    public partial class AddCustomerForm : Form
    {
        private string staffid;
        public AddCustomerForm(string staffid)
        {
            InitializeComponent();
            this.staffid = staffid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
            try
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(@"INSERT INTO customer (fname, lname, phonenumber, email, staffid) VALUES (@fname, @lname, @phone, @email, @staffid)", conn);
                command.Parameters.AddWithValue("@fname", textBoxFname.Text);
                command.Parameters.AddWithValue("@lname", textBoxLname.Text);
                command.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                command.Parameters.AddWithValue("@staffid", staffid);

                command.ExecuteNonQuery();

                conn.Close();
                this.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
                conn.Close();
            }
        }
    }
}
