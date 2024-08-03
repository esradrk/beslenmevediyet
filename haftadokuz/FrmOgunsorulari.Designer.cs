namespace haftadokuz
{
    partial class FrmOgunsorulari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOgunsorulari));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combobes = new System.Windows.Forms.ComboBox();
            this.combodiyet = new System.Windows.Forms.ComboBox();
            this.txtkilo = new System.Windows.Forms.TextBox();
            this.btnanaliz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beslenme Tercihiniz Nedir?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diyet Yapma Sebebiniz?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(0, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hedef Kilonuz Nedir?";
            // 
            // combobes
            // 
            this.combobes.FormattingEnabled = true;
            this.combobes.Location = new System.Drawing.Point(191, 27);
            this.combobes.Name = "combobes";
            this.combobes.Size = new System.Drawing.Size(139, 21);
            this.combobes.TabIndex = 3;
            // 
            // combodiyet
            // 
            this.combodiyet.FormattingEnabled = true;
            this.combodiyet.Location = new System.Drawing.Point(191, 80);
            this.combodiyet.Name = "combodiyet";
            this.combodiyet.Size = new System.Drawing.Size(139, 21);
            this.combodiyet.TabIndex = 4;
            // 
            // txtkilo
            // 
            this.txtkilo.Location = new System.Drawing.Point(191, 126);
            this.txtkilo.Name = "txtkilo";
            this.txtkilo.Size = new System.Drawing.Size(100, 20);
            this.txtkilo.TabIndex = 5;
            // 
            // btnanaliz
            // 
            this.btnanaliz.BackColor = System.Drawing.Color.Green;
            this.btnanaliz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnanaliz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnanaliz.ForeColor = System.Drawing.SystemColors.Control;
            this.btnanaliz.Location = new System.Drawing.Point(46, 169);
            this.btnanaliz.Name = "btnanaliz";
            this.btnanaliz.Size = new System.Drawing.Size(259, 42);
            this.btnanaliz.TabIndex = 6;
            this.btnanaliz.Text = "Analiz Oluştur";
            this.btnanaliz.UseVisualStyleBackColor = false;
            this.btnanaliz.Click += new System.EventHandler(this.btnanaliz_Click);
            // 
            // FrmOgunsorulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(332, 246);
            this.Controls.Add(this.btnanaliz);
            this.Controls.Add(this.txtkilo);
            this.Controls.Add(this.combodiyet);
            this.Controls.Add(this.combobes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmOgunsorulari";
            this.Text = "FrmOgunsorulari";
            this.Load += new System.EventHandler(this.FrmOgunsorulari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combobes;
        private System.Windows.Forms.ComboBox combodiyet;
        private System.Windows.Forms.TextBox txtkilo;
        private System.Windows.Forms.Button btnanaliz;
    }
}