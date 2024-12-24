namespace Steam_Cafe
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yoneticiPaneli = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yetkiliPaneli = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tarih = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoneticiPaneli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetkiliPaneli)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 29);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Font = new System.Drawing.Font("Marlett", 12.25F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(924, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 17);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "r";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Cafe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 44F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 78);
            this.label2.TabIndex = 2;
            this.label2.Text = "Steam Cafe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "H O Ş G E L D İ N İ Z ";
            // 
            // yoneticiPaneli
            // 
            this.yoneticiPaneli.BackColor = System.Drawing.Color.Transparent;
            this.yoneticiPaneli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yoneticiPaneli.BackgroundImage")));
            this.yoneticiPaneli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.yoneticiPaneli.Location = new System.Drawing.Point(136, 295);
            this.yoneticiPaneli.Name = "yoneticiPaneli";
            this.yoneticiPaneli.Size = new System.Drawing.Size(69, 69);
            this.yoneticiPaneli.TabIndex = 7;
            this.yoneticiPaneli.TabStop = false;
            this.yoneticiPaneli.Click += new System.EventHandler(this.yonetimPaneli_Click_1);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(136, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 34);
            this.label4.TabIndex = 2;
            this.label4.Text = "Yönetici\r\nGirişi\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yetkiliPaneli
            // 
            this.yetkiliPaneli.BackColor = System.Drawing.Color.Transparent;
            this.yetkiliPaneli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yetkiliPaneli.BackgroundImage")));
            this.yetkiliPaneli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.yetkiliPaneli.Location = new System.Drawing.Point(211, 295);
            this.yetkiliPaneli.Name = "yetkiliPaneli";
            this.yetkiliPaneli.Size = new System.Drawing.Size(69, 69);
            this.yetkiliPaneli.TabIndex = 6;
            this.yetkiliPaneli.TabStop = false;
            this.yetkiliPaneli.Click += new System.EventHandler(this.yetkiliPaneli_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(211, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 34);
            this.label5.TabIndex = 2;
            this.label5.Text = "Yetkili\r\nGirişi\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tarih
            // 
            this.tarih.BackColor = System.Drawing.Color.Transparent;
            this.tarih.Font = new System.Drawing.Font("Segoe UI Light", 22F);
            this.tarih.ForeColor = System.Drawing.Color.White;
            this.tarih.Location = new System.Drawing.Point(29, 155);
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(347, 45);
            this.tarih.TabIndex = 8;
            this.tarih.Text = "Steam Cafe";
            this.tarih.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(87)))), ((int)(((byte)(82)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 613);
            this.Controls.Add(this.yetkiliPaneli);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yoneticiPaneli);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tarih);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Cafe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoneticiPaneli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yetkiliPaneli)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox yetkiliPaneli;
        private System.Windows.Forms.PictureBox yoneticiPaneli;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label tarih;
    }
}

