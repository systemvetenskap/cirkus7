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
            this.dtpTicketTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgSelectedCustomerTicket = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAnge = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnChangeTicket = new System.Windows.Forms.Button();
            this.lblTodaysDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCustomerTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTicketTo
            // 
            this.dtpTicketTo.Enabled = false;
            this.dtpTicketTo.Location = new System.Drawing.Point(28, 110);
            this.dtpTicketTo.Name = "dtpTicketTo";
            this.dtpTicketTo.Size = new System.Drawing.Size(164, 20);
            this.dtpTicketTo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ändra biljett reservation";
            // 
            // dgSelectedCustomerTicket
            // 
            this.dgSelectedCustomerTicket.AllowUserToAddRows = false;
            this.dgSelectedCustomerTicket.AllowUserToDeleteRows = false;
            this.dgSelectedCustomerTicket.AllowUserToResizeColumns = false;
            this.dgSelectedCustomerTicket.AllowUserToResizeRows = false;
            this.dgSelectedCustomerTicket.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedCustomerTicket.GridColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.Location = new System.Drawing.Point(28, 136);
            this.dgSelectedCustomerTicket.MultiSelect = false;
            this.dgSelectedCustomerTicket.Name = "dgSelectedCustomerTicket";
            this.dgSelectedCustomerTicket.ReadOnly = true;
            this.dgSelectedCustomerTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelectedCustomerTicket.Size = new System.Drawing.Size(763, 88);
            this.dgSelectedCustomerTicket.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(168, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Spara ändringar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // lblAnge
            // 
            this.lblAnge.AutoSize = true;
            this.lblAnge.Location = new System.Drawing.Point(28, 66);
            this.lblAnge.Name = "lblAnge";
            this.lblAnge.Size = new System.Drawing.Size(226, 13);
            this.lblAnge.TabIndex = 10;
            this.lblAnge.Text = "Ange hur länge biljetten ska kunna reserveras:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(28, 95);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(67, 13);
            this.lblTo.TabIndex = 12;
            this.lblTo.Text = "Till och med:";
            // 
            // btnChangeTicket
            // 
            this.btnChangeTicket.Location = new System.Drawing.Point(28, 244);
            this.btnChangeTicket.Name = "btnChangeTicket";
            this.btnChangeTicket.Size = new System.Drawing.Size(106, 23);
            this.btnChangeTicket.TabIndex = 13;
            this.btnChangeTicket.Text = "Ändra biljett";
            this.btnChangeTicket.UseVisualStyleBackColor = true;
            this.btnChangeTicket.Click += new System.EventHandler(this.btnChangeTicket_Click);
            // 
            // lblTodaysDate
            // 
            this.lblTodaysDate.AutoSize = true;
            this.lblTodaysDate.Location = new System.Drawing.Point(636, 120);
            this.lblTodaysDate.Name = "lblTodaysDate";
            this.lblTodaysDate.Size = new System.Drawing.Size(79, 13);
            this.lblTodaysDate.TabIndex = 14;
            this.lblTodaysDate.Text = "Dagens datum:";
            // 
            // ChangeTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 279);
            this.Controls.Add(this.lblTodaysDate);
            this.Controls.Add(this.btnChangeTicket);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblAnge);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgSelectedCustomerTicket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTicketTo);
            this.Name = "ChangeTicketForm";
            this.Text = "ChangeTicket";
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
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnChangeTicket;
        private System.Windows.Forms.Label lblTodaysDate;
    }
}