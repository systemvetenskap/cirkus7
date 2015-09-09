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
        public ReserveTicketForm()
        {
            InitializeComponent();
            string sql = "select show.showid, show.name, show.date from show";
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewShows.DataSource = dt;

            

           
            
            conn.Close();
        }

        private void dataGridViewShows_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

            conn.Open();
            string sql = "select acts.name from acts where showid = '"+ +'"';

            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            
            DataTable dt = new DataTable();

            da.Fill(dt);
        }
    }
}
