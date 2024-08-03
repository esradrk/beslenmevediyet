namespace haftadokuz
{
    partial class FrmAnaliz
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnogun;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnogun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(624, 126);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnogun
            // 
            this.btnogun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnogun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnogun.Location = new System.Drawing.Point(236, 160);
            this.btnogun.Name = "btnogun";
            this.btnogun.Size = new System.Drawing.Size(187, 50);
            this.btnogun.TabIndex = 1;
            this.btnogun.Text = "Öğün Planla";
            this.btnogun.UseVisualStyleBackColor = false;
            this.btnogun.Click += new System.EventHandler(this.btnogun_Click);
            // 
            // FrmAnaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 222);
            this.Controls.Add(this.btnogun);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmAnaliz";
            this.Text = "FrmAnaliz";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
