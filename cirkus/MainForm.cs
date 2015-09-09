using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cirkus
{
    public partial class MainForm : Form
    {
        private string staffID;
        private string staffFname;
        private string staffLname;

        public MainForm(string adminAuthorization, string staffID, string staffFname, string staffLname)
        {
            InitializeComponent();
            
            if (adminAuthorization != "1")
            {
                tabControl1.TabPages.RemoveAt(2);
                tabControl1.TabPages.RemoveAt(1);
            }
            this.staffID = staffID;
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
            AddCustomerForm custForm = new AddCustomerForm(staffID);
            custForm.ShowDialog();

            listBoxCustomer.Items.Clear();
            listBoxTicket.Items.Clear();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}