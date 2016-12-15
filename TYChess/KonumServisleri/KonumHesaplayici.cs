

using System.Linq;

namespace TYChess.KonumServisleri
{
    public class KonumHesaplayici
    {
        public static void KareKonumGoster(Konum k)
        {
            Oyun o = Program.AktifOyun;
            var eleman = o.ElemanBul(k);
            var kare = o.OyunHaritasi.FirstOrDefault(z => z.Konum.X == k.X && z.Konum.Y == k.Y).Kare;
            kare.TasIziGoster= true;
            kare.Refresh();
        }
    }
}
