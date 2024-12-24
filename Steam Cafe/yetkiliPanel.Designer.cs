namespace Steam_Cafe
{
    partial class yetkiliPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yetkiliPanel));
            this.ustPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yanPanel = new System.Windows.Forms.Panel();
            this.masaNo = new System.Windows.Forms.Label();
            this.toplamFiyat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.odemeSiparisler = new System.Windows.Forms.FlowLayoutPanel();
            this.butonIptal = new System.Windows.Forms.Button();
            this.butonOdeme = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.siparisUrunler = new System.Windows.Forms.FlowLayoutPanel();
            this.kullaniciAdi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metinSaat = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kullaniciRol = new System.Windows.Forms.Label();
            this.saat = new System.Windows.Forms.Timer(this.components);
            this.urunArama = new System.Windows.Forms.TextBox();
            this.menuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.butonMasalar = new System.Windows.Forms.Button();
            this.ustPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.yanPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.ustPanel.Size = new System.Drawing.Size(1301, 29);
            this.ustPanel.TabIndex = 1;
            this.ustPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ustPanel_MouseDown);
            this.ustPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ustPanel_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Font = new System.Drawing.Font("Marlett", 12.25F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(1275, 6);
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
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Cafe - Yetkili Paneli";
            // 
            // yanPanel
            // 
            this.yanPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.yanPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yanPanel.Controls.Add(this.masaNo);
            this.yanPanel.Controls.Add(this.toplamFiyat);
            this.yanPanel.Controls.Add(this.label3);
            this.yanPanel.Controls.Add(this.odemeSiparisler);
            this.yanPanel.Controls.Add(this.butonIptal);
            this.yanPanel.Controls.Add(this.butonOdeme);
            this.yanPanel.Controls.Add(this.label2);
            this.yanPanel.Location = new System.Drawing.Point(925, -1);
            this.yanPanel.Name = "yanPanel";
            this.yanPanel.Size = new System.Drawing.Size(376, 906);
            this.yanPanel.TabIndex = 23;
            // 
            // masaNo
            // 
            this.masaNo.BackColor = System.Drawing.Color.ForestGreen;
            this.masaNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.masaNo.ForeColor = System.Drawing.Color.White;
            this.masaNo.Location = new System.Drawing.Point(0, 115);
            this.masaNo.Name = "masaNo";
            this.masaNo.Size = new System.Drawing.Size(373, 23);
            this.masaNo.TabIndex = 17;
            this.masaNo.Text = "Henüz bir masa seçilmedi.";
            this.masaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toplamFiyat
            // 
            this.toplamFiyat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.toplamFiyat.ForeColor = System.Drawing.Color.Orange;
            this.toplamFiyat.Location = new System.Drawing.Point(258, 800);
            this.toplamFiyat.Name = "toplamFiyat";
            this.toplamFiyat.Size = new System.Drawing.Size(100, 23);
            this.toplamFiyat.TabIndex = 17;
            this.toplamFiyat.Text = "0,00 ₺";
            this.toplamFiyat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(15, 804);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Toplam";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // odemeSiparisler
            // 
            this.odemeSiparisler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.odemeSiparisler.Location = new System.Drawing.Point(0, 142);
            this.odemeSiparisler.Name = "odemeSiparisler";
            this.odemeSiparisler.Size = new System.Drawing.Size(376, 644);
            this.odemeSiparisler.TabIndex = 22;
            // 
            // butonIptal
            // 
            this.butonIptal.BackColor = System.Drawing.Color.Black;
            this.butonIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonIptal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.butonIptal.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butonIptal.Location = new System.Drawing.Point(272, 838);
            this.butonIptal.Name = "butonIptal";
            this.butonIptal.Size = new System.Drawing.Size(86, 51);
            this.butonIptal.TabIndex = 21;
            this.butonIptal.Text = "İptal";
            this.butonIptal.UseVisualStyleBackColor = false;
            this.butonIptal.Click += new System.EventHandler(this.butonIptal_Click);
            // 
            // butonOdeme
            // 
            this.butonOdeme.BackColor = System.Drawing.Color.Crimson;
            this.butonOdeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonOdeme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.butonOdeme.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butonOdeme.Image = global::Steam_Cafe.Properties.Resources.iconPayment;
            this.butonOdeme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonOdeme.Location = new System.Drawing.Point(18, 838);
            this.butonOdeme.Name = "butonOdeme";
            this.butonOdeme.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.butonOdeme.Size = new System.Drawing.Size(248, 51);
            this.butonOdeme.TabIndex = 20;
            this.butonOdeme.Text = "Ödeme Yap";
            this.butonOdeme.UseVisualStyleBackColor = false;
            this.butonOdeme.Click += new System.EventHandler(this.butonOdeme_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Marlett", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(369, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "r";
            // 
            // siparisUrunler
            // 
            this.siparisUrunler.BackColor = System.Drawing.Color.WhiteSmoke;
            this.siparisUrunler.Location = new System.Drawing.Point(100, 71);
            this.siparisUrunler.Name = "siparisUrunler";
            this.siparisUrunler.Size = new System.Drawing.Size(824, 829);
            this.siparisUrunler.TabIndex = 24;
            // 
            // kullaniciAdi
            // 
            this.kullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.kullaniciAdi.Location = new System.Drawing.Point(208, 20);
            this.kullaniciAdi.Name = "kullaniciAdi";
            this.kullaniciAdi.Size = new System.Drawing.Size(100, 23);
            this.kullaniciAdi.TabIndex = 4;
            this.kullaniciAdi.Text = "Kullanıcı Adı";
            this.kullaniciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.metinSaat);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.kullaniciRol);
            this.panel2.Controls.Add(this.kullaniciAdi);
            this.panel2.Location = new System.Drawing.Point(925, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 83);
            this.panel2.TabIndex = 5;
            // 
            // metinSaat
            // 
            this.metinSaat.BackColor = System.Drawing.Color.Transparent;
            this.metinSaat.Font = new System.Drawing.Font("Segoe UI Semibold", 32F, System.Drawing.FontStyle.Bold);
            this.metinSaat.ForeColor = System.Drawing.Color.Crimson;
            this.metinSaat.Location = new System.Drawing.Point(4, 8);
            this.metinSaat.Name = "metinSaat";
            this.metinSaat.Size = new System.Drawing.Size(157, 66);
            this.metinSaat.TabIndex = 16;
            this.metinSaat.Text = "19:44";
            this.metinSaat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::Steam_Cafe.Properties.Resources.iconVarsayilanResim;
            this.pictureBox2.Location = new System.Drawing.Point(309, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // kullaniciRol
            // 
            this.kullaniciRol.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.kullaniciRol.ForeColor = System.Drawing.Color.OliveDrab;
            this.kullaniciRol.Location = new System.Drawing.Point(209, 42);
            this.kullaniciRol.Name = "kullaniciRol";
            this.kullaniciRol.Size = new System.Drawing.Size(99, 21);
            this.kullaniciRol.TabIndex = 5;
            this.kullaniciRol.Text = "Rol";
            this.kullaniciRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // saat
            // 
            this.saat.Enabled = true;
            this.saat.Interval = 1000;
            this.saat.Tick += new System.EventHandler(this.saat_Tick);
            // 
            // urunArama
            // 
            this.urunArama.BackColor = System.Drawing.Color.WhiteSmoke;
            this.urunArama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urunArama.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunArama.ForeColor = System.Drawing.Color.Gray;
            this.urunArama.Location = new System.Drawing.Point(134, 39);
            this.urunArama.Name = "urunArama";
            this.urunArama.Size = new System.Drawing.Size(177, 22);
            this.urunArama.TabIndex = 26;
            this.urunArama.Text = "Ürün Ara...";
            this.urunArama.TextChanged += new System.EventHandler(this.urunArama_TextChanged);
            this.urunArama.Enter += new System.EventHandler(this.urunArama_Enter);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuPanel.Location = new System.Drawing.Point(4, 35);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(90, 853);
            this.menuPanel.TabIndex = 23;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(102, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // butonMasalar
            // 
            this.butonMasalar.BackColor = System.Drawing.Color.ForestGreen;
            this.butonMasalar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butonMasalar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.butonMasalar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butonMasalar.Image = global::Steam_Cafe.Properties.Resources.iconPayment;
            this.butonMasalar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butonMasalar.Location = new System.Drawing.Point(792, 31);
            this.butonMasalar.Name = "butonMasalar";
            this.butonMasalar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.butonMasalar.Size = new System.Drawing.Size(132, 40);
            this.butonMasalar.TabIndex = 23;
            this.butonMasalar.Text = "Masalar";
            this.butonMasalar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butonMasalar.UseVisualStyleBackColor = false;
            this.butonMasalar.Click += new System.EventHandler(this.butonMasalar_Click);
            // 
            // yetkiliPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1301, 900);
            this.Controls.Add(this.butonMasalar);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.urunArama);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.siparisUrunler);
            this.Controls.Add(this.ustPanel);
            this.Controls.Add(this.yanPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "yetkiliPanel";
            this.Text = "Steam Cafe - Yetkili Paneli";
            this.Load += new System.EventHandler(this.yetkiliPanel_Load);
            this.ustPanel.ResumeLayout(false);
            this.ustPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.yanPanel.ResumeLayout(false);
            this.yanPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ustPanel;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel yanPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel siparisUrunler;
        private System.Windows.Forms.Label kullaniciAdi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label kullaniciRol;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label metinSaat;
        private System.Windows.Forms.Timer saat;
        private System.Windows.Forms.Button butonOdeme;
        private System.Windows.Forms.Button butonIptal;
        private System.Windows.Forms.FlowLayoutPanel odemeSiparisler;
        private System.Windows.Forms.TextBox urunArama;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel menuPanel;
        private System.Windows.Forms.Label toplamFiyat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butonMasalar;
        private System.Windows.Forms.Label masaNo;
    }
}