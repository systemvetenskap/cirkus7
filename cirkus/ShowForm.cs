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
using System.IO;

namespace cirkus
{
    public partial class ShowForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");        
        NpgsqlCommand command;
        DataRow row;
        DataTable dtActs, dtSelectedSeats, dt, dtSeats;
        BindingSource bs = new BindingSource();
        BindingSource fs = new BindingSource();
        NpgsqlDataAdapter da;
        public string name;
        int selected_actid;
        string addedshowid,addedactid, acts, section, seat_number;
        string selected_actname;

        public ShowForm()
        {
            InitializeComponent();

            loadSeats();

        }

        public void ButtonVisibleSparaAndringar()
        {
            buttonSparaAndringar.Visible = false;
        }

        public void ButtonVisibleLaggTillForestallning()
        {
            buttonLaggTIllForestallning.Visible = false;
        }

        public void SetID(string s)
        {
            Name = s;
            textBoxBeskrivning.Text = Name;

            conn.Open();
          
            NpgsqlCommand cmd = new NpgsqlCommand("select a.actid, a.name , s.date, s.name, s.seat_number, s.showid, s.sale_start, s.sale_stop from show s inner join acts a on s.showid = a.showid where s.showid = '" + Name + "' group by a.actid, a.name , s.date, s.name, s.seat_number, s.showid, s.sale_start, s.sale_stop ", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            Act newAct = new Act();

            while (dr.Read())
            {
                textBoxBeskrivning.Text = dr.GetValue(3).ToString();
                textBoxAntalFriplatser.Text = dr.GetValue(4).ToString();
                dateTimePickerDatum.Value = Convert.ToDateTime(dr.GetValue(2).ToString());
                dateTimePickerForsaljningstidFran.Value = Convert.ToDateTime(dr.GetValue(6).ToString());
                dateTimePickerForsaljningstidTill.Value = Convert.ToDateTime(dr.GetValue(7).ToString());
              
            }
            conn.Close();
        }


        private void buttonLaggTillAkt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtActname.Text))
            {
                MessageBox.Show("Du måste ange akt i textboxen");
            }

            else
            {
           
                DataRow row = dtActs.NewRow();

                row[1] = txtActname.Text.ToString();
                
                dtActs.Rows.Add(row);
                   
                dgActs.DataSource = dtActs;
               
                this.dgActs.Columns[0].Visible = false;
                dgActs.Columns[1].Width = 80;
                dgActs.ClearSelection();
                labelAngeAkt.Visible = false;

                DataRow lastRow = dtActs.Rows[dgActs.Rows.Count - 1];
                selected_actid = int.Parse(lastRow[0].ToString());

                NpgsqlDataAdapter cmd = new NpgsqlDataAdapter("select seatid, section, rownumber from seats order by section, rownumber", conn);

                cmd.Fill(dtSeats);


                for (int r = 0; r < dtSeats.Rows.Count; r++)
                {
                    DataRow dr = dtSeats.Rows[r];

                    object value = dr[0];
                    if (value == DBNull.Value)
                    {
                        dr[0] = selected_actid;
                    }

                }

                dgTest.DataSource = dtSeats;
                

            }

        }

        private void buttonRaderaAkt_Click(object sender, EventArgs e)
        {
   
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {
            DataColumn id = new DataColumn();
            dtSelectedSeats = new DataTable();           
            dtSelectedSeats.Columns.Add("id");
            dtSelectedSeats.Columns.Add("name");
            dtSelectedSeats.Columns.Add("seatid");
            dtSelectedSeats.Columns.Add("section");
            dtSelectedSeats.Columns.Add("rownumber");
            dtActs = new DataTable();
            id.DataType = System.Type.GetType("System.Int32");
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.ColumnName = "id";
            dtActs.Columns.Add(id);
            dtActs.Columns.Add("name");
            dtSeats = new DataTable();
            dtSeats.Columns.Add("id");

        }

        private void buttonSparaAndringar_Click(object sender, EventArgs e)
        {
            bool allowAdd = true;
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                //MessageBox.Show("Du måste ange beskrivning");
                textBoxBeskrivning.BackColor = Color.Tomato;
                labelAngeBeskrivningen.Visible = true;
                allowAdd = false;
            }



            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                labelAngeStaplatser.Visible = true;
                allowAdd = false;
            }

            if (allowAdd)
            {
                string name, date, sale_start, sale_stop;

                name = textBoxBeskrivning.Text;
                date = dateTimePickerDatum.Text;
                sale_start = dateTimePickerForsaljningstidFran.Text;
                sale_stop = dateTimePickerForsaljningstidTill.Text;

                int seat_number = Convert.ToInt16(textBoxAntalFriplatser.Text);

                string sql = "update show set name = @name, date = @date, seat_number = @seat_number, sale_start = @sale_start, sale_stop = @sale_stop where showid = '" + Name + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@seat_number", seat_number);
                cmd.Parameters.AddWithValue("@sale_start", sale_start);
                cmd.Parameters.AddWithValue("@sale_stop", sale_stop);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

        

                this.Close();
                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.LoadShows();

                MessageBox.Show("Ändringarna har sparats!");
            }
        }

        private void buttonLaggTIllForestallning_Click(object sender, EventArgs e)
        {
            bool allowAdd = true;
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                //MessageBox.Show("Du måste ange beskrivning");
                textBoxBeskrivning.BackColor = Color.Tomato;
                labelAngeBeskrivningen.Visible = true;
                allowAdd = false;
            }

   

            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                labelAngeStaplatser.Visible = true;
                allowAdd = false;
            }

            if (allowAdd)
            {

                string name, date, sale_start, sale_stop;

                name = textBoxBeskrivning.Text;
                date = dateTimePickerDatum.Text;
                sale_start = dateTimePickerForsaljningstidFran.Text;
                sale_stop = dateTimePickerForsaljningstidTill.Text;

                int seat_number = Convert.ToInt16(textBoxAntalFriplatser.Text);

                conn.Open();

                command = new NpgsqlCommand(@"Insert into show (name, seat_number, date, sale_start, sale_stop) Values (@name, @seat_number, @date, @sale_start, @sale_stop)", conn);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@seat_number", seat_number);
                command.Parameters.AddWithValue("@sale_start", sale_start);
                command.Parameters.AddWithValue("@sale_stop", sale_stop);
                command.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                command = new NpgsqlCommand("select currval('show_showid_seq');", conn);
                NpgsqlDataReader read;
                read = command.ExecuteReader();
                read.Read();
                addedshowid = read[0].ToString();
                conn.Close();

                foreach (DataRow r in dtActs.Rows)
                {
                    int id = int.Parse(r[0].ToString());
                    string an = r[1].ToString();

                    conn.Open();
                    command = new NpgsqlCommand("insert into acts(name, showid) values(:nm, :shid)", conn);
                    command.Parameters.Add(new NpgsqlParameter("nm", an));
                    command.Parameters.Add(new NpgsqlParameter("shid", addedshowid));
                    command.ExecuteNonQuery();
                    

                    
                    command = new NpgsqlCommand("select currval('acts_actid_seq');", conn);                   
                    read = command.ExecuteReader();
                    read.Read();
                    addedactid = read[0].ToString();
                    conn.Close();

                    foreach (DataRow rw in dtSelectedSeats.Rows)
                    {
                        if (int.Parse(rw[0].ToString()) == id)
                        {
                            int seatid = int.Parse(rw[3].ToString());
                            conn.Open();
                            command = new NpgsqlCommand("insert into available_seats(actid, seatid) values (:aid, :sid)", conn);
                            command.Parameters.Add(new NpgsqlParameter("aid", addedactid));
                            command.Parameters.Add(new NpgsqlParameter("sid", seatid));
                            command.ExecuteNonQuery();
                            conn.Close();

                            

                        }

                    }


                    MessageBox.Show("Föreställning skapad");
                }



                this.Close();
                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.LoadShows();
            }
        }

        private void buttonaddSeat_Click(object sender, EventArgs e)
        {
          


            foreach (DataGridViewRow r in dgSeats.SelectedRows)
            {
                DataGridViewRow t = (DataGridViewRow)r.Clone();
                

                t.Cells[0].Value = r.Cells[0].Value;
                t.Cells[1].Value = r.Cells[1].Value;
                t.Cells[2].Value = r.Cells[2].Value;

                row = dtSelectedSeats.NewRow();
                row[0] = selected_actid;
                row[1] = selected_actname;
                row[2] = r.Cells[0].Value;
                row[3] = r.Cells[1].Value;
                row[4] = r.Cells[2].Value;
                dtSelectedSeats.Rows.Add(row);

              

                int i = this.dgSeats.SelectedCells[0].RowIndex;

                dtSeats.Rows.RemoveAt(dgSeats.CurrentCell.RowIndex);
                

                dgAseats.DataSource = dtSelectedSeats;
                
            }




        }

        private void labelAntalFriplatser_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAntalFriplatser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxAntalFriplatser_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxAntalFriplatser.Text, "  ^ [0-9]"))
            {
                textBoxAntalFriplatser.Text = "";
            }
        }

        private void textBoxBeskrivning_Click(object sender, EventArgs e)
        {
            textBoxBeskrivning.BackColor = Color.White;
            labelAngeBeskrivningen.Visible = false;
        }

        private void test_Click(object sender, EventArgs e)
        {
         

        }

        private void dgActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgActs.SelectedRows[0].Index;

            selected_actid = int.Parse(dgActs[0, selectedIndex].Value.ToString());

            selected_actname = dgActs[1, selectedIndex].Value.ToString();
   

            
  


            dgTest.DataSource = dtSeats;
            dgSeats.DataSource = dtSeats;

            bs.DataSource = dtSelectedSeats;

            bs.Filter = string.Format("id = '{0}'", selected_actid);

            fs.DataSource = dtSeats;
            fs.Filter = string.Format("id = '{0}'", selected_actid);

            dgSeats.
           






        }

        private void textBoxAntalFriplatser_Click(object sender, EventArgs e)
        {
            textBoxAntalFriplatser.BackColor = Color.White;
            labelAngeStaplatser.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelAkter_Click(object sender, EventArgs e)
        {

        }
        public void loadSeats()
        {
            conn.Open();
            da = new NpgsqlDataAdapter("select distinct section from seats order by section", conn);
            dt = new DataTable();

            da.Fill(dt);

           
            conn.Close();

            conn.Open();
            da = new NpgsqlDataAdapter("select distinct rownumber from seats order by rownumber", conn);
            dt = new DataTable();

            da.Fill(dt);


            
            conn.Close();
        }
    }
}
