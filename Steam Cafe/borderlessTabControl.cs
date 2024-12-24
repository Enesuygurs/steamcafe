using System;
using System.Drawing;
using System.Windows.Forms;

public class BorderlessTabControl : TabControl
{
    public BorderlessTabControl()
    {
        // Sekme başlıklarını gizlemek için ayarları düzenle
        this.SizeMode = TabSizeMode.Fixed;
        this.ItemSize = new Size(1, 1); // Sekme başlıklarını küçült
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Tasarım modunda hiçbir şey değiştirme, varsayılan davranış
        if (this.DesignMode)
        {
            base.OnPaint(e);
            return;
        }

        // Çalışma zamanında başlıkları gizle
        e.Graphics.Clear(this.Parent?.BackColor ?? SystemColors.Control);

        Rectangle displayRect = this.DisplayRectangle;
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillRectangle(brush, displayRect);
        }

        base.OnPaint(e);
    }

    protected override void CreateHandle()
    {
        base.CreateHandle();

        // Tasarım modunda başlıkları göster
        if (!this.DesignMode)
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
    }

    protected override void WndProc(ref Message m)
    {
        // Tasarım modunda herhangi bir müdahale yapma
        if (this.DesignMode)
        {
            base.WndProc(ref m);
            return;
        }

        // Çalışma zamanında sekmeleri gizle
        if (m.Msg == 0x1328) // WM_PAINT mesajı
        {
            m.Result = IntPtr.Zero; // Sekme başlıklarını gizlemek için
        }
        else
        {
            base.WndProc(ref m);
        }
    }
}
