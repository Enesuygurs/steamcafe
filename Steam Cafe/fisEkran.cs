using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Steam_Cafe
{
    public partial class fisEkran : Form
    {
        public Point mouseLocation;
        private PrintDocument fis;
        private PrintDocument fis2;
        private float scaleFactor = 1.0f;
        public fisEkran(PrintDocument siparisFis, PrintDocument fisPdf)
        {
            InitializeComponent();
            fis = siparisFis;
            siparisFis.PrintPage += fis_PrintPage;
            fis2 = fisPdf;
        }
        private void fis_PrintPage(object sender, PrintPageEventArgs e) => e.Graphics.ScaleTransform(scaleFactor, scaleFactor);
        private void fisEkran_Load(object sender, EventArgs e)
        {
            fisOnizleme.Document = fis;
            fisOnizleme.Zoom = 1.0;
        }
      
        private void butonYazdir_Click(object sender, EventArgs e)
        {
            try
            {
                fis2.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazdırma sırasında bir hata oluştu: " + ex.Message);
            }
        }
        private void closeButton_Click(object sender, EventArgs e) { this.Close(); }
        private void ustPanel_MouseDown(object sender, MouseEventArgs e) => mouseLocation = new Point(-e.X, -e.Y);
        private void ustPanel_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) this.Location = new Point(Control.MousePosition.X + mouseLocation.X, Control.MousePosition.Y + mouseLocation.Y); }

    }
}
