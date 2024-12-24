using System;
using System.Drawing;
using System.Windows.Forms;

namespace Steam_Cafe
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;
        private Timer solukEfekt;
        private string hedefKullanici;
        private string hedefSifre;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.Location = new Point(Control.MousePosition.X + mouseLocation.X, Control.MousePosition.Y + mouseLocation.Y);
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void solukEfekt_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0) {
                this.Opacity -= 0.05;
            } else {
                solukEfekt.Stop();
                solukEfekt.Dispose();
                this.Hide();
                girisPanel girisPanel = new girisPanel();
                girisPanel.Show();
            }
        }

        private void yonetimPaneli_Click_1(object sender, EventArgs e) { paneliAc(); }
        private void yetkiliPaneli_Click(object sender, EventArgs e) { paneliAc(); }

        private void paneliAc()
        {
            solukEfekt = new Timer { Interval = 50 };
            solukEfekt.Tick += solukEfekt_Tick;
            solukEfekt.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tarih.Text = DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("tr-TR"));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // Test Aşamaları
             this.Hide();
             yonetimPanel yonetimPanel = new yonetimPanel(true);
             yonetimPanel.Show(); 

            /*  this.Hide();
             girisPanel yonetimPanel = new girisPanel();
             yonetimPanel.Show(); */

            /* yetkiliPanel yetkiliPanel = new yetkiliPanel("osman.dere", "Garson");
             yetkiliPanel.Show();
             this.Hide(); */
        }
    }
}
