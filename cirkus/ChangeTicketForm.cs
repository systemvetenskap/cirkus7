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
        int bookingid;

       
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

            string sql = "UPDATE booking SET reserved_to = @toDate WHERE bookingid = @bookingid";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@toDate", toDate);
            cmd.Parameters.AddWithValue("@bookingid", bookingid);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            btnChangeTicket.Enabled = true;
            btnSave.Enabled = false;
            dtpTicketTo.Enabled = false;
            this.Close();
            
        }

        private void btnChangeTicket_Click(object sender, EventArgs e)
        {
            dtpTicketTo.Enabled = true;
            btnSave.Enabled = true;
            btnChangeTicket.Enabled = false;
        }

        private void dgSelectedTicket(object sender, DataGridViewCellEventArgs e)
        {
            int selectedindex = dgSelectedCustomerTicket.SelectedRows[0].Index;
            bookingid = int.Parse(dgSelectedCustomerTicket[0, selectedindex].Value.ToString());
        }
    }
}
