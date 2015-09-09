﻿namespace cirkus
{
    partial class ReserveTicketForm
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
            this.numericChild = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericYouth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericAdult = new System.Windows.Forms.NumericUpDown();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewShows = new System.Windows.Forms.DataGridView();
            this.dataGridViewActs = new System.Windows.Forms.DataGridView();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxSeats = new System.Windows.Forms.CheckedListBox();
            this.comboBoxSection = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblChild = new System.Windows.Forms.Label();
            this.lblYouth = new System.Windows.Forms.Label();
            this.lblAdult = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSelectedSeats = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYouth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAdult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericChild
            // 
            this.numericChild.Location = new System.Drawing.Point(53, 34);
            this.numericChild.Name = "numericChild";
            this.numericChild.Size = new System.Drawing.Size(37, 20);
            this.numericChild.TabIndex = 2;
            this.numericChild.ValueChanged += new System.EventHandler(this.added_child);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Barn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ungdom";
            // 
            // numericYouth
            // 
            this.numericYouth.Location = new System.Drawing.Point(53, 61);
            this.numericYouth.Name = "numericYouth";
            this.numericYouth.Size = new System.Drawing.Size(37, 20);
            this.numericYouth.TabIndex = 4;
            this.numericYouth.ValueChanged += new System.EventHandler(this.added_youth);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vuxen";
            // 
            // numericAdult
            // 
            this.numericAdult.Location = new System.Drawing.Point(53, 87);
            this.numericAdult.Name = "numericAdult";
            this.numericAdult.Size = new System.Drawing.Size(37, 20);
            this.numericAdult.TabIndex = 6;
            this.numericAdult.ValueChanged += new System.EventHandler(this.added_adult);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 394);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Reservera";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 417);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(91, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "Bokad/Betald";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(465, 452);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 13;
            this.buttonAdd.Text = "Lägg till";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(8, 452);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Avbryt";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewShows
            // 
            this.dataGridViewShows.AllowUserToAddRows = false;
            this.dataGridViewShows.AllowUserToDeleteRows = false;
            this.dataGridViewShows.AllowUserToResizeColumns = false;
            this.dataGridViewShows.AllowUserToResizeRows = false;
            this.dataGridViewShows.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewShows.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShows.ColumnHeadersVisible = false;
            this.dataGridViewShows.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewShows.Name = "dataGridViewShows";
            this.dataGridViewShows.ReadOnly = true;
            this.dataGridViewShows.RowHeadersVisible = false;
            this.dataGridViewShows.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewShows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShows.Size = new System.Drawing.Size(239, 131);
            this.dataGridViewShows.TabIndex = 18;
            this.dataGridViewShows.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rowselection_changed);
            // 
            // dataGridViewActs
            // 
            this.dataGridViewActs.AllowUserToAddRows = false;
            this.dataGridViewActs.AllowUserToDeleteRows = false;
            this.dataGridViewActs.AllowUserToResizeColumns = false;
            this.dataGridViewActs.AllowUserToResizeRows = false;
            this.dataGridViewActs.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewActs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActs.ColumnHeadersVisible = false;
            this.dataGridViewActs.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewActs.Name = "dataGridViewActs";
            this.dataGridViewActs.ReadOnly = true;
            this.dataGridViewActs.RowHeadersVisible = false;
            this.dataGridViewActs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewActs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActs.Size = new System.Drawing.Size(124, 99);
            this.dataGridViewActs.TabIndex = 19;
            this.dataGridViewActs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActs_CellClick);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(9, 30);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 17);
            this.radioButton3.TabIndex = 22;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Logeplats";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(103, 30);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 17);
            this.radioButton4.TabIndex = 23;
            this.radioButton4.Text = "Fri placering";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 121);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Hela föreställningen";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(295, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 195);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tillgängliga platser";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkedListBoxSeats);
            this.groupBox5.Controls.Add(this.comboBoxSection);
            this.groupBox5.Location = new System.Drawing.Point(9, 53);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 126);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sektioner";
            // 
            // checkedListBoxSeats
            // 
            this.checkedListBoxSeats.FormattingEnabled = true;
            this.checkedListBoxSeats.Location = new System.Drawing.Point(116, 30);
            this.checkedListBoxSeats.Name = "checkedListBoxSeats";
            this.checkedListBoxSeats.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxSeats.TabIndex = 1;
            this.checkedListBoxSeats.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checked_seats);
            // 
            // comboBoxSection
            // 
            this.comboBoxSection.FormattingEnabled = true;
            this.comboBoxSection.Location = new System.Drawing.Point(6, 30);
            this.comboBoxSection.Name = "comboBoxSection";
            this.comboBoxSection.Size = new System.Drawing.Size(82, 21);
            this.comboBoxSection.TabIndex = 0;
            this.comboBoxSection.SelectedIndexChanged += new System.EventHandler(this.seat_sectionchanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewShows);
            this.groupBox2.Location = new System.Drawing.Point(8, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 195);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Föreställningar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numericChild);
            this.groupBox3.Controls.Add(this.numericYouth);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numericAdult);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(8, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 150);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Antal personer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewActs);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Location = new System.Drawing.Point(138, 226);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 150);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Akter";
            // 
            // lblChild
            // 
            this.lblChild.AutoSize = true;
            this.lblChild.Location = new System.Drawing.Point(307, 236);
            this.lblChild.Name = "lblChild";
            this.lblChild.Size = new System.Drawing.Size(35, 13);
            this.lblChild.TabIndex = 29;
            this.lblChild.Text = "label4";
            // 
            // lblYouth
            // 
            this.lblYouth.AutoSize = true;
            this.lblYouth.Location = new System.Drawing.Point(310, 266);
            this.lblYouth.Name = "lblYouth";
            this.lblYouth.Size = new System.Drawing.Size(35, 13);
            this.lblYouth.TabIndex = 30;
            this.lblYouth.Text = "label5";
            // 
            // lblAdult
            // 
            this.lblAdult.AutoSize = true;
            this.lblAdult.Location = new System.Drawing.Point(313, 293);
            this.lblAdult.Name = "lblAdult";
            this.lblAdult.Size = new System.Drawing.Size(35, 13);
            this.lblAdult.TabIndex = 31;
            this.lblAdult.Text = "label6";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(313, 315);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 32;
            this.lblTotal.Text = "label6";
            // 
            // lblSelectedSeats
            // 
            this.lblSelectedSeats.AutoSize = true;
            this.lblSelectedSeats.Location = new System.Drawing.Point(504, 261);
            this.lblSelectedSeats.Name = "lblSelectedSeats";
            this.lblSelectedSeats.Size = new System.Drawing.Size(35, 13);
            this.lblSelectedSeats.TabIndex = 33;
            this.lblSelectedSeats.Text = "label4";
            // 
            // ReserveTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(685, 491);
            this.Controls.Add(this.lblSelectedSeats);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblAdult);
            this.Controls.Add(this.lblYouth);
            this.Controls.Add(this.lblChild);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "ReserveTicketForm";
            this.Text = "ReserveTicketForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYouth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAdult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericChild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericYouth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericAdult;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewShows;
        private System.Windows.Forms.DataGridView dataGridViewActs;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkedListBoxSeats;
        private System.Windows.Forms.ComboBox comboBoxSection;
        private System.Windows.Forms.Label lblChild;
        private System.Windows.Forms.Label lblYouth;
        private System.Windows.Forms.Label lblAdult;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSelectedSeats;
    }
}