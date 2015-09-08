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
            this.listBoxAkterPris = new System.Windows.Forms.ListBox();
            this.labelBeskrivning = new System.Windows.Forms.Label();
            this.labelBarnPris = new System.Windows.Forms.Label();
            this.labelUngdomPris = new System.Windows.Forms.Label();
            this.labelVuxenPris = new System.Windows.Forms.Label();
            this.labelPris = new System.Windows.Forms.Label();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelAldersgrupp = new System.Windows.Forms.Label();
            this.labelDatum = new System.Windows.Forms.Label();
            this.labelAntalFriplatser = new System.Windows.Forms.Label();
            this.labelAntalFastplatser = new System.Windows.Forms.Label();
            this.labelForsaljningstid = new System.Windows.Forms.Label();
            this.labelFriplatser = new System.Windows.Forms.Label();
            this.labelFastplatser = new System.Windows.Forms.Label();
            this.textBoxFastplatserVuxen = new System.Windows.Forms.TextBox();
            this.textBoxFriplatserVuxen = new System.Windows.Forms.TextBox();
            this.textBoxFastplatserUngdom = new System.Windows.Forms.TextBox();
            this.textBoxFastplatserBarn = new System.Windows.Forms.TextBox();
            this.textBoxAkter = new System.Windows.Forms.TextBox();
            this.textBoxAntalFriplatser = new System.Windows.Forms.TextBox();
            this.textBoxFriplatserUngdom = new System.Windows.Forms.TextBox();
            this.textBoxAntalFastplatser = new System.Windows.Forms.TextBox();
            this.textBoxFriplatserBarn = new System.Windows.Forms.TextBox();
            this.buttonLaggTIllForestallning = new System.Windows.Forms.Button();
            this.buttonSparaAndringar = new System.Windows.Forms.Button();
            this.buttonRaderaAkt = new System.Windows.Forms.Button();
            this.dateTimePickerForsaljningstidFran = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerForsaljningstidTill = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAldersgrupp = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonLaggTillAkt
            // 
            this.buttonLaggTillAkt.Location = new System.Drawing.Point(158, 267);
            this.buttonLaggTillAkt.Name = "buttonLaggTillAkt";
            this.buttonLaggTillAkt.Size = new System.Drawing.Size(100, 23);
            this.buttonLaggTillAkt.TabIndex = 0;
            this.buttonLaggTillAkt.Text = "Lägg till i listan";
            this.buttonLaggTillAkt.UseVisualStyleBackColor = true;
            this.buttonLaggTillAkt.Click += new System.EventHandler(this.buttonLaggTillAkt_Click);
            // 
            // textBoxBeskrivning
            // 
            this.textBoxBeskrivning.Location = new System.Drawing.Point(31, 48);
            this.textBoxBeskrivning.Name = "textBoxBeskrivning";
            this.textBoxBeskrivning.Size = new System.Drawing.Size(100, 20);
            this.textBoxBeskrivning.TabIndex = 1;
            // 
            // listBoxAkterPris
            // 
            this.listBoxAkterPris.FormattingEnabled = true;
            this.listBoxAkterPris.Location = new System.Drawing.Point(282, 267);
            this.listBoxAkterPris.Name = "listBoxAkterPris";
            this.listBoxAkterPris.Size = new System.Drawing.Size(120, 56);
            this.listBoxAkterPris.TabIndex = 2;
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
            // labelBarnPris
            // 
            this.labelBarnPris.AutoSize = true;
            this.labelBarnPris.Location = new System.Drawing.Point(32, 428);
            this.labelBarnPris.Name = "labelBarnPris";
            this.labelBarnPris.Size = new System.Drawing.Size(29, 13);
            this.labelBarnPris.TabIndex = 5;
            this.labelBarnPris.Text = "Barn";
            // 
            // labelUngdomPris
            // 
            this.labelUngdomPris.AutoSize = true;
            this.labelUngdomPris.Location = new System.Drawing.Point(32, 396);
            this.labelUngdomPris.Name = "labelUngdomPris";
            this.labelUngdomPris.Size = new System.Drawing.Size(47, 13);
            this.labelUngdomPris.TabIndex = 6;
            this.labelUngdomPris.Text = "Ungdom";
            // 
            // labelVuxenPris
            // 
            this.labelVuxenPris.AutoSize = true;
            this.labelVuxenPris.Location = new System.Drawing.Point(32, 366);
            this.labelVuxenPris.Name = "labelVuxenPris";
            this.labelVuxenPris.Size = new System.Drawing.Size(37, 13);
            this.labelVuxenPris.TabIndex = 7;
            this.labelVuxenPris.Text = "Vuxen";
            // 
            // labelPris
            // 
            this.labelPris.AutoSize = true;
            this.labelPris.Location = new System.Drawing.Point(37, 306);
            this.labelPris.Name = "labelPris";
            this.labelPris.Size = new System.Drawing.Size(24, 13);
            this.labelPris.TabIndex = 8;
            this.labelPris.Text = "Pris";
            // 
            // labelAkter
            // 
            this.labelAkter.AutoSize = true;
            this.labelAkter.Location = new System.Drawing.Point(29, 254);
            this.labelAkter.Name = "labelAkter";
            this.labelAkter.Size = new System.Drawing.Size(32, 13);
            this.labelAkter.TabIndex = 9;
            this.labelAkter.Text = "Akter";
            // 
            // labelAldersgrupp
            // 
            this.labelAldersgrupp.AutoSize = true;
            this.labelAldersgrupp.Location = new System.Drawing.Point(29, 212);
            this.labelAldersgrupp.Name = "labelAldersgrupp";
            this.labelAldersgrupp.Size = new System.Drawing.Size(63, 13);
            this.labelAldersgrupp.TabIndex = 10;
            this.labelAldersgrupp.Text = "Åldersgrupp";
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(29, 170);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(38, 13);
            this.labelDatum.TabIndex = 11;
            this.labelDatum.Text = "Datum";
            // 
            // labelAntalFriplatser
            // 
            this.labelAntalFriplatser.AutoSize = true;
            this.labelAntalFriplatser.Location = new System.Drawing.Point(155, 125);
            this.labelAntalFriplatser.Name = "labelAntalFriplatser";
            this.labelAntalFriplatser.Size = new System.Drawing.Size(73, 13);
            this.labelAntalFriplatser.TabIndex = 12;
            this.labelAntalFriplatser.Text = "Antal friplatser";
            // 
            // labelAntalFastplatser
            // 
            this.labelAntalFastplatser.AutoSize = true;
            this.labelAntalFastplatser.Location = new System.Drawing.Point(28, 125);
            this.labelAntalFastplatser.Name = "labelAntalFastplatser";
            this.labelAntalFastplatser.Size = new System.Drawing.Size(82, 13);
            this.labelAntalFastplatser.TabIndex = 13;
            this.labelAntalFastplatser.Text = "Antal fastplatser";
            // 
            // labelForsaljningstid
            // 
            this.labelForsaljningstid.AutoSize = true;
            this.labelForsaljningstid.Location = new System.Drawing.Point(28, 78);
            this.labelForsaljningstid.Name = "labelForsaljningstid";
            this.labelForsaljningstid.Size = new System.Drawing.Size(108, 13);
            this.labelForsaljningstid.TabIndex = 14;
            this.labelForsaljningstid.Text = "Försäljningstid från/till";
            // 
            // labelFriplatser
            // 
            this.labelFriplatser.AutoSize = true;
            this.labelFriplatser.Location = new System.Drawing.Point(179, 332);
            this.labelFriplatser.Name = "labelFriplatser";
            this.labelFriplatser.Size = new System.Drawing.Size(49, 13);
            this.labelFriplatser.TabIndex = 15;
            this.labelFriplatser.Text = "Friplatser";
            // 
            // labelFastplatser
            // 
            this.labelFastplatser.AutoSize = true;
            this.labelFastplatser.Location = new System.Drawing.Point(94, 333);
            this.labelFastplatser.Name = "labelFastplatser";
            this.labelFastplatser.Size = new System.Drawing.Size(58, 13);
            this.labelFastplatser.TabIndex = 16;
            this.labelFastplatser.Text = "Fastplatser";
            // 
            // textBoxFastplatserVuxen
            // 
            this.textBoxFastplatserVuxen.Location = new System.Drawing.Point(96, 361);
            this.textBoxFastplatserVuxen.Name = "textBoxFastplatserVuxen";
            this.textBoxFastplatserVuxen.Size = new System.Drawing.Size(56, 20);
            this.textBoxFastplatserVuxen.TabIndex = 17;
            // 
            // textBoxFriplatserVuxen
            // 
            this.textBoxFriplatserVuxen.Location = new System.Drawing.Point(173, 356);
            this.textBoxFriplatserVuxen.Name = "textBoxFriplatserVuxen";
            this.textBoxFriplatserVuxen.Size = new System.Drawing.Size(55, 20);
            this.textBoxFriplatserVuxen.TabIndex = 18;
            // 
            // textBoxFastplatserUngdom
            // 
            this.textBoxFastplatserUngdom.Location = new System.Drawing.Point(96, 394);
            this.textBoxFastplatserUngdom.Name = "textBoxFastplatserUngdom";
            this.textBoxFastplatserUngdom.Size = new System.Drawing.Size(56, 20);
            this.textBoxFastplatserUngdom.TabIndex = 19;
            // 
            // textBoxFastplatserBarn
            // 
            this.textBoxFastplatserBarn.Location = new System.Drawing.Point(96, 423);
            this.textBoxFastplatserBarn.Name = "textBoxFastplatserBarn";
            this.textBoxFastplatserBarn.Size = new System.Drawing.Size(56, 20);
            this.textBoxFastplatserBarn.TabIndex = 20;
            // 
            // textBoxAkter
            // 
            this.textBoxAkter.Location = new System.Drawing.Point(31, 270);
            this.textBoxAkter.Name = "textBoxAkter";
            this.textBoxAkter.Size = new System.Drawing.Size(100, 20);
            this.textBoxAkter.TabIndex = 21;
            // 
            // textBoxAntalFriplatser
            // 
            this.textBoxAntalFriplatser.Location = new System.Drawing.Point(158, 141);
            this.textBoxAntalFriplatser.Name = "textBoxAntalFriplatser";
            this.textBoxAntalFriplatser.Size = new System.Drawing.Size(100, 20);
            this.textBoxAntalFriplatser.TabIndex = 24;
            // 
            // textBoxFriplatserUngdom
            // 
            this.textBoxFriplatserUngdom.Location = new System.Drawing.Point(173, 393);
            this.textBoxFriplatserUngdom.Name = "textBoxFriplatserUngdom";
            this.textBoxFriplatserUngdom.Size = new System.Drawing.Size(55, 20);
            this.textBoxFriplatserUngdom.TabIndex = 25;
            // 
            // textBoxAntalFastplatser
            // 
            this.textBoxAntalFastplatser.Location = new System.Drawing.Point(31, 141);
            this.textBoxAntalFastplatser.Name = "textBoxAntalFastplatser";
            this.textBoxAntalFastplatser.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalFastplatser.TabIndex = 26;
            // 
            // textBoxFriplatserBarn
            // 
            this.textBoxFriplatserBarn.Location = new System.Drawing.Point(173, 425);
            this.textBoxFriplatserBarn.Name = "textBoxFriplatserBarn";
            this.textBoxFriplatserBarn.Size = new System.Drawing.Size(55, 20);
            this.textBoxFriplatserBarn.TabIndex = 28;
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
            this.buttonRaderaAkt.Location = new System.Drawing.Point(413, 267);
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
            this.dateTimePickerForsaljningstidFran.Location = new System.Drawing.Point(32, 94);
            this.dateTimePickerForsaljningstidFran.Name = "dateTimePickerForsaljningstidFran";
            this.dateTimePickerForsaljningstidFran.Size = new System.Drawing.Size(152, 20);
            this.dateTimePickerForsaljningstidFran.TabIndex = 32;
            // 
            // dateTimePickerForsaljningstidTill
            // 
            this.dateTimePickerForsaljningstidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidTill.Location = new System.Drawing.Point(249, 94);
            this.dateTimePickerForsaljningstidTill.Name = "dateTimePickerForsaljningstidTill";
            this.dateTimePickerForsaljningstidTill.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerForsaljningstidTill.TabIndex = 33;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatum.Location = new System.Drawing.Point(31, 186);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerDatum.TabIndex = 34;
            // 
            // comboBoxAldersgrupp
            // 
            this.comboBoxAldersgrupp.FormattingEnabled = true;
            this.comboBoxAldersgrupp.Location = new System.Drawing.Point(31, 228);
            this.comboBoxAldersgrupp.Name = "comboBoxAldersgrupp";
            this.comboBoxAldersgrupp.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAldersgrupp.TabIndex = 35;
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(728, 477);
            this.Controls.Add(this.comboBoxAldersgrupp);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.dateTimePickerForsaljningstidTill);
            this.Controls.Add(this.dateTimePickerForsaljningstidFran);
            this.Controls.Add(this.buttonRaderaAkt);
            this.Controls.Add(this.buttonSparaAndringar);
            this.Controls.Add(this.buttonLaggTIllForestallning);
            this.Controls.Add(this.textBoxFriplatserBarn);
            this.Controls.Add(this.textBoxAntalFastplatser);
            this.Controls.Add(this.textBoxFriplatserUngdom);
            this.Controls.Add(this.textBoxAntalFriplatser);
            this.Controls.Add(this.textBoxAkter);
            this.Controls.Add(this.textBoxFastplatserBarn);
            this.Controls.Add(this.textBoxFastplatserUngdom);
            this.Controls.Add(this.textBoxFriplatserVuxen);
            this.Controls.Add(this.textBoxFastplatserVuxen);
            this.Controls.Add(this.labelFastplatser);
            this.Controls.Add(this.labelFriplatser);
            this.Controls.Add(this.labelForsaljningstid);
            this.Controls.Add(this.labelAntalFastplatser);
            this.Controls.Add(this.labelAntalFriplatser);
            this.Controls.Add(this.labelDatum);
            this.Controls.Add(this.labelAldersgrupp);
            this.Controls.Add(this.labelAkter);
            this.Controls.Add(this.labelPris);
            this.Controls.Add(this.labelVuxenPris);
            this.Controls.Add(this.labelUngdomPris);
            this.Controls.Add(this.labelBarnPris);
            this.Controls.Add(this.labelBeskrivning);
            this.Controls.Add(this.listBoxAkterPris);
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
        private System.Windows.Forms.ListBox listBoxAkterPris;
        private System.Windows.Forms.Label labelBeskrivning;
        private System.Windows.Forms.Label labelBarnPris;
        private System.Windows.Forms.Label labelUngdomPris;
        private System.Windows.Forms.Label labelVuxenPris;
        private System.Windows.Forms.Label labelPris;
        private System.Windows.Forms.Label labelAkter;
        private System.Windows.Forms.Label labelAldersgrupp;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Label labelAntalFriplatser;
        private System.Windows.Forms.Label labelAntalFastplatser;
        private System.Windows.Forms.Label labelForsaljningstid;
        private System.Windows.Forms.Label labelFriplatser;
        private System.Windows.Forms.Label labelFastplatser;
        private System.Windows.Forms.TextBox textBoxFastplatserVuxen;
        private System.Windows.Forms.TextBox textBoxFriplatserVuxen;
        private System.Windows.Forms.TextBox textBoxFastplatserUngdom;
        private System.Windows.Forms.TextBox textBoxFastplatserBarn;
        private System.Windows.Forms.TextBox textBoxAkter;
        private System.Windows.Forms.TextBox textBoxAntalFriplatser;
        private System.Windows.Forms.TextBox textBoxFriplatserUngdom;
        private System.Windows.Forms.TextBox textBoxAntalFastplatser;
        private System.Windows.Forms.TextBox textBoxFriplatserBarn;
        private System.Windows.Forms.Button buttonLaggTIllForestallning;
        private System.Windows.Forms.Button buttonSparaAndringar;
        private System.Windows.Forms.Button buttonRaderaAkt;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidFran;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidTill;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.ComboBox comboBoxAldersgrupp;
    }
}