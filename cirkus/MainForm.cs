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
    public partial class MainForm : Form
    {
        private string staffUserId;
        private string staffFname;
        private string staffLname;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        private void listCustomers()
        {
            string sql = "SELECT lname, fname, customerid FROM customer;";
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgCustomers.DataSource = dt;
            //DataGridViewColumn column = dgCustomers.Columns[0];
            //DataGridViewColumn column1 = dgCustomers.Columns[1];
            //DataGridViewColumn column2 = dgCustomers.Columns[2];
            ////this.dgCustomers.Columns[0].Visible = false;
            //column.Width = 60;
            //column1.Width = 60;
            //column2.Width = 80;

            conn.Close();
        }

        private void listTickets()
        {
            
        }

        public MainForm(string adminAuthorization, string staffUserID, string staffFname, string staffLname)
        {
            InitializeComponent();
            
            if (adminAuthorization != "1")
            {
                tabControl1.TabPages.RemoveAt(2);
                tabControl1.TabPages.RemoveAt(1);
            }
            this.staffUserId = staffUserID;
            this.staffLname = staffLname;
            this.staffFname = staffFname;

            labelStaffName.Text = staffFname + " " + staffLname;
        }

        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm(staffUserId);
            custForm.ShowDialog();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curTab = tabControl1.SelectedIndex;

            switch (curTab)
            {
                default:
                    //Sälja biljetter tabben.
                    listCustomers();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}