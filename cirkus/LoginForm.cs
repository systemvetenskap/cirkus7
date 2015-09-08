using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace cirkus
{
    public partial class LoginForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        public LoginForm()
        {
            InitializeComponent();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string anvandarnamn, losenord, behorighet;

            anvandarnamn = textUsername.Text;
            losenord = textPassword.Text;

            try
            {
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(@"select auth from staff where username = @user and password = @pass;", conn);
                command.Parameters.AddWithValue("@user", anvandarnamn);
                command.Parameters.AddWithValue("@pass", losenord);

                NpgsqlDataReader read;
                read = command.ExecuteReader();
                read.Read();
                behorighet = read[0].ToString();
                conn.Close();

                if (behorighet == "0" || behorighet == "1")
                {
                    MainForm frm = new MainForm();
                    this.Visible = false;
                    frm.abc = 0;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.Visible = true;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Fel användarnamn/lösenord");
                conn.Close();
            }
          
        }
    }
}
