namespace cirkus
{
    partial class ChangeTicketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeTicketForm));
            this.dtpTicketTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgSelectedCustomerTicket = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAnge = new System.Windows.Forms.Label();
            this.btnChangeTicket = new System.Windows.Forms.Button();
            this.lblTodaysDate = new System.Windows.Forms.Label();
            this.checkBoxPaidTicket = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCustomerTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTicketTo
            // 
            this.dtpTicketTo.Enabled = false;
            this.dtpTicketTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTicketTo.Location = new System.Drawing.Point(17, 61);
            this.dtpTicketTo.Name = "dtpTicketTo";
            this.dtpTicketTo.Size = new System.Drawing.Size(226, 20);
            this.dtpTicketTo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ändra biljett reservation";
            // 
            // dgSelectedCustomerTicket
            // 
            this.dgSelectedCustomerTicket.AllowUserToAddRows = false;
            this.dgSelectedCustomerTicket.AllowUserToDeleteRows = false;
            this.dgSelectedCustomerTicket.AllowUserToResizeColumns = false;
            this.dgSelectedCustomerTicket.AllowUserToResizeRows = false;
            this.dgSelectedCustomerTicket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSelectedCustomerTicket.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedCustomerTicket.GridColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.Location = new System.Drawing.Point(17, 87);
            this.dgSelectedCustomerTicket.MultiSelect = false;
            this.dgSelectedCustomerTicket.Name = "dgSelectedCustomerTicket";
            this.dgSelectedCustomerTicket.ReadOnly = true;
            this.dgSelectedCustomerTicket.RowHeadersVisible = false;
            this.dgSelectedCustomerTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelectedCustomerTicket.Size = new System.Drawing.Size(824, 88);
            this.dgSelectedCustomerTicket.TabIndex = 7;
            this.dgSelectedCustomerTicket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSelectedTicket);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(137, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Spara ändringar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // lblAnge
            // 
            this.lblAnge.AutoSize = true;
            this.lblAnge.Location = new System.Drawing.Point(17, 46);
            this.lblAnge.Name = "lblAnge";
            this.lblAnge.Size = new System.Drawing.Size(226, 13);
            this.lblAnge.TabIndex = 10;
            this.lblAnge.Text = "Ange hur länge biljetten ska kunna reserveras:";
            // 
            // btnChangeTicket
            // 
            this.btnChangeTicket.BackColor = System.Drawing.Color.HotPink;
            this.btnChangeTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeTicket.Location = new System.Drawing.Point(17, 183);
            this.btnChangeTicket.Name = "btnChangeTicket";
            this.btnChangeTicket.Size = new System.Drawing.Size(106, 23);
            this.btnChangeTicket.TabIndex = 13;
            this.btnChangeTicket.Text = "Ändra biljett";
            this.btnChangeTicket.UseVisualStyleBackColor = false;
            this.btnChangeTicket.Click += new System.EventHandler(this.btnChangeTicket_Click);
            // 
            // lblTodaysDate
            // 
            this.lblTodaysDate.AutoSize = true;
            this.lblTodaysDate.Location = new System.Drawing.Point(289, 69);
            this.lblTodaysDate.Name = "lblTodaysDate";
            this.lblTodaysDate.Size = new System.Drawing.Size(79, 13);
            this.lblTodaysDate.TabIndex = 14;
            this.lblTodaysDate.Text = "Dagens datum:";
            // 
            // checkBoxPaidTicket
            // 
            this.checkBoxPaidTicket.AutoSize = true;
            this.checkBoxPaidTicket.Enabled = false;
            this.checkBoxPaidTicket.Location = new System.Drawing.Point(273, 189);
            this.checkBoxPaidTicket.Name = "checkBoxPaidTicket";
            this.checkBoxPaidTicket.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPaidTicket.TabIndex = 15;
            this.checkBoxPaidTicket.Text = "Biljetten är betald";
            this.checkBoxPaidTicket.UseVisualStyleBackColor = true;
            this.checkBoxPaidTicket.CheckedChanged += new System.EventHandler(this.checkBoxPaidTicket_CheckedChanged);
            // 
            // ChangeTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(860, 219);
            this.Controls.Add(this.checkBoxPaidTicket);
            this.Controls.Add(this.lblTodaysDate);
            this.Controls.Add(this.btnChangeTicket);
            this.Controls.Add(this.lblAnge);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgSelectedCustomerTicket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTicketTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangeTicketForm";
            this.Text = "Ändra biljett";
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCustomerTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTicketTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgSelectedCustomerTicket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAnge;
        private System.Windows.Forms.Button btnChangeTicket;
        private System.Windows.Forms.Label lblTodaysDate;
        private System.Windows.Forms.CheckBox checkBoxPaidTicket;
    }
}