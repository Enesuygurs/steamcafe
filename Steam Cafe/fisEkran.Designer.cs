namespace Steam_Cafe
{
    partial class fisEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fisEkran));
            this.ustPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fisOnizleme = new System.Windows.Forms.PrintPreviewControl();
            this.butonYazdir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ustPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ustPanel
            // 
            this.ustPanel.BackColor = System.Drawing.Color.Orange;
            this.ustPanel.Controls.Add(this.closeButton);
            this.ustPanel.Controls.Add(this.pictureBox1);
            this.ustPanel.Controls.Add(this.label1);
            this.ustPanel.Location = new System.Drawing.Point(0, 0);
            this.ustPanel.Name = "ustPanel";
            this.ustPanel.Size = new System.Drawing.Size(770, 29);
            this.ustPanel.TabIndex = 2;
            this.ustPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ustPanel_MouseDown);
            this.ustPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ustPanel_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Font = new System.Drawing.Font("Marlett", 12.25F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(745, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 17);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "r";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Cafe - Sipariş Fişi";
            // 
            // fisOnizleme
            // 
            this.fisOnizleme.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fisOnizleme.Location = new System.Drawing.Point(0, 27);
            this.fisOnizleme.Name = "fisOnizleme";
            this.fisOnizleme.Size = new System.Drawing.Size(770, 926);
            this.fisOnizleme.TabIndex = 3;
            // 
            // butonYazdir
            // 
            this.butonYazdir.BackColor = System.Drawing.Color.DarkViolet;
            this.butonYazdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonYazdir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.butonYazdir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butonYazdir.Image = global::Steam_Cafe.Properties.Resources.iconYazdir;
            this.butonYazdir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonYazdir.Location = new System.Drawing.Point(325, 35);
            this.butonYazdir.Name = "butonYazdir";
            this.butonYazdir.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.butonYazdir.Size = new System.Drawing.Size(119, 40);
            this.butonYazdir.TabIndex = 24;
            this.butonYazdir.Text = "Yazdır";
            this.butonYazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butonYazdir.UseVisualStyleBackColor = false;
            this.butonYazdir.Click += new System.EventHandler(this.butonYazdir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // fisEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 953);
            this.Controls.Add(this.butonYazdir);
            this.Controls.Add(this.fisOnizleme);
            this.Controls.Add(this.ustPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fisEkran";
            this.Text = "Steam Cafe - Sipariş Fişi";
            this.Load += new System.EventHandler(this.fisEkran_Load);
            this.ustPanel.ResumeLayout(false);
            this.ustPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ustPanel;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintPreviewControl fisOnizleme;
        private System.Windows.Forms.Button butonYazdir;
    }
}