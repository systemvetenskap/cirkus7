namespace cirkus
{
    partial class ShowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLaggTillAkt = new System.Windows.Forms.Button();
            this.textBoxBeskrivning = new System.Windows.Forms.TextBox();
            this.labelBeskrivning = new System.Windows.Forms.Label();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelDatum = new System.Windows.Forms.Label();
            this.labelAntalFriplatser = new System.Windows.Forms.Label();
            this.labelForsaljningstid = new System.Windows.Forms.Label();
            this.txtActname = new System.Windows.Forms.TextBox();
            this.textBoxAntalFriplatser = new System.Windows.Forms.TextBox();
            this.buttonLaggTIllForestallning = new System.Windows.Forms.Button();
            this.buttonSparaAndringar = new System.Windows.Forms.Button();
            this.buttonRaderaAkt = new System.Windows.Forms.Button();
            this.dateTimePickerForsaljningstidFran = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerForsaljningstidTill = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonaddSeat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAngeBeskrivningen = new System.Windows.Forms.Label();
            this.labelAngeAkt = new System.Windows.Forms.Label();
            this.labelAngeStaplatser = new System.Windows.Forms.Label();
            this.textBoxSeats = new System.Windows.Forms.TextBox();
            this.dgSeats = new System.Windows.Forms.DataGridView();
            this.dgAseats = new System.Windows.Forms.DataGridView();
            this.dgActs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAseats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLaggTillAkt
            // 
            this.buttonLaggTillAkt.Location = new System.Drawing.Point(137, 189);
            this.buttonLaggTillAkt.Name = "buttonLaggTillAkt";
            this.buttonLaggTillAkt.Size = new System.Drawing.Size(100, 23);
            this.buttonLaggTillAkt.TabIndex = 0;
            this.buttonLaggTillAkt.Text = "Lägg till i listan";
            this.buttonLaggTillAkt.UseVisualStyleBackColor = true;
            this.buttonLaggTillAkt.Click += new System.EventHandler(this.buttonLaggTillAkt_Click);
            // 
            // textBoxBeskrivning
            // 
            this.textBoxBeskrivning.Location = new System.Drawing.Point(30, 46);
            this.textBoxBeskrivning.Name = "textBoxBeskrivning";
            this.textBoxBeskrivning.Size = new System.Drawing.Size(100, 20);
            this.textBoxBeskrivning.TabIndex = 1;
            this.textBoxBeskrivning.Click += new System.EventHandler(this.textBoxBeskrivning_Click);
            // 
            // labelBeskrivning
            // 
            this.labelBeskrivning.AutoSize = true;
            this.labelBeskrivning.Location = new System.Drawing.Point(28, 30);
            this.labelBeskrivning.Name = "labelBeskrivning";
            this.labelBeskrivning.Size = new System.Drawing.Size(62, 13);
            this.labelBeskrivning.TabIndex = 4;
            this.labelBeskrivning.Text = "Beskrivning";
            // 
            // labelAkter
            // 
            this.labelAkter.AutoSize = true;
            this.labelAkter.Location = new System.Drawing.Point(29, 170);
            this.labelAkter.Name = "labelAkter";
            this.labelAkter.Size = new System.Drawing.Size(49, 13);
            this.labelAkter.TabIndex = 9;
            this.labelAkter.Text = "Aktnamn";
            this.labelAkter.Click += new System.EventHandler(this.labelAkter_Click);
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(32, 78);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(38, 13);
            this.labelDatum.TabIndex = 11;
            this.labelDatum.Text = "Datum";
            // 
            // labelAntalFriplatser
            // 
            this.labelAntalFriplatser.AutoSize = true;
            this.labelAntalFriplatser.Location = new System.Drawing.Point(29, 125);
            this.labelAntalFriplatser.Name = "labelAntalFriplatser";
            this.labelAntalFriplatser.Size = new System.Drawing.Size(79, 13);
            this.labelAntalFriplatser.TabIndex = 12;
            this.labelAntalFriplatser.Text = "Antal ståplatser";
            this.labelAntalFriplatser.Click += new System.EventHandler(this.labelAntalFriplatser_Click);
            // 
            // labelForsaljningstid
            // 
            this.labelForsaljningstid.AutoSize = true;
            this.labelForsaljningstid.Location = new System.Drawing.Point(44, 498);
            this.labelForsaljningstid.Name = "labelForsaljningstid";
            this.labelForsaljningstid.Size = new System.Drawing.Size(108, 13);
            this.labelForsaljningstid.TabIndex = 14;
            this.labelForsaljningstid.Text = "Försäljningstid från/till";
            // 
            // txtActname
            // 
            this.txtActname.Location = new System.Drawing.Point(30, 189);
            this.txtActname.Name = "txtActname";
            this.txtActname.Size = new System.Drawing.Size(100, 20);
            this.txtActname.TabIndex = 21;
            // 
            // textBoxAntalFriplatser
            // 
            this.textBoxAntalFriplatser.Location = new System.Drawing.Point(30, 141);
            this.textBoxAntalFriplatser.Name = "textBoxAntalFriplatser";
            this.textBoxAntalFriplatser.Size = new System.Drawing.Size(100, 20);
            this.textBoxAntalFriplatser.TabIndex = 24;
            this.textBoxAntalFriplatser.Click += new System.EventHandler(this.textBoxAntalFriplatser_Click);
            this.textBoxAntalFriplatser.TextChanged += new System.EventHandler(this.textBoxAntalFriplatser_TextChanged);
            this.textBoxAntalFriplatser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAntalFriplatser_KeyPress);
            // 
            // buttonLaggTIllForestallning
            // 
            this.buttonLaggTIllForestallning.Location = new System.Drawing.Point(751, 457);
            this.buttonLaggTIllForestallning.Name = "buttonLaggTIllForestallning";
            this.buttonLaggTIllForestallning.Size = new System.Drawing.Size(155, 23);
            this.buttonLaggTIllForestallning.TabIndex = 29;
            this.buttonLaggTIllForestallning.Text = "Skapa föreställning";
            this.buttonLaggTIllForestallning.UseVisualStyleBackColor = true;
            this.buttonLaggTIllForestallning.Click += new System.EventHandler(this.buttonLaggTIllForestallning_Click);
            // 
            // buttonSparaAndringar
            // 
            this.buttonSparaAndringar.Location = new System.Drawing.Point(630, 457);
            this.buttonSparaAndringar.Name = "buttonSparaAndringar";
            this.buttonSparaAndringar.Size = new System.Drawing.Size(100, 23);
            this.buttonSparaAndringar.TabIndex = 30;
            this.buttonSparaAndringar.Text = "Spara ändringar";
            this.buttonSparaAndringar.UseVisualStyleBackColor = true;
            this.buttonSparaAndringar.Click += new System.EventHandler(this.buttonSparaAndringar_Click);
            // 
            // buttonRaderaAkt
            // 
            this.buttonRaderaAkt.Location = new System.Drawing.Point(165, 302);
            this.buttonRaderaAkt.Name = "buttonRaderaAkt";
            this.buttonRaderaAkt.Size = new System.Drawing.Size(100, 23);
            this.buttonRaderaAkt.TabIndex = 31;
            this.buttonRaderaAkt.Text = "Radera akt";
            this.buttonRaderaAkt.UseVisualStyleBackColor = true;
            this.buttonRaderaAkt.Click += new System.EventHandler(this.buttonRaderaAkt_Click);
            // 
            // dateTimePickerForsaljningstidFran
            // 
            this.dateTimePickerForsaljningstidFran.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidFran.Location = new System.Drawing.Point(46, 514);
            this.dateTimePickerForsaljningstidFran.Name = "dateTimePickerForsaljningstidFran";
            this.dateTimePickerForsaljningstidFran.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerForsaljningstidFran.TabIndex = 32;
            // 
            // dateTimePickerForsaljningstidTill
            // 
            this.dateTimePickerForsaljningstidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidTill.Location = new System.Drawing.Point(225, 514);
            this.dateTimePickerForsaljningstidTill.Name = "dateTimePickerForsaljningstidTill";
            this.dateTimePickerForsaljningstidTill.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerForsaljningstidTill.TabIndex = 33;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatum.Location = new System.Drawing.Point(31, 94);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDatum.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tillgängliga sittplatser i akten";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonaddSeat
            // 
            this.buttonaddSeat.Location = new System.Drawing.Point(497, 457);
            this.buttonaddSeat.Name = "buttonaddSeat";
            this.buttonaddSeat.Size = new System.Drawing.Size(100, 23);
            this.buttonaddSeat.TabIndex = 43;
            this.buttonaddSeat.Text = "Lägg till ";
            this.buttonaddSeat.UseVisualStyleBackColor = true;
            this.buttonaddSeat.Click += new System.EventHandler(this.buttonaddSeat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Tillagda akter";
            // 
            // labelAngeBeskrivningen
            // 
            this.labelAngeBeskrivningen.AutoSize = true;
            this.labelAngeBeskrivningen.BackColor = System.Drawing.Color.White;
            this.labelAngeBeskrivningen.ForeColor = System.Drawing.Color.Red;
            this.labelAngeBeskrivningen.Location = new System.Drawing.Point(136, 49);
            this.labelAngeBeskrivningen.Name = "labelAngeBeskrivningen";
            this.labelAngeBeskrivningen.Size = new System.Drawing.Size(148, 13);
            this.labelAngeBeskrivningen.TabIndex = 45;
            this.labelAngeBeskrivningen.Text = "Du måste ange beskrivningen";
            this.labelAngeBeskrivningen.Visible = false;
            // 
            // labelAngeAkt
            // 
            this.labelAngeAkt.AutoSize = true;
            this.labelAngeAkt.BackColor = System.Drawing.Color.White;
            this.labelAngeAkt.ForeColor = System.Drawing.Color.Red;
            this.labelAngeAkt.Location = new System.Drawing.Point(243, 199);
            this.labelAngeAkt.Name = "labelAngeAkt";
            this.labelAngeAkt.Size = new System.Drawing.Size(153, 13);
            this.labelAngeAkt.TabIndex = 46;
            this.labelAngeAkt.Text = "Du måste lägga till minst en akt";
            this.labelAngeAkt.Visible = false;
            // 
            // labelAngeStaplatser
            // 
            this.labelAngeStaplatser.AutoSize = true;
            this.labelAngeStaplatser.BackColor = System.Drawing.Color.White;
            this.labelAngeStaplatser.ForeColor = System.Drawing.Color.Red;
            this.labelAngeStaplatser.Location = new System.Drawing.Point(136, 144);
            this.labelAngeStaplatser.Name = "labelAngeStaplatser";
            this.labelAngeStaplatser.Size = new System.Drawing.Size(129, 13);
            this.labelAngeStaplatser.TabIndex = 47;
            this.labelAngeStaplatser.Text = "Du måste antal ståplatser ";
            this.labelAngeStaplatser.Visible = false;
            // 
            // textBoxSeats
            // 
            this.textBoxSeats.Location = new System.Drawing.Point(296, 339);
            this.textBoxSeats.Name = "textBoxSeats";
            this.textBoxSeats.Size = new System.Drawing.Size(92, 20);
            this.textBoxSeats.TabIndex = 49;
            // 
            // dgSeats
            // 
            this.dgSeats.AllowUserToAddRows = false;
            this.dgSeats.AllowUserToDeleteRows = false;
            this.dgSeats.AllowUserToResizeColumns = false;
            this.dgSeats.AllowUserToResizeRows = false;
            this.dgSeats.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSeats.ColumnHeadersVisible = false;
            this.dgSeats.Location = new System.Drawing.Point(264, 365);
            this.dgSeats.Name = "dgSeats";
            this.dgSeats.ReadOnly = true;
            this.dgSeats.RowHeadersVisible = false;
            this.dgSeats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSeats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSeats.Size = new System.Drawing.Size(227, 115);
            this.dgSeats.TabIndex = 48;
            // 
            // dgAseats
            // 
            this.dgAseats.AllowUserToAddRows = false;
            this.dgAseats.AllowUserToDeleteRows = false;
            this.dgAseats.AllowUserToResizeColumns = false;
            this.dgAseats.AllowUserToResizeRows = false;
            this.dgAseats.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgAseats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAseats.ColumnHeadersVisible = false;
            this.dgAseats.Location = new System.Drawing.Point(30, 365);
            this.dgAseats.Name = "dgAseats";
            this.dgAseats.ReadOnly = true;
            this.dgAseats.RowHeadersVisible = false;
            this.dgAseats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAseats.Size = new System.Drawing.Size(188, 115);
            this.dgAseats.TabIndex = 50;
            // 
            // dgActs
            // 
            this.dgActs.AllowUserToAddRows = false;
            this.dgActs.AllowUserToDeleteRows = false;
            this.dgActs.AllowUserToResizeColumns = false;
            this.dgActs.AllowUserToResizeRows = false;
            this.dgActs.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActs.ColumnHeadersVisible = false;
            this.dgActs.Location = new System.Drawing.Point(30, 243);
            this.dgActs.Name = "dgActs";
            this.dgActs.ReadOnly = true;
            this.dgActs.RowHeadersVisible = false;
            this.dgActs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActs.Size = new System.Drawing.Size(124, 82);
            this.dgActs.TabIndex = 51;
            this.dgActs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActs_CellClick);
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(947, 714);
            this.Controls.Add(this.dgActs);
            this.Controls.Add(this.dgAseats);
            this.Controls.Add(this.textBoxSeats);
            this.Controls.Add(this.dgSeats);
            this.Controls.Add(this.labelAngeStaplatser);
            this.Controls.Add(this.labelAngeAkt);
            this.Controls.Add(this.labelAngeBeskrivningen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonaddSeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.dateTimePickerForsaljningstidTill);
            this.Controls.Add(this.dateTimePickerForsaljningstidFran);
            this.Controls.Add(this.buttonRaderaAkt);
            this.Controls.Add(this.buttonSparaAndringar);
            this.Controls.Add(this.buttonLaggTIllForestallning);
            this.Controls.Add(this.textBoxAntalFriplatser);
            this.Controls.Add(this.txtActname);
            this.Controls.Add(this.labelForsaljningstid);
            this.Controls.Add(this.labelAntalFriplatser);
            this.Controls.Add(this.labelDatum);
            this.Controls.Add(this.labelAkter);
            this.Controls.Add(this.labelBeskrivning);
            this.Controls.Add(this.textBoxBeskrivning);
            this.Controls.Add(this.buttonLaggTillAkt);
            this.Name = "ShowForm";
            this.Text = "Forestallning";
            this.Load += new System.EventHandler(this.ShowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAseats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLaggTillAkt;
        private System.Windows.Forms.TextBox textBoxBeskrivning;
        private System.Windows.Forms.Label labelBeskrivning;
        private System.Windows.Forms.Label labelAkter;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Label labelAntalFriplatser;
        private System.Windows.Forms.Label labelForsaljningstid;
        private System.Windows.Forms.TextBox txtActname;
        private System.Windows.Forms.TextBox textBoxAntalFriplatser;
        private System.Windows.Forms.Button buttonLaggTIllForestallning;
        private System.Windows.Forms.Button buttonSparaAndringar;
        private System.Windows.Forms.Button buttonRaderaAkt;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidFran;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidTill;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonaddSeat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAngeBeskrivningen;
        private System.Windows.Forms.Label labelAngeAkt;
        private System.Windows.Forms.Label labelAngeStaplatser;
        private System.Windows.Forms.TextBox textBoxSeats;
        private System.Windows.Forms.DataGridView dgSeats;
        private System.Windows.Forms.DataGridView dgAseats;
        private System.Windows.Forms.DataGridView dgActs;
    }
}