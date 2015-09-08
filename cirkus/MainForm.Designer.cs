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
            this.tabBiljett = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabForestallning = new System.Windows.Forms.TabPage();
            this.textBoxAntalVuxenBiljetter = new System.Windows.Forms.TextBox();
            this.buttonSkapaForestalnning = new System.Windows.Forms.Button();
            this.listBoxAkter = new System.Windows.Forms.ListBox();
            this.listBoxForestallningar = new System.Windows.Forms.ListBox();
            this.labelAkter = new System.Windows.Forms.Label();
            this.labelForestallning = new System.Windows.Forms.Label();
            this.tabKonto = new System.Windows.Forms.TabPage();
            this.labelVuxenbiljetter = new System.Windows.Forms.Label();
            this.labelUngdomsbiljetter = new System.Windows.Forms.Label();
            this.labelBarnbiljetter = new System.Windows.Forms.Label();
            this.labelTotalt = new System.Windows.Forms.Label();
            this.labelAntal = new System.Windows.Forms.Label();
            this.labelKronor = new System.Windows.Forms.Label();
            this.buttonAndraForestallning = new System.Windows.Forms.Button();
            this.buttonRaderaForestallning = new System.Windows.Forms.Button();
            this.buttonSkrivUtForestallning = new System.Windows.Forms.Button();
            this.textBoxTotaltKronor = new System.Windows.Forms.TextBox();
            this.textBoxTotaltAntal = new System.Windows.Forms.TextBox();
            this.textBoxKronorBarnbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxAntalBarnbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxKronorUngdomsbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxAntalUngdomsbiljetter = new System.Windows.Forms.TextBox();
            this.textBoxKronorVuxenbiljetter = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabBiljett.SuspendLayout();
            this.tabForestallning.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBiljett);
            this.tabControl1.Controls.Add(this.tabForestallning);
            this.tabControl1.Controls.Add(this.tabKonto);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBiljett
            // 
            this.tabBiljett.Controls.Add(this.textBox1);
            this.tabBiljett.Controls.Add(this.label2);
            this.tabBiljett.Controls.Add(this.label1);
            this.tabBiljett.Controls.Add(this.listBox1);
            this.tabBiljett.Location = new System.Drawing.Point(4, 22);
            this.tabBiljett.Name = "tabBiljett";
            this.tabBiljett.Padding = new System.Windows.Forms.Padding(3);
            this.tabBiljett.Size = new System.Drawing.Size(932, 474);
            this.tabBiljett.TabIndex = 0;
            this.tabBiljett.Text = "Biljettförsäljning";
            this.tabBiljett.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 4;
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
            this.label1.Location = new System.Drawing.Point(876, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(190, 394);
            this.listBox1.TabIndex = 0;
            // 
            // tabForestallning
            // 
            this.tabForestallning.Controls.Add(this.textBoxKronorVuxenbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxAntalUngdomsbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxKronorUngdomsbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxAntalBarnbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxKronorBarnbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxTotaltAntal);
            this.tabForestallning.Controls.Add(this.textBoxTotaltKronor);
            this.tabForestallning.Controls.Add(this.buttonSkrivUtForestallning);
            this.tabForestallning.Controls.Add(this.buttonRaderaForestallning);
            this.tabForestallning.Controls.Add(this.buttonAndraForestallning);
            this.tabForestallning.Controls.Add(this.labelKronor);
            this.tabForestallning.Controls.Add(this.labelAntal);
            this.tabForestallning.Controls.Add(this.labelTotalt);
            this.tabForestallning.Controls.Add(this.labelBarnbiljetter);
            this.tabForestallning.Controls.Add(this.labelUngdomsbiljetter);
            this.tabForestallning.Controls.Add(this.labelVuxenbiljetter);
            this.tabForestallning.Controls.Add(this.textBoxAntalVuxenBiljetter);
            this.tabForestallning.Controls.Add(this.buttonSkapaForestalnning);
            this.tabForestallning.Controls.Add(this.listBoxAkter);
            this.tabForestallning.Controls.Add(this.listBoxForestallningar);
            this.tabForestallning.Controls.Add(this.labelAkter);
            this.tabForestallning.Controls.Add(this.labelForestallning);
            this.tabForestallning.Location = new System.Drawing.Point(4, 22);
            this.tabForestallning.Name = "tabForestallning";
            this.tabForestallning.Padding = new System.Windows.Forms.Padding(3);
            this.tabForestallning.Size = new System.Drawing.Size(932, 474);
            this.tabForestallning.TabIndex = 1;
            this.tabForestallning.Text = "Föreställning";
            this.tabForestallning.UseVisualStyleBackColor = true;
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
            // tabKonto
            // 
            this.tabKonto.Location = new System.Drawing.Point(4, 22);
            this.tabKonto.Name = "tabKonto";
            this.tabKonto.Size = new System.Drawing.Size(932, 474);
            this.tabKonto.TabIndex = 2;
            this.tabKonto.Text = "Konto";
            this.tabKonto.UseVisualStyleBackColor = true;
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
            // labelUngdomsbiljetter
            // 
            this.labelUngdomsbiljetter.AutoSize = true;
            this.labelUngdomsbiljetter.Location = new System.Drawing.Point(562, 112);
            this.labelUngdomsbiljetter.Name = "labelUngdomsbiljetter";
            this.labelUngdomsbiljetter.Size = new System.Drawing.Size(85, 13);
            this.labelUngdomsbiljetter.TabIndex = 7;
            this.labelUngdomsbiljetter.Text = "Ungdomsbiljetter";
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
            // labelTotalt
            // 
            this.labelTotalt.AutoSize = true;
            this.labelTotalt.Location = new System.Drawing.Point(562, 195);
            this.labelTotalt.Name = "labelTotalt";
            this.labelTotalt.Size = new System.Drawing.Size(34, 13);
            this.labelTotalt.TabIndex = 9;
            this.labelTotalt.Text = "Totalt";
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
            // labelKronor
            // 
            this.labelKronor.AutoSize = true;
            this.labelKronor.Location = new System.Drawing.Point(803, 37);
            this.labelKronor.Name = "labelKronor";
            this.labelKronor.Size = new System.Drawing.Size(38, 13);
            this.labelKronor.TabIndex = 11;
            this.labelKronor.Text = "Kronor";
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
            // buttonRaderaForestallning
            // 
            this.buttonRaderaForestallning.Location = new System.Drawing.Point(182, 227);
            this.buttonRaderaForestallning.Name = "buttonRaderaForestallning";
            this.buttonRaderaForestallning.Size = new System.Drawing.Size(72, 23);
            this.buttonRaderaForestallning.TabIndex = 13;
            this.buttonRaderaForestallning.Text = "Radera";
            this.buttonRaderaForestallning.UseVisualStyleBackColor = true;
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
            // textBoxTotaltKronor
            // 
            this.textBoxTotaltKronor.Location = new System.Drawing.Point(790, 192);
            this.textBoxTotaltKronor.Name = "textBoxTotaltKronor";
            this.textBoxTotaltKronor.Size = new System.Drawing.Size(79, 20);
            this.textBoxTotaltKronor.TabIndex = 15;
            // 
            // textBoxTotaltAntal
            // 
            this.textBoxTotaltAntal.Location = new System.Drawing.Point(677, 192);
            this.textBoxTotaltAntal.Name = "textBoxTotaltAntal";
            this.textBoxTotaltAntal.Size = new System.Drawing.Size(79, 20);
            this.textBoxTotaltAntal.TabIndex = 16;
            // 
            // textBoxKronorBarnbiljetter
            // 
            this.textBoxKronorBarnbiljetter.Location = new System.Drawing.Point(790, 140);
            this.textBoxKronorBarnbiljetter.Name = "textBoxKronorBarnbiljetter";
            this.textBoxKronorBarnbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorBarnbiljetter.TabIndex = 17;
            // 
            // textBoxAntalBarnbiljetter
            // 
            this.textBoxAntalBarnbiljetter.Location = new System.Drawing.Point(677, 140);
            this.textBoxAntalBarnbiljetter.Name = "textBoxAntalBarnbiljetter";
            this.textBoxAntalBarnbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalBarnbiljetter.TabIndex = 18;
            // 
            // textBoxKronorUngdomsbiljetter
            // 
            this.textBoxKronorUngdomsbiljetter.Location = new System.Drawing.Point(790, 111);
            this.textBoxKronorUngdomsbiljetter.Name = "textBoxKronorUngdomsbiljetter";
            this.textBoxKronorUngdomsbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorUngdomsbiljetter.TabIndex = 19;
            // 
            // textBoxAntalUngdomsbiljetter
            // 
            this.textBoxAntalUngdomsbiljetter.Location = new System.Drawing.Point(677, 113);
            this.textBoxAntalUngdomsbiljetter.Name = "textBoxAntalUngdomsbiljetter";
            this.textBoxAntalUngdomsbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxAntalUngdomsbiljetter.TabIndex = 20;
            // 
            // textBoxKronorVuxenbiljetter
            // 
            this.textBoxKronorVuxenbiljetter.Location = new System.Drawing.Point(790, 74);
            this.textBoxKronorVuxenbiljetter.Name = "textBoxKronorVuxenbiljetter";
            this.textBoxKronorVuxenbiljetter.Size = new System.Drawing.Size(79, 20);
            this.textBoxKronorVuxenbiljetter.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Välkommen";
            this.tabControl1.ResumeLayout(false);
            this.tabBiljett.ResumeLayout(false);
            this.tabBiljett.PerformLayout();
            this.tabForestallning.ResumeLayout(false);
            this.tabForestallning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBiljett;
        private System.Windows.Forms.TabPage tabForestallning;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabKonto;
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
    }
}