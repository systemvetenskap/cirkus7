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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAseats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLaggTillAkt
            // 
            this.buttonLaggTillAkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaggTillAkt.Location = new System.Drawing.Point(113, 36);
            this.buttonLaggTillAkt.Name = "buttonLaggTillAkt";
            this.buttonLaggTillAkt.Size = new System.Drawing.Size(54, 23);
            this.buttonLaggTillAkt.TabIndex = 0;
            this.buttonLaggTillAkt.Text = "+";
            this.buttonLaggTillAkt.UseVisualStyleBackColor = true;
            this.buttonLaggTillAkt.Click += new System.EventHandler(this.buttonLaggTillAkt_Click);
            // 
            // textBoxBeskrivning
            // 
            this.textBoxBeskrivning.Location = new System.Drawing.Point(8, 26);
            this.textBoxBeskrivning.Name = "textBoxBeskrivning";
            this.textBoxBeskrivning.Size = new System.Drawing.Size(100, 20);
            this.textBoxBeskrivning.TabIndex = 1;
            this.textBoxBeskrivning.Click += new System.EventHandler(this.textBoxBeskrivning_Click);
            this.textBoxBeskrivning.TextChanged += new System.EventHandler(this.textBoxBeskrivning_TextChanged);
            // 
            // labelBeskrivning
            // 
            this.labelBeskrivning.AutoSize = true;
            this.labelBeskrivning.Location = new System.Drawing.Point(6, 10);
            this.labelBeskrivning.Name = "labelBeskrivning";
            this.labelBeskrivning.Size = new System.Drawing.Size(62, 13);
            this.labelBeskrivning.TabIndex = 4;
            this.labelBeskrivning.Text = "Beskrivning";
            this.labelBeskrivning.Click += new System.EventHandler(this.labelBeskrivning_Click);
            // 
            // labelAkter
            // 
            this.labelAkter.AutoSize = true;
            this.labelAkter.Location = new System.Drawing.Point(5, 17);
            this.labelAkter.Name = "labelAkter";
            this.labelAkter.Size = new System.Drawing.Size(49, 13);
            this.labelAkter.TabIndex = 9;
            this.labelAkter.Text = "Aktnamn";
            this.labelAkter.Click += new System.EventHandler(this.labelAkter_Click);
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(6, 53);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(38, 13);
            this.labelDatum.TabIndex = 11;
            this.labelDatum.Text = "Datum";
            // 
            // labelAntalFriplatser
            // 
            this.labelAntalFriplatser.AutoSize = true;
            this.labelAntalFriplatser.Location = new System.Drawing.Point(6, 147);
            this.labelAntalFriplatser.Name = "labelAntalFriplatser";
            this.labelAntalFriplatser.Size = new System.Drawing.Size(79, 13);
            this.labelAntalFriplatser.TabIndex = 12;
            this.labelAntalFriplatser.Text = "Antal ståplatser";
            this.labelAntalFriplatser.Click += new System.EventHandler(this.labelAntalFriplatser_Click);
            // 
            // labelForsaljningstid
            // 
            this.labelForsaljningstid.AutoSize = true;
            this.labelForsaljningstid.Location = new System.Drawing.Point(4, 101);
            this.labelForsaljningstid.Name = "labelForsaljningstid";
            this.labelForsaljningstid.Size = new System.Drawing.Size(108, 13);
            this.labelForsaljningstid.TabIndex = 14;
            this.labelForsaljningstid.Text = "Försäljningstid från/till";
            // 
            // txtActname
            // 
            this.txtActname.Location = new System.Drawing.Point(6, 36);
            this.txtActname.Name = "txtActname";
            this.txtActname.Size = new System.Drawing.Size(100, 20);
            this.txtActname.TabIndex = 21;
            // 
            // textBoxAntalFriplatser
            // 
            this.textBoxAntalFriplatser.Location = new System.Drawing.Point(7, 163);
            this.textBoxAntalFriplatser.Name = "textBoxAntalFriplatser";
            this.textBoxAntalFriplatser.Size = new System.Drawing.Size(100, 20);
            this.textBoxAntalFriplatser.TabIndex = 24;
            this.textBoxAntalFriplatser.Click += new System.EventHandler(this.textBoxAntalFriplatser_Click);
            this.textBoxAntalFriplatser.TextChanged += new System.EventHandler(this.textBoxAntalFriplatser_TextChanged);
            this.textBoxAntalFriplatser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAntalFriplatser_KeyPress);
            // 
            // buttonLaggTIllForestallning
            // 
            this.buttonLaggTIllForestallning.Location = new System.Drawing.Point(12, 464);
            this.buttonLaggTIllForestallning.Name = "buttonLaggTIllForestallning";
            this.buttonLaggTIllForestallning.Size = new System.Drawing.Size(184, 55);
            this.buttonLaggTIllForestallning.TabIndex = 29;
            this.buttonLaggTIllForestallning.Text = "Skapa föreställning";
            this.buttonLaggTIllForestallning.UseVisualStyleBackColor = true;
            this.buttonLaggTIllForestallning.Click += new System.EventHandler(this.buttonLaggTIllForestallning_Click);
            // 
            // buttonSparaAndringar
            // 
            this.buttonSparaAndringar.Location = new System.Drawing.Point(220, 464);
            this.buttonSparaAndringar.Name = "buttonSparaAndringar";
            this.buttonSparaAndringar.Size = new System.Drawing.Size(115, 55);
            this.buttonSparaAndringar.TabIndex = 30;
            this.buttonSparaAndringar.Text = "Spara ändringar";
            this.buttonSparaAndringar.UseVisualStyleBackColor = true;
            this.buttonSparaAndringar.Click += new System.EventHandler(this.buttonSparaAndringar_Click);
            // 
            // buttonRaderaAkt
            // 
            this.buttonRaderaAkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRaderaAkt.Location = new System.Drawing.Point(136, 166);
            this.buttonRaderaAkt.Name = "buttonRaderaAkt";
            this.buttonRaderaAkt.Size = new System.Drawing.Size(31, 23);
            this.buttonRaderaAkt.TabIndex = 31;
            this.buttonRaderaAkt.Text = "-";
            this.buttonRaderaAkt.UseVisualStyleBackColor = true;
            this.buttonRaderaAkt.Click += new System.EventHandler(this.buttonRaderaAkt_Click);
            // 
            // dateTimePickerForsaljningstidFran
            // 
            this.dateTimePickerForsaljningstidFran.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidFran.Location = new System.Drawing.Point(5, 117);
            this.dateTimePickerForsaljningstidFran.Name = "dateTimePickerForsaljningstidFran";
            this.dateTimePickerForsaljningstidFran.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerForsaljningstidFran.TabIndex = 32;
            // 
            // dateTimePickerForsaljningstidTill
            // 
            this.dateTimePickerForsaljningstidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidTill.Location = new System.Drawing.Point(93, 117);
            this.dateTimePickerForsaljningstidTill.Name = "dateTimePickerForsaljningstidTill";
            this.dateTimePickerForsaljningstidTill.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerForsaljningstidTill.TabIndex = 33;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatum.Location = new System.Drawing.Point(5, 69);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDatum.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tillgängliga sittplatser i akten";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonaddSeat
            // 
            this.buttonaddSeat.Location = new System.Drawing.Point(8, 161);
            this.buttonaddSeat.Name = "buttonaddSeat";
            this.buttonaddSeat.Size = new System.Drawing.Size(227, 29);
            this.buttonaddSeat.TabIndex = 43;
            this.buttonaddSeat.Text = "Lägg till ";
            this.buttonaddSeat.UseVisualStyleBackColor = true;
            this.buttonaddSeat.Click += new System.EventHandler(this.buttonaddSeat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 91);
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
            this.labelAngeBeskrivningen.Location = new System.Drawing.Point(113, 29);
            this.labelAngeBeskrivningen.Name = "labelAngeBeskrivningen";
            this.labelAngeBeskrivningen.Size = new System.Drawing.Size(151, 13);
            this.labelAngeBeskrivningen.TabIndex = 45;
            this.labelAngeBeskrivningen.Text = "Du måste ange en beskrivning";
            this.labelAngeBeskrivningen.Visible = false;
            // 
            // labelAngeAkt
            // 
            this.labelAngeAkt.AutoSize = true;
            this.labelAngeAkt.BackColor = System.Drawing.Color.White;
            this.labelAngeAkt.ForeColor = System.Drawing.Color.Red;
            this.labelAngeAkt.Location = new System.Drawing.Point(5, 65);
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
            this.labelAngeStaplatser.Location = new System.Drawing.Point(113, 166);
            this.labelAngeStaplatser.Name = "labelAngeStaplatser";
            this.labelAngeStaplatser.Size = new System.Drawing.Size(156, 13);
            this.labelAngeStaplatser.TabIndex = 47;
            this.labelAngeStaplatser.Text = "Du måste ange antal ståplatser ";
            this.labelAngeStaplatser.Visible = false;
            // 
            // textBoxSeats
            // 
            this.textBoxSeats.Location = new System.Drawing.Point(143, 14);
            this.textBoxSeats.Name = "textBoxSeats";
            this.textBoxSeats.Size = new System.Drawing.Size(92, 20);
            this.textBoxSeats.TabIndex = 49;
            this.textBoxSeats.TextChanged += new System.EventHandler(this.textBoxSeats_TextChanged);
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
            this.dgSeats.Location = new System.Drawing.Point(8, 40);
            this.dgSeats.Name = "dgSeats";
            this.dgSeats.ReadOnly = true;
            this.dgSeats.RowHeadersVisible = false;
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
            this.dgAseats.Location = new System.Drawing.Point(273, 40);
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
            this.dgActs.Location = new System.Drawing.Point(6, 107);
            this.dgActs.Name = "dgActs";
            this.dgActs.ReadOnly = true;
            this.dgActs.RowHeadersVisible = false;
            this.dgActs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActs.Size = new System.Drawing.Size(124, 82);
            this.dgActs.TabIndex = 51;
            this.dgActs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActs_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxBeskrivning);
            this.groupBox1.Controls.Add(this.labelBeskrivning);
            this.groupBox1.Controls.Add(this.labelDatum);
            this.groupBox1.Controls.Add(this.dateTimePickerDatum);
            this.groupBox1.Controls.Add(this.dateTimePickerForsaljningstidFran);
            this.groupBox1.Controls.Add(this.labelAngeStaplatser);
            this.groupBox1.Controls.Add(this.labelAngeBeskrivningen);
            this.groupBox1.Controls.Add(this.labelForsaljningstid);
            this.groupBox1.Controls.Add(this.dateTimePickerForsaljningstidTill);
            this.groupBox1.Controls.Add(this.labelAntalFriplatser);
            this.groupBox1.Controls.Add(this.textBoxAntalFriplatser);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 205);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Skapa föreställning";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgActs);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtActname);
            this.groupBox2.Controls.Add(this.buttonLaggTillAkt);
            this.groupBox2.Controls.Add(this.labelAkter);
            this.groupBox2.Controls.Add(this.labelAngeAkt);
            this.groupBox2.Controls.Add(this.buttonRaderaAkt);
            this.groupBox2.Location = new System.Drawing.Point(306, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 205);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.dgAseats);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgSeats);
            this.groupBox3.Controls.Add(this.buttonaddSeat);
            this.groupBox3.Controls.Add(this.textBoxSeats);
            this.groupBox3.Location = new System.Drawing.Point(12, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 211);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 29);
            this.button1.TabIndex = 51;
            this.button1.Text = "Ta bort";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Sök:";
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSparaAndringar);
            this.Controls.Add(this.buttonLaggTIllForestallning);
            this.Name = "ShowForm";
            this.Text = "Forestallning";
            this.Load += new System.EventHandler(this.ShowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAseats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}