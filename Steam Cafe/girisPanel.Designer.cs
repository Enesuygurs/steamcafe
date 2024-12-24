namespace Steam_Cafe
{
    partial class girisPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(girisPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kullaniciadi = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.girisButon = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.yanResim = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.yanResim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 29);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
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
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Cafe - Yetkili Girişi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(104, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = " Y Ö N E T İ M  P A N E L İ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 44F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(32, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 78);
            this.label2.TabIndex = 9;
            this.label2.Text = "Steam Cafe";
            // 
            // kullaniciadi
            // 
            this.kullaniciadi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kullaniciadi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kullaniciadi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciadi.ForeColor = System.Drawing.Color.Black;
            this.kullaniciadi.Location = new System.Drawing.Point(130, 276);
            this.kullaniciadi.Name = "kullaniciadi";
            this.kullaniciadi.Size = new System.Drawing.Size(177, 22);
            this.kullaniciadi.TabIndex = 16;
            this.kullaniciadi.Text = "Admin";
            // 
            // sifre
            // 
            this.sifre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sifre.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sifre.Location = new System.Drawing.Point(130, 317);
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = 'S';
            this.sifre.Size = new System.Drawing.Size(177, 22);
            this.sifre.TabIndex = 18;
            this.sifre.Text = "admin123";
            this.sifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sifre_KeyPress);
            // 
            // girisButon
            // 
            this.girisButon.BackColor = System.Drawing.Color.Black;
            this.girisButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.girisButon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.girisButon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.girisButon.Location = new System.Drawing.Point(150, 362);
            this.girisButon.Name = "girisButon";
            this.girisButon.Size = new System.Drawing.Size(102, 32);
            this.girisButon.TabIndex = 19;
            this.girisButon.Text = "Giriş Yap";
            this.girisButon.UseVisualStyleBackColor = false;
            this.girisButon.Click += new System.EventHandler(this.girisButon_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(130, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 2);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(130, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 2);
            this.panel3.TabIndex = 21;
            // 
            // yanResim
            // 
            this.yanResim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yanResim.BackgroundImage")));
            this.yanResim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yanResim.Controls.Add(this.closeButton);
            this.yanResim.Location = new System.Drawing.Point(384, -5);
            this.yanResim.Name = "yanResim";
            this.yanResim.Size = new System.Drawing.Size(384, 535);
            this.yanResim.TabIndex = 22;
            this.yanResim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yanResim_MouseDown);
            this.yanResim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.yanResim_MouseMove);
            this.yanResim.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yanResim_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.Font = new System.Drawing.Font("Marlett", 12.25F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(358, 10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 17);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "r";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Image = global::Steam_Cafe.Properties.Resources.iconSifreSiyah;
            this.pictureBox5.Location = new System.Drawing.Point(90, 311);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = global::Steam_Cafe.Properties.Resources.iconKullaniciSiyah;
            this.pictureBox3.Location = new System.Drawing.Point(90, 270);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::Steam_Cafe.Properties.Resources.iconVarsayilanResim;
            this.pictureBox2.Location = new System.Drawing.Point(167, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // girisPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(768, 509);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.yanResim);
            this.Controls.Add(this.girisButon);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.kullaniciadi);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "girisPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam Cafe - Yetkili Girişi";
            this.Load += new System.EventHandler(this.girisPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.yanResim.ResumeLayout(false);
            this.yanResim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox kullaniciadi;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button girisButon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Panel yanResim;
    }
}