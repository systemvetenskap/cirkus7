using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private int showid;
        private int actid;
        private string staffUserId;
        private string staffFname;
        private string staffLname;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        private string sql = "";
        public DataTable dt = new DataTable();
        private NpgsqlDataAdapter da;
        private List<show> allShowsList;
        private int CustomerID;
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
                    LoadAkter();
                    LoadStatistics();
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
        public void tomFaltochFarg()
        {
            textBoxPersonnummer.Clear();
            textBoxFornamn.Clear();
            textBoxEfternamn.Clear();
            textBoxEpost.Clear();
            textBoxTelefonnummer.Clear();
            textBoxAnvandarnamn.Clear();
            textBoxLosenord.Clear();
            comboBoxBehorighetsniva.ResetText();

            textBoxPersonnummer.BackColor = Color.White;
            textBoxFornamn.BackColor = Color.White;
            textBoxEfternamn.BackColor = Color.White;
            textBoxEpost.BackColor = Color.White;
            textBoxTelefonnummer.BackColor = Color.White;
            textBoxAnvandarnamn.BackColor = Color.White;
            textBoxLosenord.BackColor = Color.White;
            comboBoxBehorighetsniva.BackColor = Color.White;


        }

        #endregion
        #region Biljettförsäljning
        private void textBoxSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            listCustomers();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Biljett", new Font("arial", 17), new SolidBrush(Color.Black), 10, 10);
            e.Graphics.DrawString("Kundens namn", new Font("arial", 17), new SolidBrush(Color.Black), 10, 50);
            e.Graphics.DrawString("Plats", new Font("arial", 17), new SolidBrush(Color.Black), 10, 90);
            e.Graphics.DrawString("Föreställning", new Font("arial", 17), new SolidBrush(Color.Black), 10, 130);
            e.Graphics.DrawString("Akter", new Font("arial", 17), new SolidBrush(Color.Black), 10, 170);
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

                conn.Close();

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
            int currentRow = dgCustomers.SelectedRows[0].Index;
            string CustomerID = dgCustomers[2, currentRow].Value.ToString();
            if (currentRow != -1)
            {
                string sql = @"select booking.bookingid, show.name, acts.name, seats.section, seats.rownumber, price_group_seat.group, price_group_seat.price, booking.reserved_to from show inner join acts on show.showid = acts.showid inner
join available_seats on acts.actid = available_seats.actid
inner
join seats on available_seats.seatid = seats.seatid
inner
join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
inner
join price_group_seat on booked_seats.priceid = price_group_seat.priceid
inner
join booking on booked_seats.bookingid = booking.bookingid
inner
join customer on booking.customerid = customer.customerid WHERE customer.customerid = '" + CustomerID + "'";

                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTickets.DataSource = dt;
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

        }
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm(staffUserId);
            custForm.ShowDialog();

        }
        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            conn.Close();
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //PrintDialog pdialog = new PrintDialog();
            //pdialog.Document = printDocument1;
            //pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(partOfForm());

            //if (pdialog.ShowDialog() == DialogResult.OK)
            //{
            printDocument1.Print();
            //}

        }
        private void dgCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listTickets();
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
        private void dgvAkter_SelectionChanged(object sender, EventArgs e)
        {
            //LoadAkter();
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
                dgvShowsList.Columns["showid"].Visible = false;
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

        public void LoadStatistics()
        {
            if (dgvAkter.RowCount != 0)
            {
                //Antal Vuxenbiljetter
                int selectedIndex = dgvAkter.SelectedRows[0].Index;
                actid = int.Parse(dgvAkter[1, selectedIndex].Value.ToString());


                conn.Open();
                string sql = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'vuxen' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                textBoxAntalVuxenBiljetter.Clear();

                while (dr.Read())
                {
                    textBoxAntalVuxenBiljetter.Text = dr.GetValue(1).ToString();
                }

                if (textBoxAntalVuxenBiljetter.Text == "")
                {
                    textBoxAntalVuxenBiljetter.Text = "0";
                }
                conn.Close();

                //Anttal ungdomsbiljetter
                conn.Open();
                string sqlAU = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'ungdom' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmdAU = new NpgsqlCommand(sqlAU, conn);
                NpgsqlDataReader drAU = cmdAU.ExecuteReader();

                textBoxAntalUngdomsbiljetter.Clear();

                while (drAU.Read())
                {
                    textBoxAntalUngdomsbiljetter.Text = drAU.GetValue(1).ToString();
                }

                if (textBoxAntalUngdomsbiljetter.Text == "")
                {
                    textBoxAntalUngdomsbiljetter.Text = "0";
                }
                conn.Close();

                //Antal ungdomsbiljetter
                conn.Open();
                string sqlAB = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'barn' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmdAB = new NpgsqlCommand(sqlAB, conn);
                NpgsqlDataReader drAB = cmdAB.ExecuteReader();

                textBoxAntalBarnbiljetter.Clear();

                while (drAB.Read())
                {
                    textBoxAntalBarnbiljetter.Text = drAB.GetValue(1).ToString();
                }

                if (textBoxAntalBarnbiljetter.Text == "")
                {
                    textBoxAntalBarnbiljetter.Text = "0";
                }
                conn.Close();

                //Totalt antal
                int antalVuxen, antalUngdom, antalBarn;
                string totaltSumma;

                antalVuxen = Convert.ToInt32(textBoxAntalVuxenBiljetter.Text);
                antalUngdom = Convert.ToInt32(textBoxAntalUngdomsbiljetter.Text);
                antalBarn = Convert.ToInt32(textBoxAntalBarnbiljetter.Text);
                totaltSumma = Convert.ToString(antalVuxen + antalUngdom + antalBarn);

                textBoxTotaltAntal.Text = totaltSumma;

                //Kronor vuxen
                conn.Open();
                string sqlKV = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'vuxen' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmdKV = new NpgsqlCommand(sqlKV, conn);
                NpgsqlDataReader drKV = cmdKV.ExecuteReader();

                textBoxKronorVuxenbiljetter.Clear();

                while (drKV.Read())
                {
                    textBoxKronorVuxenbiljetter.Text = drKV.GetValue(0).ToString();
                }

                if (textBoxKronorVuxenbiljetter.Text == "")
                {
                    textBoxKronorVuxenbiljetter.Text = "0";
                }
                conn.Close();

                //Kronor ungdom
                conn.Open();
                string sqlKU = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'ungdom' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmdKU = new NpgsqlCommand(sqlKU, conn);
                NpgsqlDataReader drKU = cmdKU.ExecuteReader();

                textBoxKronorUngdomsbiljetter.Clear();

                while (drKU.Read())
                {
                    textBoxKronorUngdomsbiljetter.Text = drKU.GetValue(0).ToString();
                }

                if (textBoxKronorUngdomsbiljetter.Text == "")
                {
                    textBoxKronorUngdomsbiljetter.Text = "0";
                }
                conn.Close();

                //Kronor ungdom
                conn.Open();
                string sqlKB = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.actid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.actid = '" + actid + "' and price_group_seat.group = 'barn' group by price_group_seat.group, acts.actid";

                NpgsqlCommand cmdKB = new NpgsqlCommand(sqlKB, conn);
                NpgsqlDataReader drKB = cmdKB.ExecuteReader();

                textBoxKronorBarnbiljetter.Clear();

                while (drKB.Read())
                {
                    textBoxKronorBarnbiljetter.Text = drKB.GetValue(0).ToString();
                }

                if (textBoxKronorBarnbiljetter.Text == "")
                {
                    textBoxKronorBarnbiljetter.Text = "0";
                }
                conn.Close();

                //Totalt kronor
                int kronorVuxen, kronorUngdom, kronorBarn;
                string totaltKornor;

                kronorVuxen = Convert.ToInt32(textBoxKronorVuxenbiljetter.Text);
                kronorUngdom = Convert.ToInt32(textBoxKronorUngdomsbiljetter.Text);
                kronorBarn = Convert.ToInt32(textBoxKronorBarnbiljetter.Text);
                totaltKornor = Convert.ToString(kronorVuxen + kronorUngdom + kronorBarn);

                textBoxTotaltKronor.Text = totaltKornor;
            }

        }

        public void LoadAkter()
        {
            if (dgvShowsList.RowCount != 0)
            {
                int selectedIndex = dgvShowsList.SelectedRows[0].Index;
                showid = int.Parse(dgvShowsList[0, selectedIndex].Value.ToString());

                string sql = "select name, actid from acts where showid = '" + showid + "' group by name, actid order by name";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgvAkter.DataSource = dt;
                conn.Close();

                this.dgvAkter.Columns[1].Visible = false;
            }
        }
        private void dgvShowsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadAkter();
            LoadStatistics();

        }
        #endregion
        #region Konto
        private void textBoxSearchStaff_TextChanged(object sender, EventArgs e)
        {
            ListaPersonal();
        }
        private void btnTomFalten_Click(object sender, EventArgs e)
        {
            tomFaltochFarg();
        }
        private void ListaPersonal()//Metod för att lista personalen i Datagriden.
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
                DataGridViewColumn column3 = dgStaff.Columns[3];

                column.Width = 60;
                column1.Width = 100;
                column2.Width = 100;
                column3.Width = 100;

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
            //Kontrollerar längden, siffror/bokstäver och tomma fält
            if (textBoxPersonnummer.TextLength > 10 || textBoxPersonnummer.TextLength < 10 || string.IsNullOrWhiteSpace(textBoxPersonnummer.Text))
            {
                textBoxPersonnummer.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange personnummret, med 10 siffror";
                return;
            }
            if (textBoxFornamn.TextLength > 60 || !BaraBokstäver(textBoxFornamn.Text) || string.IsNullOrWhiteSpace(textBoxFornamn.Text))
            {
                textBoxFornamn.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange förnamn, utan siffror, max 60 bokstäver";
                return;
            }
            if (textBoxEfternamn.TextLength > 60 || !BaraBokstäver(textBoxEfternamn.Text) || string.IsNullOrWhiteSpace(textBoxEfternamn.Text))
            {
                textBoxEfternamn.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange förnamn, utan siffror, max 60 bokstäver.";
                return;
            }
            if (textBoxTelefonnummer.TextLength > 10 || !EndastSiffror(textBoxTelefonnummer.Text) || string.IsNullOrWhiteSpace(textBoxTelefonnummer.Text))
            {
                textBoxTelefonnummer.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange telefonnummer, max 10 siffror";
                return;
            }
            if (textBoxEpost.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxEpost.Text))
            {
                textBoxEpost.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange epost, max 60 tecken";
                return;
            }
            if (textBoxAnvandarnamn.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxAnvandarnamn.Text))
            {
                textBoxAnvandarnamn.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange epost, max 60 tecken";
                return;
            }
            if (textBoxLosenord.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxLosenord.Text))
            {
                textBoxLosenord.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Ange lösenord, max 60 tecken";
                return;
            }
            if (string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
            {
                comboBoxBehorighetsniva.BackColor = Color.Tomato;
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Välj en behörighet";
                return;
            }
            //Slut kontrollera längden, siffror/bokstäver och tomma fält
            try
            {
                conn.Open();
                string sql = "INSERT INTO staff (ssn,fname,lname,phonenumber,email,username,password,auth) VALUES(:ssn, :fname, :lname, :phonenumber, :email, :username, :password, :auth)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.Add(new NpgsqlParameter("ssn", textBoxPersonnummer.Text));
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
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Green;
                LblStatus.Text = "Användare tillagd";

                cmd.ExecuteNonQuery();
                conn.Close();
                ListaPersonal();
                tomFaltochFarg();
            }
            catch (NpgsqlException)
            {
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Tomato;
                LblStatus.Text = "Användaren finns redan";

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
            btnRaderaKonto.Enabled = true;
            btnTomFalten.Enabled = false;

            if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Uppdatera/ändra konto")
            {
                int selectedIndex = dgStaff.SelectedRows[0].Index;

                staffid = int.Parse(dgStaff[0, selectedIndex].Value.ToString());

                btnSkapaKonto.Enabled = false;
                dgStaff.Enabled = false;

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select ssn, fname, lname, phonenumber, email, username, password, auth
                                                        from staff where staffid = '" + staffid + "'", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();
                read.Read();

                textBoxPersonnummer.Text = read[0].ToString();
                textBoxFornamn.Text = read[1].ToString();
                textBoxEfternamn.Text = read[2].ToString();
                textBoxTelefonnummer.Text = read[3].ToString();
                textBoxEpost.Text = read[4].ToString();
                textBoxAnvandarnamn.Text = read[5].ToString();
                textBoxLosenord.Text = read[6].ToString();
                int auth = int.Parse(read[7].ToString());

                if (auth == 0)
                {
                    comboBoxBehorighetsniva.SelectedText = "Biljettförsäljare";

                }
                else if (auth == 1)
                {
                    comboBoxBehorighetsniva.SelectedText = "Administratör";

                }

                conn.Close();
                btnUpdateraKonto.Text = "Spara ändringar";
                textBoxAnvandarnamn.Enabled = false;

            }
            else if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Spara ändringar")
            {

                //Kontrollerar längden, siffror/bokstäver och tomma fält
                if (textBoxPersonnummer.TextLength > 10 || textBoxPersonnummer.TextLength < 10 || string.IsNullOrWhiteSpace(textBoxPersonnummer.Text))
                {
                    textBoxPersonnummer.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange personnummret, med 10 siffror";
                    return;
                }
                if (textBoxFornamn.TextLength > 60 || !BaraBokstäver(textBoxFornamn.Text) || string.IsNullOrWhiteSpace(textBoxFornamn.Text))
                {
                    textBoxFornamn.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange förnamn, utan siffror, max 60 bokstäver";
                    return;
                }
                if (textBoxEfternamn.TextLength > 60 || !BaraBokstäver(textBoxEfternamn.Text) || string.IsNullOrWhiteSpace(textBoxEfternamn.Text))
                {
                    textBoxEfternamn.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange förnamn, utan siffror, max 60 bokstäver.";
                    return;
                }
                if (textBoxTelefonnummer.TextLength > 10 || !EndastSiffror(textBoxTelefonnummer.Text) || string.IsNullOrWhiteSpace(textBoxTelefonnummer.Text))
                {
                    textBoxTelefonnummer.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange telefonnummer, max 10 siffror";
                    return;
                }
                if (textBoxEpost.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxEpost.Text))
                {
                    textBoxEpost.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange epost, max 60 tecken";
                    return;
                }
                if (textBoxAnvandarnamn.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxAnvandarnamn.Text))
                {
                    textBoxAnvandarnamn.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange epost, max 60 tecken";
                    return;
                }
                if (textBoxLosenord.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxLosenord.Text))
                {
                    textBoxLosenord.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Ange lösenord, max 60 tecken";
                    return;
                }
                if (string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
                {
                    comboBoxBehorighetsniva.BackColor = Color.Tomato;
                    LblStatus.Visible = true;
                    LblStatus.ForeColor = Color.Tomato;
                    LblStatus.Text = "Välj en behörighet";
                    return;
                }
                //Slut kontrollera längden, siffror/bokstäver och tomma fält

                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(@"update staff set ssn = @ssn, fname = @fn, lname = @ln, phonenumber = @pn, email = @email, 
                                                        username = @un, password = @pass, auth = @auth where staffid =@id", conn);

                cmd.Parameters.Add(new NpgsqlParameter("ssn", textBoxPersonnummer.Text));
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
                else if (comboBoxBehorighetsniva.SelectedIndex == 1)
                {
                    int auth = 1;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }

                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Green;
                LblStatus.Text = "Användare updaterad";

                cmd.ExecuteNonQuery();

                conn.Close();

                btnTomFalten.Enabled = true;
                btnRaderaKonto.Enabled = false;
                dgStaff.Enabled = true;
                ListaPersonal();
                btnUpdateraKonto.Text = "Uppdatera/ändra konto";
                textBoxAnvandarnamn.Enabled = true;
                btnSkapaKonto.Enabled = true;
                tomFaltochFarg();

            }

        }
        private void btnRaderaKonto_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Är du säker på att du vill ta bort den markerade användaren ?",
                "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                int SelectedStaff;

                DataGridViewRow selectedrow = this.dgStaff.SelectedRows[0];
                SelectedStaff = Convert.ToInt32(selectedrow.Cells["staffid"].Value);
                string sql = "DELETE FROM staff WHERE staffid = '" + SelectedStaff + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {

                    MessageBox.Show(ex.Message);

                    DialogResult Warning = MessageBox.Show("Det går ej att ta bort denna användaren. Användaren har en eller flera aktiva föreställningar kopplade till kontot.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                conn.Close();

                textBoxAnvandarnamn.Enabled = true;
                dgStaff.Enabled = true;
                btnRaderaKonto.Enabled = false;
                btnSkapaKonto.Enabled = true;
                btnSkapaKonto.Text = "Skapa/Lägg till konto";
                btnUpdateraKonto.Text = "Uppdatera/ändra konto";
                LblStatus.Visible = true;
                LblStatus.ForeColor = Color.Red;
                LblStatus.Text = "Användare raderad";
                ListaPersonal();
                tomFaltochFarg();
            }
            if (Confirmation == DialogResult.No)
            {
                return;
            }
        }
        #endregion

        private void dgvAkter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadStatistics();
        }
        private void dgvShowsList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                LoadAkter();
                LoadStatistics();
            }
            else if (e.KeyCode == Keys.Down)
            {
                LoadAkter();
                LoadStatistics();
            }
        }
        private void dgvAkter_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                
                LoadStatistics();
            }
            else if (e.KeyCode == Keys.Down)
            {
               
                LoadStatistics();
            }
        }
        private void buttonEditTicket_Click(object sender, EventArgs e)
        {
            int SelectedCustomer = this.dgCustomers.SelectedRows[0].Index;
            int SelectedTicket = this.dgTickets.SelectedRows[0].Index;

            ChangeTicketForm Ctf;
            if (SelectedTicket != -1 && SelectedCustomer != -1)


            {
                foreach (DataGridViewRow r in dgTickets.SelectedRows)
                {
                    DataGridViewRow t = (DataGridViewRow)r.Clone();
                    t.Cells[0].Value = r.Cells[0].Value;
                    t.Cells[1].Value = r.Cells[1].Value;
                    t.Cells[2].Value = r.Cells[2].Value;
                    t.Cells[3].Value = r.Cells[3].Value;
                    t.Cells[4].Value = r.Cells[4].Value;
                    t.Cells[5].Value = r.Cells[5].Value;
                    t.Cells[6].Value = r.Cells[6].Value;
                    t.Cells[7].Value = r.Cells[7].Value;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Boknings ID");
                    dt.Columns.Add("Föreställning");
                    dt.Columns.Add("Akt");
                    dt.Columns.Add("Sektion");
                    dt.Columns.Add("Platsnummer");
                    dt.Columns.Add("Biljettyp");
                    dt.Columns.Add("Pris");
                    dt.Columns.Add("Reserverad till");


                    DataRow row;
                    row = dt.NewRow();
                    row[0] = r.Cells[0].Value;
                    row[1] = r.Cells[1].Value;
                    row[2] = r.Cells[2].Value;
                    row[3] = r.Cells[3].Value;
                    row[4] = r.Cells[4].Value;
                    row[5] = r.Cells[5].Value;
                    row[6] = r.Cells[6].Value;
                    row[7] = r.Cells[7].Value;

                    dt.Rows.Add(row);
                    Ctf = new ChangeTicketForm(dt);
                    Ctf.ShowDialog();


                }
                try
                {
                    //Ctf = new ChangeTicketForm(dt);
                    //Ctf.ShowDialog();
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

        }
        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Är du säker på att du vill ta bort den markerade biljetten ?",
            "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                int SelectedTicket;
                DataGridViewRow selectedTicket = this.dgTickets.SelectedRows[0];
                SelectedTicket = Convert.ToInt32(selectedTicket.Cells["bookingid"].Value);

                string sql = "DELETE FROM booking WHERE bookingid = '" + SelectedTicket + "'";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {

                    MessageBox.Show(ex.Message);

                    DialogResult Warning = MessageBox.Show("Det går ej att ta bort denna biljetten.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }
                conn.Close();
            }
            listTickets();
        }
        private void dgCustomers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                listTickets();
            }
            else if (e.KeyCode == Keys.Down)
            {
                listTickets();
            }
        }
        private void dgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            listTickets(); //Merge
        }
    }
}
