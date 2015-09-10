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
        int showid, actid;
        int totalChild, totalYouth, totalAdult, total, checkedseats, price;
        string show, act, bseats, selectedsection;
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
            conn.Open();
            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewActs.DataSource = dt;
            this.dataGridViewActs.Columns[0].Visible = false;
            dataGridViewActs.Columns[1].Width = 129;

           

            dataGridViewActs.Rows[0].Selected = true;
            conn.Close();

            loadSection();


        }
        private void loadSection()
        {

            comboBoxSection.DataSource = null;
            comboBoxSection.Items.Clear();

            try
            {

                int selectedIndex = dataGridViewActs.SelectedRows[0].Index;

                actid = int.Parse(dataGridViewActs[0, selectedIndex].Value.ToString());
                string sql = @"select distinct section from seats inner join available_seats on seats.seatid = available_seats.seatid 
                            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "' order by section";

                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBoxSection.DataSource = dt;
                comboBoxSection.DisplayMember = "section";

                string s = comboBoxSection.Text.ToString();
                selectedsection = s;
                

                comboBoxSection.SelectedIndex = 0;

                conn.Close();

                load_Seats();
            }
            catch
            {
                comboBoxSection.DataSource = null;
                comboBoxSection.Items.Clear();

            }

        }
        private void load_Seats()
        {
            conn.Open();
            selectedsection = comboBoxSection.Text.ToString();
            
            string getSeatnr = @"select rownumber, section from seats inner join available_seats on seats.seatid = available_seats.seatid 
                                    inner join acts on available_seats.actid = acts.actid 
                                        left join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                            where booked_seat_id is null and acts.actid = '" + actid + "' and seats.section = '"+selectedsection+"' order by rownumber ";



            NpgsqlDataAdapter da = new NpgsqlDataAdapter(getSeatnr, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            checkedListBoxSeats.DataSource = dt;
            checkedListBoxSeats.DisplayMember = "rownumber";
            conn.Close();
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (this.dgCustom.DataSource != null)
                {
                    this.dgCustom.DataSource = null;
                }
                else
                {
                  this.dgCustom.Rows.Clear();
                   dgCustom.BackgroundColor = Color.Gray;
                    dgCustom.ForeColor = Color.Gray;
                }

                txtenamn.Enabled = true;
                txtepost.Enabled = true;
                txtfnamn.Enabled = true;
                txttel.Enabled = true;

            }
            else if (checkBox2.Checked == false)
            {
                dgCustom.BackgroundColor = Color.White;
                dgCustom.ForeColor = Color.White;
                
                dgCustom.Visible = true;
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

        private void dataGridViewActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Close();
            loadSection();
            create_summary();
          
        }
        private void seat_sectionchanged(object sender, EventArgs e)
        {
            conn.Close();
            load_Seats();
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
            if (items.CheckedItems.Count > total)
            {
                e.NewValue = CheckState.Unchecked;
            }
            if (e.CurrentValue == CheckState.Unchecked)
            {
                checkedseats++;
                calculate_people();
            }
            else if(e.CurrentValue == CheckState.Checked)
            {
                checkedseats--;
                calculate_people();

            }
         
        }

        private void added_child(object sender, EventArgs e)
        {
            totalChild = Convert.ToInt16(numericChild.Value);
            calculate_people();
        }

      


      
        public void calculate_people()
        {
           total = totalChild + totalYouth + totalAdult;
 
            if(checkedseats == total)
            {
                checkedListBoxSeats.SelectionMode = SelectionMode.None;
            }
        }
       
        private void create_summary()
        {
            try
            {
              
                int selectedshow = dataGridViewShows.SelectedCells[0].RowIndex;
                DataGridViewRow selectedShow= dataGridViewShows.Rows[selectedshow];
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


    }
}
