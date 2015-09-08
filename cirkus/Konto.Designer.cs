namespace cirkus
{
    partial class Konto
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
            this.tabBiljett = new System.Windows.Forms.TabPage();
            this.tabForestallning = new System.Windows.Forms.TabPage();
            this.tabKonto = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBehorighetsniva = new System.Windows.Forms.ComboBox();
            this.btnTomFalten = new System.Windows.Forms.Button();
            this.btnUpdateraKonto = new System.Windows.Forms.Button();
            this.btnSkapaKonto = new System.Windows.Forms.Button();
            this.lblSokPerson = new System.Windows.Forms.Label();
            this.textBoxLosenord = new System.Windows.Forms.TextBox();
            this.textBoxEfternamn = new System.Windows.Forms.TextBox();
            this.textBoxTelefonnummer = new System.Windows.Forms.TextBox();
            this.textBoxEpost = new System.Windows.Forms.TextBox();
            this.textBoxAnvandarnamn = new System.Windows.Forms.TextBox();
            this.textBoxFornamn = new System.Windows.Forms.TextBox();
            this.lblLosenord = new System.Windows.Forms.Label();
            this.lblAnvandarnamn = new System.Windows.Forms.Label();
            this.lblEpost = new System.Windows.Forms.Label();
            this.lblTelefonnummer = new System.Windows.Forms.Label();
            this.lblEfternamn = new System.Windows.Forms.Label();
            this.textBoxSokfalt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFornamn = new System.Windows.Forms.Label();
            this.listBoxRegister = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabKonto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBiljett);
            this.tabControl1.Controls.Add(this.tabForestallning);
            this.tabControl1.Controls.Add(this.tabKonto);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 500);
            this.tabControl1.TabIndex = 1;
            // 
            // tabBiljett
            // 
            this.tabBiljett.Location = new System.Drawing.Point(4, 22);
            this.tabBiljett.Name = "tabBiljett";
            this.tabBiljett.Padding = new System.Windows.Forms.Padding(3);
            this.tabBiljett.Size = new System.Drawing.Size(932, 474);
            this.tabBiljett.TabIndex = 0;
            this.tabBiljett.Text = "Biljettförsäljning";
            this.tabBiljett.UseVisualStyleBackColor = true;
            // 
            // tabForestallning
            // 
            this.tabForestallning.Location = new System.Drawing.Point(4, 22);
            this.tabForestallning.Name = "tabForestallning";
            this.tabForestallning.Padding = new System.Windows.Forms.Padding(3);
            this.tabForestallning.Size = new System.Drawing.Size(932, 474);
            this.tabForestallning.TabIndex = 1;
            this.tabForestallning.Text = "Föreställning";
            this.tabForestallning.UseVisualStyleBackColor = true;
            // 
            // tabKonto
            // 
            this.tabKonto.Controls.Add(this.label3);
            this.tabKonto.Controls.Add(this.comboBoxBehorighetsniva);
            this.tabKonto.Controls.Add(this.btnTomFalten);
            this.tabKonto.Controls.Add(this.btnUpdateraKonto);
            this.tabKonto.Controls.Add(this.btnSkapaKonto);
            this.tabKonto.Controls.Add(this.lblSokPerson);
            this.tabKonto.Controls.Add(this.textBoxLosenord);
            this.tabKonto.Controls.Add(this.textBoxEfternamn);
            this.tabKonto.Controls.Add(this.textBoxTelefonnummer);
            this.tabKonto.Controls.Add(this.textBoxEpost);
            this.tabKonto.Controls.Add(this.textBoxAnvandarnamn);
            this.tabKonto.Controls.Add(this.textBoxFornamn);
            this.tabKonto.Controls.Add(this.lblLosenord);
            this.tabKonto.Controls.Add(this.lblAnvandarnamn);
            this.tabKonto.Controls.Add(this.lblEpost);
            this.tabKonto.Controls.Add(this.lblTelefonnummer);
            this.tabKonto.Controls.Add(this.lblEfternamn);
            this.tabKonto.Controls.Add(this.textBoxSokfalt);
            this.tabKonto.Controls.Add(this.label2);
            this.tabKonto.Controls.Add(this.lblFornamn);
            this.tabKonto.Controls.Add(this.listBoxRegister);
            this.tabKonto.Location = new System.Drawing.Point(4, 22);
            this.tabKonto.Name = "tabKonto";
            this.tabKonto.Size = new System.Drawing.Size(932, 474);
            this.tabKonto.TabIndex = 2;
            this.tabKonto.Text = "Konto";
            this.tabKonto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Behörighetsnivå:";
            // 
            // comboBoxBehorighetsniva
            // 
            this.comboBoxBehorighetsniva.FormattingEnabled = true;
            this.comboBoxBehorighetsniva.Items.AddRange(new object[] {
            "Biljettförsäljare",
            "Administratör"});
            this.comboBoxBehorighetsniva.Location = new System.Drawing.Point(79, 348);
            this.comboBoxBehorighetsniva.Name = "comboBoxBehorighetsniva";
            this.comboBoxBehorighetsniva.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBehorighetsniva.TabIndex = 6;
            // 
            // btnTomFalten
            // 
            this.btnTomFalten.Location = new System.Drawing.Point(319, 386);
            this.btnTomFalten.Name = "btnTomFalten";
            this.btnTomFalten.Size = new System.Drawing.Size(121, 31);
            this.btnTomFalten.TabIndex = 9;
            this.btnTomFalten.Text = "Töm fälten";
            this.btnTomFalten.UseVisualStyleBackColor = true;
            // 
            // btnUpdateraKonto
            // 
            this.btnUpdateraKonto.Location = new System.Drawing.Point(79, 424);
            this.btnUpdateraKonto.Name = "btnUpdateraKonto";
            this.btnUpdateraKonto.Size = new System.Drawing.Size(121, 31);
            this.btnUpdateraKonto.TabIndex = 8;
            this.btnUpdateraKonto.Text = "Updatera konto";
            this.btnUpdateraKonto.UseVisualStyleBackColor = true;
            // 
            // btnSkapaKonto
            // 
            this.btnSkapaKonto.Location = new System.Drawing.Point(79, 387);
            this.btnSkapaKonto.Name = "btnSkapaKonto";
            this.btnSkapaKonto.Size = new System.Drawing.Size(121, 31);
            this.btnSkapaKonto.TabIndex = 7;
            this.btnSkapaKonto.Text = "Skapa konto";
            this.btnSkapaKonto.UseVisualStyleBackColor = true;
            // 
            // lblSokPerson
            // 
            this.lblSokPerson.AutoSize = true;
            this.lblSokPerson.Location = new System.Drawing.Point(319, 45);
            this.lblSokPerson.Name = "lblSokPerson";
            this.lblSokPerson.Size = new System.Drawing.Size(61, 13);
            this.lblSokPerson.TabIndex = 20;
            this.lblSokPerson.Text = "Sök person";
            // 
            // textBoxLosenord
            // 
            this.textBoxLosenord.Location = new System.Drawing.Point(79, 301);
            this.textBoxLosenord.Name = "textBoxLosenord";
            this.textBoxLosenord.Size = new System.Drawing.Size(121, 20);
            this.textBoxLosenord.TabIndex = 5;
            // 
            // textBoxEfternamn
            // 
            this.textBoxEfternamn.Location = new System.Drawing.Point(79, 113);
            this.textBoxEfternamn.Name = "textBoxEfternamn";
            this.textBoxEfternamn.Size = new System.Drawing.Size(121, 20);
            this.textBoxEfternamn.TabIndex = 1;
            // 
            // textBoxTelefonnummer
            // 
            this.textBoxTelefonnummer.Location = new System.Drawing.Point(79, 160);
            this.textBoxTelefonnummer.Name = "textBoxTelefonnummer";
            this.textBoxTelefonnummer.Size = new System.Drawing.Size(121, 20);
            this.textBoxTelefonnummer.TabIndex = 2;
            // 
            // textBoxEpost
            // 
            this.textBoxEpost.Location = new System.Drawing.Point(79, 207);
            this.textBoxEpost.Name = "textBoxEpost";
            this.textBoxEpost.Size = new System.Drawing.Size(121, 20);
            this.textBoxEpost.TabIndex = 3;
            // 
            // textBoxAnvandarnamn
            // 
            this.textBoxAnvandarnamn.Location = new System.Drawing.Point(79, 254);
            this.textBoxAnvandarnamn.Name = "textBoxAnvandarnamn";
            this.textBoxAnvandarnamn.Size = new System.Drawing.Size(121, 20);
            this.textBoxAnvandarnamn.TabIndex = 4;
            // 
            // textBoxFornamn
            // 
            this.textBoxFornamn.Location = new System.Drawing.Point(79, 66);
            this.textBoxFornamn.Name = "textBoxFornamn";
            this.textBoxFornamn.Size = new System.Drawing.Size(121, 20);
            this.textBoxFornamn.TabIndex = 0;
            // 
            // lblLosenord
            // 
            this.lblLosenord.AutoSize = true;
            this.lblLosenord.Location = new System.Drawing.Point(82, 286);
            this.lblLosenord.Name = "lblLosenord";
            this.lblLosenord.Size = new System.Drawing.Size(54, 13);
            this.lblLosenord.TabIndex = 13;
            this.lblLosenord.Text = "Lösenord:";
            // 
            // lblAnvandarnamn
            // 
            this.lblAnvandarnamn.AutoSize = true;
            this.lblAnvandarnamn.Location = new System.Drawing.Point(82, 239);
            this.lblAnvandarnamn.Name = "lblAnvandarnamn";
            this.lblAnvandarnamn.Size = new System.Drawing.Size(82, 13);
            this.lblAnvandarnamn.TabIndex = 12;
            this.lblAnvandarnamn.Text = "Användarnamn:";
            // 
            // lblEpost
            // 
            this.lblEpost.AutoSize = true;
            this.lblEpost.Location = new System.Drawing.Point(82, 192);
            this.lblEpost.Name = "lblEpost";
            this.lblEpost.Size = new System.Drawing.Size(40, 13);
            this.lblEpost.TabIndex = 11;
            this.lblEpost.Text = "E post:";
            // 
            // lblTelefonnummer
            // 
            this.lblTelefonnummer.AutoSize = true;
            this.lblTelefonnummer.Location = new System.Drawing.Point(82, 145);
            this.lblTelefonnummer.Name = "lblTelefonnummer";
            this.lblTelefonnummer.Size = new System.Drawing.Size(83, 13);
            this.lblTelefonnummer.TabIndex = 10;
            this.lblTelefonnummer.Text = "Telefonnummer:";
            // 
            // lblEfternamn
            // 
            this.lblEfternamn.AutoSize = true;
            this.lblEfternamn.Location = new System.Drawing.Point(82, 98);
            this.lblEfternamn.Name = "lblEfternamn";
            this.lblEfternamn.Size = new System.Drawing.Size(58, 13);
            this.lblEfternamn.TabIndex = 9;
            this.lblEfternamn.Text = "Efternamn:";
            // 
            // textBoxSokfalt
            // 
            this.textBoxSokfalt.Location = new System.Drawing.Point(319, 60);
            this.textBoxSokfalt.Name = "textBoxSokfalt";
            this.textBoxSokfalt.Size = new System.Drawing.Size(209, 20);
            this.textBoxSokfalt.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Konto";
            // 
            // lblFornamn
            // 
            this.lblFornamn.AutoSize = true;
            this.lblFornamn.Location = new System.Drawing.Point(82, 51);
            this.lblFornamn.Name = "lblFornamn";
            this.lblFornamn.Size = new System.Drawing.Size(51, 13);
            this.lblFornamn.TabIndex = 6;
            this.lblFornamn.Text = "Förnamn:";
            // 
            // listBoxRegister
            // 
            this.listBoxRegister.FormattingEnabled = true;
            this.listBoxRegister.Location = new System.Drawing.Point(319, 95);
            this.listBoxRegister.Name = "listBoxRegister";
            this.listBoxRegister.Size = new System.Drawing.Size(209, 251);
            this.listBoxRegister.TabIndex = 11;
            // 
            // Konto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 523);
            this.Controls.Add(this.tabControl1);
            this.Name = "Konto";
            this.Text = "Konto";
            this.tabControl1.ResumeLayout(false);
            this.tabKonto.ResumeLayout(false);
            this.tabKonto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBiljett;
        private System.Windows.Forms.TabPage tabForestallning;
        private System.Windows.Forms.TabPage tabKonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBehorighetsniva;
        private System.Windows.Forms.Button btnTomFalten;
        private System.Windows.Forms.Button btnUpdateraKonto;
        private System.Windows.Forms.Button btnSkapaKonto;
        private System.Windows.Forms.Label lblSokPerson;
        private System.Windows.Forms.TextBox textBoxLosenord;
        private System.Windows.Forms.TextBox textBoxEfternamn;
        private System.Windows.Forms.TextBox textBoxTelefonnummer;
        private System.Windows.Forms.TextBox textBoxEpost;
        private System.Windows.Forms.TextBox textBoxAnvandarnamn;
        private System.Windows.Forms.TextBox textBoxFornamn;
        private System.Windows.Forms.Label lblLosenord;
        private System.Windows.Forms.Label lblAnvandarnamn;
        private System.Windows.Forms.Label lblEpost;
        private System.Windows.Forms.Label lblTelefonnummer;
        private System.Windows.Forms.Label lblEfternamn;
        private System.Windows.Forms.TextBox textBoxSokfalt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFornamn;
        private System.Windows.Forms.ListBox listBoxRegister;
    }
}