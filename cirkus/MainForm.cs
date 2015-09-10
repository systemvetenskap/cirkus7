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
using System.Configuration;

namespace cirkus
{
    public partial class MainForm : Form
    {
        #region Variables
        private int staffid;
        private string staffUserId;
        private string staffFname;
        private string staffLname;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        private string sql = "";
        public DataTable dt = new DataTable();
        private NpgsqlDataAdapter da;
        private List<show> allShowsList;
        #endregion
        #region Main
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
                    LoadShows();
                    break;
                case 2:
                    ListaPersonal();
                    break;
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            listCustomers();

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

        #endregion
        #region Biljettförsäljning
        private void textBoxSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            listCustomers();
        }
        private void listCustomers()
        {
            string sqlSearch = textBoxSearchCustomer.Text;
            string sql = "SELECT lname, fname, customerid FROM customer WHERE LOWER(lname) LIKE LOWER('%" + sqlSearch + "%') OR LOWER(fname) LIKE LOWER('%" + sqlSearch + "%');";
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgCustomers.DataSource = dt;
                dgCustomers.Columns[0].HeaderText = "Efternamn";
                dgCustomers.Columns[1].HeaderText = "Förnamn";
                dgCustomers.Columns[2].HeaderText = "ID";
                dgCustomers.Columns[0].Width = 60;
                dgCustomers.Columns[1].Width = 60;
                dgCustomers.Columns[2].Width = 60;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void listTickets()
        {

        }
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm(staffUserId);
            custForm.ShowDialog();

        }
        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }
        #endregion
        #region Föreställningar
        private void buttonSkapaForestalnning_Click_1(object sender, EventArgs e)
        {
            ShowForm showForm = new ShowForm();
            showForm.ButtonVisibleSparaAndringar();

            showForm.ShowDialog();
        }
        private void buttonRaderaForestallning_Click(object sender, EventArgs e)
        {
            int selectedID;

            DataGridViewRow row = this.dgvShowsList.SelectedRows[0];

            selectedID = Convert.ToInt32(row.Cells["showid"].Value);

            string sql = "DELETE FROM show WHERE showid = '" + selectedID + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);


            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            LoadShows();
            MessageBox.Show("Förestälningen är raderad!");
        }

        private void buttonAndraForestallning_Click(object sender, EventArgs e)
        {
            int selectedID;
            DataGridViewRow row = this.dgvShowsList.SelectedRows[0];
            selectedID = Convert.ToInt32(row.Cells["showid"].Value);


            string nySelectedID = selectedID.ToString();

            ShowForm frm = new ShowForm();
            frm.SetID(nySelectedID);

            frm.ButtonVisibleLaggTillForestallning();

            frm.ShowDialog();
        }
        public void LoadShows()
        {
            DataTable dt = new DataTable();
            String sql;
            dgvShowsList.DataSource = null;
            dgvShowsList.Rows.Clear();

            try
            {



                conn.Open();
                sql = "select showid, date, name from show order by date DESC";
                da = new NpgsqlDataAdapter(sql, conn);
                da.Fill(dt);
                dgvShowsList.DataSource = dt;
                conn.Close();
                dgvShowsList.Columns["showid"].Visible = false;
            }
            catch
            {
            }


        }
        #endregion
        #region Konto
        private void textBoxSearchStaff_TextChanged(object sender, EventArgs e)
        {
            ListaPersonal();
        }
        private void ListaPersonal()//Metod för att lista personalen i Datagriden under konto tabben.
        {
            string sqlSearchStaff = textBoxSearchStaff.Text;
            string sql = "SELECT staffid, lname, fname, phonenumber  FROM staff WHERE LOWER(fname) LIKE LOWER('%" + sqlSearchStaff + "%') OR LOWER(lname) LIKE LOWER('%" + sqlSearchStaff + "%')";
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgStaff.DataSource = dt;

                dgStaff.Columns[0].Visible = false;
                dgStaff.Columns[1].Visible = true;
                dgStaff.Columns[2].Visible = true;
                dgStaff.Columns[3].Visible = true;

                dgStaff.Columns[1].HeaderText = "Efternamn";
                dgStaff.Columns[2].HeaderText = "Förnamn";
                dgStaff.Columns[3].HeaderText = "Telefonnummer";               

                DataGridViewColumn column = dgStaff.Columns[0];
                DataGridViewColumn column1 = dgStaff.Columns[1];
                DataGridViewColumn column2 = dgStaff.Columns[2];
               
                column.Width = 60;
                column1.Width = 60;
                column2.Width = 80;

                conn.Close();

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

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
        private void btnSkapaKonto_Click(object sender, EventArgs e)
        {
            //Kontrollerar längden på textboxarna
            if (textBoxFornamn.TextLength>60 || textBoxEfternamn.TextLength>60)
            {
                MessageBox.Show("Förnamn och efternamn får max innehålla 60 tecken");
                return;
            }
            if (textBoxTelefonnummer.TextLength>10)
            {
                MessageBox.Show("Telefonnummret får max innehålla 10 siffror");
                return;
            }
            if (textBoxEpost.TextLength>60)
            {
                MessageBox.Show("Epostadressen får innehålla max 60 tecken");
                return;
            }
            if (textBoxAnvandarnamn.TextLength>60 || textBoxLosenord.TextLength>60)
            {
                MessageBox.Show("Användarnamnet och lösenordet får max innehålla 60 tecken.");
                return;
            }
            //Slut kontrollera längd på textboxar

            //Kontrollerar siffror och bokstäver
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
            //Slut kontrollerar siffror och bokstäver

            //Kontrollerar tomma textboxar
            if (string.IsNullOrEmpty(textBoxFornamn.Text) || string.IsNullOrEmpty(textBoxEfternamn.Text)
                || string.IsNullOrEmpty(textBoxTelefonnummer.Text) || string.IsNullOrEmpty(textBoxEpost.Text)
                || string.IsNullOrEmpty(textBoxAnvandarnamn.Text) || string.IsNullOrEmpty(textBoxLosenord.Text)
                || string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
            {
                MessageBox.Show("Ett eller flera fält är tomma. Fyll i alla fält");
                return;
            }
            //Slut konrtrollerar tomma textboxar
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
                tomFalt();
            }
            catch (NpgsqlException)
            {

                MessageBox.Show("Användarnamnet är upptaget");
                conn.Close();
            }

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
        private void btnUpdateraKonto_Click(object sender, EventArgs e)
        {
            //Kontrollerar längden på textboxarna
            if (textBoxFornamn.TextLength > 60 || textBoxEfternamn.TextLength > 60)
            {
                MessageBox.Show("Förnamn och efternamn får max innehålla 60 tecken");
                return;
            }
            if (textBoxTelefonnummer.TextLength > 10)
            {
                MessageBox.Show("Telefonnummret får max innehålla 10 siffror");
                return;
            }
            if (textBoxEpost.TextLength > 60)
            {
                MessageBox.Show("Epostadressen får innehålla max 60 tecken");
                return;
            }
            if (textBoxAnvandarnamn.TextLength > 60 || textBoxLosenord.TextLength > 60)
            {
                MessageBox.Show("Användarnamnet och lösenordet får max innehålla 60 tecken.");
                return;
            }
            //Slut kontrollera längden på textboxar
            //Kontrollerar siffror och bokstäver
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
            //Slut kontrollerar siffror och bokstäver

            if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Uppdatera konto")
            {
                int selectedIndex = dgStaff.SelectedRows[0].Index;

                staffid = int.Parse(dgStaff[0, selectedIndex].Value.ToString());

                //btnTomFalten.Enabled = false;
                btnSkapaKonto.Enabled = false;
                dgStaff.Enabled = false;

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
            else if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Spara ändringar")
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

                dgStaff.Enabled = true;
                tomFalt();
                ListaPersonal();
                btnUpdateraKonto.Text = "Uppdatera konto";
                textBoxAnvandarnamn.Enabled = true;
                btnSkapaKonto.Enabled = true;

            }

        }
        private void btnTomFalten_Click(object sender, EventArgs e)
        {
            tomFalt();
        }
        #endregion
    }
}
