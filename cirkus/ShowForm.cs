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
    public partial class ShowForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432; User Id=pgmvaru_g7;Password=akrobatik;Database=pgmvaru_g7;SSL=true;");

        public ShowForm()
        {
            InitializeComponent();
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
                listBoxAkterPris.Items.Add(newAct);
                listBoxAkterPris.SelectedIndex = 0;
            }

        }

        private void buttonRaderaAkt_Click(object sender, EventArgs e)
        {
            if (listBoxAkterPris.Items.Count != -1)
            {
                listBoxAkterPris.Items.RemoveAt(listBoxAkterPris.SelectedIndex);
            }
            
            else
            {
                MessageBox.Show("Listan är redan tom");
            }
        }

        private void ShowForm_Load(object sender, EventArgs e)
        {
            comboBoxAldersgrupp.Items[0] = "Vuxenbil";
        }

        private void buttonSparaAndringar_Click(object sender, EventArgs e)
        {

        }

        private void buttonLaggTIllForestallning_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBeskrivning.Text))
            {
                MessageBox.Show("Du måste ange beskrivning");
            }

            else
            {
                string name, date;

                name = textBoxBeskrivning.Text;
                date = dateTimePickerDatum.Text;
                int seat_number = Convert.ToInt16(textBoxAntalFriplatser.Text);

                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"Insert into show (name, seat_number, date) Values (@name, @seat_number, @date)", conn);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@seat_number", seat_number);
                command.ExecuteNonQuery();

                //NpgsqlCommand command2 = new NpgsqlCommand("'select currval(show_showid_seq)';", conn);
                //NpgsqlDataReader read;
                //read = command.ExecuteReader();

                //read.Read();
                //string showid = read[0].ToString();

                this.Close();
                conn.Close();
                
            }
        }

        
    
    }
}
