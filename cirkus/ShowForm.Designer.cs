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
            this.listBoxAkter = new System.Windows.Forms.ListBox();
            this.labelBeskrivning = new System.Windows.Forms.Label();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelDatum = new System.Windows.Forms.Label();
            this.labelAntalFriplatser = new System.Windows.Forms.Label();
            this.labelForsaljningstid = new System.Windows.Forms.Label();
            this.textBoxAkter = new System.Windows.Forms.TextBox();
            this.textBoxAntalFriplatser = new System.Windows.Forms.TextBox();
            this.buttonLaggTIllForestallning = new System.Windows.Forms.Button();
            this.buttonSparaAndringar = new System.Windows.Forms.Button();
            this.buttonRaderaAkt = new System.Windows.Forms.Button();
            this.dateTimePickerForsaljningstidFran = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerForsaljningstidTill = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.listBoxT_platser = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSection = new System.Windows.Forms.ComboBox();
            this.comboBoxseatnumber = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonaddSeat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
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
            // 
            // listBoxAkter
            // 
            this.listBoxAkter.FormattingEnabled = true;
            this.listBoxAkter.Location = new System.Drawing.Point(30, 243);
            this.listBoxAkter.Name = "listBoxAkter";
            this.listBoxAkter.Size = new System.Drawing.Size(141, 56);
            this.listBoxAkter.TabIndex = 2;
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
            this.labelForsaljningstid.Location = new System.Drawing.Point(28, 418);
            this.labelForsaljningstid.Name = "labelForsaljningstid";
            this.labelForsaljningstid.Size = new System.Drawing.Size(108, 13);
            this.labelForsaljningstid.TabIndex = 14;
            this.labelForsaljningstid.Text = "Försäljningstid från/till";
            // 
            // textBoxAkter
            // 
            this.textBoxAkter.Location = new System.Drawing.Point(30, 189);
            this.textBoxAkter.Name = "textBoxAkter";
            this.textBoxAkter.Size = new System.Drawing.Size(100, 20);
            this.textBoxAkter.TabIndex = 21;
            // 
            // textBoxAntalFriplatser
            // 
            this.textBoxAntalFriplatser.Location = new System.Drawing.Point(30, 141);
            this.textBoxAntalFriplatser.Name = "textBoxAntalFriplatser";
            this.textBoxAntalFriplatser.Size = new System.Drawing.Size(100, 20);
            this.textBoxAntalFriplatser.TabIndex = 24;
            // 
            // buttonLaggTIllForestallning
            // 
            this.buttonLaggTIllForestallning.Location = new System.Drawing.Point(598, 442);
            this.buttonLaggTIllForestallning.Name = "buttonLaggTIllForestallning";
            this.buttonLaggTIllForestallning.Size = new System.Drawing.Size(100, 23);
            this.buttonLaggTIllForestallning.TabIndex = 29;
            this.buttonLaggTIllForestallning.Text = "Lägg till föreställningen";
            this.buttonLaggTIllForestallning.UseVisualStyleBackColor = true;
            this.buttonLaggTIllForestallning.Click += new System.EventHandler(this.buttonLaggTIllForestallning_Click);
            // 
            // buttonSparaAndringar
            // 
            this.buttonSparaAndringar.Location = new System.Drawing.Point(479, 442);
            this.buttonSparaAndringar.Name = "buttonSparaAndringar";
            this.buttonSparaAndringar.Size = new System.Drawing.Size(100, 23);
            this.buttonSparaAndringar.TabIndex = 30;
            this.buttonSparaAndringar.Text = "Spara ändringar";
            this.buttonSparaAndringar.UseVisualStyleBackColor = true;
            this.buttonSparaAndringar.Click += new System.EventHandler(this.buttonSparaAndringar_Click);
            // 
            // buttonRaderaAkt
            // 
            this.buttonRaderaAkt.Location = new System.Drawing.Point(177, 276);
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
            this.dateTimePickerForsaljningstidFran.Location = new System.Drawing.Point(30, 434);
            this.dateTimePickerForsaljningstidFran.Name = "dateTimePickerForsaljningstidFran";
            this.dateTimePickerForsaljningstidFran.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerForsaljningstidFran.TabIndex = 32;
            // 
            // dateTimePickerForsaljningstidTill
            // 
            this.dateTimePickerForsaljningstidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidTill.Location = new System.Drawing.Point(209, 434);
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
            // listBoxT_platser
            // 
            this.listBoxT_platser.FormattingEnabled = true;
            this.listBoxT_platser.Location = new System.Drawing.Point(30, 323);
            this.listBoxT_platser.Name = "listBoxT_platser";
            this.listBoxT_platser.Size = new System.Drawing.Size(139, 56);
            this.listBoxT_platser.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tillgängliga sittplatser i akten";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxSection
            // 
            this.comboBoxSection.FormattingEnabled = true;
            this.comboBoxSection.Location = new System.Drawing.Point(187, 358);
            this.comboBoxSection.Name = "comboBoxSection";
            this.comboBoxSection.Size = new System.Drawing.Size(50, 21);
            this.comboBoxSection.TabIndex = 39;
            // 
            // comboBoxseatnumber
            // 
            this.comboBoxseatnumber.FormattingEnabled = true;
            this.comboBoxseatnumber.Location = new System.Drawing.Point(243, 358);
            this.comboBoxseatnumber.Name = "comboBoxseatnumber";
            this.comboBoxseatnumber.Size = new System.Drawing.Size(64, 21);
            this.comboBoxseatnumber.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Sektion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Platsnummer";
            // 
            // buttonaddSeat
            // 
            this.buttonaddSeat.Location = new System.Drawing.Point(322, 356);
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
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(728, 477);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonaddSeat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxseatnumber);
            this.Controls.Add(this.comboBoxSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxT_platser);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.dateTimePickerForsaljningstidTill);
            this.Controls.Add(this.dateTimePickerForsaljningstidFran);
            this.Controls.Add(this.buttonRaderaAkt);
            this.Controls.Add(this.buttonSparaAndringar);
            this.Controls.Add(this.buttonLaggTIllForestallning);
            this.Controls.Add(this.textBoxAntalFriplatser);
            this.Controls.Add(this.textBoxAkter);
            this.Controls.Add(this.labelForsaljningstid);
            this.Controls.Add(this.labelAntalFriplatser);
            this.Controls.Add(this.labelDatum);
            this.Controls.Add(this.labelAkter);
            this.Controls.Add(this.labelBeskrivning);
            this.Controls.Add(this.listBoxAkter);
            this.Controls.Add(this.textBoxBeskrivning);
            this.Controls.Add(this.buttonLaggTillAkt);
            this.Name = "ShowForm";
            this.Text = "Forestallning";
            this.Load += new System.EventHandler(this.ShowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLaggTillAkt;
        private System.Windows.Forms.TextBox textBoxBeskrivning;
        private System.Windows.Forms.ListBox listBoxAkter;
        private System.Windows.Forms.Label labelBeskrivning;
        private System.Windows.Forms.Label labelAkter;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Label labelAntalFriplatser;
        private System.Windows.Forms.Label labelForsaljningstid;
        private System.Windows.Forms.TextBox textBoxAkter;
        private System.Windows.Forms.TextBox textBoxAntalFriplatser;
        private System.Windows.Forms.Button buttonLaggTIllForestallning;
        private System.Windows.Forms.Button buttonSparaAndringar;
        private System.Windows.Forms.Button buttonRaderaAkt;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidFran;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidTill;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.ListBox listBoxT_platser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSection;
        private System.Windows.Forms.ComboBox comboBoxseatnumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonaddSeat;
        private System.Windows.Forms.Label label4;
    }
}