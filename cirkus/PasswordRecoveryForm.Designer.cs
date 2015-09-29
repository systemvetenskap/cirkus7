namespace cirkus
{
    partial class PasswordRecoveryForm
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendPassword = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(20, 252);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(323, 20);
            this.textBoxEmail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(20, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ange din epost adress:";
            // 
            // btnSendPassword
            // 
            this.btnSendPassword.Location = new System.Drawing.Point(20, 300);
            this.btnSendPassword.Name = "btnSendPassword";
            this.btnSendPassword.Size = new System.Drawing.Size(323, 39);
            this.btnSendPassword.TabIndex = 2;
            this.btnSendPassword.Text = "Skicka lösenord";
            this.btnSendPassword.UseVisualStyleBackColor = true;
            this.btnSendPassword.Click += new System.EventHandler(this.btnSendPassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::cirkus.Properties.Resources.cirkus_kul_bus_300x211;
            this.pictureBox1.Location = new System.Drawing.Point(38, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 212);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Cyan;
            this.lblStatus.Location = new System.Drawing.Point(20, 364);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "status";
            this.lblStatus.Visible = false;
            // 
            // PasswordRecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(385, 438);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSendPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PasswordRecoveryForm";
            this.Text = "PasswordRecoveryForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStatus;
    }
}