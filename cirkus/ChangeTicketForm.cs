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
    public partial class ChangeTicketForm : Form
    {
        public ChangeTicketForm(DataTable dt)
        {
            InitializeComponent();
            dgSelectedCustomerTicket.DataSource = dt;
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {

        }
    }
}
