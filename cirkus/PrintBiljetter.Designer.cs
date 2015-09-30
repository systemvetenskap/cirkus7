namespace cirkus
{
    partial class PrintBiljetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintBiljetter));
            this.dgTicketsDirekt = new System.Windows.Forms.DataGridView();
            this.buttonPrintBiljettDirekt = new System.Windows.Forms.Button();
            this.dgTicketActsDirekt = new System.Windows.Forms.DataGridView();
            this.printDocumentBIljettDirekt = new System.Drawing.Printing.PrintDocument();
            this.printDialogBiljetD = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicketsDirekt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicketActsDirekt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTicketsDirekt
            // 
            this.dgTicketsDirekt.AllowUserToAddRows = false;
            this.dgTicketsDirekt.AllowUserToDeleteRows = false;
            this.dgTicketsDirekt.AllowUserToResizeColumns = false;
            this.dgTicketsDirekt.AllowUserToResizeRows = false;
            this.dgTicketsDirekt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTicketsDirekt.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTicketsDirekt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgTicketsDirekt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTicketsDirekt.Location = new System.Drawing.Point(43, 36);
            this.dgTicketsDirekt.MultiSelect = false;
            this.dgTicketsDirekt.Name = "dgTicketsDirekt";
            this.dgTicketsDirekt.ReadOnly = true;
            this.dgTicketsDirekt.RowHeadersVisible = false;
            this.dgTicketsDirekt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTicketsDirekt.Size = new System.Drawing.Size(516, 106);
            this.dgTicketsDirekt.TabIndex = 16;
            this.dgTicketsDirekt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTicketsDirekt_CellClick);
            this.dgTicketsDirekt.Click += new System.EventHandler(this.dgTicketsDirekt_Click);
            // 
            // buttonPrintBiljettDirekt
            // 
            this.buttonPrintBiljettDirekt.Location = new System.Drawing.Point(447, 249);
            this.buttonPrintBiljettDirekt.Name = "buttonPrintBiljettDirekt";
            this.buttonPrintBiljettDirekt.Size = new System.Drawing.Size(112, 26);
            this.buttonPrintBiljettDirekt.TabIndex = 28;
            this.buttonPrintBiljettDirekt.Text = "Print";
            this.buttonPrintBiljettDirekt.UseVisualStyleBackColor = true;
            this.buttonPrintBiljettDirekt.Click += new System.EventHandler(this.buttonPrintBiljettDirekt_Click);
            // 
            // dgTicketActsDirekt
            // 
            this.dgTicketActsDirekt.AllowUserToAddRows = false;
            this.dgTicketActsDirekt.AllowUserToDeleteRows = false;
            this.dgTicketActsDirekt.AllowUserToResizeColumns = false;
            this.dgTicketActsDirekt.AllowUserToResizeRows = false;
            this.dgTicketActsDirekt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTicketActsDirekt.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTicketActsDirekt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgTicketActsDirekt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTicketActsDirekt.Location = new System.Drawing.Point(43, 148);
            this.dgTicketActsDirekt.MultiSelect = false;
            this.dgTicketActsDirekt.Name = "dgTicketActsDirekt";
            this.dgTicketActsDirekt.ReadOnly = true;
            this.dgTicketActsDirekt.RowHeadersVisible = false;
            this.dgTicketActsDirekt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTicketActsDirekt.Size = new System.Drawing.Size(516, 95);
            this.dgTicketActsDirekt.TabIndex = 29;
            this.dgTicketActsDirekt.Click += new System.EventHandler(this.dgTicketActsDirekt_Click);
            // 
            // printDocumentBIljettDirekt
            // 
            this.printDocumentBIljettDirekt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentBIljettDirekt_PrintPage);
            // 
            // printDialogBiljetD
            // 
            this.printDialogBiljetD.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(43, 249);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(357, 137);
            this.printPreviewControl1.TabIndex = 30;
            // 
            // PrintBiljetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 398);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.dgTicketActsDirekt);
            this.Controls.Add(this.buttonPrintBiljettDirekt);
            this.Controls.Add(this.dgTicketsDirekt);
            this.Name = "PrintBiljetter";
            this.Text = "PrintBiljetter";
            this.Load += new System.EventHandler(this.PrintBiljetter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTicketsDirekt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicketActsDirekt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTicketsDirekt;
        private System.Windows.Forms.Button buttonPrintBiljettDirekt;
        private System.Windows.Forms.DataGridView dgTicketActsDirekt;
        private System.Drawing.Printing.PrintDocument printDocumentBIljettDirekt;
        private System.Windows.Forms.PrintDialog printDialogBiljetD;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
    }
}