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
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;

namespace cirkus
{
    public partial class PasswordRecoveryForm : Form
    {
        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        private void btnSendPassword_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string firstname;
            string lastname;
            string password;
            string username;

            lblStatus.Visible = false;

            if (!IsValidEmail(email))
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Vänligen ange en giltig e-post adress";
                return;
            }
            else
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(@"select fname, lname, email, password, username FROM staff WHERE email='"+email+"'", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    firstname = dr[0].ToString();
                    lastname = dr[1].ToString();
                    email = dr[2].ToString();
                    password = dr[3].ToString();
                    username = dr[4].ToString();
                    

                    string password_mail ="Hej "+firstname+" "+lastname+"\nDitt lösenord är: "+password+"\nDitt användarnamn är: "+username+" ";

                    conn.Close();

                    MailMessage mail = new MailMessage("kulbusstest@gmail.com", email, "Cirkus Kul&Bus - Lösenord", password_mail);

                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("kulbusstest@gmail.com", "Test12345");
                    client.EnableSsl = true;

                    client.Send(mail);

                    lblStatus.Visible = true;
                    lblStatus.Text = "Lösenordet har skickats till din e-post";
                    return;
                }
                catch (InvalidOperationException)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "E-posten finns inte registrerad hos oss";
                    return;
                }
            }
        }
    }
}
