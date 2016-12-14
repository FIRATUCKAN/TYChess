using System;
using System.Drawing;
using System.Windows.Forms;

using TYChess.Taslar;

namespace TYChess
{
    public class Kare : Control
    {
        #region DevelopmentAmacli
        public string Adres { get; set; }
        public bool AdresiGoster { get; set; }
        #endregion

        public int ID { get; set; }
        public KareRengi KareRengi { get; set; }
        //public Tas Tas { get; set; } /* bunu buradan kaldirmaliyiz */
        public bool IsSelected { get; set; }
        public bool TasIziGoster { get; set; }
        //public Konum Konum { get; set; }
        public Konum Konum
        {
            get { return Program.AktifOyun.ElemanBul(ID).Konum; }
        }

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

            SolidBrush b = new SolidBrush(this.KareRengi == KareRengi.Beyaz ? Color.White : Color.Maroon);
            Rectangle r = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            e.Graphics.FillRectangle(b, r);
            if (AdresiGoster)
                e.Graphics.DrawString(Adres, Font, new SolidBrush(Color.Red), 20, 20);

            if (IsSelected) {
                Pen p = new Pen(new SolidBrush(Color.Red));
                p.Width = 4;
                e.Graphics.DrawRectangle(p, 2, 2, e.ClipRectangle.Width - 4, e.ClipRectangle.Height - 4);
            }

            if (TasIziGoster) {
                SolidBrush sb = new SolidBrush(Color.Yellow);
                e.Graphics.FillRectangle(sb, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);
            }

            var eleman = Program.AktifOyun.ElemanBul(ID);
            if (eleman.TasVarMi)
                e.Graphics.DrawImage(eleman.Tas.GetIcon(), new Point(5, 5));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            IsSelected = true;
            Program.AktifOyun.SeciliKare = this;
            Refresh();
        }

    }

    public enum KareRengi { Siyah = 1, Beyaz = 2 };
}