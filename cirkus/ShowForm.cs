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
        #region Main
        public string name;
        private NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        private NpgsqlCommand command;
        private NpgsqlDataAdapter da;
        private DataTable cSeats = new DataTable();
        private DataTable dtActs, dtSelectedSeats, dtSeats;
        private BindingSource bs = new BindingSource();
        private BindingSource fs = new BindingSource();
        private int selected_actid;
        private int selectedIndex;
        private string addedshowid, addedactid;
        private string selected_actname;

        public ShowForm()
        {
            InitializeComponent();
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
            dtActs.Columns.Add("start_time");
            dtActs.Columns.Add("end_time");
            dtSeats = new DataTable();
            dtSeats.Columns.Add("id");
            cSeats.Columns.Add("id");
            cSeats.Columns.Add("seatid");
            cSeats.Columns.Add("section");
            cSeats.Columns.Add("rownumber");

            label1.Text = "Börja med att välja en form!";
        }
        private void buttonSparaAndringar_Click(object sender, EventArgs e)
        {
            bool allowAdd = true;
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                //MessageBox.Show("Du måste ange beskrivning");
                textBoxBeskrivning.BackColor = Color.Tomato;

                allowAdd = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange antal ståplatser";
                textBoxAntalFriplatser.BackColor = Color.Tomato;

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
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Ändringarna har sparats";
            }
        }
        private void buttonLaggTIllForestallning_Click(object sender, EventArgs e)
        {
            bool allowAdd = true;
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                textBoxBeskrivning.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange ett namn för föreställningen";
                allowAdd = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Ange antal ståplatser för föreställningen";
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
                    string st = r[3].ToString();
                    string et = r[4].ToString();

                    conn.Open();
                    command = new NpgsqlCommand("insert into acts(name, showid, free_placement, start_time, end_time) values(:nm, :shid, :fp, :st, :et)", conn);
                    command.Parameters.Add(new NpgsqlParameter("nm", an));
                    command.Parameters.Add(new NpgsqlParameter("shid", addedshowid));
                    command.Parameters.Add(new NpgsqlParameter("fp", fp));
                    command.Parameters.Add(new NpgsqlParameter("st", st));
                    command.Parameters.Add(new NpgsqlParameter("et", et));
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
        #endregion
        #region Föreställning
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
                txtActname.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Skriv ett namn för akten";
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Skriv in antal ståplatser för akten";
                return;

            }
            else
            {
                DataRow row = dtActs.NewRow();

                row[1] = txtActname.Text.ToString();
                row[2] = textBoxAntalFriplatser.Text.ToString();
                row[3] = timeStart.Text;
                row[4] = timeEnd.Text;

                dtActs.Rows.Add(row);

                dgActs.DataSource = dtActs;

                this.dgActs.Columns[0].Visible = false;
                this.dgActs.Columns[2].Visible = false;
                dgActs.Columns[1].Width = 80;
                dgActs.ClearSelection();

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
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Akten är tillagd i föreställningen";
                txtActname.BackColor = Color.White;
                textBoxAntalFriplatser.BackColor = Color.White;
                txtActname.Clear();
                textBoxAntalFriplatser.Clear();
            }

        }
        private void buttonRaderaAkt_Click(object sender, EventArgs e)
        {
            DataRow row = dtActs.NewRow();

            row[1] = txtActname.Text.ToString();
            row[2] = textBoxAntalFriplatser.Text.ToString();

            if (dgActs.SelectedRows.Count > 0)
            {
                dtActs.Rows.RemoveAt(dgActs.SelectedRows[0].Index);

                dgActs.DataSource = dtActs;

                this.dgActs.Columns[0].Visible = false;
                this.dgActs.Columns[2].Visible = false;
                dgActs.Columns[1].Width = 80;

                txtActname.Clear();
                textBoxAntalFriplatser.Clear();

            }

            else
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Tomato;
                lblStatus.Text = "Välj en akt att ta bort först";
                return;
            }
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
        private void textBoxBeskrivning_Click(object sender, EventArgs e)
        {

            textBoxBeskrivning.BackColor = Color.White;

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
        }
        #endregion
        #region Karta
        private struct Section
        {
            public string name;
            public int row;
            public int column;

            public override string ToString()
            {
                return name;
            }
        }
        private List<Section> sectionList = new List<Section>();
        private List<Button> seatList = new List<Button>();
        private int actionIndex = -2;

        private void seatmap()
        {
            string sid = selected_actid.ToString();
            foreach (CheckBox cb in groupBoxSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;

            }

            foreach (CheckBox cb in groupBoxSeatMap.Controls.OfType<CheckBox>())
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
                }
            }
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
                    foreach (CheckBox cb in groupBoxSeatMap.Controls.OfType<CheckBox>())
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

                            lblLayout.Visible = true;
                            lblLayout.ForeColor = Color.Green;
                            lblLayout.Text = "Layout för vald akt sparad";
                            lblStatus.Visible = false;
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
        private void check_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in groupBoxSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = true;

            }
        }
        private void uncheck_Click(object sender, EventArgs e)
        {
            foreach (CheckBox cb in groupBoxSeatMap.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;

            }
        }
        private void comboBoxMapShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionIndex == -2)
            {
                actionIndex++;
            }
            //loadPicture();
            pictureBoxSeatMap.Refresh();
        }
        private void buttonAddSection_Click(object sender, EventArgs e)
        {
            Section sec = new Section();
            sec.row = (int)numericUpDownRow.Value;
            sec.column = (int)numericUpDownColumn.Value;
            sec.name = textBoxSection.Text;
            sectionList.Add(sec);
            listBoxSections.Items.Add(sec);
        }
        private void buttonRemoveSection_Click(object sender, EventArgs e)
        {
            if (listBoxSections.SelectedIndex != -1)
            {
                sectionList.Remove((Section)listBoxSections.SelectedItem);
                listBoxSections.Items.RemoveAt(listBoxSections.SelectedIndex);
            }
            MessageBox.Show(sectionList.Count.ToString());
        }
        private void pictureBoxSeatMap_Click(object sender, EventArgs e)
        {
            Point location = pictureBoxSeatMap.PointToClient(Cursor.Position);
            if(actionIndex == -1) 
            {
                Label orc = new Label();
                orc.Location = location;
                orc.Text = "Orkester";
                groupBoxSeatMap.Controls.Add(orc);
                orc.BringToFront();
                actionIndex++;
            } else if(actionIndex >=0 && actionIndex < sectionList.Count)
            {
                Button seat = new Button();
                seat.Location = location;
                seat.Name = "buttonNyKnapp";
                seat.Text = sectionList[actionIndex].name;
                seat.UseVisualStyleBackColor = true;
                //seat.Click += new System.EventHandler(seat_click);
                groupBoxSeatMap.Controls.Add(seat);
                seat.BringToFront();
                seatList.Add(seat);
                actionIndex++;
            }
        }
        private void pictureBoxSeatMap_Paint(object sender, PaintEventArgs e)
        {
            if (comboBoxMapShape.SelectedIndex != -1)
            {
                string selectedShape = comboBoxMapShape.SelectedItem.ToString();
                Graphics g = e.Graphics;
                Rectangle rect = new Rectangle(0, 0, 3 * (int)numericUpDownX.Value, 3 * (int)numericUpDownY.Value);

                switch (selectedShape)
                {
                    case "Rektangel":
                        g.DrawRectangle(Pens.Black, rect);
                        break;
                    case "Cirkel":
                        g.DrawEllipse(Pens.Black, rect);
                        break;
                    default:
                        g.DrawRectangle(Pens.Red, rect);
                        break;
                }
            }
        }
        private void listBoxSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSections.SelectedIndex != -1)
            {
                buttonRemoveSection.Enabled = true;
            }
            else
            {
                buttonRemoveSection.Enabled = false;
            }
        }
        /*private void loadPicture()
{
OpenFileDialog fd = new OpenFileDialog();
fd.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
fd.AddExtension = true;
if (fd.ShowDialog() == DialogResult.OK)
{
pbSeatMap.Image = Image.FromFile(fd.FileName);
}
}*/
        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxSeatMap.Refresh();
        }
        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxSeatMap.Refresh();
        }
        #endregion
    }
}
