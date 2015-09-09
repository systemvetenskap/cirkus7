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
        private int staffid;
        private string staffUserId;
        private string staffFname;
        private string staffLname;

        public int abc, cde;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
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
            AddCustomerForm custForm = new AddCustomerForm();

                }

            listBoxCustomer.Items.Clear();
            listBoxTicket.Items.Clear();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonSkapaForestalnning_Click(object sender, EventArgs e)
        {
            ShowForm showForm = new ShowForm();
            showForm.ShowDialog();
        }

        private void listForestallning()
        {
            conn.Open();
            sql = "select date, name from show order by date";
            dt = new DataTable();
            da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(dt);
            conn.Close();

            allShowsList = new List<show>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                show curS = new show();
                curS.name = dt.Rows[i][0].ToString();
                curS.date = dt.Rows[i][1].ToString();
                allShowsList.Add(curS);
            }

        }

        public void refreshForestallningslist()
        {
            listBoxForestallningar.Items.Clear();
            listForestallning();
            listBoxForestallningar.DataSource = allShowsList;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Lista alla Föreställningar i tab 2 .
            listForestallning();
            listBoxForestallningar.DataSource = allShowsList; 
        }
    }
}
