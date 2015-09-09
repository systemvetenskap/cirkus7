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
        int showid;
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

        private void dataGridViewShows_SelectionChanged(object sender, EventArgs e)
        {
         


        }



        private void rowselection_changed(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridViewShows.SelectedRows[0].Index;

            showid = int.Parse(dataGridViewShows[0, selectedIndex].Value.ToString());

            string sql = "select acts.name, acts.actnumber from acts where showid = '" + showid + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridViewActs.DataSource = dt;
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
    }
}
