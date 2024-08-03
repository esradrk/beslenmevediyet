namespace haftadokuz
{
    partial class frmgirisyap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgirisyap));
            this.btngiris = new System.Windows.Forms.Button();
            this.btnuye = new System.Windows.Forms.Button();
            this.lblad = new System.Windows.Forms.Label();
            this.lblsoyad = new System.Windows.Forms.Label();
            this.txtad = new System.Windows.Forms.TextBox();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btngiris
            // 
            this.btngiris.Location = new System.Drawing.Point(12, 238);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(92, 23);
            this.btngiris.TabIndex = 0;
            this.btngiris.Text = "Giriş Yap";
            this.btngiris.UseVisualStyleBackColor = true;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // btnuye
            // 
            this.btnuye.Location = new System.Drawing.Point(139, 238);
            this.btnuye.Name = "btnuye";
            this.btnuye.Size = new System.Drawing.Size(91, 23);
            this.btnuye.TabIndex = 1;
            this.btnuye.Text = "Üye Ol";
            this.btnuye.UseVisualStyleBackColor = true;
            this.btnuye.Click += new System.EventHandler(this.btnuye_Click);
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.lblad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblad.Location = new System.Drawing.Point(34, 96);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(23, 15);
            this.lblad.TabIndex = 2;
            this.lblad.Text = "Ad";
            // 
            // lblsoyad
            // 
            this.lblsoyad.AutoSize = true;
            this.lblsoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsoyad.Location = new System.Drawing.Point(34, 161);
            this.lblsoyad.Name = "lblsoyad";
            this.lblsoyad.Size = new System.Drawing.Size(37, 15);
            this.lblsoyad.TabIndex = 3;
            this.lblsoyad.Text = "Şifre";
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(90, 89);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(100, 20);
            this.txtad.TabIndex = 4;
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(90, 154);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(100, 20);
            this.txtsifre.TabIndex = 5;
            // 
            // frmgirisyap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(242, 342);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.txtad);
            this.Controls.Add(this.lblsoyad);
            this.Controls.Add(this.lblad);
            this.Controls.Add(this.btnuye);
            this.Controls.Add(this.btngiris);
            this.Name = "frmgirisyap";
            this.Text = "girisyap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Button btnuye;
        private System.Windows.Forms.Label lblad;
        private System.Windows.Forms.Label lblsoyad;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtsifre;
    }
}