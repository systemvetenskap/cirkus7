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

        #region Methods
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
        public bool BaraBokstäver(string namn)
        {
            bool okej = true;
            foreach (char bokstav in namn)
            {
                if (!char.IsLetter(bokstav))
                {
                    okej = false;
                }
            }
            return okej;
        }
        public bool EndastSiffror(string värde)
        {
            bool barasiffror = true;
            foreach (char siffra in värde)
            {
                if (!char.IsDigit(siffra))
                {
                    barasiffror = false;
                }
            }
            return barasiffror;
        }
        public void emptyTextboxes()
        {
            textBoxFname.BackColor = Color.White;
            textBoxLname.BackColor = Color.White;
            textBoxPhone.BackColor = Color.White;
            textBoxEmail.BackColor = Color.White;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            emptyTextboxes();
            if (textBoxFname.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxFname.Text) || !BaraBokstäver(textBoxFname.Text))
            {
                textBoxFname.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange förnamn, max 60 bokstäver";
                return;
            }
            if (textBoxLname.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxLname.Text)|| !BaraBokstäver(textBoxLname.Text))
            {
                textBoxLname.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange efternamn, max 60 bokstäver";
                return;
            }
            if (textBoxPhone.TextLength > 10 || string.IsNullOrWhiteSpace(textBoxPhone.Text) || !EndastSiffror(textBoxPhone.Text))
            {
                textBoxPhone.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange telefonnummer, max 10 siffror";
                return;
            }
            if (textBoxEmail.Text.Length > 60 || string.IsNullOrWhiteSpace(textBoxEmail.Text) || !IsValidEmail(textBoxEmail.Text))
            {
                textBoxEmail.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange en giltig email, max 60 tecken";
                return;
            }

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

                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.ListCustomers();

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
