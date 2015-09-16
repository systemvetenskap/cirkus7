﻿using System;
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

namespace cirkus
{
    public partial class ReserveTicketForm : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        int showid, actid, fillMode ,seatid,agegroup, customerid, total, checkedseats, priceid, freeSseats, freeLseats, tickets, ticketid;      
        string show, act, bseats, selectedsection;
        bool newcust;
        bool seatType = true; 
        DataTable shows,section,dtfSeats;
        DataTable seats = new DataTable();
        DataTable chosenacts = new DataTable();
        DataTable selectedseats = new DataTable();
        DataTable acts = new DataTable();
        DataRow row;
        BindingSource filterseats = new BindingSource();
        BindingSource filterBseats = new BindingSource();
        BindingSource filterActs = new BindingSource();
        BindingSource filterSacts = new BindingSource();
        NpgsqlCommand cmd;

        public ReserveTicketForm()
        {
            InitializeComponent();
            loadShows();

        }
        public void loadShows()
        {
            string sql = "select show.showid, show.name, show.date from show";
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            shows = new DataTable();
            da.Fill(shows);

            dataGridViewShows.DataSource = shows;

            this.dataGridViewShows.Columns[0].Visible = false;
            dataGridViewShows.Columns[1].Width = 149;
            dataGridViewShows.Columns[2].Width = 90;

            conn.Close();

            

            //loadActs();

        }
        private void loadActs()
        {
            filterActs.DataSource = acts;
            filterActs.Filter = string.Format("ticketid = '{0}'", comboTicketnr.SelectedItem.ToString());
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;
            filterSacts.DataSource = chosenacts;
            filterSacts.Filter = string.Format("ticketid = '{0}'", comboTicketnr.SelectedItem.ToString());

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            lblshowid.Text = showid.ToString();
            
            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            if (acts.Rows.Count > 0)
            {
                for (int row = 0; row < acts.Rows.Count; row++)
                {
                    DataRow rows = acts.Rows[row];
                    if (rows.RowState != DataRowState.Deleted)
                    {
                        object id = rows[0];
                        object id2 = comboTicketnr.SelectedItem.ToString();
                        string a = comboTicketnr.SelectedItem.ToString();
                        string b = rows[0].ToString();
                        lbltest.Text = a;
                        lbltest2.Text = ticketid.ToString();

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
                            object value4 = comboTicketnr.SelectedItem.ToString();

                            if (value3 == DBNull.Value)
                            {
                                drw[0] = int.Parse(comboTicketnr.SelectedItem.ToString());

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
                            object value4 = comboTicketnr.SelectedItem.ToString();

                            if (value3 == DBNull.Value)
                            {
                                drw[0] = int.Parse(comboTicketnr.SelectedItem.ToString());

                            }
                        }



                    }
                    break;
            }



                dataGridViewActs.DataSource = acts;
                this.dataGridViewActs.Columns[0].Visible = false;
                this.dataGridViewActs.Columns[1].Visible = false;
                dataGridViewActs.Columns[1].Width = 129;
                dataGridViewActs.ClearSelection();



            //dataGridViewActs.CurrentCell.Selected = false;

            dgTestActs.DataSource = acts;




        }
        private void loadSection()
        {

            //comboBoxSection.DataSource = null;
            //comboBoxSection.Items.Clear();

            try
            {

                int selectedIndex = dataGridViewActs.SelectedRows[0].Index;

                actid = int.Parse(dataGridViewActs[1, selectedIndex].Value.ToString());
                //string sql = @"select section, rownumber from seats inner join available_seats on seats.seatid = available_seats.seatid 
                //            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "' order by section, rownumber";
                lbltest.Text = actid.ToString();
                string sqlSearch = textBoxSeats.Text;
                string sql3 = @"select available_seats.available_seats_id as seatid, seats.section, seats.rownumber from seats 
                                inner join available_seats on seats.seatid = available_seats.seatid
                                left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                inner join acts on available_seats.actid = acts.actid  
                                where acts.actid = '" + actid + "' and LOWER(section)LIKE LOWER('%" + sqlSearch + "%') and booked_seats.booked_seat_id is null  order by section, rownumber";


                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql3, conn);

                section = new DataTable();

                da.Fill(section);

                //comboBoxSection.DataSource = dt;
                //comboBoxSection.DisplayMember = "section";

                //string s = comboBoxSection.Text.ToString();
                //selectedsection = s;


                //comboBoxSection.SelectedIndex = 0;

                dgSeats.DataSource = section;
                //this.dgSeats.Columns[0].Visible = false;
                //dgSeats.Columns[1].Width = 60;
                //dgSeats.Columns[2].Width = 60;
                //dgSeats.CurrentCell.Selected = false;
                conn.Close();

                dgTestActs.DataSource = section;

                //load_Seats();

                
            }
            catch
            {
                

            }

            try
            {
                int selectedIndexSeat = dgSeats.SelectedRows[0].Index;

                seatid = int.Parse(dgSeats[0, selectedIndexSeat].Value.ToString());

                //label11.Text = seatid.ToString();
            }
            catch
            {

            }
     
        }
        private void load_Seats()
        {
            conn.Close();
            conn.Open();
            

            string getSeatnr = @"select available_seats.available_seats_id as seatid, acts.actid, section, rownumber from seats inner join available_seats on seats.seatid = available_seats.seatid 
                                    inner join acts on available_seats.actid = acts.actid
                                    inner join show on acts.showid = show.showid
                                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                            where booked_seat_id is null and show.showid = '" + showid+"' order by rownumber ";



            NpgsqlDataAdapter da = new NpgsqlDataAdapter(getSeatnr, conn);
            

            da.Fill(seats);

            //dgSeats.DataSource = seats;
            dgTestActs.DataSource = seats;
            dataGridViewActs.ClearSelection();
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
            lblNoShow.Visible = false;
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());
            load_Seats();
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
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (total > 0 && string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                tickets = Convert.ToInt16(txtBoxNrP.Text);
                for (int i = 1; i <= tickets; i++)
                {
                    comboTicketnr.Items.Add(i);
                }
                comboTicketnr.Text = "1";
                

            }
            else {
                lblTotalError.Visible = true;
                lblTotalError.Text = "Vänligen ange antal personer";
                lblTotalError.ForeColor = Color.Tomato;
                txtBoxNrP.BackColor = Color.Tomato;
                lblA.Text = "";
                lblB.Text = "";
       
            }
            if (dataGridViewShows.SelectedRows.Count == 0)
            {
                lblNoShow.Visible = true;
                lblNoShow.Text = "Välj en föreställning";
                lblNoShow.ForeColor = Color.Tomato;
                dataGridViewShows.BackColor = Color.Tomato;
               

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel2.Visible = true;

   

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (newcust == true)
            {
                string fn = txtfnamn.Text;
                string ln = txtenamn.Text;
                string pn = txttel.Text;
                string em = txtepost.Text;
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
            if (newcust == false)
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

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadSection();

        }

        private void selected_seat(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgSeats.SelectedRows[0].Index;

            seatid = int.Parse(dgSeats[0, selectedIndex].Value.ToString());

            //label11.Text = seatid.ToString();
        }

        private void btnAddSeats_Click(object sender, EventArgs e)
        {
     
            if (checkedseats < total)
            {
               
                    foreach (DataGridViewRow r in dgSeats.SelectedRows)
                    {
                        DataGridViewRow t = (DataGridViewRow)r.Clone();
                        t.Cells[0].Value = r.Cells[0].Value;
                        t.Cells[1].Value = r.Cells[1].Value;
                        t.Cells[2].Value = r.Cells[2].Value;
                        t.Cells[3].Value = r.Cells[3].Value;
                    

                    row = selectedseats.NewRow();
                    row[0] = r.Cells[0].Value;
                    row[1] = r.Cells[1].Value;
                    row[2] = r.Cells[2].Value;
                    row[3] = r.Cells[3].Value;
                    row[4] = ticketid;
                    row[5] =  priceid;
                    selectedseats.Rows.Add(row);

                    filterseats.RemoveAt(dgSeats.CurrentCell.RowIndex);

                    dgTestActs.DataSource = selectedseats;
                    dgBseats.DataSource = selectedseats;
                        

                      }


               
   
                
            }

        }

        private void btnRemSeats_Click(object sender, EventArgs e)
        {

        }

        private void dgActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgActs.SelectedRows[0].Index;

            actid = int.Parse(dgActs[1, selectedIndex].Value.ToString());

            dgSeats.DataSource = seats;
            filterseats.DataSource = seats;
            filterseats.Filter = string.Format("actid = '{0}'", actid);
            filterBseats.DataSource = selectedseats;
            filterBseats.Filter = string.Format("actid = '{0}'", actid);
            dgSeats.Columns[0].Visible = false;
            dgSeats.Columns[1].Visible = false;
            ///dgBseats.Columns[1].Visible = false;
            /*dgSeats.DataSource = seats;
           

            dgBseats.DataSource = selectedseats;
          

        
            dgSeats.ClearSelection();
            dgBseats.ClearSelection();*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switch (agegroup)
            {
                case 0:
                    MessageBox.Show("Välj åldersgrupp");
                    return;

                case 1:
                    priceid = 1;

                    


                    break;
                case 2:
                    priceid = 3;
                    break;
                case 3:
                    priceid = 4;
                    break;
            }
            foreach (DataGridViewRow r in dataGridViewActs.SelectedRows)
            {
                DataGridViewRow t = (DataGridViewRow)r.Clone();
                t.Cells[0].Value = r.Cells[0].Value;
                t.Cells[1].Value = r.Cells[1].Value;
                t.Cells[2].Value = r.Cells[2].Value;

                row = chosenacts.NewRow();
                row[0] = r.Cells[0].Value;
                row[1] = r.Cells[1].Value;
                row[2] = r.Cells[2].Value;
                row[3] = priceid;
                chosenacts.Rows.Add(row);





                dgActs.DataSource = chosenacts;
                filterActs.RemoveAt(dataGridViewActs.SelectedRows[0].Index);
                dgActs.Columns[0].Visible = false;
                dgActs.Columns[1].Visible = false;


                //DataRow[] rows = section.Select("actid ='" + actid + "'");
                //foreach (DataRow rw in rows)
                //rw.Delete();
                //dataGridViewActs.Rows.Remove(dataGridViewActs.SelectedRows[0]);
                dgActs.ClearSelection();
                dataGridViewActs.ClearSelection();
                //dgSeats.DataSource = seats;
                //reload_datable();
                //dgTestActs.DataSource = chosenacts;
                //load_Seats();

            }
        }

        private void txtBoxNrP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxNrP.Text) == false)
            {
                total = Convert.ToInt16(txtBoxNrP.Text);
                countSeats();
            }
            else
            {
                lblA.Text = "";
                lblB.Text = "";
            }
            
           
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void txtBoxNrP_Click(object sender, EventArgs e)
        {

            txtBoxNrP.BackColor = Color.White;
            lblTotalError.Visible = false;
        }

        private void comboTicketnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cboIndex = comboTicketnr.SelectedIndex;
            ticketid = int.Parse(this.comboTicketnr.Items[cboIndex].ToString());
            lbltest.Text = ticketid.ToString();
            loadActs();
            countSeats();
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

            lblcustid.Text = customerid.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            createBooking();
            
        }

        private void cbAgegroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAgegroup.Text == "Barn")
            {
                agegroup = 1;
                
            }
            if (cbAgegroup.Text == "Ungdom")
            {
                agegroup = 2;
                
            }
            if (cbAgegroup.Text == "Vuxen")
            {

                agegroup = 3;
               
            }
            if (cbAgegroup.Text == "Åldersgrupp")
            {
                MessageBox.Show("Välj ålersgrupp för biljetten");
                return;
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
                           inner join show on acts.showid = show.showid where show.showid = '"+showid+"'";
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
                    where show.showid = '" + showid +"' group by show.seat_number";
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
        private void reload_datable()
        {
            dgSeats.DataSource = null;
            dgSeats.DataSource = section;
            this.dgSeats.Columns[0].Visible = false;
            dgSeats.Columns[1].Width = 60;
            dgSeats.Columns[2].Width = 60;
            //this.dgSeats.CurrentCell = this.dgSeats[1, 0];

            try
            {

                int selectedIndex = dgSeats.SelectedRows[0].Index;

                seatid = int.Parse(dgSeats[0, selectedIndex].Value.ToString());

                //label11.Text = seatid.ToString();

            }
            catch
            {

            }
       

           


        }
        private void createBooking()
        {
            string sql;
            int custid = customerid;
            int shid = showid;
            
            

                foreach (DataRow row in selectedseats.Rows)
                {
                    int seatid = int.Parse(row[1].ToString());
                    string actid = row[2].ToString();
                    int priceid = int.Parse(row[5].ToString());
                    lblSeatid.Text = row[1].ToString();
                    lblAct.Text = row[2].ToString();
                    lblPris.Text = row[1].ToString();

                    /*conn.Open();
                    sql = "insert into booking(customerid,showid) values(:cid,:shid)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("cid", custid));
                    cmd.Parameters.Add(new NpgsqlParameter("shid", shid));


                    cmd.ExecuteNonQuery();
                   

                    
                    cmd = new NpgsqlCommand("select currval('booking_bookingid_seq');", conn);
                    NpgsqlDataReader read;
                    read = cmd.ExecuteReader();

                    read.Read();
                    int addedbookingid = int.Parse(read[0].ToString());
                    conn.Close();
                   
                    conn.Open();
                    sql = "insert into booked_seats(available_seats_id, bookingid, priceid ) values(:sid, :bid, :pid)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("sid", seatid));                  
                    cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                    cmd.Parameters.Add(new NpgsqlParameter("pid", priceid));

                    cmd.ExecuteNonQuery();
                    

                    cmd = new NpgsqlCommand("select currval('booked_seats_booked_seat_id_seq');", conn);
                    
                    read = cmd.ExecuteReader();

                    read.Read();
                    int addedbookedseat = int.Parse(read[0].ToString());
                    conn.Close();

                    conn.Open();
                    sql = "insert into ticket(bookingid, booked_seat_id, actid ) values(:bid, :boid, :pid)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.Add(new NpgsqlParameter("bid", addedbookingid));
                    cmd.Parameters.Add(new NpgsqlParameter("boid", addedbookedseat));
                    cmd.Parameters.Add(new NpgsqlParameter("pid",actid));

                    cmd.ExecuteNonQuery();
                    conn.Close();*/

            }


            MessageBox.Show("Bokning utförd");



        }
        private void countSeats()
        {
            if (dataGridViewShows.SelectedRows.Count > 0)
            {
                try
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

                    /*conn.Open();
                    sql = @"select acts.free_placement - count(booked_standing) as diff  from acts
                                inner join booked_standing on acts.actid = booked_standing.actid
                                inner join show on acts.showid = show.showid
                                where show.showid = '"+showid+"' group by acts.free_placement";
                    cmd = new NpgsqlCommand(sql, conn);

                    read = cmd.ExecuteReader();

                    read.Read();
                    freeSseats = int.Parse(read[0].ToString());*/
                    conn.Close();
                 
                    if (freeLseats < total && total > 0)
                    {
                        lblA.Visible = true;
                        lblA.Text = "Antal personer överstiger antal lediga sittplatser";
                        lblA.ForeColor = Color.Tomato;                       

                    }
                    else if(freeLseats >= total && total > 0)
                    {
                        lblA.Visible = true;
                        lblA.Text = "Lediga sittplatser";
                        lblA.ForeColor = Color.Green;
                    }

                    /*if (freeSseats < total && total > 0 )
                    {
                        lblB.Visible = true;
                        lblB.Text = "Antal personer överstiger antal lediga ståplatser";
                        lblB.ForeColor = Color.Tomato;

                    }*/
                    else if(freeSseats >= total && total > 0)
                    {
                        lblB.Visible = true;
                        lblB.Text = "Lediga ståplatser";
                        lblB.ForeColor = Color.Green;
                    }

                }
                catch 
                {
                    

                }


            }

        }

    }
}
