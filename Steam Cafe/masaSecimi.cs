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

namespace Steam_Cafe
{
    public partial class masaSecimi : Form
    {
        public Point mouseLocation;
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=cafesistemi";
        private Dictionary<int, List<Tuple<string, decimal>>> masaSiparisleri;
        public string SecilenMasa { get; set; }

        public masaSecimi(Dictionary<int, List<Tuple<string, decimal>>> siparisler)
        {
            InitializeComponent();
            this.masaSiparisleri = siparisler;
        }

        private void masaSecimi_Load(object sender, EventArgs e)
        {
            string query = "SELECT masaNo, durum FROM masalar ORDER BY masano ASC";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int masaNo = reader.GetInt32(0);
                        string masaAd = reader.GetString(1);
                        Button btnMasa = new Button
                        {
                            Text = "Masa " + Convert.ToString(masaNo),
                            Width = 147,
                            Height = 129,
                            Padding = new Padding(0, 20, 0, 20),
                            Image = Properties.Resources.iconMasaBuyuk,
                            ImageAlign = ContentAlignment.TopCenter,
                            Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                            FlatStyle = FlatStyle.Flat,
                            TextAlign = ContentAlignment.BottomCenter,
                            BackColor = Color.Crimson,
                            ForeColor = Color.White,
                            Tag = masaNo
                        };

                        if (masaSiparisleri.ContainsKey(masaNo) && masaSiparisleri[masaNo].Count > 0)  btnMasa.BackColor = Color.ForestGreen;
                        btnMasa.Click += MasaSecildi;
                        masalar.Controls.Add(btnMasa);
                    }
                }
            }
        }

        private void MasaSecildi(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            int selectedMasaNo = (int)selectedButton.Tag;
            SecilenMasa = "Seçilen Masa: " + selectedButton.Text;
            ((yetkiliPanel)this.Owner).UpdateMasaLabel(SecilenMasa);
            ((yetkiliPanel)this.Owner).MasaSecildi(selectedMasaNo);
            this.Close();
        }
        private void ustPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.Location = new Point(Control.MousePosition.X + mouseLocation.X, Control.MousePosition.Y + mouseLocation.Y);
        }

        private void ustPanel_MouseDown(object sender, MouseEventArgs e) => mouseLocation = new Point(-e.X, -e.Y);
        private void closeButton_Click(object sender, EventArgs e) => this.Close();
    }
}
