﻿using System;
using System.Collections;
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
        #region Variables in ReserveTicketForm
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        private int showid, actid, fillMode,  agegroup, customerid, total,  freeSseats, freeLseats,  nrotickets, ticketid,  checks;
        private string show, showname, customeremail, customerfname, customerlname,  bokningid, actname, aname,  acttime;    
        private double childS = 0, youthS = 0, adultS = 0, child = 0, youth = 0, adult = 0, discount = 0, discountS = 0;
        private bool newcust;
        private bool seatType = true;
        private bool fullShowS;
        private int addedbookingid = 0;
        DataTable shows,  dtfSeats, dtPersons;
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
        #endregion
        #region Methods in ReserveTicketForm
        public ReserveTicketForm()
        {
            InitializeComponent();
            loadShows();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

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
            panel2.Visible = false;
            cSeats.Columns.Add("ticketid");
            cSeats.Columns.Add("actid");
            cSeats.Columns.Add("section");
            cSeats.Columns.Add("rownumber");
            cSeats.Columns.Add("priceid");
            cSeats.Columns.Add("seatid");
            cSeats.Columns.Add("fp", typeof(bool)).SetOrdinal(6);
            cSeats.Columns.Add("actname").SetOrdinal(7);
            lblStatus1.Visible = false;
            lblStatusAge.Visible = false;

            priceChildS.Text = "";
            priceYouthS.Text = "";
            priceAdultS.Text = "";
            priceChild.Text = "";
            priceYouth.Text = "";
            priceAdult.Text = "";
            childDisS.Text = "";
            youthDisS.Text = "";
            adultDisS.Text = "";
            childdis.Text = "";
            youthdisc.Text = "";
            adultdisc.Text = "";
        }
        public void loadShows()
        {
            string sql = "select show.showid, show.name, show.date, show.price_group from show where now()::date  >= sale_start and now()::date <= sale_stop";
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            shows = new DataTable();
            da.Fill(shows);

            dataGridViewShows.DataSource = shows;

            dataGridViewShows.Columns[1].HeaderText = "Namn";
            dataGridViewShows.Columns[2].HeaderText = "Datum";

            this.dataGridViewShows.Columns[0].Visible = false;
            this.dataGridViewShows.Columns[3].Visible = false;


            conn.Close();
        }
        private void loadActs()
        {

            filterActs.DataSource = acts;
            filterActs.Filter = string.Format("ticketid = '{0}'", dgTickets.SelectedRows[0].Index.ToString());
          
            int selectedIndex2 = dgTickets.SelectedRows[0].Index;
        
            //int selectedIndex = dataGridViewShows.SelectedRows[0].Index;
            //showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());
            //showdate = Convert.ToDateTime(dataGridViewShows[2, selectedIndex].Value.ToString());
            dgActs.DataSource = acts;
            int selectedIndex3 = dgActs.SelectedRows[0].Index;

            actid = int.Parse(dgActs[1, selectedIndex3].Value.ToString());


            //string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);




            //dgTEST.DataSource = acts;
            //if (acts.Rows.Count > 0)
            //{
            //    for (int row = 0; row < acts.Rows.Count; row++)
            //    {
            //        DataRow rows = acts.Rows[row];
            //        if (rows.RowState != DataRowState.Deleted)
            //        {
            //            object id = rows[0];
            //            object id2 = dgTickets[0, selectedIndex2].Value.ToString();
            //            string a = dgTickets[0, selectedIndex2].Value.ToString();
            //            string b = rows[0].ToString();


            //            if (a != b)
            //            {
            //                fillMode = 1;


            //            }
            //            else
            //            {
            //                return;
            //            }

            //        }

            //    }
            //}
            //else
            //{

            //    fillMode = 2;


            //}
            //switch (fillMode)
            //{

            //    case 1:

            //        conn.Open();
            //        da.Fill(acts);

            //        conn.Close();
            //        for (int rw = 0; rw < acts.Rows.Count; rw++)
            //        {
            //            DataRow drw = acts.Rows[rw];
            //            if (drw.RowState != DataRowState.Deleted)
            //            {
            //                object value3 = drw[0];
            //                object value4 = dgTickets[0, selectedIndex2].Value.ToString();

            //                if (value3 == DBNull.Value)
            //                {
            //                    drw[0] = int.Parse(dgTickets[0, selectedIndex2].Value.ToString());
            //                    drw[3] = false;


            //                }
            //            }

            //        }

            //        break;
            //    case 2:
            //        conn.Open();

            //        da.Fill(acts);
            //        conn.Close();
            //        for (int rw = 0; rw < acts.Rows.Count; rw++)
            //        {
            //            DataRow drw = acts.Rows[rw];
            //            if (drw.RowState != DataRowState.Deleted)
            //            {
            //                object value3 = drw[0];
            //                object value4 = dgTickets[0, selectedIndex2].Value.ToString();

            //                if (value3 == DBNull.Value)
            //                {
            //                    drw[0] = int.Parse(dgTickets[0, selectedIndex2].Value.ToString());
            //                    drw[3] = false;

            //                }
            //            }



            //        }
            //        break;
            //}

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
        private void seat_sectionchanged(object sender, EventArgs e)
        {
            conn.Close();
          
        }
        private void checked_seats(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (items.CheckedItems.Count > total - 1)
            {
                e.NewValue = CheckState.Unchecked;

            }

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
        private void clearSelect()
        {
            dataGridViewShows.CurrentCell.Selected = false;
        }
        private void createBooking()
        {
            DataTable ds = new DataTable();
            ds.Columns.Add("bookingid");
            string sql;
            int custid = customerid;
            int shid = showid;
            int ix = 0;
            int numberOfacts = 0;
            double priceid = 0;

            string type = "";
            for (int i = 0; i < nrotickets; i++)
            {

                string tid = i.ToString();
                foreach (DataRow r in dtPersons.Rows)
                {
                    if (tid == r[0].ToString())
                    {
                        agegroup = int.Parse(r[2].ToString());
                        numberOfacts = int.Parse(r[3].ToString());

                    }

                }
                string seattype = "";
                if (numberOfacts < showacts.Rows.Count)
                {
                    if (agegroup == 0)
                    {

                        priceid = childS * numberOfacts;
                        type = "Barn";
                        seattype = "Parkett";
                    }
                    if (agegroup == 1)
                    {
                        priceid = youthS * numberOfacts;
                        type = "Ungdom";
                        seattype = "Parkett";
                    }
                    if (agegroup == 2)
                    {
                        priceid = adultS * numberOfacts;
                        type = "Vuxen";
                        seattype = "Parkett";
                    }
                }
                else if (numberOfacts == showacts.Rows.Count)
                {

                    if (agegroup == 0)
                    {


                        priceid = (childS * numberOfacts) * (discountS / 100);
                        type = "Barn";
                        seattype = "Parkett";
                       

                    }
                    if (agegroup == 1)
                    {

                        priceid = (youthS * numberOfacts) * (discountS / 100);
                        type = "Ungdom";
                        seattype = "Parkett";
                    }
                    if (agegroup == 2)
                    {

                        priceid = (adultS * numberOfacts) * (discountS / 100);
                        type = "Vuxen";
                        seattype = "Parkett";
                    }

                }

                if (radioRes.Checked == true && radioButtonDirectSale.Checked == false)
                {
                    conn.Open();
                    sql = "insert into booking(customerid,showid, reserved_to, paid) values(:cid,:shid, :rto, :pai)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("cid", custid));
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", dateReservedto.Value.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new NpgsqlParameter("pai", false));
                    cmd.ExecuteNonQuery();
                    ix++;

                }
                else if (radioPaid.Checked == true && radioButtonDirectSale.Checked == false)
                {
                    conn.Open();
                    sql = "insert into booking(customerid,showid, paid) values(:cid,:shid, :rto)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("cid", custid));
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", true));

                    cmd.ExecuteNonQuery();

                    ix++;
                }
                else if (radioButtonDirectSale.Checked == true)
                {
                    conn.Open();
                    sql = "insert into booking(showid, paid) values(:shid, :rto)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));
                    cmd.Parameters.Add(new NpgsqlParameter("rto", true));
                    cmd.ExecuteNonQuery();

                    ix++;
                }

                cmd = new NpgsqlCommand("select currval('booking_bookingid_seq');", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();


                read.Read();
                addedbookingid = int.Parse(read[0].ToString());

                conn.Close();
                if (radioButtonDirectSale.Checked == true)
                {
                    DataRow row = ds.NewRow();
                    row[0] = addedbookingid;
                    ds.Rows.Add(row);

                }
           
                ix++;
                foreach (DataRow dr in cSeats.Rows)
                {
                    ix++;
                    string id = dr[0].ToString();
                    string actid = dr[1].ToString();
                    string section = dr[2].ToString();
                    string rownr = dr[3].ToString();


                    string seatid = dr[5].ToString();
                    bool chck = Convert.ToBoolean(dr[6].ToString());
                    ix++;

                    if (id == tid && chck == false)
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
                        double calculate = priceid / numberOfacts;
                        cmd = new NpgsqlCommand("insert into sold_tickets(showid, actid,type,sum, bookingid,seattype,seatid) values(:shid, :aid, :typ, :su, :bid, :styp, :sid)", conn);
                        cmd.Parameters.Add(new NpgsqlParameter("shid", showid));
                        cmd.Parameters.Add(new NpgsqlParameter("aid", actid));
                        cmd.Parameters.Add(new NpgsqlParameter("typ", type));
                        cmd.Parameters.Add(new NpgsqlParameter("su", calculate));
                        cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                        cmd.Parameters.Add(new NpgsqlParameter("styp", seattype));
                        cmd.Parameters.Add(new NpgsqlParameter("sid", seatid));
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else if (id == tid && chck == true)
                    {

                        if (numberOfacts < showacts.Rows.Count)
                        {
                            if (agegroup == 0)
                            {

                                priceid = child * numberOfacts;
                                type = "Barn";
                                seattype = "Fri placering";

                            }
                            if (agegroup == 1)
                            {
                                priceid = youth * numberOfacts;
                                type = "Ungdom";
                                seattype = "Fri placering";
                            }
                            if (agegroup == 2)
                            {
                                priceid = adult * numberOfacts;
                                type = "Vuxen";
                                seattype = "Fri placering";
                            }
                        }
                        else if (numberOfacts == showacts.Rows.Count)
                        {

                            if (agegroup == 0)
                            {

                                priceid = (child * numberOfacts) * (discount / 100);
                                type = "Barn";
                                seattype = "Fri placering";

                            }
                            if (agegroup == 1)
                            {

                                priceid = (youth * numberOfacts) * (discount / 100);
                                type = "Ungdom";
                                seattype = "Fri placering";
                            }
                            if (agegroup == 2)
                            {

                                priceid = (adult * numberOfacts) * (discount / 100);
                                type = "Vuxen";
                                seattype = "Fri placering";
                            }

                        }
                        //double calculate = priceid / numberOfacts;
                        conn.Open();
                        cmd = new NpgsqlCommand("insert into sold_tickets(showid, actid,type,sum, bookingid,seattype) values(:shid, :aid, :typ, :su, :bid, :st)", conn);
                        cmd.Parameters.Add(new NpgsqlParameter("shid", showid));
                        cmd.Parameters.Add(new NpgsqlParameter("aid", actid));
                        cmd.Parameters.Add(new NpgsqlParameter("typ", type));
                        cmd.Parameters.Add(new NpgsqlParameter("su", priceid));
                        cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                        cmd.Parameters.Add(new NpgsqlParameter("st", seattype));

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        cmd = new NpgsqlCommand("insert into booked_standing(bookingid, actid)values(:bid, :aid)", conn);
                        cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                        cmd.Parameters.Add(new NpgsqlParameter("aid", actid));
                        cmd.ExecuteNonQuery();
                conn.Close();
            }

                }

                ix++;
            }
            if (radioButtonDirectSale.Checked == true)
            {
                PrintBiljetter rb = new PrintBiljetter(ds);
                rb.ShowDialog();
            }

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
          
            int selectedIndex = dgActs.SelectedRows[0].Index;

            actid = int.Parse(dgActs[1, selectedIndex].Value.ToString());


            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = true;
                cb.Enabled = false;
                cb.BackColor = Color.WhiteSmoke;

            }
            if (fullShowS == false)
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
                seatSugg();
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
            else if (fullShowS == true)
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
                seatSugg();
            }


        }
        public void clearSeatMap()
        {
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
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

            foreach (DataRow r in dt.Rows)
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

             
                foreach (DataRow row in dtBid.Rows)
                {
                    int bid = int.Parse(row[0].ToString());
                    conn.Open();
                    da = new NpgsqlDataAdapter(@"select acts.name, seats.section, seats.rownumber, acts.start_time, acts.end_time, sold_tickets.seattype from acts
                                                    inner join sold_tickets on acts.actid = sold_tickets.actid
                                                    left join available_seats on sold_tickets.seatid = available_seats.available_seats_id
                                                    left join seats on available_seats.seatid = seats.seatid where bookingid = '" + bid + "'", conn);

                    DataTable acts = new DataTable();

                    da.Fill(acts);

                    conn.Close();
                    foreach (DataRow r in acts.Rows)
                    {
                        if (r[5].ToString() == "Fri placering") 
                        {
                            actname += " " + r[0].ToString() + ": Fri placering";
                        }
                        else
                        {
                            actname += " " + r[0].ToString() + ": " + r[1].ToString() + r[2].ToString();
                        }

                        
                    }
                    conn.Open();
                    cmd = new NpgsqlCommand(@"select sold_tickets.type, sum(sum) from sold_tickets
                                                inner join booking on sold_tickets.bookingid = booking.bookingid
                                                where booking.bookingid = '" + bid + "' group by sold_tickets.type", conn);
                    NpgsqlDataReader read = cmd.ExecuteReader();
                    string pris = "";
                    string aldersgrupp = "";
                    while (read.Read())
                    {
                        aldersgrupp = read[0].ToString();
                        pris = read[1].ToString();
                    }
                    conn.Close();

                    int pointImage = 600;
                    int imageHeight = 210;
                    int prisPoint = 650;

                    foreach (DataRow ro in acts.Rows)
                    {
                        pointImage -= 20;
                        imageHeight += 20;
                        prisPoint -= 20;
                    }

                    conn.Open();
                    cmd = new NpgsqlCommand("select show.date from show inner join booking on show.showid = booking.showid where booking.bookingid = '" + bid + "'", conn);
                    read = cmd.ExecuteReader();
                    read.Read();
                    show_date = read[0].ToString();
                    conn.Close();

                    bokningid = bid.ToString();

      
                    #region PDF

                    MemoryStream ms = new MemoryStream();
                    Document doc = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                    doc.Open();
                 

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
                    foreach (DataRow rows in acts.Rows)
                    {
                        int set = i * 20;

                        string s = rows[0].ToString();
                        string s1 = rows[3].ToString();
                        string s2 = rows[4].ToString();
                        cb.SetTextMatrix(160, 650 - set);

                        cb.ShowText(s + ": " + s1 + "-" + s2);
                        i++;

                    }


                    cb.SetTextMatrix(160, prisPoint);
                    cb.ShowText(pris + "kr");

                    cb.EndText();

                    //image 

                    string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

                    iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(path + "\\Resources\\backgroundClown.jpg");

                  
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

                client.Send(mail);

            }

        }
        public void backrgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("Klart");
            }
        }
        private void seatSugg()
        {
            string sql = @"select seats.section, seats.rownumber, seats.seatid from available_seats 
                            inner join seats on available_seats.seatid = seats.seatid
                            inner join acts on available_seats.actid = acts.actid
                            inner join show on acts.showid = show.showid
                            left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                            where acts.actid = '" + actid + "' and booked_seats.booked_seat_id is null order by seats.seatid ";
            conn.Open();
            NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            conn.Close();

            //dt = RemDup(dt, "seatid");
            //dt.AcceptChanges();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("nr");
            dt2.Columns.Add("sect");
            dt2.Columns.Add("seatid");

            int x = 0;
            int y = 0;
            for (int dr = 0; dr < dt.Rows.Count - 1; dr++)
            {
                DataRow r = dt.Rows[dr];
                y = int.Parse(r[1].ToString());
                string s = r[0].ToString();


                for (int row = dr + 1; row <= dr + 1; row++)
                {
                    DataRow rw = dt.Rows[row];
                    x = int.Parse(rw[1].ToString());

                    if (x - y == 1 && s == rw[0].ToString())
                    {
                        DataRow drow = dt2.NewRow();
                        drow[0] = y;
                        drow[1] = s;
                        drow[2] = r[2];

                        dt2.Rows.Add(drow);
                        if (y + 1 == x && s == rw[0].ToString())
                        {

                            drow = dt2.NewRow();
                            drow[0] = y + 1;
                            drow[1] = s;
                            drow[2] = rw[2];
                            dt2.Rows.Add(drow);
                        }
                    }
                }
            }
            dt2 = RemDup(dt2, "seatid");
            dt2.AcceptChanges();
            //dgTest2.DataSource = dt;
            //dgTEST.DataSource = dt2;
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                if (dt2.Rows.Count > 0)
                {
                    for (int dr = 0; dr < nrotickets; dr++)
                    {
                        DataRow r = dt2.Rows[dr];
                        string s = r[1].ToString() + r[0].ToString();
                        if (cb.Name == s)
                        {
                            if (cb.BackColor != Color.Blue)
                            {
                                cb.Checked = false;
                                cb.Enabled = true;

                                cb.BackColor = Color.Orange;
                            }
                        }
                    }
                }
            }
        }
        private void printDocumentBIljettDirekt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string pris = "";
            string aldersgrupp = "";

            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(@"select distinct booking.bookingid,booking.customerid from booking where booking.showid = '" + showid + "' and booking.customerid = '" + customerid + "'", conn);
            DataTable dtBid = new DataTable();

            da.Fill(dtBid);
            conn.Close();

            foreach (DataRow row in dtBid.Rows)
            {
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 18);
                System.Drawing.Font drawFontBold = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
                System.Drawing.Font drawFontBoldAndUnderline = new System.Drawing.Font("Arial", 18, FontStyle.Bold | FontStyle.Underline);
                SolidBrush drawBrush = new SolidBrush(Color.Black);


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

                int point = 350;
                foreach (DataRow r in acts.Rows)
        {
                    actname += " " + r[0].ToString() + ": " + r[1].ToString() + r[2].ToString();
                    acttime += " " + r[0].ToString() + ": " + r[3].ToString() + "-" + r[4].ToString() + "\n";
                    point += 40;
                }



                int regtangelP = point + 60;

      
                System.Drawing.Image i2 = cirkus.Properties.Resources.backgroundClown;
                Point p2 = new Point(100, 100);

     
                System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(20, 40, 750, regtangelP);


       
                int x = 0;
                int y = 0;
                int width = i2.Width;
                int height = i2.Height;
                GraphicsUnit units = GraphicsUnit.Pixel;



        
                e.Graphics.DrawImage(i2, destRect, x, y, width, height, units); 

                e.Graphics.DrawString("Biljett Cirkus Kul & Bus", drawFontBoldAndUnderline, drawBrush, new PointF(44, 110));


                e.Graphics.DrawString("BokningsID:", drawFontBold, drawBrush, new PointF(45, 150));
                e.Graphics.DrawString("Datum:", drawFontBold, drawBrush, new PointF(45, 190));
                e.Graphics.DrawString("Namn:", drawFontBold, drawBrush, new PointF(45, 230));
                e.Graphics.DrawString("Åldersgrupp:", drawFontBold, drawBrush, new PointF(45, 270));
                e.Graphics.DrawString("Akt/plats:", drawFontBold, drawBrush, new PointF(45, 310));
                e.Graphics.DrawString("Tider:", drawFontBold, drawBrush, new PointF(45, 350));
                e.Graphics.DrawString("Pris:", drawFontBold, drawBrush, new PointF(45, point));
                e.Graphics.DrawString("---------------------------------------- Klipp här -----------------------------------------------", drawFont, drawBrush, new PointF(00, point + 110));


                e.Graphics.DrawString(bokningid, drawFont, drawBrush, new PointF(250, 150));
                e.Graphics.DrawString(showdate.ToString(), drawFont, drawBrush, new PointF(250, 190));
                e.Graphics.DrawString(show, drawFont, drawBrush, new PointF(250, 230));
                e.Graphics.DrawString(aldersgrupp, drawFont, drawBrush, new PointF(250, 270));
                e.Graphics.DrawString(actname, drawFont, drawBrush, new PointF(250, 310));
                e.Graphics.DrawString(acttime, drawFont, drawBrush, new PointF(250, 350));
                e.Graphics.DrawString(pris + " kronor", drawFont, drawBrush, new PointF(250, point));
            }
        }
        #endregion
        #region Events in ReserveTicketForm
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
            int pricelist = int.Parse(dataGridViewShows[3, selectedIndex].Value.ToString());

            conn.Close();
            conn.Open();
            string sql = @"select acts.actid,acts.name, acts.start_time, acts.end_time,count(available_seats.available_seats_id)  - count(booked_seats.booked_seat_id) as antal from available_seats
                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                        inner join acts on available_seats.actid = acts.actid
                        inner join show on acts.showid = show.showid
                        where show.showid = '" + showid + "' group by acts.actid, acts.name,acts.name, acts.start_time, acts.end_time";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            showacts = new DataTable();

            da.Fill(showacts);
            showacts.Columns.Add("free", typeof(int)).SetOrdinal(5);
            dgShowActs.DataSource = showacts;
            dgShowActs.Columns[1].HeaderText = "Namn";
            dgShowActs.Columns[2].HeaderText = "Starttid";
            dgShowActs.Columns[3].HeaderText = "Sluttid";
            dgShowActs.Columns[4].HeaderText = "Parkettplatser";
            dgShowActs.Columns[5].HeaderText = "Fri placering";
            dgShowActs.Columns[2].Width = 40;
            dgShowActs.Columns[3].Width = 40;

            dgShowActs.Columns[0].Visible = false;
            conn.Close();

            string sql2 = @"select distinct acts.actid, acts.free_placement - count(booked_standing.actid)as free from acts
                                    inner join show on acts.showid = show.showid
                                    left join booked_standing on acts.actid = booked_standing.actid
                                    where show.showid = '" + showid + "' group by booked_standing.actid,acts.actid,acts.free_placement ";
            da = new NpgsqlDataAdapter(sql2, conn);
            DataTable temp = new DataTable();
            da.Fill(temp);

            foreach (DataRow r in temp.Rows)
            {
                string actid = r[0].ToString();
                for (int i = 0; i < showacts.Rows.Count; i++)
                {
                    DataRow drw = showacts.Rows[i];
                    string aid = drw[0].ToString();
                    if (actid == aid)
                    {
                        drw[5] = r[1];
                    }
                }
            }
            dgShowActs.ClearSelection();
         
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select childprice_seat,youthchild_seat, adultprice_seat, childprice, youthprice, adultprice, discount_seat, discount from pricegroup where priceid = @pid", conn);
            cmd.Parameters.AddWithValue("@pid", pricelist);
            NpgsqlDataReader re = cmd.ExecuteReader();
            //double childS = 0, youthS  = 0, adultS = 0, child = 0, youth = 0, adult = 0, discount = 0, discountS = 0;
            while (re.Read())
            {
                childS = Convert.ToDouble(re[0].ToString());
                youthS = Convert.ToDouble(re[1].ToString());
                adultS = Convert.ToDouble(re[2].ToString());
                child = Convert.ToDouble(re[3].ToString());
                youth = Convert.ToDouble(re[4].ToString());
                adult = Convert.ToDouble(re[5].ToString());
                discountS = Convert.ToDouble(re[6].ToString());
                discount = Convert.ToDouble(re[7].ToString());
                conn.Close();
            }
            double childdiss = (childS * showacts.Rows.Count) * (discountS / 100);
            double youthdiss = (youthS * showacts.Rows.Count) * (discountS / 100);
            double adultdiss = (adultS * showacts.Rows.Count) * (discountS / 100);
            double childis =   (child * showacts.Rows.Count) * (discount / 100);
            double youthdis =  (youth * showacts.Rows.Count) * (discount / 100);
            double adultdis =  (adult * showacts.Rows.Count) * (discount / 100);

            priceChildS.Text = childS.ToString() + " kr";
            priceYouthS.Text = youthS.ToString() + " kr";
            priceAdultS.Text = adultS.ToString() + " kr";
            priceChild.Text = child.ToString() + " kr";
            priceYouth.Text = youth.ToString() + " kr";
            priceAdult.Text = adult.ToString() + " kr";
            childDisS.Text = childdiss.ToString() + " kr";
            youthDisS.Text = youthdiss.ToString() + " kr";
            adultDisS.Text = adultdiss.ToString() + " kr";
            childdis.Text = childis.ToString() + " kr";
            youthdisc.Text = youthdis.ToString() + " kr";
            adultdisc.Text = adultdis.ToString() + " kr";



        }
     
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (total > 0 && string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false && EndastSiffror(txtBoxNrP.Text) == true && dataGridViewShows.SelectedRows.Count > 0)
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
                for (int id = 0; id < dtPersons.Rows.Count; id++)
                {
                    DataRow rw = dtPersons.Rows[id];
                    for(int act = 0; act < showacts.Rows.Count; act++)
                    {
                        DataRow rws = showacts.Rows[act];
                        DataRow drow = acts.NewRow();
                        drow[0] = rw[0];
                        drow[1] = rws[0];
                        drow[2] = rws[1];
                        drow[3] = false;
                        acts.Rows.Add(drow);

                }
                    

                }
     
                   
                dgTickets.DataSource = dtPersons;
                //comboTicketnr.Text = "2";
                dgTickets.ClearSelection();
                dgTickets.Columns[0].Visible = false;
                dgTickets.Columns[2].Visible = false;
                dgTickets.Columns[3].Visible = false;
                int selectedIndex = dataGridViewShows.SelectedRows[0].Index;
                showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());
                showdate = Convert.ToDateTime(dataGridViewShows[2, selectedIndex].Value.ToString());
                showname = dataGridViewShows[1, selectedIndex].Value.ToString();
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
            
            if(cSeats.Rows.Count < dtPersons.Rows.Count)
            {
                MessageBox.Show("Välj minst en plats till varje person!");

            }
            else
            {
                panel2.Visible = true;
                dgCustom.DataSource = null;
                radioButtonDirectSale.Checked = true;
                create_summary();

            }
          


        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (newcust == false && radioButtonDirectSale.Checked == false)
            {
                panel2.Visible = true;

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
                radioButtonDirectSale.Enabled = false;
                newcust = true;
                txtenamn.Enabled = true;
                txtepost.Enabled = true;
                txtfnamn.Enabled = true;
                txttel.Enabled = true;
                radioButtonDirectSale.Checked = false;

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
                radioButtonDirectSale.Enabled = true;

            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgActs.Rows.Count > 0)
            {

                int selectedIndex3 = dgActs.SelectedRows[0].Index;

                actid = int.Parse(dgActs[1, selectedIndex3].Value.ToString());
                aname = dgActs[2, selectedIndex3].Value.ToString();
                foreach(DataRow drows in acts.Rows)
                {
                    
                    if(ticketid.ToString() == drows[0].ToString() && drows[1].ToString() == actid.ToString() && Convert.ToBoolean(drows[3].ToString()) == true)
                    {
                        loadSeatMap();
                    }
                    else if(ticketid.ToString() == drows[0].ToString() && drows[1].ToString() == actid.ToString() && Convert.ToBoolean(drows[3].ToString()) == false)
                    {
                        clearSeatMap();
                    }
                }
                
                foreach (DataRow r in cSeats.Rows)
                {

                    bool check = Convert.ToBoolean(r[6].ToString());
                    if (ticketid.ToString() == r[0].ToString() && actid.ToString() == r[1].ToString() && check == true)
                    {
                     
                        fp.Checked = true;
                        
                    }
                    else
                    {
                        fp.Checked = false;
                    }

        }

            }
        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void dgActs_Click(object sender, EventArgs e)
        {
            if(this.dgActs.Columns[3].ReadOnly == true)
            {
                lblStatusAge.Visible = true;
                lblStatusAge.ForeColor = Color.Tomato;
                lblStatusAge.Text = "Vänligen välj åldersgrupp";
            }
        }

        private void txtBoxNrP_TextChanged(object sender, EventArgs e)
        {
            if (EndastSiffror(txtBoxNrP.Text) == true && string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false)
            {
                total = Convert.ToInt32(txtBoxNrP.Text);

                for (int dr = 0; dr < dgShowActs.Rows.Count; dr++)
                {
                    DataGridViewRow row = dgShowActs.Rows[dr];
                    int check = int.Parse(row.Cells[4].Value.ToString());
                    int check2 = int.Parse(row.Cells[5].Value.ToString());
                    if(total > check)
                    {
                        dgShowActs.Rows[dr].Cells[4].Style.BackColor = Color.Tomato;
                    }
                    else
                    {
                        dgShowActs.Rows[dr].Cells[4].Style.BackColor = Color.LawnGreen;
                    }
                    if(total > check2)
                    {
                        dgShowActs.Rows[dr].Cells[5].Style.BackColor = Color.Tomato;
                    }
                    else
                    {
                        dgShowActs.Rows[dr].Cells[5].Style.BackColor = Color.LawnGreen;
                    }
                }
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(radioRes.Checked == true)
            {
                dateReservedto.Enabled = true;
            }
        }
        private void dgTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSeatStatus.Visible = false;
            checks = 0;
            cbAgegroup.SelectedIndex = -1;
            int dgIndex = dgTickets.SelectedRows[0].Index;
            ticketid = int.Parse(dgTickets[0, dgIndex].Value.ToString());
           
            loadActs();
            this.dgActs.Columns[0].ReadOnly = true;
            this.dgActs.Columns[1].ReadOnly = true;
            this.dgActs.Columns[2].ReadOnly = true;
            this.dgActs.Columns[3].ReadOnly = true;
            this.dgActs.Columns[0].Visible = false;
            this.dgActs.Columns[1].Visible = false;
            dgActs.Columns[4].Visible = false;

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
            foreach(DataRow rows in acts.Rows)
            {
                if (ticketid.ToString() == rows[0].ToString() && actid.ToString() == rows[1].ToString() && Convert.ToBoolean(rows[3]) == true)
                {
                    loadSeatMap();
                  
                }
                else if(ticketid.ToString() == rows[0].ToString() && actid.ToString() == rows[1].ToString() && Convert.ToBoolean(rows[3]) == false)
                {
                    clearSeatMap();
                }

            }
            if (dgActs.Rows.Count > 0)
            {


                foreach (DataRow r in cSeats.Rows)
                {

                    bool check = Convert.ToBoolean(r[6].ToString());
                    if (ticketid.ToString() == r[0].ToString() && actid.ToString() == r[1].ToString() && check == true)
                    {
                        
                        fp.Checked = true;
                        clearSeatMap();
                    }
                    else
                    {
                        fp.Checked = false;
                        
                    }

                }

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
                if (cb != null && cb.Checked && cb.BackColor == Color.Orange)
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
        private void fp_CheckedChanged(object sender, EventArgs e)
        {
            
            if(fp.Checked == true)
            {
                foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                {
                    gpSeatMap.Enabled = false;
                    cb.Checked = true;
                    cb.Enabled = false;
                    cb.BackColor = Color.WhiteSmoke;
                }
                DataRow row = cSeats.NewRow();
                row[0] = ticketid;
                row[1] = actid;
                row[2] = '-';
                row[3] = 0;
                row[4] = agegroup;
                row[5] = 0;
                row[6] = true;
                cSeats.Rows.Add(row);

              
        }
        else if(fp.Checked == false)
        {
             
                foreach(DataRow r in cSeats.Rows)
                {
                    
                    if(ticketid.ToString() == r[0].ToString() && r[1].ToString() == actid.ToString())
                    {
                        
                        r.Delete();
                        gpSeatMap.Enabled = true;

                    }
                }
              
            }
            cSeats.AcceptChanges();
        if(fp.Checked == false)
            {
                loadSeatMap();
            }
        }
        private void dgActs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void radioButtonDirectSale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDirectSale.Checked == true)
            {
                groupBox6.Enabled = false;
                this.dgCustom.DataSource = null;

   
            }
            else if (radioButtonDirectSale.Checked == false)
            {
                radioPaid.Enabled = true;
                radioRes.Enabled = true;
                dateReservedto.Enabled = true;
              
                listCustomers();
                checkBox2.Enabled = true;
            }
        }
        private void radioPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPaid.Checked==true)
            {
                dateReservedto.Enabled = false;
                //radioButtonDirectSale.Enabled = true;
                groupBox6.Enabled = true;
                checkBox2.Enabled = true;
            }
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


        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {

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
                lblSeatStatus.Visible = true;
                lblSeatStatus.Text = "Plats bokad";
                lblSeatStatus.ForeColor = Color.Green;
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
                    row[6] = false;
                    row[7] = aname;
                    cSeats.Rows.Add(row);
                    
                    }
                    if (cb.Checked == true && cb.BackColor == Color.Orange)
                    {
                        DataRow row = cSeats.NewRow();
                        row[0] = ticketid;
                        row[1] = actid;
                        row[2] = seatSection;
                        row[3] = seatNumber;
                        row[4] = agegroup;
                        row[6] = false;
                        row[7] = aname;
                        cSeats.Rows.Add(row);

                    }

                }
              
                char sect = '-';
                foreach (DataRow r in cSeats.Rows)
                {
                    string aid = r[1].ToString();
                  
                    sect = Char.Parse(r[2].ToString());
                    
                    
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

                        sect = Char.Parse(r[2].ToString());
                        string nr = r[3].ToString();
                        string sactid = r[1].ToString();
                        string s = sect + nr;
                        if (cb.Name == s && cb.Checked == false && cb.BackColor == Color.Green && actid.ToString() == sactid)
                        {

                            r.Delete();
                        }
                        else if (cb.Name == s && cb.Checked == false && cb.BackColor == Color.Orange && actid.ToString() == sactid)
                        {

                            r.Delete();
                        }

                    }
                    cSeats.AcceptChanges();
                }
                


                }
            else if(fullShowS == true)
            {
                lblSeatStatus.Visible = true;
                lblSeatStatus.Text = "Plats bokad";
                lblSeatStatus.ForeColor = Color.Green;
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
                            row[6] = false;
                            cSeats.Rows.Add(row);
                        }
                    }
                    else if (cb.Checked == true && cb.BackColor == Color.Orange)
                    {

                        foreach (DataRow rows in showacts.Rows)
                        {
                            DataRow row = cSeats.NewRow();
                            string aid = rows[0].ToString();
                            string sql = "select available_seats_id from available_seats inner join seats on available_seats.seatid = seats.seatid where actid = '" + aid + "' and seats.section = '" + seatSection + "' and seats.rownumber = '" + seatNumber + "'";
                            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                            conn.Open();
                            NpgsqlDataReader read = cmd.ExecuteReader();
                            while (read.Read())
                            {

                                row[5] = read[0];

                            }
                            conn.Close();

                            row[0] = ticketid;
                            row[1] = aid;
                            row[2] = seatSection;
                            row[3] = seatNumber;
                            row[4] = agegroup;
                            row[6] = false;
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
            panel1.Visible = true;
            panel2.Visible = false;
        }
        private void selected_customer(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgCustom.SelectedRows[0].Index;

            customerid = int.Parse(dgCustom[2, selectedIndex].Value.ToString());

           
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dateReservedto.Value = showdate;
            dateReservedto.Value = dateReservedto.Value.Subtract(TimeSpan.FromDays(7));

            if (newcust == true && radioButtonDirectSale.Checked == false)
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
                
            }
            if (newcust == false && radioButtonDirectSale.Checked == true)
            {
 

            }

            if (radioButtonDirectSale.Checked == false && radioPaid.Checked == true)
            {
                createBooking();
                backgroundWorker1.RunWorkerAsync();
                this.Close();
            }

            else if(radioButtonDirectSale.Checked == true)
            {
     
                createBooking();
               
            }
            else if(radioRes.Checked == true)
            {
                createBooking();
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
                    dgActs.Enabled = true;
                    
                }

                if (cbAgegroup.Text == "Ungdom")
                {
                    agegroup = 1;
                    this.dgActs.Columns[3].ReadOnly = false;
                    lblStatusAge.Visible = false;
                    dgActs.Enabled = true;
                }
                if (cbAgegroup.Text == "Vuxen")
                {

                    agegroup = 2;
                    this.dgActs.Columns[3].ReadOnly = false;
                    lblStatusAge.Visible = false;
                    dgActs.Enabled = true;
                }
                if (cbAgegroup.Text == "Åldersgrupp")
                {
                    agegroup = 4;
                    MessageBox.Show("Välj åldersgrupp för biljetten");
                    this.dgActs.Columns[3].ReadOnly = true;
                    //dgActs.Enabled = false;
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


      
        private void create_summary()
        {
            int numberOfacts = 0;
            double priceid = 0;
            label31.Text = "";
            label37.Text = showname;
            int countT = dtPersons.Rows.Count;
            label38.Text = countT.ToString();
            double price = 0;


            foreach (DataRow r in cSeats.Rows)
            {
                label31.Text += r[7].ToString() + ": " + r[2].ToString() + r[3].ToString() + "\r\n";
            }
            foreach(DataRow rw in dtPersons.Rows)
            {
                int id = int.Parse(rw[0].ToString());
                int nroact = int.Parse(rw[3].ToString());

                foreach(DataRow rows in cSeats.Rows)
                {
                    int id2 = int.Parse(rows[0].ToString());
                    int age = int.Parse(rows[4].ToString());
                    if(id == id2 && Convert.ToBoolean(rows[6].ToString()) == false)
                    {
                        if(age == 0)
                        price += childS;
                        if (age == 1)
                        price += youthS;
                        if (age == 2)
                         price += adultS;
                    }
                    else if (id == id2 && Convert.ToBoolean(rows[6].ToString()) == true)
                    {
                        if (age == 0)
                            price += child;
                        if (age == 1)
                            price += youth;
                        if (age == 2)
                            price += adult;
                    }
                }


            }
            label39.Text = price.ToString();


        }
      
        
        public void SendMail()
        {

            

        }
       
        

                }
                    #endregion
    }



