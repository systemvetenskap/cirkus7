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
        public string staffUserId, fname, lname, auth;


        private void textUsername_Click(object sender, EventArgs e)
        {
            textUsername.Clear();
        }

        private void textPassword_Click(object sender, EventArgs e)
        {
            textPassword.Clear();
        }

        private NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // nya strängar som kommer att bestämma vilket konto vi hämtar från databasen
            string username, password;

            username = textUsername.Text;
            password = textPassword.Text;

            try
            {
                // Vi använder parametrar för att det är mer säkert än att använda "username ="+username etc etc..
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(@"select staffid, fname, lname, auth from staff where username = @user and password = @pass;", conn);
                command.Parameters.AddWithValue("@user", username);
                command.Parameters.AddWithValue("@pass", password);

                NpgsqlDataReader read;
                read = command.ExecuteReader();
                read.Read();

                // Hämtar behörigheten från resultatet. Om det inte finns något resultat så avbryts koden här..
                auth = read[3].ToString();
                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Fel användarnamn/lösenord");
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
