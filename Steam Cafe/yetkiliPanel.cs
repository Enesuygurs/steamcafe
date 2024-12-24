using Npgsql;
using Steam_Cafe.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
namespace Steam_Cafe
{
    public partial class yetkiliPanel : Form
    {
        public Point mouseLocation;
        private decimal toplamFiyatDegeri = 0.00m;
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=cafesistemi";
        private string secilenMasa = string.Empty;
        public Dictionary<int, List<Tuple<string, decimal>>> masaSiparisleri = new Dictionary<int, List<Tuple<string, decimal>>>();
        private int aktifMasaNo = -1;

        public yetkiliPanel(string kullaniciadi, string kullanicirolu)
        {
            InitializeComponent();
            kullaniciAdi.Text = kullaniciadi;
            kullaniciRol.Text = kullanicirolu;
        }
        public void MasaSecildi(int masaNo)
        {
            aktifMasaNo = masaNo;
            if (masaSiparisleri.ContainsKey(masaNo))
            {
                odemeSiparisler.Controls.Clear();
                toplamFiyatDegeri = 0;
                foreach (var siparis in masaSiparisleri[masaNo]) AddProductToPayment(siparis.Item1, siparis.Item2, false);
                toplamFiyat.Text = $"{toplamFiyatDegeri:0.00} ₺";
            }
            else
            {
                masaSiparisleri[masaNo] = new List<Tuple<string, decimal>>();
                odemeSiparisler.Controls.Clear();
                toplamFiyatDegeri = 0;
                toplamFiyat.Text = "0.00 ₺";
            }
        }
        public void UpdateMasaLabel(string masaBilgisi) => masaNo.Text = masaBilgisi;
        private void yetkiliPanel_Load(object sender, EventArgs e)
        {
            // Başlangıçta Tüm ürünleri göster
            ShowAllProducts();

            // "Tümünü Göster" butonunu ekle
            Button btnTumunuGoster = new Button
            {
                Width = 85,
                Height = 85,
                BackColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Image = Properties.Resources.iconMenu,
                ImageAlign = ContentAlignment.TopCenter,
                Text = "Tümü",
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.BottomCenter,
                Padding = new Padding(0, 10, 0, 12)
            };
            btnTumunuGoster.FlatAppearance.BorderSize = 0;
            btnTumunuGoster.Click += (s, ev) => ShowAllProducts();
            menuPanel.Controls.Add(btnTumunuGoster);

            // Kategorileri yükle
            string queryKategori = "SELECT kategoriNo, kategoriAd FROM menu";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryKategori, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int kategoriNo = reader.GetInt32(0);
                        string kategoriAd = reader.GetString(1);

                        // Kategori butonu oluştur
                        Button btnKategori = new Button
                        {
                            Width = 85,
                            Text = kategoriAd,
                            Height = (kategoriAd.Length > 9) ? 100 : 85,
                            Padding = (kategoriAd.Length > 9) ? new Padding(0, 10, 0, 5) : new Padding(0, 10, 0, 12),
                            BackColor = Color.Orange,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Image = Properties.Resources.iconMenu,
                            ImageAlign = ContentAlignment.TopCenter,
                            TextAlign = ContentAlignment.BottomCenter,
                            Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                            Tag = kategoriNo
                        };
                        btnKategori.FlatAppearance.BorderSize = 0;
                        btnKategori.Click += (s, ev) => FilterProductsByCategory(kategoriNo);
                        menuPanel.Controls.Add(btnKategori);
                    }
                }
            }

            FlowLayoutPanel flowUrunler = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(flowUrunler);
        }
        private void ShowProducts(string query, NpgsqlParameter[] parameters = null)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // FlowLayoutPanel'deki mevcut ürünleri temizle
                        siparisUrunler.Controls.Clear();

                        while (reader.Read())
                        {
                            int urunNo = reader.GetInt32(0);
                            string ad = reader.GetString(1);
                            decimal fiyat = reader.GetDecimal(2);
                            int stok = reader.GetInt32(3);
                            string resim = reader.IsDBNull(4) ? "yok" : reader.GetString(4);

                            // Panel oluştur
                            Panel pnlUrun = new Panel
                            {
                                Width = 200,
                                Height = 220,
                                BackColor = Color.FromArgb(240, 240, 240),
                                Enabled = (stok <= 0 ? false : true),
                                BorderStyle = BorderStyle.None,
                                Tag = urunNo,
                                Cursor = Cursors.Hand
                            };

                            // Resim ekle
                            PictureBox pbResim = new PictureBox
                            {
                                Width = 100,
                                Height = 100,
                                Location = new Point(50, 14),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Cursor = Cursors.Hand
                            };
                            if (resim == "yok")
                            {
                                pbResim.Image = Resources.logo;
                            }
                            else
                            {
                                try
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        byte[] imageBytes = client.DownloadData(resim);
                                        using (MemoryStream stream = new MemoryStream(imageBytes)) pbResim.Image = new Bitmap(stream);
                                    }
                                }
                                catch (Exception)
                                {
                                    pbResim.Image = Resources.logo;
                                }
                            }

                            pbResim.Click += (s, ev) => AddProductToPayment(ad, fiyat);
                            // Ürün adı ekle
                            Label lblAd = new Label
                            {
                                Text = ad,
                                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                                Location = new Point(10, 120),
                                Width = 180,
                                Height = 30,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Cursor = Cursors.Hand
                            };

                            // Ürün fiyatı ekle
                            Label lblFiyat = new Label
                            {
                                Text = $"{fiyat} ₺",
                                Font = new Font("Segoe UI Semibold", 20, FontStyle.Bold),
                                Location = new Point(10, 145),
                                ForeColor = Color.Crimson,
                                Width = 180,
                                Height = 40,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Cursor = Cursors.Hand
                            };

                            // Stok bilgisi ekle
                            Label lblStok = new Label
                            {
                                Text = (stok <= 0 ? "TÜKENDİ" : "Stok: " + Convert.ToString(stok)),
                                Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold),
                                Location = new Point(10, 185),
                                ForeColor = Color.DimGray,
                                Width = 180,
                                Height = 20,
                                TextAlign = ContentAlignment.MiddleCenter
                            };

                            // Kontrolleri panele ekle
                            pnlUrun.Controls.Add(pbResim);
                            pnlUrun.Controls.Add(lblAd);
                            pnlUrun.Controls.Add(lblFiyat);
                            pnlUrun.Controls.Add(lblStok);

                            // FlowLayoutPanel'e ekle
                            siparisUrunler.Controls.Add(pnlUrun);
                        }
                    }
                }
            }
        }
        private void AddProductToPayment(string productName, decimal price, bool addToList = true)
        {
            if (aktifMasaNo == -1)
            {
                MessageBox.Show("Lütfen önce bir masa seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Veritabanında ürünün stok bilgisini al
            int mevcutStok = GetProductStock(productName);
            if (mevcutStok <= 0)
            {
                MessageBox.Show($"'{productName}' ürünü stokta yok.", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mevcut masadaki siparişlerden aynı üründen kaç adet eklendiğini kontrol et
            int mevcutSiparisAdeti = masaSiparisleri[aktifMasaNo]?.Count(s => s.Item1 == productName) ?? 0;

            // Eğer mevcut sipariş adedi stoktan büyükse stok kadar ekle
            if (mevcutSiparisAdeti >= mevcutStok)
            {
                MessageBox.Show($"'{productName}' ürününden maksimum {mevcutStok} adet eklenebilir.", "Stok Limiti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Sipariş Panelini Oluştur
            Panel pnlSiparis = new Panel
            {
                Width = odemeSiparisler.Width - 10,
                Height = 40,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(5, 5, 5, 0)
            };

            // Ürün Adı Ekle
            Label lblProductName = new Label
            {
                Text = productName,
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Width = pnlSiparis.Width / 2,
                Height = pnlSiparis.Height,
                Location = new Point(10, 0)
            };

            // Fiyat Ekle
            Label lblPrice = new Label
            {
                Text = $"{price:0.00} ₺",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Width = pnlSiparis.Width / 4,
                Height = pnlSiparis.Height,
                Location = new Point((pnlSiparis.Width / 2) + 40, 0)
            };

            // Sil Butonu Ekle
            Button btnRemove = new Button
            {
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                BackgroundImage = Properties.Resources.iconSil,
                BackgroundImageLayout = ImageLayout.Stretch,
                ImageAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Crimson,
                FlatStyle = FlatStyle.Flat,
                Width = 25,
                Height = 25,
                Location = new Point(pnlSiparis.Width - 40, 7)
            };
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.Click += (s, ev) =>
            {
                toplamFiyatDegeri -= price;
                toplamFiyat.Text = $"{toplamFiyatDegeri:0.00} ₺";
                odemeSiparisler.Controls.Remove(pnlSiparis);
                pnlSiparis.Dispose();
                masaSiparisleri[aktifMasaNo]?.Remove(new Tuple<string, decimal>(productName, price));
            };

            pnlSiparis.Controls.Add(lblProductName);
            pnlSiparis.Controls.Add(lblPrice);
            pnlSiparis.Controls.Add(btnRemove);
            odemeSiparisler.Controls.Add(pnlSiparis);
            toplamFiyatDegeri += price;
            toplamFiyat.Text = $"{toplamFiyatDegeri:0.00} ₺";

            // Listeye ekle
            if (addToList)
            {
                if (aktifMasaNo != -1) masaSiparisleri[aktifMasaNo]?.Add(new Tuple<string, decimal>(productName, price));
            }
        }
        private int GetProductStock(string productName)
        {
            int stok = 0;
            string query = "SELECT stok FROM urunler WHERE ad = @urunAd";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@urunAd", productName);
                    var result = cmd.ExecuteScalar();
                    stok = result != null ? Convert.ToInt32(result) : 0;
                }
            }

            return stok;
        }

        private void ShowAllProducts()
        {
            string query = "SELECT urunNo, ad, fiyat, stok, resim FROM urunler";
            ShowProducts(query);
        }

        private void FilterProductsByCategory(int kategoriNo)
        {
            string query = "SELECT urunNo, ad, fiyat, stok, resim FROM urunler WHERE kategoriNo = @kategoriNo";
            var parameters = new[] { new NpgsqlParameter("@kategoriNo", kategoriNo) };
            ShowProducts(query, parameters);
        }

        private void urunArama_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = urunArama.Text.ToLower();
            foreach (Control control in siparisUrunler.Controls)
            {
                if (control is Panel panel)
                {
                    Label lblAd = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Font.Size == 16);
                    if (lblAd != null) panel.Visible = lblAd.Text.ToLower().Contains(searchTerm);
                }
            }
        }

        private void butonIptal_Click(object sender, EventArgs e)
        {
            if (aktifMasaNo != -1 && masaSiparisleri.ContainsKey(aktifMasaNo)) masaSiparisleri[aktifMasaNo].Clear();
            else MessageBox.Show("Lütfen önce bir masa seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            odemeSiparisler.Controls.Clear();
            toplamFiyatDegeri = 0.00m;
            toplamFiyat.Text = $"{toplamFiyatDegeri:0.00} ₺";
        }

        private void butonMasalar_Click(object sender, EventArgs e)
        {
            masaSecimi masaSecimi = new masaSecimi(this.masaSiparisleri);
            masaSecimi.Owner = this;
            masaSecimi.Show();
        }

        private object ExecuteSql(string query, Dictionary<string, object> parameters, NpgsqlConnection conn)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                return cmd.ExecuteScalar(); // Sonuç döndür
            }
        }
        private void PrintReceipt(int siparisNo, decimal toplamTutar, List<Tuple<string, int, decimal>> urunler, decimal kdvOrani)
        {
            PrintDocument printDoc = new PrintDocument();
            PrintDocument printDoc2 = new PrintDocument();

            ConfigurePrintDocument(printDoc);
            ConfigurePrintDocument(printDoc2);

            printDoc.PrintPage += (sender, e) => DrawReceipt(e.Graphics, siparisNo, toplamTutar, urunler, kdvOrani, scale: 1.0f);
            printDoc2.PrintPage += (sender, e) => DrawReceipt(e.Graphics, siparisNo, toplamTutar, urunler, kdvOrani, scale: 2.6f);

            try
            {
                fisEkran fisEkran = new fisEkran(printDoc, printDoc2);
                fisEkran.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fiş yazdırılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurePrintDocument(PrintDocument printDoc)
        {
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, 800);
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
        }

        private void DrawReceipt(Graphics g, int siparisNo, decimal toplamTutar, List<Tuple<string, int, decimal>> urunler, decimal kdvOrani, float scale)
        {
            g.ScaleTransform(scale, scale);

            // Yazı tipleri
            Font titleFont = new Font("Arial", 12, FontStyle.Bold);
            Font subTitleFont = new Font("Arial", 9);
            Font headerFont = new Font("Arial", 8, FontStyle.Bold);
            Font font = new Font("Arial", 8);

            int y = 10;

            // Fiş Başlığı
            g.DrawString("Steam Cafe", titleFont, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawString("Sakarya Üniversitesi Kampüsü No:250/A", subTitleFont, Brushes.Black, new PointF(10, y));
            y += 15;
            g.DrawString("Serdivan / Sakarya", subTitleFont, Brushes.Black, new PointF(10, y));
            y += 20;

            g.DrawLine(Pens.Black, 10, y, 270, y);
            y += 10;

            // Sipariş Bilgileri
            g.DrawString("E-Arşiv Fatura Bilgi Fişi", headerFont, Brushes.Black, new PointF(10, y));
            y += 15;
            g.DrawString($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}", font, Brushes.Black, new PointF(10, y));
            y += 15;
            g.DrawString($"Sipariş No: {siparisNo}", font, Brushes.Black, new PointF(10, y));
            y += 20;

            // Ürün Listesi Başlığı
            g.DrawString("Ürün Adı", headerFont, Brushes.Black, new PointF(10, y));
            g.DrawString("Adet", headerFont, Brushes.Black, new PointF(150, y));
            g.DrawString("Fiyat", headerFont, Brushes.Black, new PointF(200, y));
            g.DrawString("Tutar", headerFont, Brushes.Black, new PointF(250, y));
            y += 15;

            g.DrawLine(Pens.Black, 10, y, 270, y);
            y += 10;

            // Ürünler Listesi
            decimal kdvToplam = 0;
            foreach (var urun in urunler)
            {
                string urunAdi = urun.Item1;
                int adet = urun.Item2;
                decimal fiyat = urun.Item3;
                decimal tutar = fiyat * adet;
                decimal kdvTutar = tutar * kdvOrani / 100;
                kdvToplam += kdvTutar;

                g.DrawString(urunAdi, font, Brushes.Black, new PointF(10, y));
                g.DrawString(adet.ToString(), font, Brushes.Black, new PointF(150, y));
                g.DrawString(fiyat.ToString("C", new CultureInfo("tr-TR")), font, Brushes.Black, new PointF(200, y));
                g.DrawString(tutar.ToString("C", new CultureInfo("tr-TR")), font, Brushes.Black, new PointF(250, y));
                y += 15;
            }

            // KDV ve Toplamlar
            y += 10;
            g.DrawLine(Pens.Black, 10, y, 270, y);
            y += 10;

            g.DrawString($"Ara Toplam: {(toplamTutar - kdvToplam).ToString("C", new CultureInfo("tr-TR"))}", font, Brushes.Black, new PointF(10, y));
            y += 15;
            g.DrawString($"KDV (%{kdvOrani}): {kdvToplam.ToString("C", new CultureInfo("tr-TR"))}", font, Brushes.Black, new PointF(10, y));
            y += 15;
            g.DrawString($"Genel Toplam: {toplamTutar.ToString("C", new CultureInfo("tr-TR"))}", headerFont, Brushes.Black, new PointF(10, y));
            y += 20;

            // Alt Mesaj ve Çizgiler
            g.DrawLine(Pens.Black, 10, y, 270, y);
            y += 10;
            g.DrawString("Bizi tercih ettiğiniz için teşekkür ederiz!", font, Brushes.Black, new PointF(10, y));
            y += 20;
            g.DrawLine(Pens.Black, 10, y, 270, y);
        }

        private void butonOdeme_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ödeme işlemini onaylıyor musunuz?", "Ödeme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (aktifMasaNo != -1 && masaSiparisleri.ContainsKey(aktifMasaNo) && masaSiparisleri[aktifMasaNo].Count > 0)
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();

                        // Sipariş ekle ve siparisNo'yu al
                        string querySiparis = "INSERT INTO siparisler (masaNo, zaman, durum) VALUES (@masaNo, @zaman, @durum) RETURNING siparisNo";
                        var siparisParams = new Dictionary<string, object>
                {
                    { "@masaNo", aktifMasaNo },
                    { "@zaman", DateTime.Now },
                    { "@durum", "A" }
                };
                        int siparisNo = (int)ExecuteSql(querySiparis, siparisParams, conn);

                        // Ürünleri gruplandırarak siparişe ekle
                        var groupedOrders = masaSiparisleri[aktifMasaNo]
                            .GroupBy(s => s.Item1)
                            .Select(g => new { UrunAd = g.Key, Miktar = g.Count() });

                        foreach (var groupedOrder in groupedOrders)
                        {
                            string urunAd = groupedOrder.UrunAd;
                            int urunMiktar = groupedOrder.Miktar;

                            // Ürün No'yu al
                            string queryGetUrunNo = "SELECT urunNo FROM urunler WHERE ad = @urunAd";
                            var urunParams = new Dictionary<string, object> { { "@urunAd", urunAd } };
                            int urunNo = (int)ExecuteSql(queryGetUrunNo, urunParams, conn);

                            // Ürün var mı, miktar arttır ya da yeni ekle
                            string queryCheckUrunExists = "SELECT miktar FROM siparisurunleri WHERE siparisNo = @siparisNo AND urunNo = @urunNo";
                            var checkParams = new Dictionary<string, object>
                    {
                        { "@siparisNo", siparisNo },
                        { "@urunNo", urunNo }
                    };

                            var resultCheck = ExecuteSql(queryCheckUrunExists, checkParams, conn);

                            if (resultCheck != null) // Ürün zaten varsa, miktar artır
                            {
                                int mevcutMiktar = (int)resultCheck;
                                string queryUpdateMiktar = "UPDATE siparisurunleri SET miktar = @miktar WHERE siparisNo = @siparisNo AND urunNo = @urunNo";
                                var updateParams = new Dictionary<string, object>
                        {
                            { "@siparisNo", siparisNo },
                            { "@urunNo", urunNo },
                            { "@miktar", mevcutMiktar + urunMiktar }
                        };
                                ExecuteSql(queryUpdateMiktar, updateParams, conn);
                            }
                            else // Ürün yok, yeni kayıt ekle
                            {
                                string queryInsertUrun = "INSERT INTO siparisurunleri (siparisNo, urunNo, miktar) VALUES (@siparisNo, @urunNo, @miktar)";
                                var insertParams = new Dictionary<string, object>
                        {
                            { "@siparisNo", siparisNo },
                            { "@urunNo", urunNo },
                            { "@miktar", urunMiktar }
                        };
                                ExecuteSql(queryInsertUrun, insertParams, conn);
                            }
                        }

                        // Ödeme işlemi
                        decimal odemeTutar = toplamFiyatDegeri;
                        string odemeTuru = MessageBox.Show("Ödeme Kredi Kartıyla mı yapıldı?", "Ödeme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? "Kredi Kartı" : "Nakit";

                        string queryOdeme = "INSERT INTO odemeler (siparisNo, tutar, tarih, odemeturu, durum) VALUES (@siparisNo, @tutar, @tarih, @odemeturu, @durum)";
                        var odemeParams = new Dictionary<string, object>
                        {
                            { "@siparisNo", siparisNo },
                            { "@tutar", odemeTutar },
                            { "@tarih", DateTime.Now },
                            { "@odemeturu", odemeTuru },
                            { "@durum", "P" } // Durum "Tamamlandı"
                        };
                        ExecuteSql(queryOdeme, odemeParams, conn);


                        var urunler = masaSiparisleri[aktifMasaNo]
                        .GroupBy(s => s.Item1)
                        .Select(g => new Tuple<string, int, decimal>(g.Key, g.Count(), g.First().Item2))
                        .ToList();

                        // Fiş yazdır
                        PrintReceipt(siparisNo, toplamFiyatDegeri, urunler, 10);
                    }

                    // Ödeme başarılı mesajı
                    MessageBox.Show("Ödeme işlemi başarıyla gerçekleştirildi.", "Ödeme Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Siparişleri temizle
                    masaSiparisleri[aktifMasaNo].Clear();
                    odemeSiparisler.Controls.Clear();
                    toplamFiyatDegeri = 0.00m;
                    toplamFiyat.Text = $"{toplamFiyatDegeri:0.00} ₺";
                    ShowAllProducts();
                }
                else MessageBox.Show("Lütfen önce bir masa seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Ödeme işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void urunArama_Enter(object sender, EventArgs e) => urunArama.Text = "";
        private void saat_Tick(object sender, EventArgs e) => metinSaat.Text = DateTime.Now.ToString("HH:mm");
        private void ustPanel_MouseDown(object sender, MouseEventArgs e) => mouseLocation = new Point(-e.X, -e.Y);
        private void ustPanel_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) this.Location = new Point(Control.MousePosition.X + mouseLocation.X, Control.MousePosition.Y + mouseLocation.Y); }
    }
}
