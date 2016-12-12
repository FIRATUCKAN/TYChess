using System;
using System.Linq;

namespace TYChess.KonumServisleri
{
    public class KonumHesaplayici
    {
        public static void KareKonumGoster(Konum k)
        {
            Oyun o = Program.AktifOyun;
            Kare kare = o.Kareler.Where(z => z.Konum.X == k.X && z.Konum.Y == k.Y).FirstOrDefault();
            kare.KonumGoster = true;
            kare.Refresh();
        }
    }
}
