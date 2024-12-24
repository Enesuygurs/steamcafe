using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Steam_Cafe
{
    public partial class yonetimPanel : Form
    {
        public Point mouseLocation;
        private bool yoneticiMi = false;
        private int bolumNo;
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=cafesistemi";
        public yonetimPanel(bool yonetici)
        {
            InitializeComponent();
            if (yonetici == true) yoneticiMi = true;
        }

        private void yonetimPanel_Load(object sender, EventArgs e)
        {
            istatistikleriYukle("SELECT COUNT(*) FROM urunler", sayiUrunler);
            istatistikleriYukle("SELECT COUNT(*) FROM menu", sayiMenuler);
            istatistikleriYukle("SELECT COUNT(*) FROM malzemeler", sayiMalzemeler);
            istatistikleriYukle("SELECT COUNT(*) FROM kritikstok", sayiKritikUrunler);
            if (yoneticiMi == false)
            {
                butonUrunler.Location = new Point(14, 67);
                butonMenuler.Location = new Point(14, 109);
                butonMalzemeler.Location = new Point(14, 151);
                butonKritikStoklar.Location = new Point(14, 193);
                butonSiparisler.Visible = false;
                butonRezervasyonlar.Visible = false;
                butonMasalar.Visible = false;
                butonOdemeler.Visible = false;
                butonKullanicilar.Visible = false;
                butonPerformanslar.Visible = false;
                butonVardiyalar.Visible = false;
            }
            else
            {
                istatistikleriYukle("SELECT COUNT(*) FROM siparisler", sayiSiparisler);
                istatistikleriYukle("SELECT COUNT(*) FROM rezervasyonlar", sayiRezervasyonlar);
                istatistikleriYukle("SELECT COUNT(*) FROM masalar", sayiMasalar);
                istatistikleriYukle("SELECT COUNT(*) FROM calisanlar", sayiKullanicilar);
                istatistikleriYukle("SELECT COUNT(*) FROM performans", sayiPerformanslar);
                istatistikleriYukle("SELECT COUNT(*) FROM vardiyalar", sayiVardiyalar);
            }

        }
        private void istatistikleriYukle(string query, Control control)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        int orderCount = Convert.ToInt32(command.ExecuteScalar());
                        control.Text = orderCount.ToString();
                        control.Parent.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.Location = new Point(Control.MousePosition.X + mouseLocation.X, Control.MousePosition.Y + mouseLocation.Y);
        }

        private void sekmeleriHazirla()
        {
            var basliklar = new Dictionary<int, string> { { 1, "Siparişler - Sipariş Ürünleri" }, { 2, "Ödemeler" }, { 3, "Rezervasyonlar" }, { 4, "Masalar" }, { 5, "Ürünler - Ürün Malzemeleri" }, { 6, "Menüler" }, { 7, "Malzemeler" }, { 8, "Kişiler - Çalışanlar" }, { 9, "Performanslar" }, { 10, "Kritik Stoklar" }, { 11, "Vardiyalar" } };
            sekmeBaslik.Text = basliklar.ContainsKey(bolumNo) ? basliklar[bolumNo] + " Yönetimi" : "Geçersiz Sekme";
            tabloBaslik.Text = basliklar.ContainsKey(bolumNo) ? basliklar[bolumNo] : "Geçersiz Sekme";
        }

        private void butonTik(int index, int konumY, int bolum)
        {
            borderlessTabControl1.SelectedIndex = index;
            menuButtonSide.Location = new Point(menuButtonSide.Location.X, konumY);
            bolumNo = bolum;
            ClearTextBoxes();
            sekmeleriHazirla();
        }
        private void sqlSorgu(string query, DataGridView control, char islem)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }

                    control.DataSource = dt;
                    control.ClearSelection();
                    if (islem == 'X') return;
                    if (islem == 'L') MessageBox.Show("Veriler başarıyla yüklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (islem == 'E') MessageBox.Show("Veri başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (islem == 'S') MessageBox.Show("Veri başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (islem == 'G') MessageBox.Show("Veri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void SetUIContent(Dictionary<int, (Image, string)> content)
        {
            var pictureBoxes = new List<PictureBox> { resim1, resim2, resim3, resim4, resim5, resim6, resim7, resim8, resim9 };
            var labels = new List<Label> { metin1, metin2, metin3, metin4, metin5, metin6, metin7, metin8, metin9 };
            var textBoxes = new List<Control> { veri1, veri2, veri3, veri4, veri5, veri6, veri7, veri8, veri9 };
            var textLines = new List<Control> { veri1cizgi, veri2cizgi, veri3cizgi, veri4cizgi, veri5cizgi, veri6cizgi, veri7cizgi, veri8cizgi, veri9cizgi };

            foreach (var textBox in textBoxes) textBox.Visible = false;
            foreach (var textLine in textLines) textLine.Visible = false;
            foreach (var pictureBox in pictureBoxes) pictureBox.Visible = false;
            foreach (var label in labels) label.Visible = false;
            foreach (var kvp in content)
            {
                int index = kvp.Key - 1;
                if (index >= 0 && index < pictureBoxes.Count && index < labels.Count && index < textLines.Count)
                {
                    pictureBoxes[index].Image = kvp.Value.Item1;
                    labels[index].Text = kvp.Value.Item2;
                    pictureBoxes[index].Visible = true;
                    labels[index].Visible = true;
                    textBoxes[index].Visible = true;
                    textLines[index].Visible = true;
                }
            }
        }
        private void hizala(int anaTabloX, int sekmeGrupY, bool genis = false)
        {
            const int genisTabloYukseklik = 201;
            const int darTabloYukseklik = 264;
            const int genisTabloY = 320;
            const int darTabloY = 270;

            anaTablo.Size = new Size(640, genis ? genisTabloYukseklik : darTabloYukseklik);
            anaTablo.Location = new Point(anaTabloX, genis ? genisTabloY : darTabloY);
            tabloBaslik.Location = new Point(tabloBaslik.Location.X, genis ? 288 : 237);
            var butonY = genis ? 242 : 187;
            butonListele.Location = new Point(butonListele.Location.X, butonY);
            butonEkle.Location = new Point(butonEkle.Location.X, butonY);
            butonGuncelle.Location = new Point(butonGuncelle.Location.X, butonY);
            butonSil.Location = new Point(butonSil.Location.X, butonY);

            var controls = new List<Control> { veri7, veri8, veri9, veri7cizgi, veri8cizgi, veri9cizgi, resim7, resim8, resim9, metin7, metin8, metin9 };
            foreach (var control in controls)
                control.Visible = genis;

            sekmeGrup.Location = new Point(sekmeGrup.Location.X, sekmeGrupY == 98 ? 40 : 18);
            sekmeGrup.Size = new Size(sekmeGrup.Size.Width, sekmeGrupY);
        }


        private void butonAnaSayfa_Click(object sender, EventArgs e) => butonTik(0, 25, 0);
        private void butonSiparisler_Click(object sender, EventArgs e)
        {
            butonTik(1, 67, 1);
            sqlSorgu("SELECT s.siparisNo, s.masaNo, s.zaman, s.durum, su.urunNo, su.miktar FROM siparisler s LEFT JOIN siparisurunleri su ON s.siparisNo = su.siparisNo", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconSiparis, "Sipariş No") }, { 2, (Properties.Resources.iconMasa, "Masa No") }, { 3, (Properties.Resources.iconSaat, "Zaman") }, { 4, (Properties.Resources.iconDurum, "Durum") }, { 5, (Properties.Resources.iconUrun, "Ürün No") }, { 6, (Properties.Resources.iconPerformans, "Miktar") } });
            hizala(85, 152);
        }

        private void butonOdemeler_Click(object sender, EventArgs e)
        {
            butonTik(1, 109, 2);
            sqlSorgu("SELECT * FROM odemeler", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconPayment, "Ödeme No") }, { 2, (Properties.Resources.iconSiparis, "Sipariş No") }, { 3, (Properties.Resources.iconPerformans, "Tutar") }, { 4, (Properties.Resources.iconSaat, "Tarih") }, { 5, (Properties.Resources.iconPayment, "Ödeme Türü") }, { 6, (Properties.Resources.iconDurum, "Durum") } });
            hizala(75, 152);
        }

        private void butonRezervasyonlar_Click(object sender, EventArgs e)
        {
            butonTik(1, 151, 3);
            sqlSorgu("SELECT * FROM rezervasyonlar", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconRezervasyon, "Rezervasyon No") }, { 2, (Properties.Resources.iconKullanici, "Kişi No") }, { 3, (Properties.Resources.iconMasa, "Masa No") }, { 4, (Properties.Resources.iconKullanici, "Ad") }, { 5, (Properties.Resources.iconKullanicilar, "Kişi Sayısı") }, { 6, (Properties.Resources.iconSaat, "Zaman") } });
            hizala(45, 152);
        }

        private void butonMasalar_Click(object sender, EventArgs e)
        {
            butonTik(1, 193, 4);
            sqlSorgu("SELECT * FROM masalar", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconMasa, "Masa No") }, { 2, (Properties.Resources.iconKullanicilar, "Kapasite") }, { 3, (Properties.Resources.iconDurum, "Durum") } });
            hizala(225, 98);
        }

        private void butonUrunler_Click(object sender, EventArgs e)
        {
            if (yoneticiMi == false) butonTik(1, 67, 5);
            else butonTik(1, 235, 5);
            sqlSorgu("SELECT k.urunNo, k.kategoriNo, k.ad, k.fiyat, k.stok, k.resim, c.malzemeNo, c.stok FROM urunler k LEFT JOIN urunmalzemeleri c ON k.urunNo = c.urunNo ORDER BY k.urunNo ASC", anaTablo, 'X');
            hizala(38, 215, true);
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconUrun, "Ürün No") }, { 2, (Properties.Resources.iconMenu, "Kategori No") }, { 3, (Properties.Resources.iconKullanici, "Ad") }, { 4, (Properties.Resources.iconPerformans, "Fiyat") }, { 5, (Properties.Resources.iconUrun, "Stok") }, { 6, (Properties.Resources.iconResim, "Resim") }, { 7, (Properties.Resources.iconUrun, "Malzeme No") }, { 8, (Properties.Resources.iconUrun, "Stok") } });
        }

        private void butonMenuler_Click(object sender, EventArgs e)
        {
            if (yoneticiMi == false) butonTik(1, 109, 6);
            else butonTik(1, 277, 6);
            sqlSorgu("SELECT * FROM menu", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconMenu, "Kategori No") }, { 2, (Properties.Resources.iconUrun, "Kategori Ad") } });
            hizala(242, 98);
        }

        private void butonMalzemeler_Click(object sender, EventArgs e)
        {
            if (yoneticiMi == false) butonTik(1, 151, 7);
            else butonTik(1, 319, 7);
            sqlSorgu("SELECT * FROM malzemeler", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconMalzeme, "Malzeme No") }, { 2, (Properties.Resources.iconUrun, "Ad") }, { 3, (Properties.Resources.iconUrun, "Stok") } });
            hizala(242, 98);
        }

        private void butonKullanicilar_Click(object sender, EventArgs e)
        {
            butonTik(1, 361, 8);
            sqlSorgu("SELECT k.kisiNo, k.ad, k.kisiTuru, c.rol, c.iletisim, c.performans, c.vardiya, c.kullaniciadi, c.sifre FROM kisiler k LEFT JOIN calisanlar c ON k.kisiNo = c.kisiNo", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconKullanicilar, "Kişi No") }, { 2, (Properties.Resources.iconKullanici, "Ad") }, { 3, (Properties.Resources.iconAdmin, "Kişi Türü") }, { 4, (Properties.Resources.iconAdmin, "Rol") }, { 5, (Properties.Resources.iconAdmin, "İletişim") }, { 6, (Properties.Resources.iconAdmin, "Performans") }, { 7, (Properties.Resources.iconAdmin, "Vardiya") }, { 8, (Properties.Resources.iconAdmin, "Kullanıcı Adı") }, { 9, (Properties.Resources.iconAdmin, "Şifre") } });
            hizala(45, 215, true);
        }

        private void butonPerformanslar_Click(object sender, EventArgs e)
        {
            butonTik(1, 403, 9);
            sqlSorgu("SELECT * FROM performans", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconUrun, "Performans No") }, { 2, (Properties.Resources.iconUrun, "Puan") } });
            hizala(255, 98);
        }

        private void butonKritikStoklar_Click(object sender, EventArgs e)
        {
            if (yoneticiMi == false) butonTik(1, 193, 10);
            else butonTik(1, 445, 10);
            sqlSorgu("SELECT * FROM kritikstok", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconUrun, "Ürün No") }, { 2, (Properties.Resources.iconUrun, "Ad") }, { 3, (Properties.Resources.iconPerformans, "Mevcut Stok") }, { 4, (Properties.Resources.iconMenu, "Kategori No") }, { 5, (Properties.Resources.iconSaat, "Tarih") } });
            hizala(104, 152);
        }

        private void butonVardiyalar_Click(object sender, EventArgs e)
        {
            butonTik(1, 487, 11);
            sqlSorgu("SELECT * FROM vardiyalar", anaTablo, 'X');
            SetUIContent(new Dictionary<int, (Image, string)> { { 1, (Properties.Resources.iconAdmin, "Vardiya No") }, { 2, (Properties.Resources.iconSaat, "Vardiya") } });
            hizala(255, 98);
        }
        private void goruntuleSiparisler_Click(object sender, EventArgs e)
        {
            string query = "", whereClause = "";

            switch (bolumNo)
            {
                case 1: query = "SELECT s.siparisNo, s.masaNo, s.zaman, s.durum, su.urunNo, su.miktar FROM siparisler s LEFT JOIN siparisurunleri su ON s.siparisNo = su.siparisNo"; whereClause = "s.siparisNo"; break;
                case 2: query = "SELECT * FROM odemeler"; whereClause = "odemeNo"; break;
                case 3: query = "SELECT * FROM rezervasyonlar"; whereClause = "rezervasyonNo"; break;
                case 4: query = "SELECT * FROM masalar"; whereClause = "masaNo"; break;
                case 5: query = "SELECT k.urunNo, k.kategoriNo, k.ad, k.fiyat, k.stok, k.resim, c.malzemeNo, c.stok FROM urunler k LEFT JOIN urunmalzemeleri c ON k.urunNo = c.urunNo"; whereClause = "k.urunNo"; break;
                case 6: query = "SELECT * FROM menu"; whereClause = "kategoriNo"; break;
                case 7: query = "SELECT * FROM malzemeler"; whereClause = "malzemeNo"; break;
                case 8: query = "SELECT k.kisiNo, k.ad, k.kisiTuru, c.rol, c.iletisim, c.performans, c.vardiya, c.kullaniciadi, c.sifre FROM kisiler k LEFT JOIN calisanlar c ON k.kisiNo = c.kisiNo"; whereClause = "k.kisiNo"; break;
                case 9: query = "SELECT * FROM performans"; whereClause = "performansNo"; break;
                case 10: query = "SELECT * FROM kritikstok"; whereClause = "urunNo"; break;
                case 11: query = "SELECT * FROM vardiyalar"; whereClause = "vardiyaNo"; break;
                default: return;
            }
            if (!string.IsNullOrEmpty(veri1.Text))
            {
                if (!tabloBaslik.Text.Contains(":")) tabloBaslik.Text = tabloBaslik.Text + ": " + veri1.Text;
                else tabloBaslik.Text = tabloBaslik.Text.Split(':')[0] + ": " + veri1.Text;
                query += $" WHERE {whereClause} = {veri1.Text}";
            }
            else
            {
                sekmeleriHazirla();
            }
            sqlSorgu(query, anaTablo, 'L');
        }

        private bool bosMuKontrol(bool textbox1, bool textbox2, bool textbox3, bool textbox4, bool textbox5, bool textbox6)
        {
            var veriler = new List<Control>();

            if (textbox1) veriler.Add(veri1);
            if (textbox2) veriler.Add(veri2);
            if (textbox3) veriler.Add(veri3);
            if (textbox4) veriler.Add(veri4);
            if (textbox5) veriler.Add(veri5);
            if (textbox6) veriler.Add(veri6);

            foreach (var veri in veriler)
            {
                if (string.IsNullOrWhiteSpace(veri.Text))
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void siparislerButonEkle_Click(object sender, EventArgs e)
        {
            string query1 = "", query2 = "";

            switch (bolumNo)
            {
                case 1: // Siparişler
                        // Siparişler tablosuna veri ekle
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query1 = $"INSERT INTO siparisler (siparisNo, masaNo, zaman, durum) " +
                             $"VALUES ({veri1.Text}, {veri2.Text}, '{veri3.Text}', '{veri4.Text}');";
                    // SiparişÜrünleri tablosuna veri ekle
                    query2 = $"INSERT INTO siparisurunleri (siparisNo, urunNo, miktar) " +
                             $"VALUES ({veri1.Text}, {veri5.Text}, {veri6.Text});"; // veri5 ve veri6 siparişurunleri tablosuna ekleniyor
                    break;

                case 2: // Ödemeler
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query1 = $"INSERT INTO odemeler (odemeNo, siparisNo, tutar, tarih, odemeTuru, durum) " +
                             $"VALUES ({veri1.Text}, {veri2.Text}, {veri3.Text}, '{veri4.Text}', '{veri5.Text}', '{veri6.Text}');";
                    break;

                case 3: // Rezervasyonlar
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query1 = $"INSERT INTO rezervasyonlar (rezervasyonNo, kisiNo, masaNo, ad, kisiSayisi, zaman) " +
                             $"VALUES ({veri1.Text}, {veri2.Text}, {veri3.Text}, '{veri4.Text}', '{veri5.Text}', '{veri6.Text}');";
                    break;

                case 4: // Masalar
                    if (bosMuKontrol(true, true, true, false, false, false) == false) return;
                    query1 = $"INSERT INTO masalar (masaNo, kapasite, durum) " +
                             $"VALUES ({veri1.Text}, {veri2.Text}, '{veri3.Text}');";
                    break;

                case 5: // Ürünler
                    if (bosMuKontrol(true, true, true, true, true, false) == false) return;
                    query1 = $"INSERT INTO urunler (urunNo, kategoriNo, ad, fiyat, stok, resim) " +
                             $"VALUES ({veri1.Text}, {veri2.Text}, '{veri3.Text}', {veri4.Text}, {veri5.Text}, '{veri6.Text}');";
                    query2 = $"INSERT INTO urunmalzemeleri (urunNo, malzemeNo, stok) " +
                            $"VALUES ({veri1.Text}, '{veri7.Text}', '{veri8.Text}');";
                    break;

                case 6: // Menü
                    if (bosMuKontrol(true, true, false, false, false, false) == false) return;
                    query1 = $"INSERT INTO menu (kategoriNo, kategoriAd) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}');";
                    break;

                case 7: // Malzemeler
                    if (bosMuKontrol(true, true, true, false, false, false) == false) return;
                    query1 = $"INSERT INTO malzemeler (malzemeNo, ad, stok) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}', {veri3.Text});";
                    break;

                case 8: // Kişiler
                    if (bosMuKontrol(true, true, true, true, false, false) == false) return;
                    query1 = $"INSERT INTO kisiler (kisiNo, ad, kisiTuru) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}', '{veri3.Text}');";
                    query2 = $"INSERT INTO calisanlar (kisiNo, rol, iletisim, performans, vardiya, kullaniciadi, sifre) " +
                             $"VALUES ({veri1.Text}, '{veri4.Text}', '{veri5.Text}', {veri6.Text}, {veri7.Text}, '{veri8.Text}', '{veri9.Text}');";
                    break;

                case 9: // Performans
                    if (bosMuKontrol(true, true, false, false, false, false) == false) return;
                    query1 = $"INSERT INTO performans (performansNo, puan) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}');";
                    break;

                case 10: // Kritik Stok
                    if (bosMuKontrol(true, true, true, true, true, false) == false) return;
                    query1 = $"INSERT INTO kritikstok (urunNo, ad, mevcutStok, kategoriNo, tarih) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}', {veri3.Text}, {veri4.Text}, '{veri5.Text}');";
                    break;

                case 11: // Vardiyalar
                    if (bosMuKontrol(true, true, true, true, false, false) == false) return;
                    query1 = $"INSERT INTO vardiyalar (vardiyaNo, vardiya) " +
                             $"VALUES ({veri1.Text}, '{veri2.Text}');";
                    break;

                default:
                    MessageBox.Show("Geçersiz sekme seçimi.");
                    return;
            }

            sqlSorgu(query1, anaTablo, 'E');
            if (bolumNo == 1 || bolumNo == 8 || bolumNo == 5) sqlSorgu(query2, anaTablo, 'E');
            butonListele.PerformClick();
        }

        private void ClearTextBoxes()
        {
            veri1.Clear();
            veri2.Clear();
            veri3.Clear();
            veri4.Clear();
            veri5.Clear();
            veri6.Clear();
        }

        private void siparislerButonSil_Click(object sender, EventArgs e)
        {
            string query = "";
            switch (bolumNo)
            {
                case 1: // Siparişler
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM siparisler WHERE siparisNo = {veri1.Text};";
                    break;

                case 2: // Ödemeler
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM odemeler WHERE odemeNo = {veri1.Text};";
                    break;

                case 3: // Rezervasyonlar
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM rezervasyonlar WHERE rezervasyonNo = {veri1.Text};";
                    break;

                case 4: // Masalar
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM masalar WHERE masaNo = {veri1.Text};";
                    break;

                case 5: // Ürünler
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM urunler WHERE urunNo = {veri1.Text};";
                    break;

                case 6: // Menü
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM menu WHERE kategoriNo = {veri1.Text};";
                    break;

                case 7: // Malzemeler
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM malzemeler WHERE malzemeNo = {veri1.Text};";
                    break;

                case 8: // Kişiler
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM kisiler WHERE kisiNo = {veri1.Text};";
                    break;

                case 9: // Performans
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM performans WHERE performansNo = {veri1.Text};";
                    break;

                case 10: // Kritik Stok
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM kritikstok WHERE urunNo = {veri1.Text};";
                    break;

                case 11: // Vardiyalar
                    if (bosMuKontrol(true, false, false, false, false, false) == false) return;
                    query = $"DELETE FROM vardiyalar WHERE vardiyaNo = {veri1.Text};";
                    break;
                default:
                    MessageBox.Show("Geçersiz sekme seçimi.");
                    return;
            }
            sqlSorgu(query, anaTablo, 'S'); // 'S' silme işlemini temsil ediyor
            veri1.Text = "";
            butonListele.PerformClick(); // Tabloyu güncelle
        }

        private void siparislerButonGuncelle_Click(object sender, EventArgs e)
        {
            string query = "", query2 = "";
            switch (bolumNo)
            {
                case 1: // Siparişler
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query = $"UPDATE siparisler SET masaNo = {veri2.Text}, zaman = '{veri3.Text}', durum = '{veri4.Text}' WHERE siparisNo = {veri1.Text};";
                    query2 = $"UPDATE siparisurunleri SET urunNo = '{veri5.Text}', miktar = '{veri6.Text}' WHERE siparisNo = {veri1.Text};";
                    break;

                case 2: // Ödemeler
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query = $"UPDATE odemeler SET siparisNo = {veri2.Text}, tutar = {veri3.Text}, tarih = '{veri4.Text}', odemeTuru = '{veri5.Text}', durum = '{veri6.Text}' WHERE odemeNo = {veri1.Text};";
                    break;

                case 3: // Rezervasyonlar
                    if (bosMuKontrol(true, true, true, true, true, true) == false) return;
                    query = $"UPDATE rezervasyonlar SET kisiNo = {veri2.Text}, masaNo = {veri3.Text}, ad = '{veri4.Text}', kisiSayisi = '{veri5.Text}', zaman = '{veri6.Text}' WHERE rezervasyonNo = {veri1.Text};";
                    break;

                case 4: // Masalar
                    if (bosMuKontrol(true, true, true, false, false, false) == false) return;
                    query = $"UPDATE masalar SET kapasite = {veri2.Text}, durum = '{veri3.Text}' WHERE masaNo = {veri1.Text};";
                    break;

                case 5: // Ürünler
                    if (bosMuKontrol(true, true, true, true, true, false) == false) return;
                    query = $"UPDATE urunler SET kategoriNo = {veri2.Text}, ad = '{veri3.Text}', fiyat = {veri4.Text}, stok = {veri5.Text}, resim = {veri6.Text} WHERE urunNo = {veri1.Text};";
                    query2 = $"UPDATE urunmalzemeleri SET malzemeNo = '{veri7.Text}', stok = '{veri8.Text}' WHERE urunNo = {veri1.Text};";
                    break;

                case 6: // Menü
                    if (bosMuKontrol(true, true, false, false, false, false) == false) return;
                    query = $"UPDATE menu SET kategoriAd = '{veri2.Text}' WHERE kategoriNo = {veri1.Text};";
                    break;

                case 7: // Malzemeler
                    if (bosMuKontrol(true, true, true, false, false, false) == false) return;
                    query = $"UPDATE malzemeler SET ad = '{veri2.Text}', miktar = {veri3.Text} WHERE malzemeNo = {veri1.Text};";
                    break;

                case 8: // Kişiler
                    if (bosMuKontrol(true, true, true, false, false, false) == false) return;
                    query = $"UPDATE kisiler SET ad = '{veri2.Text}', kisiTuru = '{veri3.Text}' WHERE kisiNo = {veri1.Text};";
                    break;

                case 9: // Performans
                    if (bosMuKontrol(true, true, false, false, false, false) == false) return;
                    query = $"UPDATE performans SET puan = '{veri2.Text}' WHERE performansNo = {veri1.Text};";
                    break;

                case 10: // Kritik Stok
                    if (bosMuKontrol(true, true, true, true, true, false) == false) return;
                    query = $"UPDATE kritikstok SET ad = '{veri2.Text}', mevcutStok = {veri3.Text}, kategoriNo = {veri4.Text}, tarih = '{veri5.Text}' WHERE urunNo = {veri1.Text};";
                    break;

                case 11: // Vardiyalar
                    if (bosMuKontrol(true, true, false, false, false, false) == false) return;
                    query = $"UPDATE vardiyalar SET vardiya = '{veri2.Text}' WHERE vardiyaNo = {veri1.Text};";
                    break;

                default:
                    MessageBox.Show("Geçersiz sekme seçimi.");
                    return;
            }
            sqlSorgu(query, anaTablo, 'G'); // 'G' güncelleme işlemini temsil ediyor
            if (bolumNo == 1 || bolumNo == 8 || bolumNo == 5) sqlSorgu(query2, anaTablo, 'G');
            butonListele.PerformClick(); // Tabloyu güncelle

        }

        private void ToggleLabelVisibility(Label label, bool isVisible) { label.Visible = isVisible; }
        private void veri1_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin1, false);
        private void veri1_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin1, true);
        private void veri2_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin2, false);
        private void veri2_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin2, true);
        private void veri3_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin3, false);
        private void veri3_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin3, true);
        private void veri4_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin4, false);
        private void veri4_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin4, true);
        private void veri5_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin5, false);
        private void veri5_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin5, true);
        private void veri6_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin6, false);
        private void veri6_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin6, true);
        private void veri7_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin7, false);
        private void veri7_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin7, true);
        private void veri8_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin8, false);
        private void veri8_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin8, true);
        private void veri9_Enter(object sender, EventArgs e) => ToggleLabelVisibility(metin9, false);
        private void veri9_Leave(object sender, EventArgs e) => ToggleLabelVisibility(metin9, true);
        private void baslik_Click(object sender, EventArgs e) { Clipboard.SetText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")); }
        private void panel1_MouseDown(object sender, MouseEventArgs e) { mouseLocation = new Point(-e.X, -e.Y); }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anaForm = new Form1();
            anaForm.Show();
        }

        private void anaTablo_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
           
        }

    }
}
