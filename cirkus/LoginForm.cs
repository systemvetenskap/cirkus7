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
            // nya strängar som kommer att bestämma vilket konto vi hämtar från databasen
            string username, password, auth;

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

                // Hämtar behörigheten från resultatet. Om det inte finns något resultat så avbryts koden här.
                auth = read[0].ToString();

                // Huvudfönstret skapas och öppnas, auth bestämmer om adminverktygen ska visas eller inte. om värdet är 1 så visas de.
                MainForm frm = new MainForm(auth, read[0].ToString(), read[1].ToString(), read[2].ToString());
                conn.Close();

                this.Visible = false;
                    
                // Visa dialogfönstret.
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // det här används när man väljer att logga ut.
                    this.Visible = true;
                }
                else
                {
                    // Det här används när programmet avslutas. Då ska hela applikationen avslutas.
                    Application.Exit();
                }
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
