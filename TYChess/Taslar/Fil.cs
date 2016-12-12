using System;
using System.Linq;
using System.Drawing;

using TYChess.KonumServisleri;

namespace TYChess.Taslar
{
    public class Fil : Tas
    {
        public Fil(TasRengi renk) : base(renk, "bishop") { }

        public override void HareketAlaniniHesapla(Konum k)
        {
            Konum k1 = k;
            while (k1.TahtaIcindeMi()) {
                KonumHesaplayici.KareKonumGoster(k1);
                k1.Sag();
                k1.Yukari();
            }

            Konum k2 = k;
            while (k2.TahtaIcindeMi()) {
                KonumHesaplayici.KareKonumGoster(k2);
                k2.SolYukari();
            }
        }
    }
}