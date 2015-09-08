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
            this.button4 = new System.Windows.Forms.Button();
            this.buttonEditTicket = new System.Windows.Forms.Button();
            this.buttonReserveTicket = new System.Windows.Forms.Button();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxOlderTickets = new System.Windows.Forms.CheckBox();
            this.listBoxTicket = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxCustomer = new System.Windows.Forms.ListBox();
            this.tabShow = new System.Windows.Forms.TabPage();
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
            this.listBoxAkter = new System.Windows.Forms.ListBox();
            this.listBoxForestallningar = new System.Windows.Forms.ListBox();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelForestallning = new System.Windows.Forms.Label();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.comboBoxBehorighetsniva = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTomFalten = new System.Windows.Forms.Button();
            this.listBoxRegister = new System.Windows.Forms.ListBox();
            this.btnUpdateraKonto = new System.Windows.Forms.Button();
            this.lblFornamn = new System.Windows.Forms.Label();
            this.btnSkapaKonto = new System.Windows.Forms.Button();
            this.textBoxSokfalt = new System.Windows.Forms.TextBox();
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
            this.tabControl1.SuspendLayout();
            this.tabTicket.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabShow.SuspendLayout();
            this.tabAccount.SuspendLayout();
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
            // 
            // tabTicket
            // 
            this.tabTicket.Controls.Add(this.button4);
            this.tabTicket.Controls.Add(this.buttonEditTicket);
            this.tabTicket.Controls.Add(this.buttonReserveTicket);
            this.tabTicket.Controls.Add(this.buttonAddCustomer);
            this.tabTicket.Controls.Add(this.groupBox1);
            this.tabTicket.Controls.Add(this.checkBoxOlderTickets);
            this.tabTicket.Controls.Add(this.listBoxTicket);
            this.tabTicket.Controls.Add(this.label3);
            this.tabTicket.Controls.Add(this.textBoxSearchCustomer);
            this.tabTicket.Controls.Add(this.label2);
            this.tabTicket.Controls.Add(this.label1);
            this.tabTicket.Controls.Add(this.listBoxCustomer);
            this.tabTicket.Location = new System.Drawing.Point(4, 22);
            this.tabTicket.Name = "tabTicket";
            this.tabTicket.Padding = new System.Windows.Forms.Padding(3);
            this.tabTicket.Size = new System.Drawing.Size(925, 456);
            this.tabTicket.TabIndex = 0;
            this.tabTicket.Text = "Biljettförsäljning";
            this.tabTicket.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.buttonPrint);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(438, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 430);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utskrift";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(218, 404);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "Skriv ut";
            this.buttonPrint.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pris:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Akt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Föreställning:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Plats:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Åldersgrupp:";
            // 
            // checkBoxOlderTickets
            // 
            this.checkBoxOlderTickets.AutoSize = true;
            this.checkBoxOlderTickets.Location = new System.Drawing.Point(233, 52);
            this.checkBoxOlderTickets.Name = "checkBoxOlderTickets";
            this.checkBoxOlderTickets.Size = new System.Drawing.Size(108, 17);
            this.checkBoxOlderTickets.TabIndex = 7;
            this.checkBoxOlderTickets.Text = "Visa äldre biljetter";
            this.checkBoxOlderTickets.UseVisualStyleBackColor = true;
            // 
            // listBoxTicket
            // 
            this.listBoxTicket.FormattingEnabled = true;
            this.listBoxTicket.Location = new System.Drawing.Point(233, 75);
            this.listBoxTicket.Name = "listBoxTicket";
            this.listBoxTicket.Size = new System.Drawing.Size(190, 368);
            this.listBoxTicket.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Biljett";
            // 
            // textBoxSearchCustomer
            // 
            this.textBoxSearchCustomer.Location = new System.Drawing.Point(40, 49);
            this.textBoxSearchCustomer.Name = "textBoxSearchCustomer";
            this.textBoxSearchCustomer.Size = new System.Drawing.Size(158, 20);
            this.textBoxSearchCustomer.TabIndex = 4;
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
            // listBoxCustomer
            // 
            this.listBoxCustomer.FormattingEnabled = true;
            this.listBoxCustomer.Location = new System.Drawing.Point(8, 75);
            this.listBoxCustomer.Name = "listBoxCustomer";
            this.listBoxCustomer.Size = new System.Drawing.Size(190, 368);
            this.listBoxCustomer.TabIndex = 0;
            // 
            // tabShow
            // 
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
            this.tabShow.Controls.Add(this.listBoxAkter);
            this.tabShow.Controls.Add(this.listBoxForestallningar);
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
            this.buttonRaderaForestallning.Location = new System.Drawing.Point(182, 227);
            this.buttonRaderaForestallning.Name = "buttonRaderaForestallning";
            this.buttonRaderaForestallning.Size = new System.Drawing.Size(72, 23);
            this.buttonRaderaForestallning.TabIndex = 13;
            this.buttonRaderaForestallning.Text = "Radera";
            this.buttonRaderaForestallning.UseVisualStyleBackColor = true;
            // 
            // buttonAndraForestallning
            // 
            this.buttonAndraForestallning.Location = new System.Drawing.Point(104, 227);
            this.buttonAndraForestallning.Name = "buttonAndraForestallning";
            this.buttonAndraForestallning.Size = new System.Drawing.Size(72, 23);
            this.buttonAndraForestallning.TabIndex = 12;
            this.buttonAndraForestallning.Text = "Ändra";
            this.buttonAndraForestallning.UseVisualStyleBackColor = true;
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
            this.buttonSkapaForestalnning.Location = new System.Drawing.Point(26, 227);
            this.buttonSkapaForestalnning.Name = "buttonSkapaForestalnning";
            this.buttonSkapaForestalnning.Size = new System.Drawing.Size(72, 23);
            this.buttonSkapaForestalnning.TabIndex = 4;
            this.buttonSkapaForestalnning.Text = "Skapa ny";
            this.buttonSkapaForestalnning.UseVisualStyleBackColor = true;
            // 
            // listBoxAkter
            // 
            this.listBoxAkter.FormattingEnabled = true;
            this.listBoxAkter.Location = new System.Drawing.Point(291, 65);
            this.listBoxAkter.Name = "listBoxAkter";
            this.listBoxAkter.Size = new System.Drawing.Size(102, 147);
            this.listBoxAkter.TabIndex = 3;
            // 
            // listBoxForestallningar
            // 
            this.listBoxForestallningar.FormattingEnabled = true;
            this.listBoxForestallningar.Location = new System.Drawing.Point(26, 65);
            this.listBoxForestallningar.Name = "listBoxForestallningar";
            this.listBoxForestallningar.Size = new System.Drawing.Size(228, 147);
            this.listBoxForestallningar.TabIndex = 2;
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
            this.tabAccount.Controls.Add(this.comboBoxBehorighetsniva);
            this.tabAccount.Controls.Add(this.label9);
            this.tabAccount.Controls.Add(this.btnTomFalten);
            this.tabAccount.Controls.Add(this.listBoxRegister);
            this.tabAccount.Controls.Add(this.btnUpdateraKonto);
            this.tabAccount.Controls.Add(this.lblFornamn);
            this.tabAccount.Controls.Add(this.btnSkapaKonto);
            this.tabAccount.Controls.Add(this.textBoxSokfalt);
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
            // comboBoxBehorighetsniva
            // 
            this.comboBoxBehorighetsniva.FormattingEnabled = true;
            this.comboBoxBehorighetsniva.Items.AddRange(new object[] {
            "Biljettförsäljare",
            "Administratör"});
            this.comboBoxBehorighetsniva.Location = new System.Drawing.Point(59, 336);
            this.comboBoxBehorighetsniva.Name = "comboBoxBehorighetsniva";
            this.comboBoxBehorighetsniva.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBehorighetsniva.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Konto";
            // 
            // btnTomFalten
            // 
            this.btnTomFalten.Location = new System.Drawing.Point(299, 374);
            this.btnTomFalten.Name = "btnTomFalten";
            this.btnTomFalten.Size = new System.Drawing.Size(121, 31);
            this.btnTomFalten.TabIndex = 32;
            this.btnTomFalten.Text = "Töm fälten";
            this.btnTomFalten.UseVisualStyleBackColor = true;
            // 
            // listBoxRegister
            // 
            this.listBoxRegister.FormattingEnabled = true;
            this.listBoxRegister.Location = new System.Drawing.Point(299, 83);
            this.listBoxRegister.Name = "listBoxRegister";
            this.listBoxRegister.Size = new System.Drawing.Size(209, 251);
            this.listBoxRegister.TabIndex = 37;
            // 
            // btnUpdateraKonto
            // 
            this.btnUpdateraKonto.Location = new System.Drawing.Point(59, 412);
            this.btnUpdateraKonto.Name = "btnUpdateraKonto";
            this.btnUpdateraKonto.Size = new System.Drawing.Size(121, 31);
            this.btnUpdateraKonto.TabIndex = 31;
            this.btnUpdateraKonto.Text = "Updatera konto";
            this.btnUpdateraKonto.UseVisualStyleBackColor = true;
            // 
            // lblFornamn
            // 
            this.lblFornamn.AutoSize = true;
            this.lblFornamn.Location = new System.Drawing.Point(62, 39);
            this.lblFornamn.Name = "lblFornamn";
            this.lblFornamn.Size = new System.Drawing.Size(51, 13);
            this.lblFornamn.TabIndex = 27;
            this.lblFornamn.Text = "Förnamn:";
            // 
            // btnSkapaKonto
            // 
            this.btnSkapaKonto.Location = new System.Drawing.Point(59, 375);
            this.btnSkapaKonto.Name = "btnSkapaKonto";
            this.btnSkapaKonto.Size = new System.Drawing.Size(121, 31);
            this.btnSkapaKonto.TabIndex = 29;
            this.btnSkapaKonto.Text = "Skapa konto";
            this.btnSkapaKonto.UseVisualStyleBackColor = true;
            // 
            // textBoxSokfalt
            // 
            this.textBoxSokfalt.Location = new System.Drawing.Point(299, 48);
            this.textBoxSokfalt.Name = "textBoxSokfalt";
            this.textBoxSokfalt.Size = new System.Drawing.Size(209, 20);
            this.textBoxSokfalt.TabIndex = 35;
            // 
            // lblSokPerson
            // 
            this.lblSokPerson.AutoSize = true;
            this.lblSokPerson.Location = new System.Drawing.Point(299, 33);
            this.lblSokPerson.Name = "lblSokPerson";
            this.lblSokPerson.Size = new System.Drawing.Size(61, 13);
            this.lblSokPerson.TabIndex = 39;
            this.lblSokPerson.Text = "Sök person";
            // 
            // lblEfternamn
            // 
            this.lblEfternamn.AutoSize = true;
            this.lblEfternamn.Location = new System.Drawing.Point(62, 86);
            this.lblEfternamn.Name = "lblEfternamn";
            this.lblEfternamn.Size = new System.Drawing.Size(58, 13);
            this.lblEfternamn.TabIndex = 33;
            this.lblEfternamn.Text = "Efternamn:";
            // 
            // textBoxLosenord
            // 
            this.textBoxLosenord.Location = new System.Drawing.Point(59, 289);
            this.textBoxLosenord.Name = "textBoxLosenord";
            this.textBoxLosenord.Size = new System.Drawing.Size(121, 20);
            this.textBoxLosenord.TabIndex = 26;
            // 
            // lblTelefonnummer
            // 
            this.lblTelefonnummer.AutoSize = true;
            this.lblTelefonnummer.Location = new System.Drawing.Point(62, 133);
            this.lblTelefonnummer.Name = "lblTelefonnummer";
            this.lblTelefonnummer.Size = new System.Drawing.Size(83, 13);
            this.lblTelefonnummer.TabIndex = 34;
            this.lblTelefonnummer.Text = "Telefonnummer:";
            // 
            // textBoxEfternamn
            // 
            this.textBoxEfternamn.Location = new System.Drawing.Point(59, 101);
            this.textBoxEfternamn.Name = "textBoxEfternamn";
            this.textBoxEfternamn.Size = new System.Drawing.Size(121, 20);
            this.textBoxEfternamn.TabIndex = 22;
            // 
            // lblEpost
            // 
            this.lblEpost.AutoSize = true;
            this.lblEpost.Location = new System.Drawing.Point(62, 180);
            this.lblEpost.Name = "lblEpost";
            this.lblEpost.Size = new System.Drawing.Size(40, 13);
            this.lblEpost.TabIndex = 36;
            this.lblEpost.Text = "E post:";
            // 
            // textBoxTelefonnummer
            // 
            this.textBoxTelefonnummer.Location = new System.Drawing.Point(59, 148);
            this.textBoxTelefonnummer.Name = "textBoxTelefonnummer";
            this.textBoxTelefonnummer.Size = new System.Drawing.Size(121, 20);
            this.textBoxTelefonnummer.TabIndex = 23;
            // 
            // lblAnvandarnamn
            // 
            this.lblAnvandarnamn.AutoSize = true;
            this.lblAnvandarnamn.Location = new System.Drawing.Point(62, 227);
            this.lblAnvandarnamn.Name = "lblAnvandarnamn";
            this.lblAnvandarnamn.Size = new System.Drawing.Size(82, 13);
            this.lblAnvandarnamn.TabIndex = 38;
            this.lblAnvandarnamn.Text = "Användarnamn:";
            // 
            // textBoxEpost
            // 
            this.textBoxEpost.Location = new System.Drawing.Point(59, 195);
            this.textBoxEpost.Name = "textBoxEpost";
            this.textBoxEpost.Size = new System.Drawing.Size(121, 20);
            this.textBoxEpost.TabIndex = 24;
            // 
            // textBoxFornamn
            // 
            this.textBoxFornamn.Location = new System.Drawing.Point(59, 54);
            this.textBoxFornamn.Name = "textBoxFornamn";
            this.textBoxFornamn.Size = new System.Drawing.Size(121, 20);
            this.textBoxFornamn.TabIndex = 21;
            // 
            // textBoxAnvandarnamn
            // 
            this.textBoxAnvandarnamn.Location = new System.Drawing.Point(59, 242);
            this.textBoxAnvandarnamn.Name = "textBoxAnvandarnamn";
            this.textBoxAnvandarnamn.Size = new System.Drawing.Size(121, 20);
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
            this.tabControl1.ResumeLayout(false);
            this.tabTicket.ResumeLayout(false);
            this.tabTicket.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabShow.ResumeLayout(false);
            this.tabShow.PerformLayout();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTicket;
        private System.Windows.Forms.TabPage tabShow;
        private System.Windows.Forms.TextBox textBoxSearchCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxCustomer;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxOlderTickets;
        private System.Windows.Forms.ListBox listBoxTicket;
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
        private System.Windows.Forms.ListBox listBoxAkter;
        private System.Windows.Forms.ListBox listBoxForestallningar;
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
        private System.Windows.Forms.ListBox listBoxRegister;
        private System.Windows.Forms.Button btnUpdateraKonto;
        private System.Windows.Forms.Label lblFornamn;
        private System.Windows.Forms.Button btnSkapaKonto;
        private System.Windows.Forms.TextBox textBoxSokfalt;
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
    }
}