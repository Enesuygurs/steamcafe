using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Steam_Cafe
{
    public partial class girisPanel : Form
    {
        public Point mouseLocation;
        private bool isDragging = false;
        private List<(string kullaniciAdi, string sifre)> adminListesi = new List<(string, string)>();
        private List<(string kullaniciAdi, string sifre)> calisanlarListesi = new List<(string, string)>();
        private List<(string kullaniciAdi, string sifre)> sefListesi = new List<(string, string)>();
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=cafesistemi";

        public girisPanel()
        {
            InitializeComponent();
        }

        private void girisButon_Click(object sender, EventArgs e)
        {
            string girilenKullaniciAdi = kullaniciadi.Text;
            string girilenSifre = sifre.Text; 

            // Admin kullanıcı adı ve şifre kontrolü
            bool adminBulundu = false;
            foreach (var admin in adminListesi)
            {
                if (admin.kullaniciAdi == girilenKullaniciAdi && admin.sifre == girilenSifre)
                {
                    adminBulundu = true;
                    break;
                }
            }
            // Şef kullanıcı kontrolü
            bool sefBulundu = false;
            foreach (var sef in sefListesi)
            {
                if (sef.kullaniciAdi == girilenKullaniciAdi && sef.sifre == girilenSifre)
                {
                    sefBulundu = true;
                    break;
                }
            }
            // Yetkili kullanıcı adı ve şifre kontrolü
            bool yetkiliBulundu = false;
            foreach (var calisan in calisanlarListesi)
            {
                if (calisan.kullaniciAdi == girilenKullaniciAdi && calisan.sifre == girilenSifre)
                {
                    yetkiliBulundu = true;
                    break;
                }
            }

            if (adminBulundu)
            {
                MessageBox.Show("Admin girişi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yonetimPanel yonetimPanel = new yonetimPanel(true);
                yonetimPanel.Show();
                this.Hide();
            } else if (sefBulundu)
            {
                MessageBox.Show("Şef girişi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yonetimPanel sefPanel = new yonetimPanel(false);
                sefPanel.Show();
                this.Hide();
            } else if (yetkiliBulundu)
            {
                MessageBox.Show("Yetkili girişi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yetkiliPanel yetkiliPanel = new yetkiliPanel(kullaniciadi.Text, "Garson");
                yetkiliPanel.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anaForm = new Form1();
            anaForm.Show();
        }

        private void sifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) girisButon.PerformClick();
        }

        private void girisPanel_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    // Admin kullanıcılarını almak için sorgu
                    string adminQuery = "SELECT kullaniciadi, sifre FROM yoneticiler";
                    using (var cmd = new NpgsqlCommand(adminQuery, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) // Admin kullanıcıları listeye ekliyoruz
                        {
                            string username = reader.GetString(0);
                            string password = reader.GetString(1);
                            adminListesi.Add((username, password));
                        }
                    }

                    // Yetkili kullanıcıları almak için sorgu
                    string calisanlarQuery = "SELECT kullaniciAdi, sifre, rol FROM calisanlar";
                    using (var cmd = new NpgsqlCommand(calisanlarQuery, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(0);
                            string password = reader.GetString(1);
                            string rol = reader.GetString(2);

                            // Şefleri seç
                            if (rol == "Şef") sefListesi.Add((username, password));
                            else calisanlarListesi.Add((username, password));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantısı sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseLocation = e.Location;
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) this.Location = new Point(this.Location.X + e.X - mouseLocation.X, this.Location.Y + e.Y - mouseLocation.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) isDragging = false;
        }

        private void yanResim_MouseDown(object sender, MouseEventArgs e) => panel1_MouseDown(sender, e);
        private void yanResim_MouseMove(object sender, MouseEventArgs e) => panel1_MouseMove(sender, e);
        private void yanResim_MouseUp(object sender, MouseEventArgs e) => panel1_MouseUp(sender, e);

    }
}
