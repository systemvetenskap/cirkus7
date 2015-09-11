namespace cirkus
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTicket = new System.Windows.Forms.TabPage();
            this.dgTickets = new System.Windows.Forms.DataGridView();
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.textBoxSearchCustomer = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonEditTicket = new System.Windows.Forms.Button();
            this.buttonReserveTicket = new System.Windows.Forms.Button();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPrintPrice = new System.Windows.Forms.TextBox();
            this.textBoxPrintAct = new System.Windows.Forms.TextBox();
            this.textBoxPrintShow = new System.Windows.Forms.TextBox();
            this.textBoxPrintAge = new System.Windows.Forms.TextBox();
            this.textBoxPrintSeat = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxOlderTickets = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabShow = new System.Windows.Forms.TabPage();
            this.dgvAkter = new System.Windows.Forms.DataGridView();
            this.dgvShowsList = new System.Windows.Forms.DataGridView();
            this.textBoxKronorVuxenbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxAntalUngdomsbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxKronorUngdomsbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxAntalBarnbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxKronorBarnbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxTotaltAntal = new System.Windows.Forms.TextBox();
            this.textBoxTotaltKronor = new System.Windows.Forms.TextBox();
            this.buttonSkrivUtForestallning = new System.Windows.Forms.Button();
            this.buttonRaderaForestallning = new System.Windows.Forms.Button();
            this.buttonAndraForestallning = new System.Windows.Forms.Button();
            this.labelKronor = new System.Windows.Forms.Label();
            this.labelAntal = new System.Windows.Forms.Label();
            this.labelTotalt = new System.Windows.Forms.Label();
            this.labelBarnbiljetter = new System.Windows.Forms.Label();
            this.labelUngdomsbiljetter = new System.Windows.Forms.Label();
            this.labelVuxenbiljetter = new System.Windows.Forms.Label();
            this.textBoxAntalVuxenBiljetter = new System.Windows.Forms.TextBox();
            this.buttonSkapaForestalnning = new System.Windows.Forms.Button();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelForestallning = new System.Windows.Forms.Label();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPersonnummer = new System.Windows.Forms.Label();
            this.textBoxPersonnummer = new System.Windows.Forms.TextBox();
            this.LblVarning = new System.Windows.Forms.Label();
            this.lblBehorighetsniva = new System.Windows.Forms.Label();
            this.lblLosenord = new System.Windows.Forms.Label();
            this.dgStaff = new System.Windows.Forms.DataGridView();
            this.textBoxSearchStaff = new System.Windows.Forms.TextBox();
            this.comboBoxBehorighetsniva = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTomFalten = new System.Windows.Forms.Button();
            this.btnUpdateraKonto = new System.Windows.Forms.Button();
            this.lblFornamn = new System.Windows.Forms.Label();
            this.btnSkapaKonto = new System.Windows.Forms.Button();
            this.lblSokPerson = new System.Windows.Forms.Label();
            this.lblEfternamn = new System.Windows.Forms.Label();
            this.textBoxLosenord = new System.Windows.Forms.TextBox();
            this.lblTelefonnummer = new System.Windows.Forms.Label();
            this.textBoxEfternamn = new System.Windows.Forms.TextBox();
            this.lblEpost = new System.Windows.Forms.Label();
            this.textBoxTelefonnummer = new System.Windows.Forms.TextBox();
            this.lblAnvandarnamn = new System.Windows.Forms.Label();
            this.textBoxEpost = new System.Windows.Forms.TextBox();
            this.textBoxFornamn = new System.Windows.Forms.TextBox();
            this.textBoxAnvandarnamn = new System.Windows.Forms.TextBox();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelStaffName = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabControl1.SuspendLayout();
            this.tabTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowsList)).BeginInit();
            this.tabAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTicket);
            this.tabControl1.Controls.Add(this.tabShow);
            this.tabControl1.Controls.Add(this.tabAccount);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 482);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabTicket
            // 
            this.tabTicket.Controls.Add(this.dgTickets);
            this.tabTicket.Controls.Add(this.dgCustomers);
            this.tabTicket.Controls.Add(this.textBoxSearchCustomer);
            this.tabTicket.Controls.Add(this.button4);
            this.tabTicket.Controls.Add(this.buttonEditTicket);
            this.tabTicket.Controls.Add(this.buttonReserveTicket);
            this.tabTicket.Controls.Add(this.buttonAddCustomer);
            this.tabTicket.Controls.Add(this.groupBox1);
            this.tabTicket.Controls.Add(this.checkBoxOlderTickets);
            this.tabTicket.Controls.Add(this.label3);
            this.tabTicket.Controls.Add(this.label2);
            this.tabTicket.Controls.Add(this.label1);
            this.tabTicket.Location = new System.Drawing.Point(4, 22);
            this.tabTicket.Name = "tabTicket";
            this.tabTicket.Padding = new System.Windows.Forms.Padding(3);
            this.tabTicket.Size = new System.Drawing.Size(925, 456);
            this.tabTicket.TabIndex = 0;
            this.tabTicket.Text = "Biljettförsäljning";
            this.tabTicket.UseVisualStyleBackColor = true;
            // 
            // dgTickets
            // 
            this.dgTickets.AllowUserToAddRows = false;
            this.dgTickets.AllowUserToDeleteRows = false;
            this.dgTickets.AllowUserToResizeColumns = false;
            this.dgTickets.AllowUserToResizeRows = false;
            this.dgTickets.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTickets.Location = new System.Drawing.Point(250, 75);
            this.dgTickets.Name = "dgTickets";
            this.dgTickets.ReadOnly = true;
            this.dgTickets.RowHeadersVisible = false;
            this.dgTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTickets.Size = new System.Drawing.Size(200, 368);
            this.dgTickets.TabIndex = 15;
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AllowUserToResizeColumns = false;
            this.dgCustomers.AllowUserToResizeRows = false;
            this.dgCustomers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Location = new System.Drawing.Point(12, 75);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.ReadOnly = true;
            this.dgCustomers.RowHeadersVisible = false;
            this.dgCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomers.Size = new System.Drawing.Size(200, 368);
            this.dgCustomers.TabIndex = 14;
            this.dgCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomers_CellClick);
            // 
            // textBoxSearchCustomer
            // 
            this.textBoxSearchCustomer.Location = new System.Drawing.Point(40, 49);
            this.textBoxSearchCustomer.Name = "textBoxSearchCustomer";
            this.textBoxSearchCustomer.Size = new System.Drawing.Size(172, 20);
            this.textBoxSearchCustomer.TabIndex = 13;
            this.textBoxSearchCustomer.TextChanged += new System.EventHandler(this.textBoxSearchCustomer_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(754, 417);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Radera biljett";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonEditTicket
            // 
            this.buttonEditTicket.Location = new System.Drawing.Point(754, 121);
            this.buttonEditTicket.Name = "buttonEditTicket";
            this.buttonEditTicket.Size = new System.Drawing.Size(165, 23);
            this.buttonEditTicket.TabIndex = 10;
            this.buttonEditTicket.Text = "Ändra biljett";
            this.buttonEditTicket.UseVisualStyleBackColor = true;
            // 
            // buttonReserveTicket
            // 
            this.buttonReserveTicket.Location = new System.Drawing.Point(754, 83);
            this.buttonReserveTicket.Name = "buttonReserveTicket";
            this.buttonReserveTicket.Size = new System.Drawing.Size(165, 23);
            this.buttonReserveTicket.TabIndex = 9;
            this.buttonReserveTicket.Text = "Boka/Reservera biljett";
            this.buttonReserveTicket.UseVisualStyleBackColor = true;
            this.buttonReserveTicket.Click += new System.EventHandler(this.buttonReserveTicket_Click);
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(754, 42);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(165, 23);
            this.buttonAddCustomer.TabIndex = 8;
            this.buttonAddCustomer.Text = "Lägg till ny kund";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            this.buttonAddCustomer.Click += new System.EventHandler(this.buttonAddCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBoxPrintPrice);
            this.groupBox1.Controls.Add(this.textBoxPrintAct);
            this.groupBox1.Controls.Add(this.textBoxPrintShow);
            this.groupBox1.Controls.Add(this.textBoxPrintAge);
            this.groupBox1.Controls.Add(this.textBoxPrintSeat);
            this.groupBox1.Controls.Add(this.buttonPrint);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(489, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 430);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utskrift";
            // 
            // textBoxPrintPrice
            // 
            this.textBoxPrintPrice.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPrintPrice.Location = new System.Drawing.Point(32, 309);
            this.textBoxPrintPrice.Name = "textBoxPrintPrice";
            this.textBoxPrintPrice.ReadOnly = true;
            this.textBoxPrintPrice.Size = new System.Drawing.Size(162, 26);
            this.textBoxPrintPrice.TabIndex = 18;
            // 
            // textBoxPrintAct
            // 
            this.textBoxPrintAct.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPrintAct.Location = new System.Drawing.Point(32, 252);
            this.textBoxPrintAct.Name = "textBoxPrintAct";
            this.textBoxPrintAct.ReadOnly = true;
            this.textBoxPrintAct.Size = new System.Drawing.Size(162, 26);
            this.textBoxPrintAct.TabIndex = 17;
            // 
            // textBoxPrintShow
            // 
            this.textBoxPrintShow.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPrintShow.Location = new System.Drawing.Point(32, 195);
            this.textBoxPrintShow.Name = "textBoxPrintShow";
            this.textBoxPrintShow.ReadOnly = true;
            this.textBoxPrintShow.Size = new System.Drawing.Size(162, 26);
            this.textBoxPrintShow.TabIndex = 16;
            // 
            // textBoxPrintAge
            // 
            this.textBoxPrintAge.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPrintAge.Location = new System.Drawing.Point(32, 81);
            this.textBoxPrintAge.Name = "textBoxPrintAge";
            this.textBoxPrintAge.ReadOnly = true;
            this.textBoxPrintAge.Size = new System.Drawing.Size(162, 26);
            this.textBoxPrintAge.TabIndex = 15;
            // 
            // textBoxPrintSeat
            // 
            this.textBoxPrintSeat.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPrintSeat.Location = new System.Drawing.Point(32, 138);
            this.textBoxPrintSeat.Name = "textBoxPrintSeat";
            this.textBoxPrintSeat.ReadOnly = true;
            this.textBoxPrintSeat.Size = new System.Drawing.Size(162, 26);
            this.textBoxPrintSeat.TabIndex = 14;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(145, 401);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "Skriv ut";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pris:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Akt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Föreställning:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Plats:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Åldersgrupp:";
            // 
            // checkBoxOlderTickets
            // 
            this.checkBoxOlderTickets.AutoSize = true;
            this.checkBoxOlderTickets.Location = new System.Drawing.Point(250, 52);
            this.checkBoxOlderTickets.Name = "checkBoxOlderTickets";
            this.checkBoxOlderTickets.Size = new System.Drawing.Size(108, 17);
            this.checkBoxOlderTickets.TabIndex = 7;
            this.checkBoxOlderTickets.Text = "Visa äldre biljetter";
            this.checkBoxOlderTickets.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Biljett";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kund";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sök";
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.dgvAkter);
            this.tabShow.Controls.Add(this.dgvShowsList);
            this.tabShow.Controls.Add(this.textBoxKronorVuxenbiljetter);
            this.tabShow.Controls.Add(this.textBoxAntalUngdomsbiljetter);
            this.tabShow.Controls.Add(this.textBoxKronorUngdomsbiljetter);
            this.tabShow.Controls.Add(this.textBoxAntalBarnbiljetter);
            this.tabShow.Controls.Add(this.textBoxKronorBarnbiljetter);
            this.tabShow.Controls.Add(this.textBoxTotaltAntal);
            this.tabShow.Controls.Add(this.textBoxTotaltKronor);
            this.tabShow.Controls.Add(this.buttonSkrivUtForestallning);
            this.tabShow.Controls.Add(this.buttonRaderaForestallning);
            this.tabShow.Controls.Add(this.buttonAndraForestallning);
            this.tabShow.Controls.Add(this.labelKronor);
            this.tabShow.Controls.Add(this.labelAntal);
            this.tabShow.Controls.Add(this.labelTotalt);
            this.tabShow.Controls.Add(this.labelBarnbiljetter);
            this.tabShow.Controls.Add(this.labelUngdomsbiljetter);
            this.tabShow.Controls.Add(this.labelVuxenbiljetter);
            this.tabShow.Controls.Add(this.textBoxAntalVuxenBiljetter);
            this.tabShow.Controls.Add(this.buttonSkapaForestalnning);
            this.tabShow.Controls.Add(this.labelAkter);
            this.tabShow.Controls.Add(this.labelForestallning);
            this.tabShow.Location = new System.Drawing.Point(4, 22);
            this.tabShow.Name = "tabShow";
            this.tabShow.Padding = new System.Windows.Forms.Padding(3);
            this.tabShow.Size = new System.Drawing.Size(925, 456);
            this.tabShow.TabIndex = 1;
            this.tabShow.Text = "Föreställning";
            this.tabShow.UseVisualStyleBackColor = true;
            // 
            // dgvAkter
            // 
            this.dgvAkter.AllowUserToResizeColumns = false;
            this.dgvAkter.AllowUserToResizeRows = false;
            this.dgvAkter.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAkter.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAkter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAkter.ColumnHeadersVisible = false;
            this.dgvAkter.Location = new System.Drawing.Point(291, 53);
            this.dgvAkter.MultiSelect = false;
            this.dgvAkter.Name = "dgvAkter";
            this.dgvAkter.ReadOnly = true;
            this.dgvAkter.RowHeadersVisible = false;
            this.dgvAkter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAkter.Size = new System.Drawing.Size(193, 107);
            this.dgvAkter.TabIndex = 23;
            this.dgvAkter.SelectionChanged += new System.EventHandler(this.dgvAkter_SelectionChanged);
            // 
            // dgvShowsList
            // 
            this.dgvShowsList.AllowUserToAddRows = false;
            this.dgvShowsList.AllowUserToResizeColumns = false;
            this.dgvShowsList.AllowUserToResizeRows = false;
            this.dgvShowsList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShowsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvShowsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowsList.ColumnHeadersVisible = false;
            this.dgvShowsList.Location = new System.Drawing.Point(26, 53);
            this.dgvShowsList.MultiSelect = false;
            this.dgvShowsList.Name = "dgvShowsList";
            this.dgvShowsList.ReadOnly = true;
            this.dgvShowsList.RowHeadersVisible = false;
            this.dgvShowsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowsList.Size = new System.Drawing.Size(228, 348);
            this.dgvShowsList.TabIndex = 22;
            this.dgvShowsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowsList_CellClick);
            // 
            // textBoxKronorVuxenbiljetter
            // 
            this.textBoxKronorVuxenbiljetter.Location = new System.Drawing.Point(790, 74);
            this.textBoxKronorVuxenbiljetter.Name = "textBoxKronorVuxenbiljetter";
            this.textBoxKronorVuxenbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorVuxenbiljetter.TabIndex = 21;
            // 
            // textBoxAntalUngdomsbiljetter
            // 
            this.textBoxAntalUngdomsbiljetter.Location = new System.Drawing.Point(677, 113);
            this.textBoxAntalUngdomsbiljetter.Name = "textBoxAntalUngdomsbiljetter";
            this.textBoxAntalUngdomsbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalUngdomsbiljetter.TabIndex = 20;
            // 
            // textBoxKronorUngdomsbiljetter
            // 
            this.textBoxKronorUngdomsbiljetter.Location = new System.Drawing.Point(790, 111);
            this.textBoxKronorUngdomsbiljetter.Name = "textBoxKronorUngdomsbiljetter";
            this.textBoxKronorUngdomsbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorUngdomsbiljetter.TabIndex = 19;
            // 
            // textBoxAntalBarnbiljetter
            // 
            this.textBoxAntalBarnbiljetter.Location = new System.Drawing.Point(677, 140);
            this.textBoxAntalBarnbiljetter.Name = "textBoxAntalBarnbiljetter";
            this.textBoxAntalBarnbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalBarnbiljetter.TabIndex = 18;
            // 
            // textBoxKronorBarnbiljetter
            // 
            this.textBoxKronorBarnbiljetter.Location = new System.Drawing.Point(790, 140);
            this.textBoxKronorBarnbiljetter.Name = "textBoxKronorBarnbiljetter";
            this.textBoxKronorBarnbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorBarnbiljetter.TabIndex = 17;
            // 
            // textBoxTotaltAntal
            // 
            this.textBoxTotaltAntal.Location = new System.Drawing.Point(677, 192);
            this.textBoxTotaltAntal.Name = "textBoxTotaltAntal";
            this.textBoxTotaltAntal.Size = new System.Drawing.Size(79, 20);
            this.textBoxTotaltAntal.TabIndex = 16;
            // 
            // textBoxTotaltKronor
            // 
            this.textBoxTotaltKronor.Location = new System.Drawing.Point(790, 192);
            this.textBoxTotaltKronor.Name = "textBoxTotaltKronor";
            this.textBoxTotaltKronor.Size = new System.Drawing.Size(79, 20);
            this.textBoxTotaltKronor.TabIndex = 15;
            // 
            // buttonSkrivUtForestallning
            // 
            this.buttonSkrivUtForestallning.Location = new System.Drawing.Point(793, 407);
            this.buttonSkrivUtForestallning.Name = "buttonSkrivUtForestallning";
            this.buttonSkrivUtForestallning.Size = new System.Drawing.Size(75, 23);
            this.buttonSkrivUtForestallning.TabIndex = 14;
            this.buttonSkrivUtForestallning.Text = "Skriva ut";
            this.buttonSkrivUtForestallning.UseVisualStyleBackColor = true;
            // 
            // buttonRaderaForestallning
            // 
            this.buttonRaderaForestallning.Location = new System.Drawing.Point(182, 407);
            this.buttonRaderaForestallning.Name = "buttonRaderaForestallning";
            this.buttonRaderaForestallning.Size = new System.Drawing.Size(72, 23);
            this.buttonRaderaForestallning.TabIndex = 13;
            this.buttonRaderaForestallning.Text = "Radera";
            this.buttonRaderaForestallning.UseVisualStyleBackColor = true;
            this.buttonRaderaForestallning.Click += new System.EventHandler(this.buttonRaderaForestallning_Click);
            // 
            // buttonAndraForestallning
            // 
            this.buttonAndraForestallning.Location = new System.Drawing.Point(104, 407);
            this.buttonAndraForestallning.Name = "buttonAndraForestallning";
            this.buttonAndraForestallning.Size = new System.Drawing.Size(72, 23);
            this.buttonAndraForestallning.TabIndex = 12;
            this.buttonAndraForestallning.Text = "Ändra";
            this.buttonAndraForestallning.UseVisualStyleBackColor = true;
            this.buttonAndraForestallning.Click += new System.EventHandler(this.buttonAndraForestallning_Click);
            // 
            // labelKronor
            // 
            this.labelKronor.AutoSize = true;
            this.labelKronor.Location = new System.Drawing.Point(803, 37);
            this.labelKronor.Name = "labelKronor";
            this.labelKronor.Size = new System.Drawing.Size(38, 13);
            this.labelKronor.TabIndex = 11;
            this.labelKronor.Text = "Kronor";
            // 
            // labelAntal
            // 
            this.labelAntal.AutoSize = true;
            this.labelAntal.Location = new System.Drawing.Point(697, 37);
            this.labelAntal.Name = "labelAntal";
            this.labelAntal.Size = new System.Drawing.Size(31, 13);
            this.labelAntal.TabIndex = 10;
            this.labelAntal.Text = "Antal";
            // 
            // labelTotalt
            // 
            this.labelTotalt.AutoSize = true;
            this.labelTotalt.Location = new System.Drawing.Point(562, 195);
            this.labelTotalt.Name = "labelTotalt";
            this.labelTotalt.Size = new System.Drawing.Size(34, 13);
            this.labelTotalt.TabIndex = 9;
            this.labelTotalt.Text = "Totalt";
            // 
            // labelBarnbiljetter
            // 
            this.labelBarnbiljetter.AutoSize = true;
            this.labelBarnbiljetter.Location = new System.Drawing.Point(562, 136);
            this.labelBarnbiljetter.Name = "labelBarnbiljetter";
            this.labelBarnbiljetter.Size = new System.Drawing.Size(62, 13);
            this.labelBarnbiljetter.TabIndex = 8;
            this.labelBarnbiljetter.Text = "Barnbiljetter";
            // 
            // labelUngdomsbiljetter
            // 
            this.labelUngdomsbiljetter.AutoSize = true;
            this.labelUngdomsbiljetter.Location = new System.Drawing.Point(562, 112);
            this.labelUngdomsbiljetter.Name = "labelUngdomsbiljetter";
            this.labelUngdomsbiljetter.Size = new System.Drawing.Size(85, 13);
            this.labelUngdomsbiljetter.TabIndex = 7;
            this.labelUngdomsbiljetter.Text = "Ungdomsbiljetter";
            // 
            // labelVuxenbiljetter
            // 
            this.labelVuxenbiljetter.AutoSize = true;
            this.labelVuxenbiljetter.Location = new System.Drawing.Point(562, 77);
            this.labelVuxenbiljetter.Name = "labelVuxenbiljetter";
            this.labelVuxenbiljetter.Size = new System.Drawing.Size(70, 13);
            this.labelVuxenbiljetter.TabIndex = 6;
            this.labelVuxenbiljetter.Text = "Vuxenbiljetter";
            // 
            // textBoxAntalVuxenBiljetter
            // 
            this.textBoxAntalVuxenBiljetter.Location = new System.Drawing.Point(677, 74);
            this.textBoxAntalVuxenBiljetter.Name = "textBoxAntalVuxenBiljetter";
            this.textBoxAntalVuxenBiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalVuxenBiljetter.TabIndex = 5;
            // 
            // buttonSkapaForestalnning
            // 
            this.buttonSkapaForestalnning.Location = new System.Drawing.Point(26, 407);
            this.buttonSkapaForestalnning.Name = "buttonSkapaForestalnning";
            this.buttonSkapaForestalnning.Size = new System.Drawing.Size(72, 23);
            this.buttonSkapaForestalnning.TabIndex = 4;
            this.buttonSkapaForestalnning.Text = "Skapa ny";
            this.buttonSkapaForestalnning.UseVisualStyleBackColor = true;
            this.buttonSkapaForestalnning.Click += new System.EventHandler(this.buttonSkapaForestalnning_Click_1);
            // 
            // labelAkter
            // 
            this.labelAkter.AutoSize = true;
            this.labelAkter.Location = new System.Drawing.Point(288, 37);
            this.labelAkter.Name = "labelAkter";
            this.labelAkter.Size = new System.Drawing.Size(32, 13);
            this.labelAkter.TabIndex = 1;
            this.labelAkter.Text = "Akter";
            // 
            // labelForestallning
            // 
            this.labelForestallning.AutoSize = true;
            this.labelForestallning.Location = new System.Drawing.Point(23, 37);
            this.labelForestallning.Name = "labelForestallning";
            this.labelForestallning.Size = new System.Drawing.Size(75, 13);
            this.labelForestallning.TabIndex = 0;
            this.labelForestallning.Text = "Föreställningar";
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.button1);
            this.tabAccount.Controls.Add(this.lblPersonnummer);
            this.tabAccount.Controls.Add(this.textBoxPersonnummer);
            this.tabAccount.Controls.Add(this.LblVarning);
            this.tabAccount.Controls.Add(this.lblBehorighetsniva);
            this.tabAccount.Controls.Add(this.lblLosenord);
            this.tabAccount.Controls.Add(this.dgStaff);
            this.tabAccount.Controls.Add(this.textBoxSearchStaff);
            this.tabAccount.Controls.Add(this.comboBoxBehorighetsniva);
            this.tabAccount.Controls.Add(this.label9);
            this.tabAccount.Controls.Add(this.btnTomFalten);
            this.tabAccount.Controls.Add(this.btnUpdateraKonto);
            this.tabAccount.Controls.Add(this.lblFornamn);
            this.tabAccount.Controls.Add(this.btnSkapaKonto);
            this.tabAccount.Controls.Add(this.lblSokPerson);
            this.tabAccount.Controls.Add(this.lblEfternamn);
            this.tabAccount.Controls.Add(this.textBoxLosenord);
            this.tabAccount.Controls.Add(this.lblTelefonnummer);
            this.tabAccount.Controls.Add(this.textBoxEfternamn);
            this.tabAccount.Controls.Add(this.lblEpost);
            this.tabAccount.Controls.Add(this.textBoxTelefonnummer);
            this.tabAccount.Controls.Add(this.lblAnvandarnamn);
            this.tabAccount.Controls.Add(this.textBoxEpost);
            this.tabAccount.Controls.Add(this.textBoxFornamn);
            this.tabAccount.Controls.Add(this.textBoxAnvandarnamn);
            this.tabAccount.Location = new System.Drawing.Point(4, 22);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Size = new System.Drawing.Size(925, 456);
            this.tabAccount.TabIndex = 2;
            this.tabAccount.Text = "Konto";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(602, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 31);
            this.button1.TabIndex = 58;
            this.button1.Text = "Radera konto";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblPersonnummer
            // 
            this.lblPersonnummer.AutoSize = true;
            this.lblPersonnummer.Location = new System.Drawing.Point(47, 72);
            this.lblPersonnummer.Name = "lblPersonnummer";
            this.lblPersonnummer.Size = new System.Drawing.Size(129, 13);
            this.lblPersonnummer.TabIndex = 57;
            this.lblPersonnummer.Text = "Personnummer: (10 siffror)";
            // 
            // textBoxPersonnummer
            // 
            this.textBoxPersonnummer.Location = new System.Drawing.Point(47, 87);
            this.textBoxPersonnummer.Name = "textBoxPersonnummer";
            this.textBoxPersonnummer.Size = new System.Drawing.Size(152, 20);
            this.textBoxPersonnummer.TabIndex = 56;
            // 
            // LblVarning
            // 
            this.LblVarning.AutoSize = true;
            this.LblVarning.Location = new System.Drawing.Point(47, 343);
            this.LblVarning.Name = "LblVarning";
            this.LblVarning.Size = new System.Drawing.Size(41, 13);
            this.LblVarning.TabIndex = 49;
            this.LblVarning.Text = "label12";
            this.LblVarning.Visible = false;
            // 
            // lblBehorighetsniva
            // 
            this.lblBehorighetsniva.AutoSize = true;
            this.lblBehorighetsniva.Location = new System.Drawing.Point(266, 267);
            this.lblBehorighetsniva.Name = "lblBehorighetsniva";
            this.lblBehorighetsniva.Size = new System.Drawing.Size(86, 13);
            this.lblBehorighetsniva.TabIndex = 46;
            this.lblBehorighetsniva.Text = "Behörighetsnivå:";
            // 
            // lblLosenord
            // 
            this.lblLosenord.AutoSize = true;
            this.lblLosenord.Location = new System.Drawing.Point(266, 202);
            this.lblLosenord.Name = "lblLosenord";
            this.lblLosenord.Size = new System.Drawing.Size(54, 13);
            this.lblLosenord.TabIndex = 45;
            this.lblLosenord.Text = "Lösenord:";
            // 
            // dgStaff
            // 
            this.dgStaff.AllowUserToAddRows = false;
            this.dgStaff.AllowUserToDeleteRows = false;
            this.dgStaff.AllowUserToResizeColumns = false;
            this.dgStaff.AllowUserToResizeRows = false;
            this.dgStaff.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgStaff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStaff.GridColor = System.Drawing.SystemColors.Window;
            this.dgStaff.Location = new System.Drawing.Point(468, 87);
            this.dgStaff.MultiSelect = false;
            this.dgStaff.Name = "dgStaff";
            this.dgStaff.RowHeadersVisible = false;
            this.dgStaff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStaff.Size = new System.Drawing.Size(252, 256);
            this.dgStaff.TabIndex = 44;
            // 
            // textBoxSearchStaff
            // 
            this.textBoxSearchStaff.Location = new System.Drawing.Point(468, 51);
            this.textBoxSearchStaff.Name = "textBoxSearchStaff";
            this.textBoxSearchStaff.Size = new System.Drawing.Size(252, 20);
            this.textBoxSearchStaff.TabIndex = 43;
            this.textBoxSearchStaff.TextChanged += new System.EventHandler(this.textBoxSearchStaff_TextChanged);
            // 
            // comboBoxBehorighetsniva
            // 
            this.comboBoxBehorighetsniva.FormattingEnabled = true;
            this.comboBoxBehorighetsniva.Items.AddRange(new object[] {
            "Biljettförsäljare",
            "Administratör"});
            this.comboBoxBehorighetsniva.Location = new System.Drawing.Point(266, 282);
            this.comboBoxBehorighetsniva.Name = "comboBoxBehorighetsniva";
            this.comboBoxBehorighetsniva.Size = new System.Drawing.Size(152, 21);
            this.comboBoxBehorighetsniva.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(47, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Konto";
            // 
            // btnTomFalten
            // 
            this.btnTomFalten.Location = new System.Drawing.Point(47, 376);
            this.btnTomFalten.Name = "btnTomFalten";
            this.btnTomFalten.Size = new System.Drawing.Size(118, 31);
            this.btnTomFalten.TabIndex = 32;
            this.btnTomFalten.Text = "Töm fälten";
            this.btnTomFalten.UseVisualStyleBackColor = true;
            this.btnTomFalten.Click += new System.EventHandler(this.btnTomFalten_Click);
            // 
            // btnUpdateraKonto
            // 
            this.btnUpdateraKonto.Location = new System.Drawing.Point(468, 376);
            this.btnUpdateraKonto.Name = "btnUpdateraKonto";
            this.btnUpdateraKonto.Size = new System.Drawing.Size(118, 31);
            this.btnUpdateraKonto.TabIndex = 31;
            this.btnUpdateraKonto.Text = "Uppdatera konto";
            this.btnUpdateraKonto.UseVisualStyleBackColor = true;
            this.btnUpdateraKonto.Click += new System.EventHandler(this.btnUpdateraKonto_Click);
            // 
            // lblFornamn
            // 
            this.lblFornamn.AutoSize = true;
            this.lblFornamn.Location = new System.Drawing.Point(47, 137);
            this.lblFornamn.Name = "lblFornamn";
            this.lblFornamn.Size = new System.Drawing.Size(51, 13);
            this.lblFornamn.TabIndex = 27;
            this.lblFornamn.Text = "Förnamn:";
            // 
            // btnSkapaKonto
            // 
            this.btnSkapaKonto.Location = new System.Drawing.Point(300, 376);
            this.btnSkapaKonto.Name = "btnSkapaKonto";
            this.btnSkapaKonto.Size = new System.Drawing.Size(118, 31);
            this.btnSkapaKonto.TabIndex = 29;
            this.btnSkapaKonto.Text = "Skapa konto";
            this.btnSkapaKonto.UseVisualStyleBackColor = true;
            this.btnSkapaKonto.Click += new System.EventHandler(this.btnSkapaKonto_Click);
            // 
            // lblSokPerson
            // 
            this.lblSokPerson.AutoSize = true;
            this.lblSokPerson.Location = new System.Drawing.Point(468, 35);
            this.lblSokPerson.Name = "lblSokPerson";
            this.lblSokPerson.Size = new System.Drawing.Size(61, 13);
            this.lblSokPerson.TabIndex = 39;
            this.lblSokPerson.Text = "Sök person";
            // 
            // lblEfternamn
            // 
            this.lblEfternamn.AutoSize = true;
            this.lblEfternamn.Location = new System.Drawing.Point(47, 202);
            this.lblEfternamn.Name = "lblEfternamn";
            this.lblEfternamn.Size = new System.Drawing.Size(58, 13);
            this.lblEfternamn.TabIndex = 33;
            this.lblEfternamn.Text = "Efternamn:";
            // 
            // textBoxLosenord
            // 
            this.textBoxLosenord.Location = new System.Drawing.Point(266, 217);
            this.textBoxLosenord.Name = "textBoxLosenord";
            this.textBoxLosenord.Size = new System.Drawing.Size(152, 20);
            this.textBoxLosenord.TabIndex = 26;
            // 
            // lblTelefonnummer
            // 
            this.lblTelefonnummer.AutoSize = true;
            this.lblTelefonnummer.Location = new System.Drawing.Point(47, 268);
            this.lblTelefonnummer.Name = "lblTelefonnummer";
            this.lblTelefonnummer.Size = new System.Drawing.Size(83, 13);
            this.lblTelefonnummer.TabIndex = 34;
            this.lblTelefonnummer.Text = "Telefonnummer:";
            // 
            // textBoxEfternamn
            // 
            this.textBoxEfternamn.Location = new System.Drawing.Point(47, 217);
            this.textBoxEfternamn.Name = "textBoxEfternamn";
            this.textBoxEfternamn.Size = new System.Drawing.Size(152, 20);
            this.textBoxEfternamn.TabIndex = 22;
            // 
            // lblEpost
            // 
            this.lblEpost.AutoSize = true;
            this.lblEpost.Location = new System.Drawing.Point(266, 72);
            this.lblEpost.Name = "lblEpost";
            this.lblEpost.Size = new System.Drawing.Size(40, 13);
            this.lblEpost.TabIndex = 36;
            this.lblEpost.Text = "E post:";
            // 
            // textBoxTelefonnummer
            // 
            this.textBoxTelefonnummer.Location = new System.Drawing.Point(47, 283);
            this.textBoxTelefonnummer.Name = "textBoxTelefonnummer";
            this.textBoxTelefonnummer.Size = new System.Drawing.Size(152, 20);
            this.textBoxTelefonnummer.TabIndex = 23;
            // 
            // lblAnvandarnamn
            // 
            this.lblAnvandarnamn.AutoSize = true;
            this.lblAnvandarnamn.Location = new System.Drawing.Point(266, 137);
            this.lblAnvandarnamn.Name = "lblAnvandarnamn";
            this.lblAnvandarnamn.Size = new System.Drawing.Size(82, 13);
            this.lblAnvandarnamn.TabIndex = 38;
            this.lblAnvandarnamn.Text = "Användarnamn:";
            // 
            // textBoxEpost
            // 
            this.textBoxEpost.Location = new System.Drawing.Point(266, 87);
            this.textBoxEpost.Name = "textBoxEpost";
            this.textBoxEpost.Size = new System.Drawing.Size(152, 20);
            this.textBoxEpost.TabIndex = 24;
            // 
            // textBoxFornamn
            // 
            this.textBoxFornamn.Location = new System.Drawing.Point(47, 152);
            this.textBoxFornamn.Name = "textBoxFornamn";
            this.textBoxFornamn.Size = new System.Drawing.Size(152, 20);
            this.textBoxFornamn.TabIndex = 21;
            // 
            // textBoxAnvandarnamn
            // 
            this.textBoxAnvandarnamn.Location = new System.Drawing.Point(266, 152);
            this.textBoxAnvandarnamn.Name = "textBoxAnvandarnamn";
            this.textBoxAnvandarnamn.Size = new System.Drawing.Size(152, 20);
            this.textBoxAnvandarnamn.TabIndex = 25;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(872, 1);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(68, 27);
            this.buttonLogOut.TabIndex = 1;
            this.buttonLogOut.Text = "Logga ut";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelStaffName
            // 
            this.labelStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStaffName.AutoSize = true;
            this.labelStaffName.Location = new System.Drawing.Point(796, 8);
            this.labelStaffName.Name = "labelStaffName";
            this.labelStaffName.Size = new System.Drawing.Size(35, 13);
            this.labelStaffName.TabIndex = 2;
            this.labelStaffName.Text = "Namn";
            this.labelStaffName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.labelStaffName);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Välkommen";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTicket.ResumeLayout(false);
            this.tabTicket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabShow.ResumeLayout(false);
            this.tabShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowsList)).EndInit();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTicket;
        private System.Windows.Forms.TabPage tabShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxOlderTickets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonEditTicket;
        private System.Windows.Forms.Button buttonReserveTicket;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.TextBox textBoxAntalVuxenBiljetter;
        private System.Windows.Forms.Button buttonSkapaForestalnning;
        private System.Windows.Forms.Label labelAkter;
        private System.Windows.Forms.Label labelForestallning;
        private System.Windows.Forms.Button buttonSkrivUtForestallning;
        private System.Windows.Forms.Button buttonRaderaForestallning;
        private System.Windows.Forms.Button buttonAndraForestallning;
        private System.Windows.Forms.Label labelKronor;
        private System.Windows.Forms.Label labelAntal;
        private System.Windows.Forms.Label labelTotalt;
        private System.Windows.Forms.Label labelBarnbiljetter;
        private System.Windows.Forms.Label labelUngdomsbiljetter;
        private System.Windows.Forms.Label labelVuxenbiljetter;
        private System.Windows.Forms.TextBox textBoxKronorVuxenbiljetter;
        private System.Windows.Forms.TextBox textBoxAntalUngdomsbiljetter;
        private System.Windows.Forms.TextBox textBoxKronorUngdomsbiljetter;
        private System.Windows.Forms.TextBox textBoxAntalBarnbiljetter;
        private System.Windows.Forms.TextBox textBoxKronorBarnbiljetter;
        private System.Windows.Forms.TextBox textBoxTotaltAntal;
        private System.Windows.Forms.TextBox textBoxTotaltKronor;
        private System.Windows.Forms.ComboBox comboBoxBehorighetsniva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTomFalten;
        private System.Windows.Forms.Button btnUpdateraKonto;
        private System.Windows.Forms.Label lblFornamn;
        private System.Windows.Forms.Button btnSkapaKonto;
        private System.Windows.Forms.Label lblSokPerson;
        private System.Windows.Forms.Label lblEfternamn;
        private System.Windows.Forms.TextBox textBoxLosenord;
        private System.Windows.Forms.Label lblTelefonnummer;
        private System.Windows.Forms.TextBox textBoxEfternamn;
        private System.Windows.Forms.Label lblEpost;
        private System.Windows.Forms.TextBox textBoxTelefonnummer;
        private System.Windows.Forms.Label lblAnvandarnamn;
        private System.Windows.Forms.TextBox textBoxEpost;
        private System.Windows.Forms.TextBox textBoxFornamn;
        private System.Windows.Forms.TextBox textBoxAnvandarnamn;
        private System.Windows.Forms.Label labelStaffName;
        private System.Windows.Forms.DataGridView dgvShowsList;
        private System.Windows.Forms.DataGridView dgCustomers;
        private System.Windows.Forms.TextBox textBoxSearchCustomer;
        private System.Windows.Forms.DataGridView dgStaff;
        private System.Windows.Forms.TextBox textBoxSearchStaff;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dgTickets;
        private System.Windows.Forms.TextBox textBoxPrintPrice;
        private System.Windows.Forms.TextBox textBoxPrintAct;
        private System.Windows.Forms.TextBox textBoxPrintShow;
        private System.Windows.Forms.TextBox textBoxPrintAge;
        private System.Windows.Forms.TextBox textBoxPrintSeat;
        private System.Windows.Forms.Label lblBehorighetsniva;
        private System.Windows.Forms.Label lblLosenord;
        private System.Windows.Forms.DataGridView dgvAkter;
        private System.Windows.Forms.Label lblPersonnummer;
        private System.Windows.Forms.TextBox textBoxPersonnummer;
        private System.Windows.Forms.Label LblVarning;
        private System.Windows.Forms.Button button1;
    }
}