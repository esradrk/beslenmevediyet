namespace haftadokuz
{
    partial class frmUyeKayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUyeKayit));
            this.grpuye = new System.Windows.Forms.GroupBox();
            this.btnuye = new System.Windows.Forms.Button();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtad = new System.Windows.Forms.TextBox();
            this.lblsifre = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblad = new System.Windows.Forms.Label();
            this.grpuye.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpuye
            // 
            this.grpuye.BackColor = System.Drawing.Color.White;
            this.grpuye.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpuye.Controls.Add(this.btnuye);
            this.grpuye.Controls.Add(this.txtsifre);
            this.grpuye.Controls.Add(this.txtemail);
            this.grpuye.Controls.Add(this.txtad);
            this.grpuye.Controls.Add(this.lblsifre);
            this.grpuye.Controls.Add(this.lblemail);
            this.grpuye.Controls.Add(this.lblad);
            this.grpuye.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.grpuye.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpuye.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grpuye.Location = new System.Drawing.Point(12, 72);
            this.grpuye.Name = "grpuye";
            this.grpuye.Size = new System.Drawing.Size(220, 189);
            this.grpuye.TabIndex = 0;
            this.grpuye.TabStop = false;
            this.grpuye.Text = "Üye Ol";
            // 
            // btnuye
            // 
            this.btnuye.Location = new System.Drawing.Point(52, 155);
            this.btnuye.Name = "btnuye";
            this.btnuye.Size = new System.Drawing.Size(101, 28);
            this.btnuye.TabIndex = 6;
            this.btnuye.Text = "Üye Ol";
            this.btnuye.UseVisualStyleBackColor = true;
            this.btnuye.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(82, 113);
            this.txtsifre.MaxLength = 15;
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(100, 21);
            this.txtsifre.TabIndex = 5;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(82, 62);
            this.txtemail.MaxLength = 30;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(100, 21);
            this.txtemail.TabIndex = 4;
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(82, 23);
            this.txtad.MaxLength = 20;
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(100, 21);
            this.txtad.TabIndex = 3;
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsifre.Location = new System.Drawing.Point(11, 116);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(37, 15);
            this.lblsifre.TabIndex = 2;
            this.lblsifre.Text = "Şifre";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblemail.Location = new System.Drawing.Point(11, 65);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(49, 15);
            this.lblemail.TabIndex = 1;
            this.lblemail.Text = "E-Mail";
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.lblad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblad.Location = new System.Drawing.Point(11, 23);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(23, 15);
            this.lblad.TabIndex = 0;
            this.lblad.Text = "Ad";
            // 
            // frmUyeKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(250, 341);
            this.Controls.Add(this.grpuye);
            this.Name = "frmUyeKayit";
            this.Text = "Öğrenci Kayıt İşlemleri";
            this.grpuye.ResumeLayout(false);
            this.grpuye.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnuye;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.Label lblsifre;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblad;
        public System.Windows.Forms.GroupBox grpuye;
    }
}

