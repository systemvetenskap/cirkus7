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
        DataTable cSeats = new DataTable();
        DataTable dtActs, dtSelectedSeats, dt, dtSeats;
        BindingSource bs = new BindingSource();
        BindingSource fs = new BindingSource();
        NpgsqlDataAdapter da;
        public string name;
        int selected_actid;
        int selectedIndex;
        string addedshowid, addedactid;
        string selected_actname;
        private void seatmap()
        {
            string sid = selected_actid.ToString();
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;

            }

            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                foreach (DataRow row in cSeats.Rows)
                {
                    string s = row[2].ToString() + row[3].ToString();
                    lblS.Text = s;
                    if (row[0].ToString() == sid)
                    {
                        if (cb.Name == s)
                        {
                            cb.Checked = true;

                        }

                    }
                    else
                    {


                    }

                }

            }

        }
        public ShowForm()
        {
            InitializeComponent();


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

            if (dgActs.SelectedRows.Count > 0)
            {
                selectedIndex = dgActs.SelectedRows[0].Index;
                if (txtActname.Text == dgActs[2, selectedIndex].Value.ToString())
                {
                    DialogResult addAct = MessageBox.Show("Vill du ändra den valda akten?",
                    "Bekräftelse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (addAct == DialogResult.Yes)
                    {
                        dtActs.Rows[selectedIndex][1] = txtActname.Text.ToString();
                        dtActs.Rows[selectedIndex][2] = textBoxAntalFriplatser.Text.ToString();

                    }

                }
            }
            if (string.IsNullOrWhiteSpace(txtActname.Text))
            {
                labelAngeAkt.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                labelAngeStaplatser.Visible = true;
                return;

            }
            else
            {

                DataRow row = dtActs.NewRow();

                row[1] = txtActname.Text.ToString();
                row[2] = textBoxAntalFriplatser.Text.ToString();
                dtActs.Rows.Add(row);

                dgActs.DataSource = dtActs;

                this.dgActs.Columns[0].Visible = false;
                this.dgActs.Columns[2].Visible = false;
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
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        object value = dr[0];
                        if (value == DBNull.Value)
                        {
                            dr[0] = selected_actid;
                        }

                    }


                }

                //dgTest1.DataSource = dtSeats;
                txtActname.Clear();
                textBoxAntalFriplatser.Clear();

            }

        }

        private void buttonRaderaAkt_Click(object sender, EventArgs e)
        {
            DataRow row = dtActs.NewRow();

            row[1] = txtActname.Text.ToString();
            row[2] = textBoxAntalFriplatser.Text.ToString();

            if (dgActs.SelectedRows.Count>0)
            {
                dtActs.Rows.RemoveAt(dgActs.SelectedRows[0].Index);

                dgActs.DataSource = dtActs;

                this.dgActs.Columns[0].Visible = false;
                this.dgActs.Columns[2].Visible = false;
                dgActs.Columns[1].Width = 80;

                txtActname.Clear();
                textBoxAntalFriplatser.Clear();
                lblActRemove.Visible = false;
            }

            else
            {
                lblActRemove.Visible = true;
                return;
            }
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
            dtActs.Columns.Add("free_placement");
            dtSeats = new DataTable();
            dtSeats.Columns.Add("id");
            cSeats.Columns.Add("id");
            cSeats.Columns.Add("seatid");
            cSeats.Columns.Add("section");
            cSeats.Columns.Add("rownumber");





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
                sale_start = dateTimePickerForsaljningstidFran.Value.ToString("yyyy-MM-dd");
                sale_stop = dateTimePickerForsaljningstidTill.Value.ToString("yyyy-MM-dd");

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
                sale_start = dateTimePickerForsaljningstidFran.Value.ToString("yyyy-MM-dd");
                sale_stop = dateTimePickerForsaljningstidTill.Value.ToString("yyyy-MM-dd");

                int seat_number = Convert.ToInt16(textBoxAntalFriplatser.Text);

                conn.Open();

                command = new NpgsqlCommand(@"Insert into show (name, date, sale_start, sale_stop) Values (@name, @date, @sale_start, @sale_stop)", conn);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@sale_start", sale_start);
                command.Parameters.AddWithValue("@sale_stop", sale_stop);
                command.ExecuteNonQuery();
            
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
                    int fp = int.Parse(r[2].ToString());

                    conn.Open();
                    command = new NpgsqlCommand("insert into acts(name, showid, free_placement) values(:nm, :shid, :fp)", conn);
                    command.Parameters.Add(new NpgsqlParameter("nm", an));
                    command.Parameters.Add(new NpgsqlParameter("shid", addedshowid));
                    command.Parameters.Add(new NpgsqlParameter("fp", fp));
                    command.ExecuteNonQuery();



                    command = new NpgsqlCommand("select currval('acts_actid_seq');", conn);
                    read = command.ExecuteReader();
                    read.Read();
                    addedactid = read[0].ToString();
                    conn.Close();

                    

                    foreach (DataRow rw in cSeats.Rows)
                    {
                        if (int.Parse(rw[0].ToString()) == id)
                        {
                            int seatid = int.Parse(rw[1].ToString());
                            conn.Open();
                            command = new NpgsqlCommand("insert into available_seats(actid, seatid) values (:aid, :sid)", conn);
                            command.Parameters.Add(new NpgsqlParameter("aid", addedactid));
                            command.Parameters.Add(new NpgsqlParameter("sid", seatid));
                            command.ExecuteNonQuery();
                            conn.Close();

                            

                        }

                    }


                    
                }

                MessageBox.Show("Föreställning skapad");

                this.Close();
                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.LoadShows();
                frm.LoadAkter();
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

        private void textBoxBeskrivning_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelBeskrivning_Click(object sender, EventArgs e)
        {

        }



        private void textBoxBeskrivning_Click(object sender, EventArgs e)
        {

            textBoxBeskrivning.BackColor = Color.White;
            labelAngeBeskrivningen.Visible = false;
        }

        private void test_Click(object sender, EventArgs e)
        {


        }

        private void Sittplatser_Enter(object sender, EventArgs e)
        {

        }

        private void txtActname_Click(object sender, EventArgs e)
        {
            labelAngeAkt.Visible = false;
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {

            if (dgActs.Rows.Count > 0)
            {

                try
                {

                    if (cSeats.Rows.Count > 0)
                    {
                        for (int i = cSeats.Rows.Count - 1; i >= 0; i--)
                        {
                            string value = selected_actid.ToString();
                            DataRow dr = cSeats.Rows[i];
                            if (dr["id"].ToString() == value)
                                dr.Delete();
                        }
                    }
                    string seatSection;
                    string seatNumber;
                    foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
                    {
                        if (cb.Checked)
                        {
                            // Kollar först så att platsen finns!
                            seatSection = cb.Name[0].ToString();
                            seatNumber = cb.Name[1].ToString();

                            NpgsqlCommand command;
                            NpgsqlDataReader read;
                            conn.Open();
                            command = new NpgsqlCommand("SELECT seatid, section, rownumber FROM seats WHERE rownumber = @rwnr AND section = @section", conn);
                            command.Parameters.Add(new NpgsqlParameter("@rwnr", seatNumber));
                            command.Parameters.AddWithValue("@section", seatSection);

                            read = command.ExecuteReader();
                            read.Read();

                            DataRow row;
                            row = cSeats.NewRow();
                            row[0] = selected_actid.ToString();
                            row[1] = read[0].ToString();
                            row[2] = read[1].ToString();
                            row[3] = read[2].ToString();
                            cSeats.Rows.Add(row);

                            conn.Close();



                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.ToString());
                }


            }
            else
            {




            }
     
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {


    }

        private void check_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = true;

            }
        }

        private void uncheck_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in gpSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;

            }
        }

        private void dateTimePickerForsaljningstidFran_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelAngeStaplatser_Click(object sender, EventArgs e)
        {

        }

        private void dgActs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dgActs.SelectedRows[0].Index;

            selected_actid = int.Parse(dgActs[0, selectedIndex].Value.ToString());

            selected_actname = dgActs[1, selectedIndex].Value.ToString();
            textBoxAntalFriplatser.Text = dgActs[2, selectedIndex].Value.ToString();
            txtActname.Text = selected_actname;

            lblActMap.Text = selected_actname.ToString();
            
            seatmap();


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
        

    }
}
