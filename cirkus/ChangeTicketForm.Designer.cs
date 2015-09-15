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
            this.dtpTicketFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSpara = new System.Windows.Forms.Button();
            this.lblAnge = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedCustomerTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTicketTo
            // 
            this.dtpTicketTo.Location = new System.Drawing.Point(315, 106);
            this.dtpTicketTo.Name = "dtpTicketTo";
            this.dtpTicketTo.Size = new System.Drawing.Size(164, 20);
            this.dtpTicketTo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ändra biljett";
            // 
            // dgSelectedCustomerTicket
            // 
            this.dgSelectedCustomerTicket.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedCustomerTicket.GridColor = System.Drawing.SystemColors.Window;
            this.dgSelectedCustomerTicket.Location = new System.Drawing.Point(24, 136);
            this.dgSelectedCustomerTicket.Name = "dgSelectedCustomerTicket";
            this.dgSelectedCustomerTicket.Size = new System.Drawing.Size(455, 79);
            this.dgSelectedCustomerTicket.TabIndex = 7;
            // 
            // dtpTicketFrom
            // 
            this.dtpTicketFrom.Location = new System.Drawing.Point(24, 106);
            this.dtpTicketFrom.Name = "dtpTicketFrom";
            this.dtpTicketFrom.Size = new System.Drawing.Size(164, 20);
            this.dtpTicketFrom.TabIndex = 8;
            // 
            // btnSpara
            // 
            this.btnSpara.Location = new System.Drawing.Point(24, 232);
            this.btnSpara.Name = "btnSpara";
            this.btnSpara.Size = new System.Drawing.Size(75, 23);
            this.btnSpara.TabIndex = 9;
            this.btnSpara.Text = "Spara";
            this.btnSpara.UseVisualStyleBackColor = true;
            this.btnSpara.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // lblAnge
            // 
            this.lblAnge.AutoSize = true;
            this.lblAnge.Location = new System.Drawing.Point(24, 66);
            this.lblAnge.Name = "lblAnge";
            this.lblAnge.Size = new System.Drawing.Size(226, 13);
            this.lblAnge.TabIndex = 10;
            this.lblAnge.Text = "Ange hur länge biljetten ska kunna reserveras:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(24, 91);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 11;
            this.lblFrom.Text = "Från:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(318, 91);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 12;
            this.lblTo.Text = "Till:";
            // 
            // ChangeTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 279);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblAnge);
            this.Controls.Add(this.btnSpara);
            this.Controls.Add(this.dtpTicketFrom);
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
        private System.Windows.Forms.DateTimePicker dtpTicketFrom;
        private System.Windows.Forms.Button btnSpara;
        private System.Windows.Forms.Label lblAnge;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
    }
}