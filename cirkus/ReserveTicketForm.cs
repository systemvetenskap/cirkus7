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
    public partial class ReserveTicketForm : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        int showid, actid, seatid,agegroup, customerid;
        int totalChild, totalYouth, totalAdult, total, checkedseats, priceid;
        string show, act, bseats, selectedsection;
        DataTable section;
        DataTable selectedseats = new DataTable();

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
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewShows.DataSource = dt;

            this.dataGridViewShows.Columns[0].Visible = false;
            dataGridViewShows.Columns[1].Width = 149;
            dataGridViewShows.Columns[2].Width = 90;

            conn.Close();



            //loadActs();

        }
        private void loadActs()
        {

            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            lblshowid.Text = showid.ToString();
            conn.Open();
            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewActs.DataSource = dt;
            this.dataGridViewActs.Columns[0].Visible = false;
            dataGridViewActs.Columns[1].Width = 129;



          
            //dataGridViewActs.CurrentCell.Selected = false;
            conn.Close();

            loadSection();


        }
        private void loadSection()
        {

            //comboBoxSection.DataSource = null;
            //comboBoxSection.Items.Clear();

            try
            {

                int selectedIndex = dataGridViewActs.SelectedRows[0].Index;

                actid = int.Parse(dataGridViewActs[0, selectedIndex].Value.ToString());
                //string sql = @"select section, rownumber from seats inner join available_seats on seats.seatid = available_seats.seatid 
                //            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "' order by section, rownumber";
                lblactid.Text = actid.ToString();
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
                dgSeats.Columns[0].Width = 20;
                dgSeats.Columns[1].Width = 60;
                dgSeats.Columns[2].Width = 60;
                dgSeats.CurrentCell.Selected = false;
                conn.Close();

                load_Seats();

                
            }
            catch
            {
                

            }

            try
            {
                int selectedIndexSeat = dgSeats.SelectedRows[0].Index;

                seatid = int.Parse(dgSeats[0, selectedIndexSeat].Value.ToString());

                label11.Text = seatid.ToString();
            }
            catch
            {

            }
     
        }
        private void load_Seats()
        {
            conn.Open();
            

            string getSeatnr = @"select rownumber, section from seats inner join available_seats on seats.seatid = available_seats.seatid 
                                    inner join acts on available_seats.actid = acts.actid 
                                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                            where booked_seat_id is null and acts.actid = '" + actid + "' and seats.section = '" + selectedsection + "' order by rownumber ";



            NpgsqlDataAdapter da = new NpgsqlDataAdapter(getSeatnr, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

          
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
            conn.Close();
            loadActs();
            create_summary();

        }

        private void ReserveTicketForm_Load(object sender, EventArgs e)
        {
            clearSelect();
            listCustomers();
            txtenamn.Enabled = false;
            txtepost.Enabled = false;
            txtfnamn.Enabled = false;
            txttel.Enabled = false;
            selectedseats.Columns.Add("seatid");
            selectedseats.Columns.Add("section");
            selectedseats.Columns.Add("rownumber");
            selectedseats.Columns.Add("priceid");
            dgBseats.DataSource = selectedseats;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            foreach (DataRow row in selectedseats.Rows)
            {
                string seatid = row[0].ToString();
                string priceid = row[3].ToString();
                conn.Open();
                string sql = "insert into booked_seats(available_seats_id,priceid) values(:sid, :pid)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.Add(new NpgsqlParameter("sid", seatid));
                cmd.Parameters.Add(new NpgsqlParameter("pid", priceid));

                cmd.ExecuteNonQuery();

                conn.Close();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
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

                txtenamn.Enabled = true;
                txtepost.Enabled = true;
                txtfnamn.Enabled = true;
                txttel.Enabled = true;

            }
            if (checkBox2.Checked == false)
            {
                dgCustom.BackgroundColor = Color.White;


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

            label11.Text = seatid.ToString();
        }

        private void btnAddSeats_Click(object sender, EventArgs e)
        {
            switch (agegroup)
            {
                case 1:
                    priceid = 1;
                    MessageBox.Show("True");
                    int s = priceid;
                    
                    
                    break;
                case 2:
                    priceid = 3;
                    break;
                case 3:
                    priceid = 4;
                    break;
            }
            if (checkedseats < total)
            {
                foreach (DataGridViewRow r in dgSeats.SelectedRows)
                {
                    DataGridViewRow t = (DataGridViewRow)r.Clone();
                    t.Cells[0].Value = r.Cells[2].Value;
                    t.Cells[1].Value = r.Cells[1].Value;
                    t.Cells[2].Value = r.Cells[0].Value;

                 

                    selectedseats.Rows.Add(r.Cells[0].Value, r.Cells[1].Value, r.Cells[2].Value, priceid);
                   
                    this.dgBseats.Columns[0].Visible = false;

                    dgBseats.Columns[1].Width = 60;
                    dgBseats.Columns[2].Width = 60;
                    dgBseats.Columns[3].Width = 20;
                    
                    DataRow[] rows = section.Select("seatid ='" + seatid + "'");
                    foreach (DataRow rw in rows)
                        rw.Delete();
                    checkedseats++;
                    reload_datable();
                }
                
            }

        }

        private void btnRemSeats_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selected_customer(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgCustom.SelectedRows[0].Index;

            customerid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            lblcustid.Text = customerid.ToString();
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

            }
        }

        private void dataGridViewActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Close();
            loadSection();
            create_summary();

        }
        private void seat_sectionchanged(object sender, EventArgs e)
        {
            conn.Close();
            //load_Seats();
        }



        private void added_youth(object sender, EventArgs e)
        {
            totalYouth = Convert.ToInt16(numericYouth.Value);
            calculate_people();
        }

        private void added_adult(object sender, EventArgs e)
        {
            totalAdult = Convert.ToInt16(numericAdult.Value);
            calculate_people();
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
            totalChild = Convert.ToInt16(numericChild.Value);
            calculate_people();
        }





        public void calculate_people()
        {
            total = totalChild + totalYouth + totalAdult;
            
  
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

                label11.Text = seatid.ToString();

            }
            catch
            {

            }
       

           


        }


    }
}
