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
            this.textBoxBeskrivning = new System.Windows.Forms.TextBox();
            this.labelBeskrivning = new System.Windows.Forms.Label();
            this.labelDatum = new System.Windows.Forms.Label();
            this.labelForsaljningstid = new System.Windows.Forms.Label();
            this.buttonLaggTIllForestallning = new System.Windows.Forms.Button();
            this.buttonSparaAndringar = new System.Windows.Forms.Button();
            this.dateTimePickerForsaljningstidFran = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerForsaljningstidTill = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSeatMap = new System.Windows.Forms.GroupBox();
            this.pictureBoxSeatMap = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.buttonAddSection = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownRow = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSection = new System.Windows.Forms.TextBox();
            this.numericUpDownColumn = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRemoveSection = new System.Windows.Forms.Button();
            this.listBoxSections = new System.Windows.Forms.ListBox();
            this.comboBoxMapShape = new System.Windows.Forms.ComboBox();
            this.lblLayout = new System.Windows.Forms.Label();
            this.uncheck = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            this.lblActMap = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.labelAntalFriplatser = new System.Windows.Forms.Label();
            this.textBoxAntalFriplatser = new System.Windows.Forms.TextBox();
            this.labelAkter = new System.Windows.Forms.Label();
            this.buttonRaderaAkt = new System.Windows.Forms.Button();
            this.buttonLaggTillAkt = new System.Windows.Forms.Button();
            this.txtActname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgActs = new System.Windows.Forms.DataGridView();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxSeatMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeatMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBeskrivning
            // 
            this.textBoxBeskrivning.Location = new System.Drawing.Point(6, 54);
            this.textBoxBeskrivning.Name = "textBoxBeskrivning";
            this.textBoxBeskrivning.Size = new System.Drawing.Size(137, 20);
            this.textBoxBeskrivning.TabIndex = 1;
            this.textBoxBeskrivning.Click += new System.EventHandler(this.textBoxBeskrivning_Click);
            this.textBoxBeskrivning.TextChanged += new System.EventHandler(this.textBoxBeskrivning_TextChanged);
            // 
            // labelBeskrivning
            // 
            this.labelBeskrivning.AutoSize = true;
            this.labelBeskrivning.Location = new System.Drawing.Point(6, 41);
            this.labelBeskrivning.Name = "labelBeskrivning";
            this.labelBeskrivning.Size = new System.Drawing.Size(62, 13);
            this.labelBeskrivning.TabIndex = 4;
            this.labelBeskrivning.Text = "Beskrivning";
            // 
            // labelDatum
            // 
            this.labelDatum.AutoSize = true;
            this.labelDatum.Location = new System.Drawing.Point(157, 38);
            this.labelDatum.Name = "labelDatum";
            this.labelDatum.Size = new System.Drawing.Size(38, 13);
            this.labelDatum.TabIndex = 11;
            this.labelDatum.Text = "Datum";
            // 
            // labelForsaljningstid
            // 
            this.labelForsaljningstid.AutoSize = true;
            this.labelForsaljningstid.Location = new System.Drawing.Point(6, 81);
            this.labelForsaljningstid.Name = "labelForsaljningstid";
            this.labelForsaljningstid.Size = new System.Drawing.Size(76, 13);
            this.labelForsaljningstid.TabIndex = 14;
            this.labelForsaljningstid.Text = "Försäljningstid ";
            // 
            // buttonLaggTIllForestallning
            // 
            this.buttonLaggTIllForestallning.Location = new System.Drawing.Point(18, 389);
            this.buttonLaggTIllForestallning.Name = "buttonLaggTIllForestallning";
            this.buttonLaggTIllForestallning.Size = new System.Drawing.Size(156, 31);
            this.buttonLaggTIllForestallning.TabIndex = 29;
            this.buttonLaggTIllForestallning.Text = "Skapa föreställning";
            this.buttonLaggTIllForestallning.UseVisualStyleBackColor = true;
            this.buttonLaggTIllForestallning.Click += new System.EventHandler(this.buttonLaggTIllForestallning_Click);
            // 
            // buttonSparaAndringar
            // 
            this.buttonSparaAndringar.Location = new System.Drawing.Point(231, 388);
            this.buttonSparaAndringar.Name = "buttonSparaAndringar";
            this.buttonSparaAndringar.Size = new System.Drawing.Size(141, 31);
            this.buttonSparaAndringar.TabIndex = 30;
            this.buttonSparaAndringar.Text = "Spara ändringar";
            this.buttonSparaAndringar.UseVisualStyleBackColor = true;
            this.buttonSparaAndringar.Click += new System.EventHandler(this.buttonSparaAndringar_Click);
            // 
            // dateTimePickerForsaljningstidFran
            // 
            this.dateTimePickerForsaljningstidFran.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerForsaljningstidFran.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerForsaljningstidFran.Location = new System.Drawing.Point(9, 97);
            this.dateTimePickerForsaljningstidFran.Name = "dateTimePickerForsaljningstidFran";
            this.dateTimePickerForsaljningstidFran.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerForsaljningstidFran.TabIndex = 32;
            this.dateTimePickerForsaljningstidFran.Value = new System.DateTime(2015, 9, 21, 0, 0, 0, 0);
            // 
            // dateTimePickerForsaljningstidTill
            // 
            this.dateTimePickerForsaljningstidTill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerForsaljningstidTill.Location = new System.Drawing.Point(123, 97);
            this.dateTimePickerForsaljningstidTill.Name = "dateTimePickerForsaljningstidTill";
            this.dateTimePickerForsaljningstidTill.Size = new System.Drawing.Size(79, 20);
            this.dateTimePickerForsaljningstidTill.TabIndex = 33;
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatum.Location = new System.Drawing.Point(157, 54);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(99, 20);
            this.dateTimePickerDatum.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 53;
            this.label2.Text = "Föreställning";
            // 
            // groupBoxSeatMap
            // 
            this.groupBoxSeatMap.Controls.Add(this.pictureBoxSeatMap);
            this.groupBoxSeatMap.Controls.Add(this.label11);
            this.groupBoxSeatMap.Controls.Add(this.label1);
            this.groupBoxSeatMap.Controls.Add(this.numericUpDownX);
            this.groupBoxSeatMap.Controls.Add(this.numericUpDownY);
            this.groupBoxSeatMap.Controls.Add(this.buttonAddSection);
            this.groupBoxSeatMap.Controls.Add(this.label10);
            this.groupBoxSeatMap.Controls.Add(this.label9);
            this.groupBoxSeatMap.Controls.Add(this.numericUpDownRow);
            this.groupBoxSeatMap.Controls.Add(this.label8);
            this.groupBoxSeatMap.Controls.Add(this.textBoxSection);
            this.groupBoxSeatMap.Controls.Add(this.numericUpDownColumn);
            this.groupBoxSeatMap.Controls.Add(this.label7);
            this.groupBoxSeatMap.Controls.Add(this.buttonRemoveSection);
            this.groupBoxSeatMap.Controls.Add(this.listBoxSections);
            this.groupBoxSeatMap.Controls.Add(this.comboBoxMapShape);
            this.groupBoxSeatMap.Controls.Add(this.lblLayout);
            this.groupBoxSeatMap.Controls.Add(this.uncheck);
            this.groupBoxSeatMap.Controls.Add(this.check);
            this.groupBoxSeatMap.Controls.Add(this.lblActMap);
            this.groupBoxSeatMap.Controls.Add(this.lblS);
            this.groupBoxSeatMap.Controls.Add(this.btnSaveMap);
            this.groupBoxSeatMap.Location = new System.Drawing.Point(401, 12);
            this.groupBoxSeatMap.Name = "groupBoxSeatMap";
            this.groupBoxSeatMap.Size = new System.Drawing.Size(464, 414);
            this.groupBoxSeatMap.TabIndex = 57;
            this.groupBoxSeatMap.TabStop = false;
            // 
            // pictureBoxSeatMap
            // 
            this.pictureBoxSeatMap.Location = new System.Drawing.Point(7, 14);
            this.pictureBoxSeatMap.Name = "pictureBoxSeatMap";
            this.pictureBoxSeatMap.Size = new System.Drawing.Size(308, 307);
            this.pictureBoxSeatMap.TabIndex = 86;
            this.pictureBoxSeatMap.TabStop = false;
            this.pictureBoxSeatMap.Click += new System.EventHandler(this.pictureBoxSeatMap_Click);
            this.pictureBoxSeatMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSeatMap_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(399, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "Höjd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Bredd";
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(335, 74);
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownX.TabIndex = 83;
            this.numericUpDownX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(401, 74);
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownY.TabIndex = 82;
            this.numericUpDownY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            // 
            // buttonAddSection
            // 
            this.buttonAddSection.Location = new System.Drawing.Point(335, 241);
            this.buttonAddSection.Name = "buttonAddSection";
            this.buttonAddSection.Size = new System.Drawing.Size(123, 23);
            this.buttonAddSection.TabIndex = 81;
            this.buttonAddSection.Text = "Lägg till sektion";
            this.buttonAddSection.UseVisualStyleBackColor = true;
            this.buttonAddSection.Click += new System.EventHandler(this.buttonAddSection_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Kolumner";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(399, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 79;
            this.label9.Text = "Rader";
            // 
            // numericUpDownRow
            // 
            this.numericUpDownRow.Location = new System.Drawing.Point(336, 216);
            this.numericUpDownRow.Name = "numericUpDownRow";
            this.numericUpDownRow.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownRow.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "Namn på sektion";
            // 
            // textBoxSection
            // 
            this.textBoxSection.Location = new System.Drawing.Point(335, 176);
            this.textBoxSection.Name = "textBoxSection";
            this.textBoxSection.Size = new System.Drawing.Size(119, 20);
            this.textBoxSection.TabIndex = 76;
            // 
            // numericUpDownColumn
            // 
            this.numericUpDownColumn.Location = new System.Drawing.Point(402, 216);
            this.numericUpDownColumn.Name = "numericUpDownColumn";
            this.numericUpDownColumn.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownColumn.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Välj form på föreställning";
            // 
            // buttonRemoveSection
            // 
            this.buttonRemoveSection.Location = new System.Drawing.Point(337, 371);
            this.buttonRemoveSection.Name = "buttonRemoveSection";
            this.buttonRemoveSection.Size = new System.Drawing.Size(120, 23);
            this.buttonRemoveSection.TabIndex = 72;
            this.buttonRemoveSection.Text = "Ta bort sektion";
            this.buttonRemoveSection.UseVisualStyleBackColor = true;
            this.buttonRemoveSection.Click += new System.EventHandler(this.buttonRemoveSection_Click);
            // 
            // listBoxSections
            // 
            this.listBoxSections.FormattingEnabled = true;
            this.listBoxSections.Location = new System.Drawing.Point(338, 270);
            this.listBoxSections.Name = "listBoxSections";
            this.listBoxSections.Size = new System.Drawing.Size(120, 95);
            this.listBoxSections.TabIndex = 71;
            this.listBoxSections.SelectedIndexChanged += new System.EventHandler(this.listBoxSections_SelectedIndexChanged);
            // 
            // comboBoxMapShape
            // 
            this.comboBoxMapShape.FormattingEnabled = true;
            this.comboBoxMapShape.Items.AddRange(new object[] {
            "Cirkel",
            "Rektangel"});
            this.comboBoxMapShape.Location = new System.Drawing.Point(333, 30);
            this.comboBoxMapShape.Name = "comboBoxMapShape";
            this.comboBoxMapShape.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMapShape.TabIndex = 70;
            this.comboBoxMapShape.SelectedIndexChanged += new System.EventHandler(this.comboBoxMapShape_SelectedIndexChanged);
            // 
            // lblLayout
            // 
            this.lblLayout.AutoSize = true;
            this.lblLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayout.Location = new System.Drawing.Point(14, 398);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(41, 13);
            this.lblLayout.TabIndex = 62;
            this.lblLayout.Text = "label1";
            this.lblLayout.Visible = false;
            // 
            // uncheck
            // 
            this.uncheck.Location = new System.Drawing.Point(174, 327);
            this.uncheck.Name = "uncheck";
            this.uncheck.Size = new System.Drawing.Size(141, 31);
            this.uncheck.TabIndex = 68;
            this.uncheck.Text = "Avmarkera alla platser";
            this.uncheck.UseVisualStyleBackColor = true;
            this.uncheck.Click += new System.EventHandler(this.uncheck_Click);
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(14, 327);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(141, 31);
            this.check.TabIndex = 67;
            this.check.Text = "Markera alla platser";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // lblActMap
            // 
            this.lblActMap.AutoSize = true;
            this.lblActMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActMap.Location = new System.Drawing.Point(144, 153);
            this.lblActMap.Name = "lblActMap";
            this.lblActMap.Size = new System.Drawing.Size(0, 16);
            this.lblActMap.TabIndex = 59;
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(137, -16);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(35, 13);
            this.lblS.TabIndex = 66;
            this.lblS.Text = "label5";
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Location = new System.Drawing.Point(14, 364);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(207, 29);
            this.btnSaveMap.TabIndex = 53;
            this.btnSaveMap.Text = "Spara layout till vald akt";
            this.btnSaveMap.UseVisualStyleBackColor = true;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // labelAntalFriplatser
            // 
            this.labelAntalFriplatser.AutoSize = true;
            this.labelAntalFriplatser.Location = new System.Drawing.Point(6, 184);
            this.labelAntalFriplatser.Name = "labelAntalFriplatser";
            this.labelAntalFriplatser.Size = new System.Drawing.Size(124, 13);
            this.labelAntalFriplatser.TabIndex = 12;
            this.labelAntalFriplatser.Text = "Antal ståplatser för akten";
            // 
            // textBoxAntalFriplatser
            // 
            this.textBoxAntalFriplatser.Location = new System.Drawing.Point(6, 199);
            this.textBoxAntalFriplatser.Name = "textBoxAntalFriplatser";
            this.textBoxAntalFriplatser.Size = new System.Drawing.Size(124, 20);
            this.textBoxAntalFriplatser.TabIndex = 24;
            this.textBoxAntalFriplatser.Click += new System.EventHandler(this.textBoxAntalFriplatser_Click);
            this.textBoxAntalFriplatser.TextChanged += new System.EventHandler(this.textBoxAntalFriplatser_TextChanged);
            this.textBoxAntalFriplatser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAntalFriplatser_KeyPress);
            // 
            // labelAkter
            // 
            this.labelAkter.AutoSize = true;
            this.labelAkter.Location = new System.Drawing.Point(6, 145);
            this.labelAkter.Name = "labelAkter";
            this.labelAkter.Size = new System.Drawing.Size(49, 13);
            this.labelAkter.TabIndex = 9;
            this.labelAkter.Text = "Aktnamn";
            // 
            // buttonRaderaAkt
            // 
            this.buttonRaderaAkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRaderaAkt.Location = new System.Drawing.Point(157, 304);
            this.buttonRaderaAkt.Name = "buttonRaderaAkt";
            this.buttonRaderaAkt.Size = new System.Drawing.Size(115, 31);
            this.buttonRaderaAkt.TabIndex = 31;
            this.buttonRaderaAkt.Text = "Ta bort akt >>";
            this.buttonRaderaAkt.UseVisualStyleBackColor = true;
            this.buttonRaderaAkt.Click += new System.EventHandler(this.buttonRaderaAkt_Click);
            // 
            // buttonLaggTillAkt
            // 
            this.buttonLaggTillAkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLaggTillAkt.Location = new System.Drawing.Point(157, 242);
            this.buttonLaggTillAkt.Name = "buttonLaggTillAkt";
            this.buttonLaggTillAkt.Size = new System.Drawing.Size(115, 31);
            this.buttonLaggTillAkt.TabIndex = 0;
            this.buttonLaggTillAkt.Text = "<< Lägg till akt";
            this.buttonLaggTillAkt.UseVisualStyleBackColor = true;
            this.buttonLaggTillAkt.Click += new System.EventHandler(this.buttonLaggTillAkt_Click);
            // 
            // txtActname
            // 
            this.txtActname.Location = new System.Drawing.Point(6, 161);
            this.txtActname.Name = "txtActname";
            this.txtActname.Size = new System.Drawing.Size(137, 20);
            this.txtActname.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Föreställningens akter";
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
            this.dgActs.Location = new System.Drawing.Point(6, 241);
            this.dgActs.Name = "dgActs";
            this.dgActs.ReadOnly = true;
            this.dgActs.RowHeadersVisible = false;
            this.dgActs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgActs.Size = new System.Drawing.Size(141, 98);
            this.dgActs.TabIndex = 51;
            this.dgActs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActs_CellClick);
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "HH:mm";
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEnd.Location = new System.Drawing.Point(247, 161);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(67, 20);
            this.timeEnd.TabIndex = 53;
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "HH:mm";
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeStart.Location = new System.Drawing.Point(150, 161);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(68, 20);
            this.timeStart.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Till:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "Akter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Till:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(9, 352);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 61;
            this.lblStatus.Text = "label1";
            this.lblStatus.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelBeskrivning);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxAntalFriplatser);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buttonRaderaAkt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelAntalFriplatser);
            this.groupBox1.Controls.Add(this.textBoxBeskrivning);
            this.groupBox1.Controls.Add(this.labelAkter);
            this.groupBox1.Controls.Add(this.buttonLaggTillAkt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtActname);
            this.groupBox1.Controls.Add(this.labelDatum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgActs);
            this.groupBox1.Controls.Add(this.dateTimePickerDatum);
            this.groupBox1.Controls.Add(this.dateTimePickerForsaljningstidTill);
            this.groupBox1.Controls.Add(this.dateTimePickerForsaljningstidFran);
            this.groupBox1.Controls.Add(this.timeEnd);
            this.groupBox1.Controls.Add(this.timeStart);
            this.groupBox1.Controls.Add(this.labelForsaljningstid);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 371);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // ShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSeatMap);
            this.Controls.Add(this.buttonSparaAndringar);
            this.Controls.Add(this.buttonLaggTIllForestallning);
            this.Name = "ShowForm";
            this.Text = "Skapa föreställning";
            this.Load += new System.EventHandler(this.ShowForm_Load);
            this.groupBoxSeatMap.ResumeLayout(false);
            this.groupBoxSeatMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeatMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxBeskrivning;
        private System.Windows.Forms.Label labelBeskrivning;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Label labelForsaljningstid;
        private System.Windows.Forms.Button buttonLaggTIllForestallning;
        private System.Windows.Forms.Button buttonSparaAndringar;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidFran;
        private System.Windows.Forms.DateTimePicker dateTimePickerForsaljningstidTill;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxSeatMap;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblActMap;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button uncheck;
        private System.Windows.Forms.Label labelAntalFriplatser;
        private System.Windows.Forms.TextBox textBoxAntalFriplatser;
        private System.Windows.Forms.Label labelAkter;
        private System.Windows.Forms.Button buttonRaderaAkt;
        private System.Windows.Forms.Button buttonLaggTillAkt;
        private System.Windows.Forms.TextBox txtActname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgActs;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox comboBoxMapShape;
        private System.Windows.Forms.Button buttonRemoveSection;
        private System.Windows.Forms.ListBox listBoxSections;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownRow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSection;
        private System.Windows.Forms.NumericUpDown numericUpDownColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddSection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.PictureBox pictureBoxSeatMap;
    }
}