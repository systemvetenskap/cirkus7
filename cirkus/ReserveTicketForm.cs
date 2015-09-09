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
            string sql = "select show.showid, show.name, show.date from show";
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            
            dataGridViewShows.DataSource = dt;


            this.dataGridViewShows.Columns[0].Visible = false;
            dataGridViewShows.Columns[1].Width = 120;
            dataGridViewShows.Columns[2].Width = 90;

            conn.Close();
        }

        private void rowselection_changed(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            string sql = "select acts.actid, acts.name from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewActs.DataSource = dt;
            this.dataGridViewActs.Columns[0].Visible = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ReserveTicketForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void selection_actChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridViewActs.SelectedRows[0].Index;

            actid = int.Parse(dataGridViewActs[0, selectedIndex].Value.ToString());
            string sql = @"select acts.actid, seats.section, seats.rownumber from seats inner join available_seats on seats.seatid = available_seats.seatid 
                            inner join acts on available_seats.actid = acts.actid where acts.actid = '" + actid + "'";
            

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewSeats.DataSource = dt;
            this.dataGridViewSeats.Columns[0].Visible = false;
        }
    }
}
