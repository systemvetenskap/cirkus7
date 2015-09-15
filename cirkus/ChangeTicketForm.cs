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
    public partial class ChangeTicketForm : Form
    {

       
        public ChangeTicketForm(DataTable dt)
        {
            InitializeComponent();
            dgSelectedCustomerTicket.DataSource = dt;

            lblTodaysDate.Text = "Dagens datum: " + DateTime.Now.ToShortDateString();
        }


        private void btnSpara_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

            string toDate = dtpTicketTo.Text;
            int bookingid = dgSelectedCustomerTicket.SelectedRows[0].Index;

            string sql = "UPDATE booking SET reserved_to = toDate WHERE bookingid = '" + bookingid + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("reserved_to", toDate);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            btnChangeTicket.Enabled = true;
            btnSave.Enabled = false;
            dtpTicketTo.Enabled = false;
        }

        private void btnChangeTicket_Click(object sender, EventArgs e)
        {
            dtpTicketTo.Enabled = true;
            btnSave.Enabled = true;
            btnChangeTicket.Enabled = false;
        }
    }
}
