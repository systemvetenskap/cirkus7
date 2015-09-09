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
    public partial class MainForm : Form
    {
        private int staffid;
        private string staffUserId;
        private string staffFname;
        private string staffLname;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        private void listCustomers()
        {
            string sql = "SELECT lname, fname, customerid FROM customer;";
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgCustomers.DataSource = dt;
            //DataGridViewColumn column = dgCustomers.Columns[0];
            //DataGridViewColumn column1 = dgCustomers.Columns[1];
            //DataGridViewColumn column2 = dgCustomers.Columns[2];
            ////this.dgCustomers.Columns[0].Visible = false;
            //column.Width = 60;
            //column1.Width = 60;
            //column2.Width = 80;

            conn.Close();
        }

        private void listTickets()
        {
            
        }
        public void ListaPersonal()//Metod för att lista personalen i Datagriden
        {
            string sql = "SELECT staffid, fname, lname, phonenumber FROM staff;";
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewStaff.DataSource = dt;       

            DataGridViewColumn column = dataGridViewStaff.Columns[0];
            DataGridViewColumn column1 = dataGridViewStaff.Columns[1];
            DataGridViewColumn column2 = dataGridViewStaff.Columns[2];
            this.dataGridViewStaff.Columns[0].Visible = false;
            column.Width = 60;
            column1.Width = 60;
            column2.Width = 80;

            conn.Close();
        }
        public bool EndastSiffror(string värde) //Metod för att kontrollera om det bara är siffror
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
        public bool BaraBokstäver(string namn)//Metod för att kontrollera om det bara är bokstäver
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


        public MainForm(string adminAuthorization, string staffUserID, string staffFname, string staffLname)
        {
            InitializeComponent();

            if (adminAuthorization != "1")
        {
                tabControl1.TabPages.RemoveAt(2);
                tabControl1.TabPages.RemoveAt(1);
            }
            this.staffUserId = staffUserID;
            this.staffLname = staffLname;
            this.staffFname = staffFname;

            labelStaffName.Text = staffFname + " " + staffLname;
        }

        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm(staffUserId);
            custForm.ShowDialog();
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
            tomFalt();
        }

        private void btnUpdateraKonto_Click(object sender, EventArgs e)
        {
            if (!EndastSiffror(textBoxTelefonnummer.Text))
            {
                MessageBox.Show("Telefonnummret får bara innehålla siffror");
                return;
            }
            if (!BaraBokstäver(textBoxFornamn.Text) || !BaraBokstäver(textBoxEfternamn.Text))
            {
                MessageBox.Show("Förnamn & efternamn får endast innehålla bokstäver");
                return;
            }

            if (dataGridViewStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Uppdatera konto")
            {
                int selectedIndex = dataGridViewStaff.SelectedRows[0].Index;

                staffid = int.Parse(dataGridViewStaff[0, selectedIndex].Value.ToString());

                btnTomFalten.Enabled = false;
                btnSkapaKonto.Enabled = false;
                dataGridViewStaff.Enabled = false;

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select fname, lname, phonenumber, email, username, password, auth
                                                        from staff where staffid = '" + staffid + "'", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();
                read.Read();

                textBoxFornamn.Text = read[0].ToString();
                textBoxEfternamn.Text = read[1].ToString();
                textBoxTelefonnummer.Text = read[2].ToString();
                textBoxEpost.Text = read[3].ToString();
                textBoxAnvandarnamn.Text = read[4].ToString();
                textBoxLosenord.Text = read[5].ToString();
                string auth = read[6].ToString();
                comboBoxBehorighetsniva.SelectedIndex = Convert.ToInt16(auth);
                conn.Close();
                btnUpdateraKonto.Text = "Spara ändringar";
                textBoxAnvandarnamn.Enabled = false;

            }
            else if (dataGridViewStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Spara ändringar") 
            {

                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(@"update staff set fname = @fn, lname = @ln, phonenumber = @pn, email = @email, 
                                                        username = @un, password = @pass, auth = @auth where staffid =@id", conn);
                                                        
                cmd.Parameters.Add(new NpgsqlParameter("fn", textBoxFornamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("ln", textBoxEfternamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("pn", textBoxTelefonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("email", textBoxEpost.Text));
                cmd.Parameters.Add(new NpgsqlParameter("un", textBoxAnvandarnamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("pass", textBoxLosenord.Text));
                cmd.Parameters.Add(new NpgsqlParameter("id", staffid));
                if (comboBoxBehorighetsniva.SelectedIndex == 0)
                {
                    int auth = 0;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }
                if (comboBoxBehorighetsniva.SelectedIndex == 1)
                {
                    int auth = 1;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));

                }

                cmd.ExecuteNonQuery();

                conn.Close();

                dataGridViewStaff.Enabled = true;
                tomFalt();
                ListaPersonal();
                btnUpdateraKonto.Text = "Uppdatera konto";
                textBoxAnvandarnamn.Enabled = true;
                btnSkapaKonto.Enabled = true;

            }

        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSkapaKonto_Click(object sender, EventArgs e)
        {
            if (!EndastSiffror(textBoxTelefonnummer.Text))
            {
                MessageBox.Show("Telefonnummret får bara innehålla siffror");
                return;
            }
            if (!BaraBokstäver(textBoxFornamn.Text)||!BaraBokstäver(textBoxEfternamn.Text))
            {
                MessageBox.Show("Förnamn & efternamn får endast innehålla bokstäver");
                return;
            }
            if (string.IsNullOrEmpty(textBoxFornamn.Text)||string.IsNullOrEmpty(textBoxEfternamn.Text)
                ||string.IsNullOrEmpty(textBoxTelefonnummer.Text)||string.IsNullOrEmpty(textBoxEpost.Text)
                ||string.IsNullOrEmpty(textBoxAnvandarnamn.Text)||string.IsNullOrEmpty(textBoxLosenord.Text)
                ||string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
            {
                MessageBox.Show("Ett eller flera fält är tomma. Fyll i alla fält");
                return;
            }
            try
            {
       
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
            catch (NpgsqlException)
            {

                MessageBox.Show("Användarnamnet är upptaget");
                conn.Close();
            }

        }
        public void tomFalt()
        {
            textBoxFornamn.Clear();
            textBoxEfternamn.Clear();
            textBoxEpost.Clear();
            textBoxTelefonnummer.Clear();
            textBoxAnvandarnamn.Clear();
            textBoxLosenord.Clear();
            comboBoxBehorighetsniva.ResetText();
        }

        private void listBoxRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



  

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curTab = tabControl1.SelectedIndex;

            switch (curTab)
            {
                default:
                    //Sälja biljetter tabben.
                    listCustomers();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}
