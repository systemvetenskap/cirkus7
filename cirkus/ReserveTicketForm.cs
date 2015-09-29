using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using System.Net;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace cirkus
{
    public partial class ReserveTicketForm : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        int showid, actid, fillMode, seatid, agegroup, customerid, total, checkedseats, priceid, freeSseats, freeLseats, tickets, nrotickets, ticketid, count, checks;
        string show, act, customeremail, customerfname, customerlname, pdf, bokningid, actname, suggSeats, acttime;
        string sections = "ABCDEFGH";
        private bool newcust;
        private bool seatType = true;
        private bool fullShowS;
        DataTable shows, section, dtfSeats, dtPersons;
        DataTable seats = new DataTable();
        DataTable chosenacts = new DataTable();
        DataTable selectedseats = new DataTable();
        DataTable acts = new DataTable();
        DataTable cSeats = new DataTable();
        DataTable fullShow = new DataTable();
        DataTable currentActs = new DataTable();
        DataTable showacts;
        DataRow row;
        DateTime showdate;
        BindingSource filterseats = new BindingSource();
        BindingSource filterBseats = new BindingSource();
        BindingSource filterActs = new BindingSource();
        BindingSource filterSacts = new BindingSource();
        NpgsqlCommand cmd;
        MailMessage mail;
     

        public ReserveTicketForm()
        {
            InitializeComponent();
            loadShows();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

        }
        public void loadShows()
        {
            string sql = "select show.showid, show.name, show.date from show where now()::date  >= sale_start and now()::date <= sale_stop";

            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            shows = new DataTable();
            da.Fill(shows);


            dataGridViewShows.DataSource = shows;


            dataGridViewShows.Columns[1].HeaderText = "Namn";
            dataGridViewShows.Columns[2].HeaderText = "Datum";

            this.dataGridViewShows.Columns[0].Visible = false;


            conn.Close();

            //loadActs();

        }
        private void loadActs()
        {
            filterActs.DataSource = acts;
            filterActs.Filter = string.Format("ticketid = '{0}'", dgTickets.SelectedRows[0].Index.ToString());
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;
            int selectedIndex2 = dgTickets.SelectedRows[0].Index;
            //filterSacts.DataSource = chosenacts;
            //filterSacts.Filter = string.Format("ticketid = '{0}'", comboTicketnr.SelectedItem.ToString());

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());
            showdate = Convert.ToDateTime(dataGridViewShows[2, selectedIndex].Value.ToString());

            //lblshowid.Text = showid.ToString();

            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            //da.Fill(acts);

            dgActs.DataSource = acts;
            dgTEST.DataSource = acts;
            if (acts.Rows.Count > 0)
            {
                for (int row = 0; row < acts.Rows.Count; row++)
                {
                    DataRow rows = acts.Rows[row];
                    if (rows.RowState != DataRowState.Deleted)
                    {
                        object id = rows[0];
                        object id2 = dgTickets[0, selectedIndex2].Value.ToString();
                        string a = dgTickets[0, selectedIndex2].Value.ToString();
                        string b = rows[0].ToString();


                        if (a != b)
                        {
                            fillMode = 1;


                        }
                        else
                        {
                            return;
                        }

                    }

                }
            }
            else
            {

                fillMode = 2;


            }
            switch (fillMode)
            {

                case 1:

                    conn.Open();
                    da.Fill(acts);

                    conn.Close();
                    for (int rw = 0; rw < acts.Rows.Count; rw++)
                    {
                        DataRow drw = acts.Rows[rw];
                        if (drw.RowState != DataRowState.Deleted)
                        {
                            object value3 = drw[0];
                            object value4 = dgTickets[0, selectedIndex2].Value.ToString();

                            if (value3 == DBNull.Value)
                            {
                                drw[0] = int.Parse(dgTickets[0, selectedIndex2].Value.ToString());
                                drw[3] = false;


                            }
                        }



                    }
                    break;
                case 2:
                    conn.Open();

                    da.Fill(acts);
                    conn.Close();
                    for (int rw = 0; rw < acts.Rows.Count; rw++)
                    {
                        DataRow drw = acts.Rows[rw];
                        if (drw.RowState != DataRowState.Deleted)
                        {
                            object value3 = drw[0];
                            object value4 = dgTickets[0, selectedIndex2].Value.ToString();

                            if (value3 == DBNull.Value)
                            {
                                drw[0] = int.Parse(dgTickets[0, selectedIndex2].Value.ToString());
                                drw[3] = false;

                            }
                        }



                    }
                    break;
            }



            //dataGridViewActs.DataSource = acts;
            //this.dataGridViewActs.Columns[0].Visible = false;
            //this.dataGridViewActs.Columns[1].Visible = false;
            //dataGridViewActs.Columns[1].Width = 129;
            //dataGridViewActs.ClearSelection();



            //dataGridViewActs.CurrentCell.Selected = false;

            //dgTest.DataSource = acts;




        }

        private void load_Seats()
        {
            conn.Close();
            conn.Open();


            string fullshowSeats = @"select distinct(seats.seatid), seats.section, seats.rownumber, count(acts.actid) from available_seats 
                                        inner join acts on available_seats.actid = acts.actid
                                        inner join seats on available_seats.seatid = seats.seatid
                                        inner join show on acts.showid = show.showid
                                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                        where show.showid = '" + showid + "' and booked_seat_id is null group by seats.seatid, seats.section, seats.rownumber having count(acts.actid) > 1 order by seats.seatid";



            NpgsqlDataAdapter da = new NpgsqlDataAdapter(fullshowSeats, conn);


            da.Fill(fullShow);

            //dgSeats.DataSource = seats;
            //dgTest.DataSource = seats;
            dataGridViewActs.ClearSelection();
            conn.Close();

            conn.Open();
            string getActsSeats = @"select available_seats.available_seats_id, seats.section, seats.rownumber, acts.actid from available_seats
                                inner join acts on available_seats.actid = acts.actid
                                inner join seats on available_seats.seatid = seats.seatid
                                inner join show on acts.showid = show.showid
                                left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                where show.showid = '" + showid + "' and booked_seats.booked_seat_id is null";
            da = new NpgsqlDataAdapter(getActsSeats, conn);
            da.Fill(currentActs);
            conn.Close();




        }
        private void listCustomers()
        {
            string sqlSearch = textBoxSearchCust.Text;
            string sql = "SELECT lname, fname, customerid FROM customer WHERE LOWER(lname) LIKE LOWER('%" + sqlSearch + "%') OR LOWER(fname) LIKE LOWER('%" + sqlSearch + "%');";
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgCustom.DataSource = dt;
                dgCustom.Columns[0].HeaderText = "Efternamn";
                dgCustom.Columns[1].HeaderText = "Förnamn";
                dgCustom.Columns[2].HeaderText = "ID";
                dgCustom.Columns[0].Width = 60;
                dgCustom.Columns[1].Width = 60;
                dgCustom.Columns[2].Width = 60;
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
        private void fillActs()
        {


        }
        private void textBoxSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            listCustomers();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewShows.CurrentCell.Selected = false;
        }

        private void rowselection_changed(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewShows.BackgroundColor = Color.WhiteSmoke;
            lblStatus1.Visible = false;
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());
            show = dataGridViewShows[1, selectedIndex].Value.ToString();
            //load_Seats();
            conn.Close();
            conn.Open();
            string sql = @"select acts.actid,acts.name, acts.start_time, acts.end_time,count(available_seats.available_seats_id)  - count(booked_seats.booked_seat_id) as antal from available_seats
                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                        inner join acts on available_seats.actid = acts.actid
                        inner join show on acts.showid = show.showid
                        where show.showid = '"+showid+"' group by acts.actid, acts.name,acts.name, acts.start_time, acts.end_time";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            showacts = new DataTable();

            da.Fill(showacts);
            dgShowActs.DataSource = showacts;
            dgShowActs.Columns[1].HeaderText = "Namn";
            dgShowActs.Columns[2].HeaderText = "Starttid";
            dgShowActs.Columns[3].HeaderText = "Sluttid";
            dgShowActs.Columns[4].HeaderText = "Lediga platser";
            dgShowActs.ClearSelection();
            dgShowActs.Columns[0].Visible = false;
            conn.Close();



        }

        private void ReserveTicketForm_Load(object sender, EventArgs e)
        {
            clearSelect();
            listCustomers();
            txtenamn.Enabled = false;
            txtepost.Enabled = false;
            txtfnamn.Enabled = false;
            txttel.Enabled = false;
            acts.Columns.Add("ticketid");
            acts.Columns.Add("actid");
            acts.Columns.Add("name");
            acts.Columns.Add("Vald akter", typeof(bool)).SetOrdinal(3);
            acts.Columns.Add("agegroup");

            selectedseats.Columns.Add("seatid");
            selectedseats.Columns.Add("actid");
            selectedseats.Columns.Add("section");
            selectedseats.Columns.Add("rownumber");
            selectedseats.Columns.Add("ticketid");
            selectedseats.Columns.Add("priceid");
            //dgBseats.DataSource = selectedseats;
            chosenacts.Columns.Add("ticketid");
            chosenacts.Columns.Add("actid");
            chosenacts.Columns.Add("name");
            chosenacts.Columns.Add("priceid");
            dtfSeats = new DataTable();
            dtfSeats.Columns.Add("actid");
            dtfSeats.Columns.Add("priceid");
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            cSeats.Columns.Add("ticketid");
            cSeats.Columns.Add("actid");
            cSeats.Columns.Add("section");
            cSeats.Columns.Add("rownumber");
            cSeats.Columns.Add("priceid");
            cSeats.Columns.Add("seatid");
            lblStatus1.Visible = false;


        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (total > 0 && string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false && EndastSiffror(txtBoxNrP.Text) == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                nrotickets = Convert.ToInt32(txtBoxNrP.Text);
                dtPersons = new DataTable();
                dtPersons.Columns.Add("id");
                dtPersons.Columns.Add("Person/Biljett");
                dtPersons.Columns.Add("agegroup");
                dtPersons.Columns.Add("nrOfacts");
                DataRow dr;
                for (int i = 0; i < nrotickets; i++)
                {
                    dr = dtPersons.NewRow();
                    int z = i + 1;
                    dr[0] = i;
                    dr[1] = "Person" + z.ToString();
                    dr[2] = 3;
                    dr[3] = 0;
                    dtPersons.Rows.Add(dr);

                }
                dgTickets.DataSource = dtPersons;
                //comboTicketnr.Text = "2";
                dgTickets.ClearSelection();
                load_Seats();

            }
            else if (dataGridViewShows.SelectedRows.Count == 0)
            {
                lblStatus1.Visible = true;
                lblStatus1.Text = "Välj en föreställning";
                lblStatus1.ForeColor = Color.Tomato;
                dataGridViewShows.BackColor = Color.Tomato;




            }
            else if (string.IsNullOrWhiteSpace(txtBoxNrP.Text) == true || EndastSiffror(txtBoxNrP.Text) == false)
            {

                lblStatus1.Visible = true;
                lblStatus1.Text = "Vänligen ange antal personer med siffor";
                lblStatus1.ForeColor = Color.Tomato;
                txtBoxNrP.BackColor = Color.Tomato;


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel2.Visible = true;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            dateReservedto.Value = showdate;
            dateReservedto.Value = dateReservedto.Value.Subtract(TimeSpan.FromDays(7));

            if (newcust == true)
            {
                string fn = txtfnamn.Text;
                string ln = txtenamn.Text;
                string pn = txttel.Text;
                string em = txtepost.Text;
                if (IsValidEmail(em) == false)
                {
                    MessageBox.Show("Ange giltig mail");

                    return;
                }
                conn.Open();

                cmd = new NpgsqlCommand("insert into customer(fname, lname, phonenumber, email) values(:fn, :ln, :pn, :em)", conn);
                cmd.Parameters.Add(new NpgsqlParameter("fn", fn));
                cmd.Parameters.Add(new NpgsqlParameter("ln", ln));
                cmd.Parameters.Add(new NpgsqlParameter("pn", pn));
                cmd.Parameters.Add(new NpgsqlParameter("em", em));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                cmd = new NpgsqlCommand("select currval('customer_customerid_seq');", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();

                read.Read();
                customerid = int.Parse(read[0].ToString());
                conn.Close();
                panel3.Visible = true;
                //panel2.Visible = false;
     


            }
            if (newcust == false || cbDf.Checked == true)
            {
                panel3.Visible = true;
                //panel2.Visible = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBoxSearchCust.Enabled = false;
                if (this.dgCustom.DataSource != null)
                {
                    this.dgCustom.DataSource = null;

                }
                else
                {
                    this.dgCustom.Rows.Clear();
                    dgCustom.BackgroundColor = Color.Gray;


                }
                cbDf.Enabled = false;
                newcust = true;
                txtenamn.Enabled = true;
                txtepost.Enabled = true;
                txtfnamn.Enabled = true;
                txttel.Enabled = true;

            }
            if (checkBox2.Checked == false)
            {
                dgCustom.BackgroundColor = Color.White;

                newcust = false;
                dgCustom.Visible = true;
                textBoxSearchCust.Enabled = true;
                listCustomers();
                txtenamn.Enabled = false;
                txtepost.Enabled = false;
                txtfnamn.Enabled = false;
                txttel.Enabled = false;
                cbDf.Enabled = true;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void selected_seat(object sender, DataGridViewCellEventArgs e)
        {


            //label11.Text = seatid.ToString();
        }



        private void btnRemSeats_Click(object sender, EventArgs e)
        {

        }

        private void dgActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgActs.SelectedRows[0].Index;

            actid = int.Parse(dgActs[1, selectedIndex].Value.ToString());
            bool chck = Convert.ToBoolean(dgActs[3, selectedIndex].Value.ToString());

            if (cbAgegroup.Text == "Åldersgrupp" || cbAgegroup.SelectedIndex == -1)
            {
                lblStatusAge.Visible = true;
                lblStatusAge.Text = "Vänligen välj åldersgrupp";
                lblStatusAge.ForeColor = Color.Tomato;
                return;

            }
            else if(chck == true)
            {
                clearSeatMap();
                loadSeatMap();
            }
            else if(chck == false)
            {
                clearSeatMap();
            }
            


       


            /*filterseats.Filter = string.Format("actid = '{0}'", actid);
            filterBseats.DataSource = selectedseats;
            filterBseats.Filter = string.Format("actid = '{0}'", actid);
            dgSeats.Columns[0].Visible = false;
            dgSeats.Columns[1].Visible = false;
            /dgBseats.Columns[1].Visible = false;
            /*dgSeats.DataSource = seats;
           

            dgBseats.DataSource = selectedseats;
          

        
            dgSeats.ClearSelection();
            dgBseats.ClearSelection();*/

            //dgTEST.DataSource = cSeats;


            //    }
            //    foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            //    {
            //        if (cb.Enabled == false && cb.Checked == false)
            //        {
            //            cb.Checked = false;
            //            cb.BackColor = Color.Gray;

            //        }


            //    }
            //}

            //private void button7_Click(object sender, EventArgs e)
            //{
            //    switch (agegroup)
            //    {
            //        case 0:
            //            MessageBox.Show("Välj åldersgrupp");
            //            return;

            //        case 1:
            //            priceid = 1;




            //            break;
            //        case 2:
            //            priceid = 3;
            //            break;
            //        case 3:
            //            priceid = 5;
            //            break;
            //    }
            //    foreach (DataGridViewRow r in dataGridViewActs.SelectedRows)
            //    {
            //        DataGridViewRow t = (DataGridViewRow)r.Clone();
            //        t.Cells[0].Value = r.Cells[0].Value;
            //        t.Cells[1].Value = r.Cells[1].Value;
            //        t.Cells[2].Value = r.Cells[2].Value;

            //        row = chosenacts.NewRow();
            //        row[0] = r.Cells[0].Value;
            //        row[1] = r.Cells[1].Value;
            //        row[2] = r.Cells[2].Value;
            //        row[3] = priceid;
            //        chosenacts.Rows.Add(row);





            //        dgActs.DataSource = chosenacts;
            //        filterActs.RemoveAt(dataGridViewActs.SelectedRows[0].Index);
            //        dgActs.Columns[0].Visible = false;
            //        dgActs.Columns[1].Visible = false;


            //        DataRow[] rows = section.Select("actid ='" + actid + "'");
            //        foreach (DataRow rw in rows)
            //            rw.Delete();
            //        dataGridViewActs.Rows.Remove(dataGridViewActs.SelectedRows[0]);
            //        dgActs.ClearSelection();
            //        dataGridViewActs.ClearSelection();
            //        dgSeats.DataSource = seats;
            //        reload_datable();
            //        dgTestActs.DataSource = chosenacts;
            //        load_Seats();

            //}

        }

        private void txtBoxNrP_TextChanged(object sender, EventArgs e)
        {
            if (EndastSiffror(txtBoxNrP.Text) == true && string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false)
            {
                total = Convert.ToInt32(txtBoxNrP.Text);
                //countSeats();
                foreach (DataGridViewRow r in dgShowActs.Rows)
                {

                    int check = Convert.ToInt32(r.Cells[4].Value);
                    if (check < total)
                    {

                        r.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                    else
                    {
                        r.DefaultCellStyle.BackColor = Color.LawnGreen;

                    }

                }
            }
            else
            {

            }



        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //conn.Open();
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter("select acts.actid, acts.name from acts inner join show on acts.showid = show.showid where show.showid = '"+showid+"'", conn);
            //da.Fill(acts);
            //conn.Close();
            checks = 0;
            cbAgegroup.SelectedIndex = -1;
            int dgIndex = dgTickets.SelectedRows[0].Index;
            ticketid = int.Parse(dgTickets[0, dgIndex].Value.ToString());
            //bool lckd = Convert.ToBoolean(dgTickets[3, dgIndex].Value.ToString());
            loadActs();
            this.dgActs.Columns[0].ReadOnly = true;
            this.dgActs.Columns[1].ReadOnly = true;
            this.dgActs.Columns[2].ReadOnly = true;
            this.dgActs.Columns[3].ReadOnly = true;
            this.dgActs.Columns[0].Visible = false;
            this.dgActs.Columns[1].Visible = false;
            checkLocked();
            int age = int.Parse(dgTickets[2, dgIndex].Value.ToString());
            if (age == 0)
            {
                cbAgegroup.SelectedIndex = 0;
            }
            else if (age == 1)
            {
                cbAgegroup.SelectedIndex = 1;

            }
            else if (age == 2)
            {
                cbAgegroup.SelectedIndex = 2;
            }
            else if (age == 3)
            {

                cbAgegroup.SelectedIndex = -1;
                cbAgegroup.Text = "Åldersgrupp";
            }




        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cbAgegroup.SelectedIndex != -1)
            {
               fullShowS = true;
                foreach (DataGridViewRow r in dgActs.Rows)
                {
                    r.Cells[3].Value = false;
                    if (Convert.ToBoolean(r.Cells[3].Value) == false)
                        r.Cells[3].Value = true;
                }
        
            }
            else
            {

                lblStatusAge.Visible = true;
                lblStatusAge.Text = "Vänligen välj åldersgrupp";
                lblStatusAge.ForeColor = Color.Tomato;
                return;
            }

        }

        private void dgTickets_SelectionChanged(object sender, EventArgs e)
        {




        }



        private void dgActs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            if (((e.ColumnIndex) == 3) && ((bool)dgActs.Rows[e.RowIndex].Cells[3].Value))
            {
                //MessageBox.Show(dgActs.Rows[e.RowIndex].Cells[3].Value.ToString());

                foreach (DataGridViewRow row in dgActs.Rows)
                {
                    bool check = Convert.ToBoolean(row.Cells[3].Value);
                    if (check == true)
                    {
                        i++;
                    }

                }
                foreach (DataRow r in dtPersons.Rows)
                {
                    int id = int.Parse(r[0].ToString());
                    if (id == ticketid)
                    {
                        r[3] = i;
                    }


                }
                clearSeatMap();
                checkLocked();


            }
            else
            {
                int ix = 0;
                // MessageBox.Show(dgActs.Rows[e.RowIndex].Cells[3].Value.ToString());

                foreach (DataGridViewRow row in dgActs.Rows)
                {
                    bool check = Convert.ToBoolean(row.Cells[3].Value);
                    if (check == false)
                    {
                        ix = 1;
                    }

                }



                foreach (DataRow r in dtPersons.Rows)
                {
                    int nr = int.Parse(r[3].ToString());
                    int id = int.Parse(r[0].ToString());
                    if (id == ticketid)
                    {
                        r[3] = nr - ix;
                    }


                }
                clearSeatMap();
                checkLocked();
            }
        }

        private void dgActs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgActs.IsCurrentCellDirty)
            {
                dgActs.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void dgActs_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbDf_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDf.Checked == true)
            {
                radioPaid.Enabled = false;
                radioRes.Enabled = false;
                dateReservedto.Enabled = false;
                this.dgCustom.DataSource = null;
                radioPaid.Checked = true;
                checkBox2.Enabled = false;


            }
            else if (cbDf.Checked == false)
            {
                radioPaid.Enabled = true;
                radioRes.Enabled = true;
                dateReservedto.Enabled = true;
                listCustomers();

                checkBox2.Enabled = true;

            }

        }

        private void A1_CheckedChanged(object sender, EventArgs e)
        {
            lblSeatStatus.Visible = false; 
            int checks = 0;
            foreach (Control c in gpSeatMap.Controls)
            {
                CheckBox cb = c as CheckBox;
                if (cb != null && cb.Checked && cb.BackColor == Color.Green)
                {
                    checks++;
                }
                if (checks > 1)
                {
                    cb = sender as CheckBox;
                    if (cb != null && cb.Checked)
                    {
                        cb.Checked = false;
                    }
                    lblSeatStatus.Visible = true;
                    lblSeatStatus.ForeColor = Color.Tomato;
                    lblSeatStatus.Text = "Endast en plats per akt";
                }
            }
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool best = true;
            //Markera de bästa platserna med grönt, bäst = alla sektioner 1-4, sämre = alla sektioner 5-8
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {

                foreach (DataRow row in cSeats.Rows)
                {

                    string s = row[2].ToString() + row[3].ToString();
                    int aid = int.Parse(row[5].ToString());



                    int num = int.Parse(row[3].ToString());

                    if (num >= 1 && num <= 4 && cb.Checked == false && cb.Name == s)
                    {
                        cb.BackColor = Color.Green;
                        best = false;


                    }
                    else if (num >= 5 && num <= 8 && cb.Checked == false && cb.Name == s && best == true)
                    {
                        cb.BackColor = Color.Green;

                    }

                }

            }
            //Kolla platser som är grönmarkerade, föreslå platser bredvid varandra efter rangordning av sektioner A - bäst, H-sämst
            /*foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                string s = sections[count].ToString();

                if(cb.BackColor == Color.Green && cb.Name[0].ToString() == s)
                {
                    
                    label14.Text = count.ToString();

                }
                else
                {
                    
                    
                }

            }*/


        }

        private void txtBoxNrP_Click(object sender, EventArgs e)
        {

            txtBoxNrP.BackColor = Color.White;
            lblStatus1.Visible = false;

        }

        private void btnSaveTicket_Click(object sender, EventArgs e)
        {
            if(fullShowS == false)
            {

            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                string seatSection = cb.Name[0].ToString();
                string seatNumber = cb.Name[1].ToString();
                if (cb.Checked == true && cb.BackColor == Color.Green) 
                {
                    DataRow row = cSeats.NewRow();
                    row[0] = ticketid;
                    row[1] = actid;
                    row[2] = seatSection;
                    row[3] = seatNumber;
                    row[4] = agegroup;
                    cSeats.Rows.Add(row);
                    
                    }

                }
                
                foreach (DataRow r in cSeats.Rows)
                {
                    string aid = r[1].ToString();
                    char sect = Char.Parse(r[2].ToString());
                    int nr = int.Parse(r[3].ToString());
                    string dup = r[5].ToString();

                    foreach (DataRow row in currentActs.Rows)
                    {
                        string aid2 = row[3].ToString();
                        char sect2 = Char.Parse(row[1].ToString());
                        int nr2 = int.Parse(row[2].ToString());
                        int aseatid = int.Parse(row[0].ToString());
                        if (aid == aid2 && sect == sect2 && nr == nr2)
                        {
                            r[5] = aseatid;
                           

                        }

                    }

                }

                cSeats = RemDup(cSeats, "seatid");
                cSeats.AcceptChanges();
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {

                    foreach (DataRow r in cSeats.Rows)
                    {

                        char sect = Char.Parse(r[2].ToString());
                        string nr = r[3].ToString();
                        string sactid = r[1].ToString();
                        string s = sect + nr;
                        if (cb.Name == s && cb.Checked == false && cb.BackColor == Color.Green && actid.ToString() == sactid)
                        {

                            r.Delete();
                        }

                    }
                    cSeats.AcceptChanges();
                }
                


                }
            else if(fullShowS == true)
            {
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {
                    string seatSection = cb.Name[0].ToString();
                    string seatNumber = cb.Name[1].ToString();
          

               
                    if (cb.Checked == true && cb.BackColor == Color.Green)
                    {
                        
                        foreach (DataRow rows in showacts.Rows)
                        {
                            DataRow row = cSeats.NewRow();
                            string aid = rows[0].ToString();
                            string sql = "select available_seats_id from available_seats inner join seats on available_seats.seatid = seats.seatid where actid = '"+aid+"' and seats.section = '" + seatSection + "' and seats.rownumber = '" + seatNumber + "'";
                            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                            conn.Open();
                            NpgsqlDataReader read = cmd.ExecuteReader();
                            while(read.Read())
                            {
                        
                                row[5] = read[0];

                            }
                            conn.Close();
                            
                            row[0] = ticketid;
                            row[1] = aid;
                            row[2] = seatSection;
                            row[3] = seatNumber;
                            row[4] = agegroup;
                            cSeats.Rows.Add(row);

                        }
                      

                    }

                }
                cSeats = RemDup(cSeats, "seatid");
                cSeats.AcceptChanges();
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {

                    foreach (DataRow r in cSeats.Rows)
                    {

                        char sect = Char.Parse(r[2].ToString());
                        string nr = r[3].ToString();
                        string s = sect + nr;
                        if (cb.Name == s && cb.Checked == false && cb.BackColor == Color.Green)
                        {

                            r.Delete();
                        }

                    }
                    cSeats.AcceptChanges();
                }

            }


            dgTEST.DataSource = cSeats;

        }

        private void comboTicketnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cboIndex = comboTicketnr.SelectedIndex;
            ticketid = int.Parse(this.comboTicketnr.Items[cboIndex].ToString());


            loadActs();

        }

        private void radioLoge_CheckedChanged(object sender, EventArgs e)
        {
            seatType = true;
        }

        private void radioFri_CheckedChanged(object sender, EventArgs e)
        {
            seatType = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selected_customer(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgCustom.SelectedRows[0].Index;

            customerid = int.Parse(dgCustom[2, selectedIndex].Value.ToString());

            //lblcustid.Text = customerid.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            createBooking();
            if (cbDf.Checked == false || radioRes.Checked == false)
            {
               
                backgroundWorker1.RunWorkerAsync();
                this.Close();
               
            }
            this.Close();

        }

        private void cbAgegroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dgActs.Rows.Count > 0)
            {
                if (cbAgegroup.Text == "Barn")
                {
                    agegroup = 0;
                    this.dgActs.Columns[3].ReadOnly = false;
                    lblStatusAge.Visible = false;
                }

                if (cbAgegroup.Text == "Ungdom")
                {
                    agegroup = 1;
                    this.dgActs.Columns[3].ReadOnly = false;
                    lblStatusAge.Visible = false;
                }
                if (cbAgegroup.Text == "Vuxen")
                {

                    agegroup = 2;
                    this.dgActs.Columns[3].ReadOnly = false;
                    lblStatusAge.Visible = false;
                }
                if (cbAgegroup.Text == "Åldersgrupp")
                {
                    agegroup = 4;
                    MessageBox.Show("Välj åldersgrupp för biljetten");
                    this.dgActs.Columns[3].ReadOnly = true;
                    return;
                }
                foreach (DataRow r in acts.Rows)
                {
                    int id = Convert.ToInt16(r[0]);
                    if (ticketid == id)
                    {
                        r[4] = agegroup;

                    }


                }
                foreach (DataRow r in dtPersons.Rows)
                {
                    int id = Convert.ToInt16(r[0]);
                    if (ticketid == id)
                    {
                        r[2] = agegroup;

                    }

                }

            }
            else
            {
                lblStatusAge.Visible = true;
                lblStatusAge.Text = "Välj en person för att kunna ange ålder";
                lblStatusAge.ForeColor = Color.Tomato;

            }

        }

        private void dataGridViewActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }
        private void seat_sectionchanged(object sender, EventArgs e)
        {
            conn.Close();
            //load_Seats();
        }
        private void checked_seats(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (items.CheckedItems.Count > total - 1)
            {
                e.NewValue = CheckState.Unchecked;

            }
            //if (e.CurrentValue == CheckState.Unchecked)
            //{
            //    checkedseats++;
            //    calculate_people();
            //}
            //else if (e.CurrentValue == CheckState.Checked)
            //{
            //    checkedseats--;
            //    calculate_people();

            //}



        }
        private void added_child(object sender, EventArgs e)
        {

            string sql = @"select count(available_seats.available_seats_id) from available_seats 
                           inner join acts on available_seats.actid = acts.actid 
                           inner join show on acts.showid = show.showid where show.showid = '" + showid + "'";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader read;
            read = cmd.ExecuteReader();

            read.Read();
            freeLseats = int.Parse(read[0].ToString());
            conn.Close();

            conn.Open();
            sql = @"select show.seat_number - count(booked_standing) as diff from show
                    inner join acts on show.showid = acts.showid
                    inner join booked_standing on acts.actid = booked_standing.actid
                    where show.showid = '" + showid + "' group by show.seat_number";
            cmd = new NpgsqlCommand(sql, conn);

            read = cmd.ExecuteReader();

            read.Read();
            freeSseats = int.Parse(read[0].ToString());
            conn.Close();




        }

        private void create_summary()
        {
            try
            {

                int selectedshow = dataGridViewShows.SelectedCells[0].RowIndex;
                DataGridViewRow selectedShow = dataGridViewShows.Rows[selectedshow];
                show = Convert.ToString(selectedShow.Cells[1].Value);
                lblShow.Text = show;
                int selectedact = dataGridViewActs.SelectedCells[0].RowIndex;
                DataGridViewRow selectedAct = dataGridViewActs.Rows[selectedact];
                act = Convert.ToString(selectedAct.Cells[1].Value);
                lblActs.Text = act;
                lblTickets.Text = total.ToString();


            }
            catch
            {

            }
        }
        private void clearSelect()
        {
            dataGridViewShows.CurrentCell.Selected = false;

        }

        private void createBooking()
        {
            string sql;
            int custid = customerid;
            int shid = showid;
            int ix = 0;
            int numberOfacts = 0;
            int priceid = 0; 
            DataTable tickets = new DataTable();
            tickets.Columns.Add("ticketid");
            tickets.Columns.Add("seatid");
            tickets.Columns.Add("priceid");
            tickets.Columns.Add("actid");
            progressBar1.Value = ix;

            
            for (int i = 0; i < nrotickets; i++)
            {
                string type = "";
                string tid = i.ToString();
                foreach (DataRow r in dtPersons.Rows)
                {
                    if (r[0].ToString() == tid)
                    {
                        numberOfacts = int.Parse(r[3].ToString());
                    }

                }
                if (numberOfacts == acts.Rows.Count)
                {
                    if (agegroup == 0)
                    {
                        priceid = 120;
                        type = "Barn";

                    }
                    if (agegroup == 1)
                    {
                        priceid = 130;
                        type = "Ungdom";
                    }
                    if (agegroup == 2)
                    {
                        priceid = 200;
                        type = "Vuxen";
                    }
                }
                else
                {
                    if (agegroup == 0)
                    {
                        priceid = 80 * numberOfacts;
                        type = "Barn";

                    }
                    if (agegroup == 1)
                    {
                        priceid = 110 * numberOfacts;
                        type = "Ungdom";
                    }
                    if (agegroup == 2)
                    {
                        priceid = 150 * numberOfacts;
                        type = "Vuxen";
                    }

                }




                if (radioRes.Checked == true)
                {
                    conn.Open();
                    sql = "insert into booking(customerid,showid, reserved_to, price, type) values(:cid,:shid, :rto, :pid, :tyd)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("cid", custid));
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", dateReservedto.Value.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new NpgsqlParameter("pid", priceid));
                    cmd.Parameters.Add(new NpgsqlParameter("tyd", type));
                    cmd.ExecuteNonQuery();
                    ix++;

                }
                else if (radioPaid.Checked == true && cbDf.Checked == false)
                {
                    conn.Open();
                    sql = "insert into booking(customerid,showid, paid, price, type) values(:cid,:shid, :rto, :pid, :tyd)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("cid", custid));
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", true));
                    cmd.Parameters.Add(new NpgsqlParameter("pid", priceid));
                    cmd.Parameters.Add(new NpgsqlParameter("tyd", type));
                    cmd.ExecuteNonQuery();
                        ix++;
                }
                else if (cbDf.Checked == true && radioPaid.Checked == true)
                {
                    conn.Open();
                    sql = "insert into booking(showid, paid, price, type) values(:shid, :rto, :pid, :tyd)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", true));
                    cmd.Parameters.Add(new NpgsqlParameter("pid", priceid));
                    cmd.Parameters.Add(new NpgsqlParameter("tyd", type));
                    cmd.ExecuteNonQuery();
                    ix++;
                }






                cmd = new NpgsqlCommand("select currval('booking_bookingid_seq');", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();

                read.Read();
                int addedbookingid = int.Parse(read[0].ToString());
                conn.Close();

                ix++;
                    foreach (DataRow dr in cSeats.Rows)
                    {
                        ix++;
                        string id = dr[0].ToString();
                        string actid = dr[1].ToString();
                        string section = dr[2].ToString();
                        string rownr = dr[3].ToString();
                  

                        string seatid = dr[5].ToString();
                        ix++;

                    if (id == tid)
                    {
                        conn.Open();
                        sql = "insert into booked_seats(available_seats_id, bookingid) values(:sid, :bid)";
                        cmd = new NpgsqlCommand(sql, conn);
                        cmd.Parameters.Add(new NpgsqlParameter("sid", seatid));
                        cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                        
                        cmd.ExecuteNonQuery();

                        cmd = new NpgsqlCommand("select currval('booked_seats_booked_seat_id_seq');", conn);

                        read = cmd.ExecuteReader();
                        ix++;

                        read.Read();
                        int addedbookedseat = int.Parse(read[0].ToString());
                        conn.Close();
                        conn.Open();
                        sql = "insert into ticket(bookingid, booked_seat_id ) values(:bid, :boid)";
                        cmd = new NpgsqlCommand(sql, conn);
                        cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                        cmd.Parameters.Add(new NpgsqlParameter("boid", addedbookedseat));


                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }

                }

                ix++;
            }
            progressBar1.Value = 100;
            
            
            

        }

        public void SendMail()
        {

            

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
        public void checkLocked()
        {
            foreach (DataRow r in dtPersons.Rows)
            {
                int id = int.Parse(r[0].ToString());
                int nr = int.Parse(r[3].ToString());
                if (id == ticketid && nr > 0)
                {
                    cbAgegroup.Enabled = false;
                    gpSeatMap.Enabled = true;

                    loadSeatMap();

                }
                else if (id == ticketid && nr == 0)
                {
                    cbAgegroup.Enabled = true;
                    gpSeatMap.Enabled = false;
                    clearSeatMap();

                }
            }
        }
        public void loadSeatMap()
        {
            dgTEST.DataSource = currentActs;
            int selectedIndex = dgActs.SelectedRows[0].Index;

            actid = int.Parse(dgActs[1, selectedIndex].Value.ToString());
            

            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = true;
                cb.Enabled = false;
                cb.BackColor = Color.WhiteSmoke;

            }
            if(fullShowS == false)
            {
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                foreach (DataRow row in currentActs.Rows)
                {
                    string s = row[1].ToString() + row[2].ToString();
              
                    if (row[3].ToString() == actid.ToString())
                    {
                        
                        if (cb.Name == s)
                        {
                            cb.Enabled = true;
                            cb.Checked = false;
                            cb.BackColor = Color.Green;
                            
                            }


                        }
                        else
                        {


                        }

                    }


                }
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {

                    foreach (DataRow r in cSeats.Rows)
                    {
                        string s = r[2].ToString() + r[3].ToString();
                        int aid = int.Parse(r[1].ToString());


                        if (cb.Name == s && aid == actid && ticketid != int.Parse(r[0].ToString()))
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                            cb.BackColor = Color.Blue;

                        }
                        else if (cb.Name == s && aid == actid && ticketid == int.Parse(r[0].ToString()))
                        {
                            cb.Checked = true;
                            cb.Enabled = true;
                            cb.BackColor = Color.Green;

                        }


                    }

                }


                        }
            else if(fullShowS == true)
            {
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {
                    foreach (DataRow row in fullShow.Rows)
                    {
                        string s = row[1].ToString() + row[2].ToString();



                            if (cb.Name == s)
                            {
                                cb.Enabled = true;
                                cb.Checked = false;
                                cb.BackColor = Color.Green;

                    }


                        
                    else
                    {


                        }

                    }


                }
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {

                    foreach (DataRow r in cSeats.Rows)
                    {
                        string s = r[2].ToString() + r[3].ToString();
                        int aid = int.Parse(r[1].ToString());


                        if (cb.Name == s && ticketid != int.Parse(r[0].ToString()))
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                            cb.BackColor = Color.Blue;

                        }
                        else if (cb.Name == s && ticketid == int.Parse(r[0].ToString()))
                        {
                            cb.Checked = true;
                            cb.Enabled = true;
                            cb.BackColor = Color.Green;

                    }


                }

                }

            }


        }
        public void clearSeatMap()
        {
            foreach(CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.BackColor = Color.WhiteSmoke;
                cb.Checked = true;
                cb.Enabled = false;
            }

        }
        public DataTable RemDup(DataTable dt, string seatid)
        {
            Hashtable ht = new Hashtable();
            ArrayList dup = new ArrayList();

            foreach(DataRow r in dt.Rows)
            {
            if (ht.Contains(r["seatid"]))
                dup.Add(r);
            else  
                ht.Add(r["seatid"], string.Empty);
            }
            foreach (DataRow row in dup)
                dt.Rows.Remove(row);

            return dt;
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("Test");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select customerid, email, fname, lname from customer where customerid = '" + customerid + "';", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            customeremail = dr[1].ToString();
            customerfname = dr[2].ToString();
            customerlname = dr[3].ToString();

            conn.Close();
           
            string confirm_mail_text = "Hej " + customerfname + " " + customerlname + "\n\nDet här är en bekräftelse på att du har köp biljetten/biljetter för kommande förestälningen \n\n\nOm du har några frågor kring ditt köp, vänligen kontakta oss via e-post: kulbusstest@gmail.com eller via telefon 000 000";


            object value = customeremail;
            if (value == DBNull.Value)
            {
                MessageBox.Show("Inget mail skickat");
            }
            else
            {
              


                mail = new MailMessage("kulbusstest@gmail.com", customeremail, "Cirkus Kull&Buss - Bokningsbekräftelse", confirm_mail_text); // (from, to, subject, body.text)

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("kulbusstest@gmail.com", "Test12345");
                client.EnableSsl = true;

                string show_date;
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(@"select distinct booking.bookingid,booking.customerid from booking where booking.showid = '" + showid + "' and booking.customerid = '" + customerid + "'", conn);
                DataTable dtBid = new DataTable();

                da.Fill(dtBid);
                conn.Close();
              
                //dgTEST.DataSource = dtBid;
                foreach (DataRow row in dtBid.Rows)
                {
                    int bid = int.Parse(row[0].ToString());
                    conn.Open();
                    da = new NpgsqlDataAdapter(@"select acts.name,seats.section, seats.rownumber, acts.start_time, acts.end_time from ticket
                                                            inner join booked_seats on ticket.booked_seat_id = booked_seats.booked_seat_id
                                                            inner join available_seats on booked_seats.available_seats_id = available_seats.available_seats_id
                                                            inner join acts on available_seats.actid = acts.actid
                                                            inner join seats on available_seats.seatid = seats.seatid                
                                                            where ticket.bookingid = '" + bid + "' order by acts.actid", conn);

                    DataTable acts = new DataTable();
                    
                    da.Fill(acts);
                    
                    conn.Close();
                    foreach (DataRow r in acts.Rows)
                    {
                        actname += " " + r[0].ToString() + ": " + r[1].ToString() + r[2].ToString();
                        //acttime += " " + r[0].ToString() + ": " + r[3].ToString() + "-" + r[4].ToString() + "";
                    }
                    conn.Open();
                    cmd = new NpgsqlCommand(@"select sum(price_group_seat.price), price_group_seat.group from price_group_seat
                                                inner join booked_seats on price_group_seat.priceid = booked_seats.priceid
                                                inner join booking on booked_seats.bookingid = booking.bookingid
                                                where booking.bookingid = '" + bid + "'group by price_group_seat.group", conn);
                    NpgsqlDataReader read = cmd.ExecuteReader();
                    string pris = "";
                    string aldersgrupp = "";

                    int pointImage = 600;
                    int imageHeight = 210;
                    int prisPoint = 650;
                    
                    foreach (DataRow ro in acts.Rows)
                    {
                        pointImage -= 20;
                        imageHeight += 20;
                        prisPoint -= 20;
                    }
                    
                    while (read.Read())
                    {
                        pris = read[0].ToString();
                        aldersgrupp = read[1].ToString();
                    }

                    conn.Close();
                    
                    conn.Open();
                    cmd = new NpgsqlCommand("select show.date from show inner join booking on show.showid = booking.showid where booking.bookingid = '" + bid + "'", conn);
                    read = cmd.ExecuteReader();
                    read.Read();
                    show_date = read[0].ToString();
                    conn.Close();

                    bokningid = bid.ToString();

                    //MemoryStream ms = new MemoryStream();
                    //Document doc = new Document(PageSize.A4, 36, 72, 108, 180);
                    //PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                    //Drawing
                    //doc.Open();
                    //doc.Add(new Paragraph("BiljettNr:" + bokningid));
                    //doc.Add(new Paragraph("Föreställning:" + show));
                    //doc.Add(new Paragraph("Åldersgrupp:" + aldersgrupp));
                    //doc.Add(new Paragraph("Biljett för " + actname));
                    //doc.Add(new Paragraph("Pris:" + pris));
                    //doc.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    #region PDF

                    MemoryStream ms = new MemoryStream();
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                    doc.Open();
                    ////Drawing

                    //Rectangle
                    PdfContentByte contentunder = writer.DirectContentUnder;
                    contentunder.SetColorStroke(BaseColor.BLACK);
                    contentunder.Rectangle(30, pointImage, 540, imageHeight);
                    contentunder.Stroke();

                    //Text
                    BaseFont f_cn = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    PdfContentByte cb = writer.DirectContent;

                    cb.BeginText();

                    cb.SetFontAndSize(FontFactory.GetFont(FontFactory.TIMES_BOLD).BaseFont, 18);
                    cb.SetTextMatrix(60, 770); // Left, Top
                    cb.ShowText("Biljett Cirkus Kul & Bus");

                    cb.SetFontAndSize(FontFactory.GetFont(FontFactory.TIMES_BOLD).BaseFont, 12);
                    cb.SetTextMatrix(60, 750);
                    cb.ShowText("BokningsID:");

                    cb.SetTextMatrix(60, 730);
                    cb.ShowText("Datum:");

                    cb.SetTextMatrix(60, 710);
                    cb.ShowText("Namn:");

                    cb.SetTextMatrix(60, 690);
                    cb.ShowText("Åldersgrupp:");

                    cb.SetTextMatrix(60, 670);
                    cb.ShowText("Akt/plats:");

                    cb.SetTextMatrix(60, 650);
                    cb.ShowText("Tider:");

                    cb.SetTextMatrix(60, prisPoint);
                    cb.ShowText("Pris:");

                    cb.SetTextMatrix(0, pointImage - 50);
                    cb.ShowText("-------------------------------------------------------------- Klipp här ------------------------------------------------------------------------------------------------------------------------- ");



                    cb.SetFontAndSize(FontFactory.GetFont(FontFactory.TIMES).BaseFont, 12);
                    cb.SetTextMatrix(160, 750);
                    cb.ShowText(bokningid);

                    cb.SetTextMatrix(160, 730);
                    cb.ShowText(show_date);

                    cb.SetTextMatrix(160, 710);
                    cb.ShowText(show);

                    cb.SetTextMatrix(160, 690);
                    cb.ShowText(aldersgrupp);

                    cb.SetTextMatrix(160, 670);
                    cb.ShowText(actname);
                    int i = 0;
                    foreach(DataRow rows in acts.Rows)
                    {
                        int set = i * 20;

                        string s = rows[0].ToString();
                        string s1 = rows[3].ToString();
                        string s2 = rows[4].ToString();
                        cb.SetTextMatrix(160, 650 - set);
                        
                        cb.ShowText(s + ": " + s1+ "-" +s2);
                        i++;

                    }
                

                    cb.SetTextMatrix(160, prisPoint);
                    cb.ShowText(pris+"kr");

                    cb.EndText();

                    //image 

                    string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

                    iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(path + "\\Resources\\backgroundClown.jpg");

                    //width height
                    PNG.ScaleAbsolute(540f, imageHeight);

                    PNG.SetAbsolutePosition(30, pointImage);
                    doc.Add(PNG);
                    writer.CloseStream = false;
                    doc.Close();
                    #endregion


                    ms.Position = 0;

                    mail.Attachments.Add(new Attachment(ms, "Biljett" + bokningid + ".pdf"));

                    actname = "";


                }

                
                MessageBox.Show("Här är vi nu");
                client.Send(mail);
             
                

            }

        }
        public void backrgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("Klart");
            }
        }
    }
}
