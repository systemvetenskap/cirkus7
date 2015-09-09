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
        public ReserveTicketForm()
        {
            InitializeComponent();
            loadShows();
        }

        private void rowselection_changed(object sender, DataGridViewCellEventArgs e)
        {
            loadActs();

        }

        private void dataGridViewActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            loadSection();
          
        }
        private void loadSection()
        {
            try
            {
                comboBoxSection.Items.Clear();
                int selectedIndex = dataGridViewActs.SelectedRows[0].Index;

                actid = int.Parse(dataGridViewActs[0, selectedIndex].Value.ToString());
                string sql = @"select distinct section from seats inner join available_seats on seats.seatid = available_seats.seatid 
                            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "'";


                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBoxSection.DataSource = dt;
                comboBoxSection.DisplayMember = "section";
            }
            catch
            {
                comboBoxSection.DataSource = null;

            }


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


        }

        private void seat_sectionchanged(object sender, EventArgs e)
        {
            string getSeatnr = @"select rownumber from seats inner join available_seats on seats.seatid = available_seats.seatid 
                            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(getSeatnr, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            checkedListBoxSeats.DataSource = dt;
            checkedListBoxSeats.DisplayMember = "rownumber";
            
           
        }

        private void loadActs()
        {
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewActs.DataSource = dt;
            this.dataGridViewActs.Columns[0].Visible = false;
            dataGridViewActs.Columns[1].Width = 129;
            loadSection();

        }


    }
}
