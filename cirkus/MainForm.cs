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
using NpgsqlTypes;

namespace cirkus
{
    public partial class MainForm : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
       
        public void ListaPersonal()
        {
            string sql = "SELECT fname, lname, phonenumber FROM staff;";
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewStaff.DataSource = dt;
            conn.Close();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

        }

        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm();

            custForm.ShowDialog();

            listBoxCustomer.Items.Clear();
            listBoxTicket.Items.Clear();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           ListaPersonal();
        }

        private void btnTomFalten_Click(object sender, EventArgs e)
        {
            textBoxFornamn.Clear();
            textBoxEfternamn.Clear();
            textBoxEpost.Clear();
            textBoxTelefonnummer.Clear();
            textBoxAnvandarnamn.Clear();
            textBoxLosenord.Clear();
        }

        private void btnUpdateraKonto_Click(object sender, EventArgs e)
        {
            //if (listBoxRegister.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Markera ett konto att updatera först");
            //}
            //else
            //{
            //    //Personal nyPersonal = new Personal();
            //    //nyPersonal.förnamn = textBoxFornamn.Text;
            //    //nyPersonal.efternamn = textBoxEfternamn.Text;
            //    //nyPersonal.telefonnummer = textBoxTelefonnummer.Text;
            //    //nyPersonal.epost = textBoxEpost.Text;
            //    //nyPersonal.användarnamn = textBoxAnvandarnamn.Text;
            //    //nyPersonal.lösenord = textBoxLosenord.Text;
            //    //nyPersonal.behörighetsnivå = comboBoxBehorighetsniva.Text;
            //}
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSkapaKonto_Click(object sender, EventArgs e)
        {
            try
            {
                //Personal nyPersonal = new Personal();
                //nyPersonal.förnamn = textBoxFornamn.Text;
                //nyPersonal.efternamn = textBoxEfternamn.Text;
                //nyPersonal.telefonnummer = textBoxTelefonnummer.Text;
                //nyPersonal.epost = textBoxEpost.Text;
                //nyPersonal.användarnamn = textBoxAnvandarnamn.Text;
                //nyPersonal.lösenord = textBoxLosenord.Text;
                //nyPersonal.behörighetsnivå = comboBoxBehorighetsniva.Text;
                conn.Open();
                string sql = "INSERT INTO staff (fname,lname,phonenumber,email,username,password,auth) VALUES(:fname, :lname, :phonenumber, :email, :username, :password, :auth)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("fname", textBoxFornamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("lname", textBoxEfternamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("phonenumber", textBoxTelefonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("email", textBoxEpost.Text));
                cmd.Parameters.Add(new NpgsqlParameter("username", textBoxAnvandarnamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("password", textBoxLosenord.Text));

                if (comboBoxBehorighetsniva.Text == "Biljettförsäljare")
                {
                    int auth = 0;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }
                else
                {
                    int auth = 1;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));

                }
                cmd.ExecuteNonQuery();
                conn.Close();
                ListaPersonal();
            }
            catch (NpgsqlException ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void listBoxRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
