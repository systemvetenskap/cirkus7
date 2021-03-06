﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Drawing.Printing;

namespace cirkus
{
    public partial class PrintBiljetter : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        
        DataTable bidt = new DataTable();
        DataTable dtActs = new DataTable();
        DataTable dtTicketDirekt = new DataTable();
        string aldersgrupp, bokningsnummer, forestallning, akt, pris, tider, datum;
        string akter = "";
        string akttider = "";
        int bid = 0;
        public PrintBiljetter(DataTable bdt)
        {
            InitializeComponent();           
            bidt = bdt;
            
        }
        private void PrintBiljetter_Load(object sender, EventArgs e)
        {
            listTicketDirekt();
            
        }
        private void dgTicketsDirekt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Selected Akt
            int selectedindexT = dgTicketsDirekt.SelectedRows[0].Index; //Selected Biljett
            int selectedindex = dgTicketActsDirekt.SelectedRows[0].Index;
            string seltic = dgTicketsDirekt[0, selectedindexT].Value.ToString();

            aldersgrupp = dgTicketsDirekt[4, selectedindexT].Value.ToString();
            bokningsnummer = dgTicketsDirekt[0, selectedindexT].Value.ToString();
            forestallning = dgTicketsDirekt[2, selectedindexT].Value.ToString();
            akt = dgTicketActsDirekt[1, selectedindex].Value.ToString();
            pris = dgTicketsDirekt[5, selectedindexT].Value.ToString();
            tider = akttider;
            datum = DateTime.Parse(dgTicketsDirekt[1, selectedindex].Value.ToString()).ToShortDateString();
        }
        private void button1_Click(object sender, EventArgs e)
        {


      }
        private void button2_Click(object sender, EventArgs e)
        {
            // Kolla dokumentet innan man skrivar ut
            printPreviewDialog1.Document = printDocumentBIljettDirekt;
            printDocumentBIljettDirekt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocumentBIljettDirekt_PrintPage);
            printPreviewDialog1.ShowDialog();
            printPreviewControl1.Document = printDocumentBIljettDirekt;
        }
        public void listTicketDirekt()
        {
            
    
            try
            {
                conn.Open();
                foreach(DataRow r in bidt.Rows)
                {
                    bid = int.Parse(r[0].ToString());
                    string sql = @"select distinct booking.bookingid, show.date, show.name, booking.paid, sold_tickets.type,  sum(sold_tickets.sum) as pris, booking.reserved_to
                            from booking
                            inner join sold_tickets on booking.bookingid = sold_tickets.bookingid
                            inner join show on sold_tickets.showid = show.showid
                            inner join acts on sold_tickets.actid = acts.actid                            
                            where booking.bookingid = '" + bid + "'  group by booking.bookingid, show.date, show.name, booking.paid, sold_tickets.type, booking.reserved_to";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                    da.Fill(dtTicketDirekt);

                }
   
                dgTicketsDirekt.DataSource = dtTicketDirekt;
                
                dgTicketsDirekt.Columns[0].HeaderText = "Boknings ID";
                dgTicketsDirekt.Columns[1].HeaderText = "Datum";
                dgTicketsDirekt.Columns[2].HeaderText = "Föreställning";
                dgTicketsDirekt.Columns[3].HeaderText = "Betald";
                dgTicketsDirekt.Columns[4].HeaderText = "Åldersgrupp";
                dgTicketsDirekt.Columns[5].HeaderText = "Pris";
                dgTicketsDirekt.Columns[6].HeaderText = "Reserverad till";

                dgTicketsDirekt.Columns[2].Width = 100;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            listAct();

        }
        private void listAct()
        {
            if (dgTicketsDirekt.Rows.Count >= 0)
            {
                int selectedindex = dgTicketsDirekt.SelectedRows[0].Index;
                int bookingid = int.Parse(dgTicketsDirekt[0, selectedindex].Value.ToString());

                string sql = @" select distinct  booked_seats.booked_seat_id, acts.name, seats.section, seats.rownumber, acts.start_time, acts.end_time, sold_tickets.seattype from acts
                                    inner join available_seats on acts.actid = available_seats.actid
                                    inner join booked_seats on available_seats.available_seats_id = booked_seats.available_seats_id
                                    inner join seats on available_seats.seatid = seats.seatid
                                    inner join sold_tickets on booked_seats.bookingid = sold_tickets.bookingid
                                    where booked_seats.bookingid = '" + bookingid + "' and sold_tickets.seattype = 'Parkett' order by booked_seats.booked_seat_id";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                dtActs = new DataTable();
                da.Fill(dtActs);
                string sql2 = @"  select distinct booked_standing.booked_standing_id, acts.name, acts.start_time,acts.end_time, sold_tickets.seattype from acts
                                    inner join booked_standing on acts.actid = booked_standing.actid
                                    inner join booking on booked_standing.bookingid = booking.bookingid
                                    inner join sold_tickets on booking.bookingid = sold_tickets.bookingid
                                    where booking.bookingid = '" + bookingid + "' and sold_tickets.seattype = 'Fri placering' order by booked_standing.booked_standing_id";
                da = new NpgsqlDataAdapter(sql2, conn);

                DataTable temp = new DataTable();
                da.Fill(temp);

                foreach (DataRow r in temp.Rows)
                {
                    DataRow row = dtActs.NewRow();

                    row[0] = r[0];
                    row[1] = r[1];
                    row[2] = "Fri placering";
                    row[3] = DBNull.Value;
                    row[4] = r[2];
                    row[5] = r[3];
                    row[6] = r[4];
                    dtActs.Rows.Add(row);
                }

                dgTicketActsDirekt.DataSource = dtActs;

                dgTicketActsDirekt.Columns[0].HeaderText = "Boknings ID";
                dgTicketActsDirekt.Columns[1].HeaderText = "Akt";
                dgTicketActsDirekt.Columns[2].HeaderText = "Sektion";
                dgTicketActsDirekt.Columns[3].HeaderText = "Sittplats";
                dgTicketActsDirekt.Columns[4].HeaderText = "Starttid";
                dgTicketActsDirekt.Columns[5].HeaderText = "Sluttid";
                dgTicketActsDirekt.Columns[6].HeaderText = "Platstyp";

                dgTicketActsDirekt.Columns[0].Width = 90;
            }
            
        }
        private void dgTicketActsDirekt_Click(object sender, EventArgs e)
        {
            
        }
        private void dgTicketsDirekt_Click(object sender, EventArgs e)
        {
            listAct();
        }
        private void buttonPrintBiljettDirekt_Click(object sender, EventArgs e)
        {
            // Printing 
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocumentBIljettDirekt;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDocumentBIljettDirekt.Print();
            }

            // Delete ticket from list after printing
            int selectedindexT = dgTicketsDirekt.SelectedRows[0].Index; //Selected Biljett
            string seltic = dgTicketsDirekt[0, selectedindexT].Value.ToString();
            
            for (int rw = 0; rw <= dgTicketsDirekt.Rows.Count; rw++)
            {
                DataRow drw = dtTicketDirekt.Rows[rw];
                if (drw.RowState != DataRowState.Deleted)
                {
                    if (drw[0].ToString() == seltic)
                    {
                        drw.Delete();
                        dgTicketActsDirekt.DataSource = null;
                    }
                }
            }


        }
        private void printDocumentBIljettDirekt_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            int point = 350;
            akter = "";
            akttider = "";
            foreach (DataRow r in dtActs.Rows)
            {
                akter += r[1].ToString() + ": " + r[2].ToString() + r[3].ToString() + ", ";
                akttider += r[1].ToString() + ": " + r[4].ToString() + "-" + r[5].ToString() + "\n";
                point += 40;
            }


            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 18);
            System.Drawing.Font drawFontBold = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            System.Drawing.Font drawFontBoldAndUnderline = new System.Drawing.Font("Arial", 18, FontStyle.Bold | FontStyle.Underline);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            

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
            e.Graphics.DrawString(akter, drawFont, drawBrush, new PointF(250, 310));
            e.Graphics.DrawString(akttider, drawFont, drawBrush, new PointF(250, 350));
            e.Graphics.DrawString(pris + " kronor", drawFont, drawBrush, new PointF(250, point));

            
        }     
    }
}
