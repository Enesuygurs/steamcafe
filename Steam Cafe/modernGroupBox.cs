using System.Drawing;
using System.Windows.Forms;

public class ModernGroupBox : GroupBox
{
    private Color titleBackColor = Color.DodgerBlue;
    private int titleHeight = 32; // Başlık yüksekliği
    private Color borderColor = Color.DodgerBlue; // Çerçeve rengi
    private int borderWidth = 2; // Çerçeve kalınlığı

    public ModernGroupBox()
    {
        // GroupBox özelliklerini ayarlayın
        this.BackColor = Color.WhiteSmoke; // Arkaplan rengini beyaz yapın
        this.ForeColor = Color.FromArgb(158, 12, 57); // Metin rengini özelleştirin
        this.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Yazı tipini ve boyutunu ayarlayın
        this.FlatStyle = FlatStyle.Flat; // Çerçeveyi kaldırın
    }

    // GroupBox'un çizimini özelleştirmek için OnPaint metodu üzerine yazın
    protected override void OnPaint(PaintEventArgs e)
    {
        // Çerçeve çizin
        var g = e.Graphics;
        var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        var borderPen = new Pen(borderColor, borderWidth);
        g.DrawRectangle(borderPen, rect);

        // Başlık arka planını çizin
        var titleRect = new Rectangle(0, 0, this.Width, titleHeight);
        var titleBrush = new SolidBrush(titleBackColor);
        g.FillRectangle(titleBrush, titleRect);

        // Başlığı özelleştirin
        g.DrawString(this.Text, this.Font, Brushes.White, titleRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
    }

    // Başlık yüksekliğini özelleştirmek için property ekleyin
    public int TitleHeight
    {
        get { return titleHeight; }
        set { titleHeight = value; Invalidate(); }
    }

    // Başlık arka plan rengini özelleştirmek için property ekleyin
    public Color TitleBackColor
    {
        get { return titleBackColor; }
        set { titleBackColor = value; Invalidate(); }
    }

    // Çerçeve rengini özelleştirmek için property ekleyin
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; Invalidate(); }
    }

    // Çerçeve kalınlığını özelleştirmek için property ekleyin
    public int BorderWidth
    {
        get { return borderWidth; }
        set { borderWidth = value; Invalidate(); }
    }
}
