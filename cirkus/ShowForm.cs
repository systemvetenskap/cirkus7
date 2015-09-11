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
using System.IO;

namespace cirkus
{
    public partial class ShowForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");
        string addedshowid, acts, section, seat_number;
        NpgsqlCommand command;
        DataTable dt;
        NpgsqlDataAdapter da;
        public string Name;

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
            //NpgsqlCommand cmd = new NpgsqlCommand("select * from show where showid = '" + Name + "'", conn);
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
                listBoxAkter.Items.Add(dr.GetValue(1).ToString());
                listBoxAkter.SelectedIndex = 0;
            }
            conn.Close();
        }


        private void buttonLaggTillAkt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAkter.Text))
            {
                MessageBox.Show("Du måste ange akt i textboxen");
            }

            else
            {
                Act newAct = new Act();

                newAct.name = textBoxAkter.Text;
                listBoxAkter.Items.Add(newAct);
                listBoxAkter.SelectedIndex = 0;
                textBoxAkter.Text = "";
                listBoxAkter.BackColor = Color.White;
                labelAngeAkt.Visible = false;
            }

        }

        private void buttonRaderaAkt_Click(object sender, EventArgs e)
        {
            if (listBoxAkter.Items.Count != 0)
            {
                listBoxAkter.Items.RemoveAt(listBoxAkter.SelectedIndex);
            }

            else
            {
                MessageBox.Show("Listan är redan tom");
            }
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSparaAndringar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                //MessageBox.Show("Du måste ange beskrivning");
                textBoxBeskrivning.BackColor = Color.Tomato;
                labelAngeBeskrivningen.Visible = true;
            }

            if (listBoxAkter.Items.Count == 0)
            {
                listBoxAkter.BackColor = Color.Tomato;
                labelAngeAkt.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                labelAngeStaplatser.Visible = true;
            }

            else
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

                //for (int i = 0; i < listBoxAkter.Items.Count; i++)
                //{
                //    acts = listBoxAkter.Items[i].ToString();
                //    conn.Open();
                //    command = new NpgsqlCommand(@"Insert into acts (name, showid) Values (@name, @showid)", conn);
                //    command.Parameters.AddWithValue("@name", acts);
                //    command.Parameters.AddWithValue("@showid", addedshowid);
                //    command.ExecuteNonQuery();
                //    conn.Close();
                //}

                this.Close();
                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.LoadShows();

                MessageBox.Show("Ändringarna har sparats!");
            }
        }

        private void buttonLaggTIllForestallning_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                //MessageBox.Show("Du måste ange beskrivning");
                textBoxBeskrivning.BackColor = Color.Tomato;
                labelAngeBeskrivningen.Visible = true;
            }

            if (listBoxAkter.Items.Count == 0)
            {
                listBoxAkter.BackColor = Color.Tomato;
                labelAngeAkt.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(textBoxAntalFriplatser.Text))
            {
                textBoxAntalFriplatser.BackColor = Color.Tomato;
                labelAngeStaplatser.Visible = true;
            }

            else
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

                for (int i = 0; i < listBoxAkter.Items.Count; i++)
                {
                    acts = listBoxAkter.Items[i].ToString();
                    conn.Open();
                    command = new NpgsqlCommand(@"Insert into acts (name, showid) Values (@name, @showid)", conn);
                    command.Parameters.AddWithValue("@name", acts);
                    command.Parameters.AddWithValue("@showid", addedshowid);
                    command.ExecuteNonQuery();
                    conn.Close();
                }

                this.Close();
                var frm = Application.OpenForms.OfType<MainForm>().Single();
                frm.LoadShows();
            }
        }

        private void buttonaddSeat_Click(object sender, EventArgs e)
        {

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

            comboBoxSection.DataSource = dt;
            comboBoxSection.DisplayMember = "section";
            conn.Close();

            conn.Open();
            da = new NpgsqlDataAdapter("select distinct rownumber from seats order by rownumber", conn);
            dt = new DataTable();

            da.Fill(dt);


            comboBoxseatnumber.DataSource = dt;
            comboBoxseatnumber.DisplayMember = "rownumber";
            conn.Close();
        }
    }
}
