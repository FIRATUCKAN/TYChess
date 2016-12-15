using System;
using System.Drawing;
using System.Windows.Forms;
using TYChess.KonumServisleri;

namespace TYChess
{
    public class Kare : Control
    {
        #region DevelopmentAmacli
        public string Adres { get; set; }
        public bool AdresiGoster { get; set; }
        #endregion

        public int Id { get; set; }
        public KareRengi KareRengi { get; set; }
        //public Tas Tas { get; set; } /* bunu buradan kaldirmaliyiz */
        //public bool IsSelected { get; set; }
        public bool TasIziGoster { get; set; }
        //public Konum Konum { get; set; }
        public Konum Konum => Program.AktifOyun.ElemanBul(Id).Konum;

        public Kare(int x, int y, int width, int height)
        {
            Top = x;
            Left = y;
            Width = width;
            Height = height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var eleman = Program.AktifOyun.ElemanBul(Id);
            var b = new SolidBrush(KareRengi == KareRengi.Beyaz ? Color.White : Color.Maroon);
            var r = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            e.Graphics.FillRectangle(b, r);
            if (AdresiGoster)
                e.Graphics.DrawString(Adres, Font, new SolidBrush(Color.Red), 20, 20);

            if (eleman.IsSelected) {
                var p = new Pen(new SolidBrush(Color.Red)) {Width = 4};
                e.Graphics.DrawRectangle(p, 2, 2, e.ClipRectangle.Width - 4, e.ClipRectangle.Height - 4);
            }

            if (TasIziGoster) {
                var sb = new SolidBrush(Color.Yellow);
                e.Graphics.FillRectangle(sb, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            }

            if (eleman.TasVarMi)
                e.Graphics.DrawImage(eleman.Tas.GetIcon(), new Point(5, 5));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var eleman = Program.AktifOyun.ElemanBul(Id);
            eleman.IsSelected = true;
            Program.AktifOyun.SeciliKare = this;
            eleman.Kare.Refresh();
        }

    }

    public enum KareRengi { Siyah = 1, Beyaz = 2 };
}