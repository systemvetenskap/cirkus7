using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;

namespace cirkus
{
    public partial class MainForm : Form
    {
        #region Variables
        private int staffid;
        private int showid;
        private int actid;
        private string staffUserId;
        private string staffFname;
        private string staffLname;
        private string show_name;
        private string show_date;
        private string akt_name;
        private string akttider = "";
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        private string sql = "";
        public DataTable dt = new DataTable();
        private NpgsqlDataAdapter da;
        private List<show> allShowsList;
        private int CustomerID;
        DataTable dtActs = new DataTable();

        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);
        public void HideCaret()
        {
            HideCaret(textBoxPrintBookingid.Handle);
            HideCaret(txtPrintDatum.Handle);
            HideCaret(textBoxPrintShow.Handle);
            HideCaret(textBoxPrintAct.Handle);
            HideCaret(textBoxPrintAge.Handle);
            HideCaret(textBoxPrintPrice.Handle);

            HideCaret(textBoxAntalVuxenBiljetter.Handle);
            HideCaret(textBoxAntalUngdomsbiljetter.Handle);
            HideCaret(textBoxAntalBarnbiljetter.Handle);
            HideCaret(textBoxTotaltAntal.Handle);
            HideCaret(textBoxKronorVuxenbiljetter.Handle);
            HideCaret(textBoxKronorUngdomsbiljetter.Handle);
            HideCaret(textBoxKronorBarnbiljetter.Handle);
            HideCaret(textBoxTotaltKronor.Handle);

        }

        #endregion
        #region Main
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curTab = tabControl1.SelectedIndex;

            switch (curTab)
            {
                default:
                    //Biljettförsäljning
                    listCustomers();
                    break;
                case 1:
                    //Föreställning
                    LoadShows();
                    LoadAkter();
                    LoadStatistics();
                    break;
                case 2:
                    //Konto
                    ListaPersonal();
                    break;
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public MainForm(string adminAuthorization, string staffFname, string staffLname, string staffUserID)
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

            if (adminAuthorization=="1")
            {
                adminAuthorization = "administratör";
            }
            else if (adminAuthorization=="0")
            {
                adminAuthorization = "biljettförsäljare";
            }

            labelStaffName.Text = "Du är inloggad som: "+ staffFname + " " + staffLname+", " + adminAuthorization;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            listCustomers();
        }
        #region HideCaret i textboxar
        private void textBoxPrintBookingid_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void txtPrintDatum_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxPrintShow_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxPrintAct_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxPrintAge_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxPrintPrice_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxAntalVuxenBiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxAntalUngdomsbiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxAntalBarnbiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxTotaltAntal_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxKronorVuxenbiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxKronorUngdomsbiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxKronorBarnbiljetter_Click(object sender, EventArgs e)
        {
            HideCaret();
        }

        private void textBoxTotaltKronor_Click(object sender, EventArgs e)
        {
            HideCaret();
        }
        #endregion

        #endregion
        #region Biljettförsäljning
        private void textBoxSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            listCustomers();
        }
        private void EmptyTextboxesTab1()
        {
            textBoxPrintShow.Clear();
            textBoxPrintBookingid.Clear();
            textBoxPrintPrice.Clear();
            textBoxPrintAct.Clear();
            textBoxPrintAge.Clear();
            akttider = "";
        }
        private void dgTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmptyTextboxesTab1();
            btnDeleteTicket.Text = "Radera vald biljett";

            int selectedindex = dgTickets.SelectedRows[0].Index;
            int bookingid = int.Parse(dgTickets[0, selectedindex].Value.ToString());

            string sql = @"select booked_seats.booked_seat_id, acts.name, seats.section, seats.rownumber, acts.start_time, acts.end_time from acts
                        inner join available_seats on acts.actid = available_seats.actid
                        inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                        inner join seats on available_seats.seatid = seats.seatid
                        where booked_seats.bookingid = '" + bookingid + "'order by acts.actid";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            dtActs = new DataTable();
            da.Fill(dtActs);

            dgTicketActs.DataSource = dtActs;

            dgTicketActs.Columns[0].HeaderText = "Boknings ID";
            dgTicketActs.Columns[1].HeaderText = "Akt";
            dgTicketActs.Columns[2].HeaderText = "Sektion";
            dgTicketActs.Columns[3].HeaderText = "Sittplats";
            dgTicketActs.Columns[4].HeaderText = "Starttid";
            dgTicketActs.Columns[5].HeaderText = "Sluttid";

            dgTicketActs.Columns[0].Width = 90;


            textBoxPrintBookingid.Text = dgTickets[0, selectedindex].Value.ToString();
            txtPrintDatum.Text = DateTime.Parse(dgTickets[1, selectedindex].Value.ToString()).ToShortDateString();
            textBoxPrintShow.Text = dgTickets[2, selectedindex].Value.ToString();
            textBoxPrintAge.Text = dgTickets[4, selectedindex].Value.ToString();
            textBoxPrintPrice.Text = dgTickets[5, selectedindex].Value.ToString();
          
            
        
            foreach(DataRow r in dtActs.Rows)
            {
                textBoxPrintAct.Text += r[1].ToString()+ ": "+ r[2].ToString() + r[3].ToString()+", "; 
                akttider += r[1].ToString() + ": " + r[4].ToString() + "-" + r[5].ToString() + "\n";

            }

            dgTicketActs.ClearSelection();

        }

        private void dgTicketActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteTicket.Text = "Radera vald akt";
            dgTickets.ClearSelection();
        }
        private void textBoxSearchTicket_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSearchTicket.Text))
            {
                dgTickets.DataSource = null;
                dgTicketActs.DataSource = null;
                dgCustomers.DataSource = null;
                listCustomers();
                listTickets();
            }
            else
            {
                dgTicketActs.DataSource = null;
                string sql = @"select distinct booking.bookingid, show.date, show.name, booking.paid, price_group_seat.group, sum(price_group_seat.price), booking.reserved_to from booking
                            inner join customer on booking.customerid = customer.customerid
                            inner join booked_seats on booking.bookingid = booked_seats.bookingid 
                            inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid 
                            inner join show on booking.showid = show.showid 
                            where booking.bookingid = '"+textBoxSearchTicket.Text+ "' group by booking.bookingid, show.date, show.name, booking.paid, price_group_seat.group, price_group_seat.price, booking.reserved_to";

                string sql2 = @"select customer.fname, customer.lname, customer.customerid from customer
                                    inner join booking on customer.customerid = booking.customerid
                                    where booking.bookingid = '" + textBoxSearchTicket.Text + "'";
                NpgsqlDataAdapter cmd = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
             
                cmd.Fill(dt);

                cmd = new NpgsqlDataAdapter(sql2, conn);
                DataTable dt2 = new DataTable();
                cmd.Fill(dt2);
                dgCustomers.DataSource = dt2;

                dgTickets.DataSource = dt;
                dgTickets.Columns[0].HeaderText = "Boknings ID";
                dgTickets.Columns[1].HeaderText = "Datum";
                dgTickets.Columns[2].HeaderText = "Föreställning";
                dgTickets.Columns[3].HeaderText = "Betald";
                dgTickets.Columns[4].HeaderText = "Åldersgrupp";
                dgTickets.Columns[5].HeaderText = "Pris";
                dgTickets.Columns[6].HeaderText = "Reserverad till";
            }

        }
        private void textBoxSearchTicket_Click(object sender, EventArgs e)
        {
            dgTicketActs.DataSource = null;
            dgTickets.DataSource = null;
        }
        private void printDocumentStatistic_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 18);
            System.Drawing.Font drawFontBold = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            System.Drawing.Font drawFontBoldAndUnderline = new System.Drawing.Font("Arial", 18, FontStyle.Bold | FontStyle.Underline);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            string AV, AU, AB, KV, KU, KB, TA, TK;

            AV = textBoxAntalVuxenBiljetter.Text;
            AU = textBoxAntalUngdomsbiljetter.Text;
            AB = textBoxAntalBarnbiljetter.Text;
            KV = textBoxKronorVuxenbiljetter.Text;
            KU = textBoxKronorUngdomsbiljetter.Text;
            KB = textBoxKronorBarnbiljetter.Text;
            TA = textBoxTotaltAntal.Text;
            TK = textBoxTotaltKronor.Text;

            //(Längd, Höjd)
            e.Graphics.DrawString("Föreställningsnamn:", drawFont, drawBrush, new PointF(35, 50));
            e.Graphics.DrawString("Datum:", drawFont, drawBrush, new PointF(35, 100));
            e.Graphics.DrawString("Akt:", drawFont, drawBrush, new PointF(35, 150));
            e.Graphics.DrawString(show_name, drawFontBold, drawBrush, new PointF(300, 50));
            e.Graphics.DrawString(show_date, drawFontBold, drawBrush, new PointF(300, 100));
            e.Graphics.DrawString(akt_name, drawFontBold, drawBrush, new PointF(300, 150));

            e.Graphics.DrawString("Antal", drawFontBold, drawBrush, new PointF(300, 250));
            e.Graphics.DrawString("Kronor", drawFontBold, drawBrush, new PointF(450, 250));

            e.Graphics.DrawString("Vuxenbiljetter:", drawFont, drawBrush, new PointF(35, 300));
            e.Graphics.DrawString("Ungdomsbiljetter:", drawFont, drawBrush, new PointF(35, 350));
            e.Graphics.DrawString("Barnbiljetter:", drawFont, drawBrush, new PointF(35, 400));
            e.Graphics.DrawString("Totallt:", drawFontBoldAndUnderline, drawBrush, new PointF(35, 480));

            e.Graphics.DrawString(AV, drawFont, drawBrush, new PointF(300, 300));
            e.Graphics.DrawString(KV, drawFont, drawBrush, new PointF(450, 300));

            e.Graphics.DrawString(AU, drawFont, drawBrush, new PointF(300, 350));
            e.Graphics.DrawString(KU, drawFont, drawBrush, new PointF(450, 350));

            e.Graphics.DrawString(AB, drawFont, drawBrush, new PointF(300, 400));
            e.Graphics.DrawString(KB, drawFont, drawBrush, new PointF(450, 400));

            e.Graphics.DrawString(TA, drawFontBoldAndUnderline, drawBrush, new PointF(300, 480));
            e.Graphics.DrawString(TK, drawFontBoldAndUnderline, drawBrush, new PointF(450, 480));
        }
        public void listCustomers()
        {
            string sqlSearch = textBoxSearchCustomer.Text;
            string sql = "SELECT lname, fname, customerid FROM customer WHERE LOWER(lname) LIKE LOWER('%" + sqlSearch + "%') OR LOWER(fname) LIKE LOWER('%" + sqlSearch + "%');";
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                dgCustomers.DataSource = dt;
                dgCustomers.Columns[0].HeaderText = "Efternamn";
                dgCustomers.Columns[1].HeaderText = "Förnamn";
                dgCustomers.Columns[2].HeaderText = "ID";
                dgCustomers.Columns[0].Width = 60;
                dgCustomers.Columns[1].Width = 60;
                dgCustomers.Columns[2].Width = 60;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void listTickets()
        {
            int currentRow = dgCustomers.SelectedRows[0].Index;
            string CustomerID = dgCustomers[2, currentRow].Value.ToString();
            if (currentRow != -1)
            {
                string sql = @"select distinct booking.bookingid, show.date, show.name, booking.paid,  type, price, booking.reserved_to from booking
                            inner join customer on booking.customerid = customer.customerid
                            inner join booked_seats on booking.bookingid = booked_seats.bookingid 
                            inner join show on booking.showid = show.showid 
                            where customer.customerid = '"+CustomerID+"' AND show.date >= now()::date group by booking.bookingid, show.date, show.name, booking.paid, booking.reserved_to,type, price";
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTickets.DataSource = dt;

                    dgTickets.DataSource = dt;
                    dgTickets.Columns[0].HeaderText = "Boknings ID";
                    dgTickets.Columns[1].HeaderText = "Datum";
                    dgTickets.Columns[2].HeaderText = "Föreställning";
                    dgTickets.Columns[3].HeaderText = "Betald";
                    dgTickets.Columns[4].HeaderText = "Åldersgrupp";
                    dgTickets.Columns[5].HeaderText = "Pris";
                    dgTickets.Columns[6].HeaderText = "Reserverad till";

                    dgTickets.Columns[2].Width = 100;
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        public void listOldTickets()
        {
            int currentRow = dgCustomers.SelectedRows[0].Index;
            string CustomerID = dgCustomers[2, currentRow].Value.ToString();
            if (currentRow != -1)
            {
                string sql = @"select distinct booking.bookingid, show.date, show.name, booking.paid, type, price, booking.reserved_to from booking
                            inner join customer on booking.customerid = customer.customerid
                            inner join booked_seats on booking.bookingid = booked_seats.bookingid 
                            inner join show on booking.showid = show.showid 
                            where customer.customerid = '" + CustomerID + "' AND show.date < now()::date group by booking.bookingid, show.date, show.name, booking.paid, type, price ,booking.reserved_to";
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgTickets.DataSource = dt;

                    dgTickets.DataSource = dt;
                    dgTickets.Columns[0].HeaderText = "Boknings ID";
                    dgTickets.Columns[1].HeaderText = "Datum";
                    dgTickets.Columns[2].HeaderText = "Föreställning";
                    dgTickets.Columns[3].HeaderText = "Betald";
                    dgTickets.Columns[4].HeaderText = "Åldersgrupp";
                    dgTickets.Columns[5].HeaderText = "Pris";
                    dgTickets.Columns[6].HeaderText = "Reserverad till";

                    dgTickets.Columns[2].Width = 100;

                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }
        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm custForm = new AddCustomerForm(staffUserId);
            custForm.ShowDialog();
        }
        private void buttonReserveTicket_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            string sql = "delete from booking where reserved_to = now()::date";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ReserveTicketForm rtf = new ReserveTicketForm();
            rtf.ShowDialog();
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (dgTickets.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Välj en biljett först");
                return;
            }
            else
            {
                //////// Printing 
                //PrintDialog pd = new PrintDialog();
                //pd.Document = printDocumentBiljett;
                //if (pd.ShowDialog() == DialogResult.OK)
                //{
                //    printDocumentBiljett.Print();
                //}


                // Kolla dokumentet innan man skrivar ut
                printPreviewControl1.Visible = true;
                printPreviewDialog1.Document = printDocumentBiljett;
                printDocumentBiljett.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocumentBiljett_PrintPage);
                printPreviewDialog1.Show();
                printPreviewControl1.Document = printDocumentBiljett;

            }

        }
        private void printDocumentBiljett_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 18);
            System.Drawing.Font drawFontBold = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            System.Drawing.Font drawFontBoldAndUnderline = new System.Drawing.Font("Arial", 18, FontStyle.Bold | FontStyle.Underline);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            int point = 350;
            foreach (DataGridViewRow ro in dgTicketActs.Rows)
            {
                point += 40;
            }

            int regtangelP = point + 60;

            ////BACKGROUND IMAGE
            System.Drawing.Image i2 = cirkus.Properties.Resources.backgroundClown;
            Point p2 = new Point(100, 100);

            // Create rectangle for displaying image, subtracting 200 (100 for left,100 for right margins).
            Rectangle destRect = new Rectangle(20, 40, 750, regtangelP);


            // Create coordinates of rectangle for source image.
            int x = 0;
            int y = 0;
            int width = i2.Width;
            int height = i2.Height;
            GraphicsUnit units = GraphicsUnit.Pixel;
            
            string aldersgrupp, bokningsnummer, forestallning, akt, pris, tider, datum;
            
            aldersgrupp = textBoxPrintAge.Text;
            bokningsnummer = textBoxPrintBookingid.Text;
            forestallning = textBoxPrintShow.Text;
            akt = textBoxPrintAct.Text;
            pris = textBoxPrintPrice.Text;
            tider = akttider;
            datum = txtPrintDatum.Text;

            //e.Graphics.DrawRectangle(Pens.Black, r);
            e.Graphics.DrawImage(i2, destRect, x, y, width, height, units); // Draw background.

            e.Graphics.DrawString("Biljett Cirkus Kul & Bus", drawFontBoldAndUnderline, drawBrush, new PointF(44, 110));
            

            e.Graphics.DrawString("BokningsID:", drawFontBold, drawBrush, new PointF(45, 150));
            e.Graphics.DrawString("Datum:", drawFontBold, drawBrush, new PointF(45, 190));
            e.Graphics.DrawString("Namn:", drawFontBold, drawBrush, new PointF(45, 230));
            e.Graphics.DrawString("Åldersgrupp:", drawFontBold, drawBrush, new PointF(45, 270));
            e.Graphics.DrawString("Akt/plats:", drawFontBold, drawBrush, new PointF(45, 310));
            e.Graphics.DrawString("Tider:", drawFontBold, drawBrush, new PointF(45, 350));
            e.Graphics.DrawString("Pris:", drawFontBold, drawBrush, new PointF(45, point));
            e.Graphics.DrawString("---------------------------------------- Klipp här -----------------------------------------------", drawFont, drawBrush, new PointF(00, point + 110));


            e.Graphics.DrawString(bokningsnummer, drawFont, drawBrush, new PointF(250, 150));
            e.Graphics.DrawString(datum, drawFont, drawBrush, new PointF(250, 190));
            e.Graphics.DrawString(forestallning, drawFont, drawBrush, new PointF(250, 230));
            e.Graphics.DrawString(aldersgrupp, drawFont, drawBrush, new PointF(250, 270));
            e.Graphics.DrawString(akt, drawFont, drawBrush, new PointF(250, 310));
            e.Graphics.DrawString(akttider, drawFont, drawBrush, new PointF(250, 350));
            e.Graphics.DrawString(pris + " kronor", drawFont, drawBrush, new PointF(250, point));

        }
        private void dgCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgTicketActs.DataSource = null;
            EmptyTextboxesTab1();
            listTickets();
        }
        private void buttonEditTicket_Click(object sender, EventArgs e)
        {
            if (dgTickets.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Välj en biljett först");
                return;
            }

            int SelectedCustomer = this.dgCustomers.SelectedRows[0].Index;
            int SelectedTicket = this.dgTickets.SelectedRows[0].Index;
            int currentRow = dgTickets.SelectedRows[0].Index;
            bool check = Convert.ToBoolean(dgTickets[3, currentRow].Value);
            ChangeTicketForm Ctf;
            

            if (SelectedTicket != -1 && SelectedCustomer != -1 && check == false)


            {
                foreach (DataGridViewRow r in dgTickets.SelectedRows)
                {
                    DataGridViewRow t = (DataGridViewRow)r.Clone();
                    t.Cells[0].Value = r.Cells[0].Value;
                    t.Cells[1].Value = r.Cells[1].Value;
                    t.Cells[2].Value = r.Cells[2].Value;
                    t.Cells[3].Value = r.Cells[3].Value;
                    t.Cells[4].Value = r.Cells[4].Value;
                    t.Cells[5].Value = r.Cells[5].Value;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Boknings ID");
                    dt.Columns.Add("Datum");
                    dt.Columns.Add("Föreställning");
                    dt.Columns.Add("Betald");
                    dt.Columns.Add("Åldersgrupp");
                    dt.Columns.Add("Pris");
                    dt.Columns.Add("Reserverad till");

                    DataRow row;
                    row = dt.NewRow();
                    row[0] = r.Cells[0].Value;
                    row[1] = r.Cells[1].Value;
                    row[2] = r.Cells[2].Value;
                    row[3] = r.Cells[3].Value;
                    row[4] = r.Cells[4].Value;
                    row[5] = r.Cells[5].Value;

                    dt.Rows.Add(row);
                    Ctf = new ChangeTicketForm(dt);
                    Ctf.ShowDialog();


                }
                try
                {
                    //Ctf = new ChangeTicketForm(dt);
                    //Ctf.ShowDialog();
                }
                catch (NpgsqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                DialogResult Warning = MessageBox.Show("Denna biljett går inte att ändra.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (btnDeleteTicket.Text=="Radera vald biljett")
            {
                DialogResult Confirmation = MessageBox.Show("Är du säker på att du vill ta bort den markerade biljetten ?",
                "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    if (dgTickets.SelectedRows.Count <= 0)
                    {
                        MessageBox.Show("Välj en biljett först");
                        return;
                    }

                    int SelectedTicket;
                    DataGridViewRow selectedTicket = this.dgTickets.SelectedRows[0];
                    SelectedTicket = Convert.ToInt32(selectedTicket.Cells["bookingid"].Value);

                    string sql = "DELETE FROM booking WHERE bookingid = '" + SelectedTicket + "'";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (NpgsqlException ex)
                    {

                        MessageBox.Show(ex.Message);

                        DialogResult Warning = MessageBox.Show("Det går ej att ta bort denna biljetten.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return;
                    }
                    conn.Close();
                }
                listTickets();
            }
            else if (btnDeleteTicket.Text=="Radera vald akt")
            {
                DialogResult Confirmation = MessageBox.Show("Är du säker på att du vill ta bort den markerade akten ?",
                "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Confirmation == DialogResult.Yes)
                {
                    if (dgTicketActs.SelectedRows.Count <= 0)
                    {
                        MessageBox.Show("Välj en akt först");
                        return;
                    }

                    DataGridViewRow selectedActs = this.dgTicketActs.SelectedRows[0];
                    int selectedAct = Convert.ToInt32(selectedActs.Cells[0].Value);

                    string sql = "DELETE FROM booked_seats WHERE booked_seat_id = '" + selectedAct + "'";
                    dgTicketActs.Rows.Remove(selectedActs);
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    conn.Open();

            

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (NpgsqlException ex)
                    {

                        MessageBox.Show(ex.Message);

                        DialogResult Warning = MessageBox.Show("Det går ej att ta bort denna akten.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return;
                    }

                    conn.Close();
                    conn.Open();
                    string sql2 = @"select booking.bookingid from booking
                                    left join booked_seats on booking.bookingid = booked_seats.bookingid
                                    where booked_seats.booked_seat_id is null";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql2, conn);
                    DataTable dat = new DataTable();
                    da.Fill(dat);
                    conn.Close();
                   
                    foreach(DataRow rw in dat.Rows)
                    {
                        conn.Open();
                        string sql3 = "delete from booking where bookingid = '"+rw[0]+ "'";
                        cmd = new NpgsqlCommand(sql3, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }

                }
                listTickets();
            }

        }
        private void dgCustomers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                listTickets();
            }
            else if (e.KeyCode == Keys.Down)
            {
                listTickets();
            }
        }
        private void dgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgTicketActs.DataSource = null;
            listTickets();
        }
        private void checkBoxOlderTickets_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOlderTickets.Checked==true)
            {
                listOldTickets();

                buttonPrint.Enabled = false;

                textBoxPrintAct.Enabled = false;
                textBoxPrintAge.Enabled = false;
                textBoxPrintPrice.Enabled = false;
                textBoxPrintBookingid.Enabled = false;
                txtPrintDatum.Enabled = false;
                textBoxPrintShow.Enabled = false;
            }
            else if (checkBoxOlderTickets.Checked==false)
            {
                listTickets();

                buttonPrint.Enabled = true;

                textBoxPrintAct.Enabled = true;
                textBoxPrintAge.Enabled = true;
                textBoxPrintPrice.Enabled = true;
                textBoxPrintBookingid.Enabled = true;
                txtPrintDatum.Enabled = true;
                textBoxPrintShow.Enabled = true;
            }
        }
        private void textBoxSearchCustomer_Click(object sender, EventArgs e)
        {
            textBoxSearchTicket.Clear();
            dgTickets.DataSource = null;
            dgTicketActs.DataSource = null;
        }
        #endregion
        #region Föreställningar
        private void buttonSkapaForestalnning_Click_1(object sender, EventArgs e)
        {
            ShowForm showForm = new ShowForm();
            showForm.ButtonVisibleSparaAndringar();

            showForm.ShowDialog();
        }
        private void buttonRaderaForestallning_Click(object sender, EventArgs e)
        {
            int selectedID;

            DataGridViewRow row = this.dgvShowsList.SelectedRows[0];

            selectedID = Convert.ToInt32(row.Cells["showid"].Value);

            string sql = "DELETE FROM show WHERE showid = '" + selectedID + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);


            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            LoadShows();
            MessageBox.Show("Förestälningen är raderad!");
        }
        private void buttonAndraForestallning_Click(object sender, EventArgs e)
        {

            
            //int selectedID;
            //DataGridViewRow row = this.dgvShowsList.SelectedRows[0];
            //selectedID = Convert.ToInt32(row.Cells["showid"].Value);


            //string nySelectedID = selectedID.ToString();

            //ShowForm frm = new ShowForm();
            //frm.SetID(nySelectedID);

            //frm.ButtonVisibleLaggTillForestallning();

            //frm.ShowDialog();
        }
        private void dgvAkter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadStatistics();
        }
        public void LoadShows()
        {
            DataTable dt = new DataTable();
            String sql;
            dgvShowsList.DataSource = null;
            dgvShowsList.Rows.Clear();

            try
            {
                conn.Open();
                sql = "select showid, date, name from show order by date DESC";
                da = new NpgsqlDataAdapter(sql, conn);
                da.Fill(dt);
                dgvShowsList.DataSource = dt;
                dgvShowsList.Columns["showid"].Visible = false;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }
        public void LoadStatistics()
        {
            if (checkBoxAllaAkter.Checked == true)
            {
                //Vuxenbiljetter
                conn.Open();
                string sql = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.showid from acts
                                inner join available_seats on acts.actid = available_seats.actid
                                inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                inner join booking on booked_seats.bookingid = booking.bookingid
                                where acts.showid = '"+showid+"' and booking.type = 'Vuxen' group by acts.showid, booking.type";


                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                textBoxAntalVuxenBiljetter.Clear();
                textBoxKronorVuxenbiljetter.Clear();

                //dr.Read();

                //textBoxAntalVuxenBiljetter.Text = dr[1].ToString();
                //textBoxKronorVuxenbiljetter.Text = dr[0].ToString();

                

                //textBoxPersonnummer.Text = read[0].ToString();

                while (dr.Read())
                {
                    textBoxAntalVuxenBiljetter.Text = dr.GetValue(1).ToString();
                    textBoxKronorVuxenbiljetter.Text = dr.GetValue(0).ToString();
                }

                if (textBoxAntalVuxenBiljetter.Text == "")
                {
                    textBoxAntalVuxenBiljetter.Text = "0";
                }

                if (textBoxKronorVuxenbiljetter.Text == "")
                {
                    textBoxKronorVuxenbiljetter.Text = "0";
                }
                conn.Close();

                //Ungdomsbiljetter
                conn.Open();
                string sqlAU = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.showid from acts
                                inner join available_seats on acts.actid = available_seats.actid
                                inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                inner join booking on booked_seats.bookingid = booking.bookingid
                                where acts.showid = '" + showid + "' and booking.type = 'Ungdom' group by acts.showid, booking.type";

                NpgsqlCommand cmdAU = new NpgsqlCommand(sqlAU, conn);
                NpgsqlDataReader drAU = cmdAU.ExecuteReader();

                textBoxAntalUngdomsbiljetter.Clear();
                textBoxKronorUngdomsbiljetter.Clear();

                while (drAU.Read())
                {
                    textBoxAntalUngdomsbiljetter.Text = drAU.GetValue(1).ToString();
                    textBoxKronorUngdomsbiljetter.Text = drAU.GetValue(0).ToString();
                }

                if (textBoxAntalUngdomsbiljetter.Text == "")
                {
                    textBoxAntalUngdomsbiljetter.Text = "0";
                }

                if (textBoxKronorUngdomsbiljetter.Text == "")
                {
                    textBoxKronorUngdomsbiljetter.Text = "0";
                }
                conn.Close();


                //Barn
                conn.Open();
                string sqlKB = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.showid from acts
                                inner join available_seats on acts.actid = available_seats.actid
                                inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                inner join booking on booked_seats.bookingid = booking.bookingid
                                where acts.showid = '" + showid + "' and booking.type = 'Barn' group by acts.showid, booking.type";

                NpgsqlCommand cmdKB = new NpgsqlCommand(sqlKB, conn);
                NpgsqlDataReader drKB = cmdKB.ExecuteReader();

                textBoxAntalBarnbiljetter.Clear();
                textBoxKronorBarnbiljetter.Clear();

                while (drKB.Read())
                {
                    textBoxAntalBarnbiljetter.Text = drKB.GetValue(1).ToString();
                    textBoxKronorBarnbiljetter.Text = drKB.GetValue(0).ToString();
                }

                if (textBoxAntalBarnbiljetter.Text == "")
                {
                    textBoxAntalBarnbiljetter.Text = "0";
                }

                if (textBoxKronorBarnbiljetter.Text == "")
                {
                    textBoxKronorBarnbiljetter.Text = "0";
                }
                conn.Close();

                //Totalt antal
                int antalVuxen, antalUngdom, antalBarn;
                string totaltSumma;

                antalVuxen = Convert.ToInt32(textBoxAntalVuxenBiljetter.Text);
                antalUngdom = Convert.ToInt32(textBoxAntalUngdomsbiljetter.Text);
                antalBarn = Convert.ToInt32(textBoxAntalBarnbiljetter.Text);
                totaltSumma = Convert.ToString(antalVuxen + antalUngdom + antalBarn);

                textBoxTotaltAntal.Text = totaltSumma;

                //Totalt kronor
                int kronorVuxen, kronorUngdom, kronorBarn;
                string totaltKornor;

                kronorVuxen = Convert.ToInt32(textBoxKronorVuxenbiljetter.Text);
                kronorUngdom = Convert.ToInt32(textBoxKronorUngdomsbiljetter.Text);
                kronorBarn = Convert.ToInt32(textBoxKronorBarnbiljetter.Text);
                totaltKornor = Convert.ToString(kronorVuxen + kronorUngdom + kronorBarn);

                textBoxTotaltKronor.Text = totaltKornor;
            }

            else if (checkBoxAllaAkter.Checked == false && dgvAkter.Rows != null)
            {
                //if (dgvAkter.RowCount != 0)
                //{
                //    //Antal Vuxenbiljetter
                //    int selectedIndex = dgvAkter.SelectedRows[0].Index;
                //    actid = int.Parse(dgvAkter[1, selectedIndex].Value.ToString());
                if(dgvAkter.Rows.Count > 0)
                {
                    int selectedIndex = dgvAkter.SelectedRows[0].Index;
                    actid = int.Parse(dgvAkter[1, selectedIndex].Value.ToString());

                    conn.Open();
                    string sql = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.actid from acts
                                    inner join available_seats on acts.actid = available_seats.actid
                                    inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                    inner join booking on booked_seats.bookingid = booking.bookingid
                                    where acts.actid = '" + actid + "' and booking.type = 'Vuxen' group by booking.type, acts.actid";


                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    textBoxAntalVuxenBiljetter.Clear();
                    textBoxKronorVuxenbiljetter.Clear();

                    while (dr.Read())
                    {
                        textBoxAntalVuxenBiljetter.Text = dr.GetValue(1).ToString();
                        textBoxKronorVuxenbiljetter.Text = dr.GetValue(0).ToString();
                    }

                    if (textBoxAntalVuxenBiljetter.Text == "")
                    {
                        textBoxAntalVuxenBiljetter.Text = "0";
                    }

                    if (textBoxKronorVuxenbiljetter.Text == "")
                    {
                        textBoxKronorVuxenbiljetter.Text = "0";
                    }
                    conn.Close();

                    //Ungdomsbiljetter
                    conn.Open();
                    string sqlAU = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.actid from acts
                                    inner join available_seats on acts.actid = available_seats.actid
                                    inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                    inner join booking on booked_seats.bookingid = booking.bookingid
                                    where acts.actid = '" + actid + "' and booking.type = 'Ungdom' group by booking.type, acts.actid";

                    NpgsqlCommand cmdAU = new NpgsqlCommand(sqlAU, conn);
                    NpgsqlDataReader drAU = cmdAU.ExecuteReader();

                    textBoxAntalUngdomsbiljetter.Clear();
                    textBoxKronorUngdomsbiljetter.Clear();

                    while (drAU.Read())
                    {
                        textBoxAntalUngdomsbiljetter.Text = drAU.GetValue(1).ToString();
                        textBoxKronorUngdomsbiljetter.Text = drAU.GetValue(0).ToString();
                    }

                    if (textBoxAntalUngdomsbiljetter.Text == "")
                    {
                        textBoxAntalUngdomsbiljetter.Text = "0";
                    }

                    if (textBoxKronorUngdomsbiljetter.Text == "")
                    {
                        textBoxKronorUngdomsbiljetter.Text = "0";
                    }
                    conn.Close();


                    //Barn
                    conn.Open();
                    string sqlKB = @"select sum(booking.price), count(booking.type) as antal, booking.type, acts.actid from acts
                                    inner join available_seats on acts.actid = available_seats.actid
                                    inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                    inner join booking on booked_seats.bookingid = booking.bookingid
                                    where acts.actid = '" + actid + "' and booking.type = 'Barn' group by booking.type, acts.actid";

                    NpgsqlCommand cmdKB = new NpgsqlCommand(sqlKB, conn);
                    NpgsqlDataReader drKB = cmdKB.ExecuteReader();

                    textBoxAntalBarnbiljetter.Clear();
                    textBoxKronorBarnbiljetter.Clear();

                    while (drKB.Read())
                    {
                        textBoxAntalBarnbiljetter.Text = drKB.GetValue(1).ToString();
                        textBoxKronorBarnbiljetter.Text = drKB.GetValue(0).ToString();
                    }

                    if (textBoxAntalBarnbiljetter.Text == "")
                    {
                        textBoxAntalBarnbiljetter.Text = "0";
                    }

                    if (textBoxKronorBarnbiljetter.Text == "")
                    {
                        textBoxKronorBarnbiljetter.Text = "0";
                    }
                    conn.Close();

                    //Totalt antal
                    int antalVuxen, antalUngdom, antalBarn;
                    string totaltSumma;

                    antalVuxen = Convert.ToInt32(textBoxAntalVuxenBiljetter.Text);
                    antalUngdom = Convert.ToInt32(textBoxAntalUngdomsbiljetter.Text);
                    antalBarn = Convert.ToInt32(textBoxAntalBarnbiljetter.Text);
                    totaltSumma = Convert.ToString(antalVuxen + antalUngdom + antalBarn);

                    textBoxTotaltAntal.Text = totaltSumma;

                    //Totalt kronor
                    int kronorVuxen, kronorUngdom, kronorBarn;
                    string totaltKornor;

                    kronorVuxen = Convert.ToInt32(textBoxKronorVuxenbiljetter.Text);
                    kronorUngdom = Convert.ToInt32(textBoxKronorUngdomsbiljetter.Text);
                    kronorBarn = Convert.ToInt32(textBoxKronorBarnbiljetter.Text);
                    totaltKornor = Convert.ToString(kronorVuxen + kronorUngdom + kronorBarn);

                    textBoxTotaltKronor.Text = totaltKornor;
                }
    
                

                
            }

            //if (dgvShowsList.RowCount != 0)
            //{
            //    //Vuxenbiljetter
            //   // int selectedIndex = dgvAkter.SelectedRows[0].Index;

            //    conn.Open();
            //    string sql = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.showid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.showid = '" + showid + "' and price_group_seat.group = 'vuxen'  group by acts.showid, price_group_seat.group";


            //    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            //    NpgsqlDataReader dr = cmd.ExecuteReader();

            //    textBoxAntalVuxenBiljetter.Clear();
            //    textBoxKronorVuxenbiljetter.Clear();

            //    while (dr.Read())
            //    {
            //        textBoxAntalVuxenBiljetter.Text = dr.GetValue(1).ToString();
            //        textBoxKronorVuxenbiljetter.Text = dr.GetValue(0).ToString();
            //    }

            //    if (textBoxAntalVuxenBiljetter.Text == "")
            //    {
            //        textBoxAntalVuxenBiljetter.Text = "0";
            //    }

            //    if (textBoxKronorVuxenbiljetter.Text == "")
            //    {
            //        textBoxKronorVuxenbiljetter.Text = "0";
            //    }
            //    conn.Close();

            //    //Ungdomsbiljetter
            //    conn.Open();
            //    string sqlAU = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.showid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.showid = '" + showid + "' and price_group_seat.group = 'ungdom'  group by acts.showid, price_group_seat.group";

            //    NpgsqlCommand cmdAU = new NpgsqlCommand(sqlAU, conn);
            //    NpgsqlDataReader drAU = cmdAU.ExecuteReader();

            //    textBoxAntalUngdomsbiljetter.Clear();
            //    textBoxKronorUngdomsbiljetter.Clear();

            //    while (drAU.Read())
            //    {
            //        textBoxAntalUngdomsbiljetter.Text = drAU.GetValue(1).ToString();
            //        textBoxKronorUngdomsbiljetter.Text = drAU.GetValue(0).ToString();
            //    }

            //    if (textBoxAntalUngdomsbiljetter.Text == "")
            //    {
            //        textBoxAntalUngdomsbiljetter.Text = "0";
            //    }

            //    if (textBoxKronorUngdomsbiljetter.Text == "")
            //    {
            //        textBoxKronorUngdomsbiljetter.Text = "0";
            //    }
            //    conn.Close();


            //    //Barn
            //    conn.Open();
            //    string sqlKB = "select sum(price_group_seat.price), count(price_group_seat.price) as antal, price_group_seat.group, acts.showid from acts inner join available_seats on acts.actid = available_seats.actid inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id inner join price_group_seat on booked_seats.priceid = price_group_seat.priceid where acts.showid = '" + showid + "' and price_group_seat.group = 'ungdom'  group by acts.showid, price_group_seat.group";

            //    NpgsqlCommand cmdKB = new NpgsqlCommand(sqlKB, conn);
            //    NpgsqlDataReader drKB = cmdKB.ExecuteReader();

            //    textBoxAntalBarnbiljetter.Clear();
            //    textBoxKronorBarnbiljetter.Clear();

            //    while (drKB.Read())
            //    {
            //        textBoxAntalBarnbiljetter.Text = drKB.GetValue(1).ToString();
            //        textBoxKronorBarnbiljetter.Text = drKB.GetValue(0).ToString();
            //    }

            //    if (textBoxAntalBarnbiljetter.Text == "")
            //    {
            //        textBoxAntalBarnbiljetter.Text = "0";
            //    }

            //    if (textBoxKronorBarnbiljetter.Text == "")
            //    {
            //        textBoxKronorBarnbiljetter.Text = "0";
            //    }
            //    conn.Close();
            //}

            ////Totalt antal
            //int antalVuxen, antalUngdom, antalBarn;
            //string totaltSumma;

            //antalVuxen = Convert.ToInt32(textBoxAntalVuxenBiljetter.Text);
            //antalUngdom = Convert.ToInt32(textBoxAntalUngdomsbiljetter.Text);
            //antalBarn = Convert.ToInt32(textBoxAntalBarnbiljetter.Text);
            //totaltSumma = Convert.ToString(antalVuxen + antalUngdom + antalBarn);

            //textBoxTotaltAntal.Text = totaltSumma;

            ////Totalt kronor
            //int kronorVuxen, kronorUngdom, kronorBarn;
            //string totaltKornor;

            //kronorVuxen = Convert.ToInt32(textBoxKronorVuxenbiljetter.Text);
            //kronorUngdom = Convert.ToInt32(textBoxKronorUngdomsbiljetter.Text);
            //kronorBarn = Convert.ToInt32(textBoxKronorBarnbiljetter.Text);
            //totaltKornor = Convert.ToString(kronorVuxen + kronorUngdom + kronorBarn);

            //textBoxTotaltKronor.Text = totaltKornor;

        }
        public void LoadAkter()
        {
            if (dgvShowsList.RowCount != 0)
            {
                int selectedIndex = dgvShowsList.SelectedRows[0].Index;
                showid = int.Parse(dgvShowsList[0, selectedIndex].Value.ToString());

                show_name = dgvShowsList[2, selectedIndex].Value.ToString();

                show_date = dgvShowsList[1, selectedIndex].Value.ToString();

                string sql = "select name, actid from acts where showid = '" + showid + "' group by name, actid order by name";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgvAkter.DataSource = dt;
                conn.Close();

                this.dgvAkter.Columns[1].Visible = false;
            }
        }
        private void dgvShowsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadAkter();
            LoadStatistics();
            
        }
        private void dgvShowsList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                LoadAkter();
                LoadStatistics();
            }
            else if (e.KeyCode == Keys.Down)
            {
                LoadAkter();
                LoadStatistics();
            }
        }
        private void dgvAkter_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {

                LoadStatistics();
            }
            else if (e.KeyCode == Keys.Down)
            {

                LoadStatistics();
            }
        }
        private void buttonSkrivUtForestallning_Click(object sender, EventArgs e)
        {
            //// Printing 
            //PrintDialog pd = new PrintDialog();
            //pd.Document = printDocumentStatistic;
            //if (pd.ShowDialog() == DialogResult.OK)
            //{
            //    printDocumentStatistic.Print();
            //}


            // Kolla dokumentet innan man skrivar ut
        }
        private void checkBoxAllaAkter_CheckedChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }
        #endregion
        #region Konto
        private void textBoxSearchStaff_TextChanged(object sender, EventArgs e)
        {
            ListaPersonal();
        }
        public void ResetColor()
        {

            textBoxPersonnummer.BackColor = Color.White;
            textBoxFornamn.BackColor = Color.White;
            textBoxEfternamn.BackColor = Color.White;
            textBoxEpost.BackColor = Color.White;
            textBoxTelefonnummer.BackColor = Color.White;
            textBoxAnvandarnamn.BackColor = Color.White;
            textBoxLosenord.BackColor = Color.White;
            comboBoxBehorighetsniva.BackColor = Color.White;
        }
        public void ResetColorandText()
        {
            textBoxPersonnummer.Clear();
            textBoxFornamn.Clear();
            textBoxEfternamn.Clear();
            textBoxEpost.Clear();
            textBoxTelefonnummer.Clear();
            textBoxAnvandarnamn.Clear();
            textBoxLosenord.Clear();
            comboBoxBehorighetsniva.ResetText();

            textBoxPersonnummer.BackColor = Color.White;
            textBoxFornamn.BackColor = Color.White;
            textBoxEfternamn.BackColor = Color.White;
            textBoxEpost.BackColor = Color.White;
            textBoxTelefonnummer.BackColor = Color.White;
            textBoxAnvandarnamn.BackColor = Color.White;
            textBoxLosenord.BackColor = Color.White;
            comboBoxBehorighetsniva.BackColor = Color.White;
        }
        private void btnTomFalten_Click(object sender, EventArgs e)
        {
            ResetColorandText();
            LblStatusKonto.Visible = false;
        }
        private void ListaPersonal()
        {
            string sqlSearchStaff = textBoxSearchStaff.Text;
            string sql = "SELECT staffid, lname, fname, phonenumber  FROM staff WHERE LOWER(fname) LIKE LOWER('%" + sqlSearchStaff + "%') OR LOWER(lname) LIKE LOWER('%" + sqlSearchStaff + "%')";
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgStaff.DataSource = dt;

                dgStaff.Columns[0].Visible = false;
                dgStaff.Columns[1].Visible = true;
                dgStaff.Columns[2].Visible = true;
                dgStaff.Columns[3].Visible = true;

                dgStaff.Columns[1].HeaderText = "Efternamn";
                dgStaff.Columns[2].HeaderText = "Förnamn";
                dgStaff.Columns[3].HeaderText = "Telefonnummer";               

                DataGridViewColumn column = dgStaff.Columns[0];
                DataGridViewColumn column1 = dgStaff.Columns[1];
                DataGridViewColumn column2 = dgStaff.Columns[2];
                DataGridViewColumn column3 = dgStaff.Columns[3];

                column.Width = 60;
                column1.Width = 100;
                column2.Width = 100;
                column3.Width = 100;

                conn.Close();

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        public bool EndastSiffror(string värde)
        {
            bool barasiffror = true;
            foreach (char siffra in värde)
            {
                if (!char.IsDigit(siffra))
                {
                    barasiffror = false;
                }
            }
            return barasiffror;
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnSkapaKonto_Click(object sender, EventArgs e)
        {
            ResetColor();

            //Kontrollerar längden, siffror/bokstäver och tomma fält
            if (textBoxPersonnummer.TextLength > 10 || textBoxPersonnummer.TextLength < 10 || string.IsNullOrWhiteSpace(textBoxPersonnummer.Text))
            {
                textBoxPersonnummer.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange personnummret, med 10 siffror";
                return;
            }
            if (textBoxFornamn.TextLength > 60 || !BaraBokstäver(textBoxFornamn.Text) || string.IsNullOrWhiteSpace(textBoxFornamn.Text))
            {
                textBoxFornamn.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange förnamn, utan siffror, max 60 bokstäver";
                return;
            }
            if (textBoxEfternamn.TextLength > 60 || !BaraBokstäver(textBoxEfternamn.Text) || string.IsNullOrWhiteSpace(textBoxEfternamn.Text))
            {
                textBoxEfternamn.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange förnamn, utan siffror, max 60 bokstäver.";
                return;
            }
            if (textBoxTelefonnummer.TextLength > 10 || !EndastSiffror(textBoxTelefonnummer.Text) || string.IsNullOrWhiteSpace(textBoxTelefonnummer.Text))
            {
                textBoxTelefonnummer.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange telefonnummer, max 10 siffror";
                return;
            }
            if (textBoxEpost.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxEpost.Text) || !IsValidEmail(textBoxEpost.Text))
            {
                textBoxEpost.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange en giltig epost, max 60 tecken";
                return;
            }
            if (textBoxAnvandarnamn.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxAnvandarnamn.Text))
            {
                textBoxAnvandarnamn.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange epost, max 60 tecken";
                return;
            }
            if (textBoxLosenord.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxLosenord.Text))
            {
                textBoxLosenord.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Ange lösenord, max 60 tecken";
                return;
            }
            if (string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
            {
                comboBoxBehorighetsniva.BackColor = Color.Tomato;
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Välj en behörighet";
                return;
            }
            //Slut kontrollera längden, siffror/bokstäver och tomma fält
            try
            {
                conn.Open();
                string sql = "INSERT INTO staff (ssn,fname,lname,phonenumber,email,username,password,auth) VALUES(:ssn, :fname, :lname, :phonenumber, :email, :username, :password, :auth)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);


                cmd.Parameters.Add(new NpgsqlParameter("ssn", textBoxPersonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("fname", textBoxFornamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("lname", textBoxEfternamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("phonenumber", textBoxTelefonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("email", textBoxEpost.Text));
                cmd.Parameters.Add(new NpgsqlParameter("username", textBoxAnvandarnamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("password", textBoxLosenord.Text));


                if (comboBoxBehorighetsniva.Text == "Biljettförsäljare")
                {
                    int auth = 0;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }
                else
                {
                    int auth = 1;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));

                }
                string email = textBoxEpost.Text;
                string firstname= textBoxFornamn.Text;
                string lastname= textBoxEfternamn.Text;
                string password = textBoxLosenord.Text;
                string username= textBoxAnvandarnamn.Text;

                string confirmation_mail = "Hej " + firstname + " " + lastname + "\nDitt lösenord är: " + password + "\nDitt användarnamn är: " + username + " ";

                MailMessage mail = new MailMessage("kulbusstest@gmail.com", email, "Cirkus Kul&Bus - Ditt nya konto", confirmation_mail);

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("kulbusstest@gmail.com", "Test12345");
                client.EnableSsl = true;

                client.Send(mail);

                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Green;
                LblStatusKonto.Text = "Användare tillagd";

                cmd.ExecuteNonQuery();
                conn.Close();
                ListaPersonal();
                ResetColorandText();

            }
            catch (NpgsqlException)
            {
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Tomato;
                LblStatusKonto.Text = "Användaren finns redan";
                conn.Close();
            }
        
        }
        public bool BaraBokstäver(string namn)
        {
            bool okej = true;
            foreach (char bokstav in namn)
            {
                if (!char.IsLetter(bokstav))
                {
                    okej = false;
                }
            }
            return okej;
        }
        private void btnUpdateraKonto_Click(object sender, EventArgs e)
        {
            ResetColor();
            LblStatusKonto.Visible = false;
            btnRaderaKonto.Enabled = true;
            btnTomFalten.Enabled = false;

            if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Uppdatera/ändra konto")
            {
                int selectedIndex = dgStaff.SelectedRows[0].Index;

                staffid = int.Parse(dgStaff[0, selectedIndex].Value.ToString());

                btnSkapaKonto.Enabled = false;
                dgStaff.Enabled = false;

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"select ssn, fname, lname, phonenumber, email, username, password, auth
                                                        from staff where staffid = '" + staffid + "'", conn);
                NpgsqlDataReader read;
                read = cmd.ExecuteReader();
                read.Read();

                textBoxPersonnummer.Text = read[0].ToString();
                textBoxFornamn.Text = read[1].ToString();
                textBoxEfternamn.Text = read[2].ToString();
                textBoxTelefonnummer.Text = read[3].ToString();
                textBoxEpost.Text = read[4].ToString();
                textBoxAnvandarnamn.Text = read[5].ToString();
                textBoxLosenord.Text = read[6].ToString();
                int auth = int.Parse(read[7].ToString());

                if (auth == 0)
                {
                    comboBoxBehorighetsniva.SelectedText = "Biljettförsäljare";

                }
                else if (auth == 1)
                {
                    comboBoxBehorighetsniva.SelectedText = "Administratör";

                }

                conn.Close();
                btnUpdateraKonto.Text = "Spara ändringar";
                textBoxAnvandarnamn.Enabled = false;

            }
            else if (dgStaff.SelectedRows.Count > 0 && btnUpdateraKonto.Text == "Spara ändringar")
            {

                //Kontrollerar längden, siffror/bokstäver och tomma fält
                if (textBoxPersonnummer.TextLength > 10 || textBoxPersonnummer.TextLength < 10 || string.IsNullOrWhiteSpace(textBoxPersonnummer.Text))
                {
                    textBoxPersonnummer.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange personnummret, med 10 siffror";
                    return;
                }
                if (textBoxFornamn.TextLength > 60 || !BaraBokstäver(textBoxFornamn.Text) || string.IsNullOrWhiteSpace(textBoxFornamn.Text))
                {
                    textBoxFornamn.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange förnamn, utan siffror, max 60 bokstäver";
                    return;
                }
                if (textBoxEfternamn.TextLength > 60 || !BaraBokstäver(textBoxEfternamn.Text) || string.IsNullOrWhiteSpace(textBoxEfternamn.Text))
                {
                    textBoxEfternamn.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange förnamn, utan siffror, max 60 bokstäver.";
                    return;
                }
                if (textBoxTelefonnummer.TextLength > 10 || !EndastSiffror(textBoxTelefonnummer.Text) || string.IsNullOrWhiteSpace(textBoxTelefonnummer.Text))
                {
                    textBoxTelefonnummer.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange telefonnummer, max 10 siffror";
                    return;
                }
                if (textBoxEpost.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxEpost.Text)||!IsValidEmail(textBoxEpost.Text))
                {
                    textBoxEpost.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange en giltig epost, max 60 tecken";
                    return;
                }
                if (textBoxAnvandarnamn.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxAnvandarnamn.Text))
                {
                    textBoxAnvandarnamn.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange epost, max 60 tecken";
                    return;
                }
                if (textBoxLosenord.TextLength > 60 || string.IsNullOrWhiteSpace(textBoxLosenord.Text))
                {
                    textBoxLosenord.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Ange lösenord, max 60 tecken";
                    return;
                }
                if (string.IsNullOrEmpty(comboBoxBehorighetsniva.Text))
                {
                    comboBoxBehorighetsniva.BackColor = Color.Tomato;
                    LblStatusKonto.Visible = true;
                    LblStatusKonto.ForeColor = Color.Tomato;
                    LblStatusKonto.Text = "Välj en behörighet";
                    return;
                }
                //Slut kontrollera längden, siffror/bokstäver och tomma fält
               
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(@"update staff set ssn = @ssn, fname = @fn, lname = @ln, phonenumber = @pn, email = @email,                                                         username = @un, password = @pass, auth = @auth where staffid =@id", conn);

                cmd.Parameters.Add(new NpgsqlParameter("ssn", textBoxPersonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("fn", textBoxFornamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("ln", textBoxEfternamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("pn", textBoxTelefonnummer.Text));
                cmd.Parameters.Add(new NpgsqlParameter("email", textBoxEpost.Text));
                cmd.Parameters.Add(new NpgsqlParameter("un", textBoxAnvandarnamn.Text));
                cmd.Parameters.Add(new NpgsqlParameter("pass", textBoxLosenord.Text));
                cmd.Parameters.Add(new NpgsqlParameter("id", staffid));

                if (comboBoxBehorighetsniva.SelectedIndex == 0)
                {
                    int auth = 0;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }
                else if (comboBoxBehorighetsniva.SelectedIndex == 1)
                {
                    int auth = 1;
                    cmd.Parameters.Add(new NpgsqlParameter("auth", auth));
                }

                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Green;
                LblStatusKonto.Text = "Användare updaterad";
  
                cmd.ExecuteNonQuery();
                conn.Close();

                btnTomFalten.Enabled = true;
                btnRaderaKonto.Enabled = false;
                dgStaff.Enabled = true;
                ListaPersonal();
                btnUpdateraKonto.Text = "Uppdatera/ändra konto";
                textBoxAnvandarnamn.Enabled = true;
                btnSkapaKonto.Enabled = true;
                ResetColorandText();
            }

        }
        private void btnRaderaKonto_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show("Är du säker på att du vill ta bort den markerade användaren ?",
                "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                int SelectedStaff;

                DataGridViewRow selectedrow = this.dgStaff.SelectedRows[0];
                SelectedStaff = Convert.ToInt32(selectedrow.Cells["staffid"].Value);
                string sql = "DELETE FROM staff WHERE staffid = '" + SelectedStaff + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    
                    DialogResult Warning = MessageBox.Show("Det går ej att ta bort denna användaren. Användaren har en eller flera aktiva föreställningar kopplade till kontot.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                conn.Close();

                textBoxAnvandarnamn.Enabled = true;
                dgStaff.Enabled = true;
                btnRaderaKonto.Enabled = false;
                btnSkapaKonto.Enabled = true;
                btnTomFalten.Enabled = true;
                btnSkapaKonto.Text = "Skapa/Lägg till konto";
                btnUpdateraKonto.Text = "Uppdatera/ändra konto";
                LblStatusKonto.Visible = true;
                LblStatusKonto.ForeColor = Color.Red;
                LblStatusKonto.Text = "Användare raderad";
                ListaPersonal();
                ResetColorandText();
            }
            if (Confirmation == DialogResult.No)
            {
                return;
            }         
        }
        #endregion

        private void textBoxKronorUngdomsbiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAntalBarnbiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKronorBarnbiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTotaltAntal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAntalVuxenBiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTotaltKronor_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKronorVuxenbiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAntalUngdomsbiljetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocumentStatistic;
            printDocumentStatistic.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocumentStatistic_PrintPage);
            printPreviewDialog1.Show();
            printPreviewControl1.Document = printDocumentStatistic;
        }

        
    }
}
