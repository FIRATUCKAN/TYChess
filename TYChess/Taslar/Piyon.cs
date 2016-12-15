

using TYChess.KonumServisleri;

namespace TYChess.Taslar
{
    public class Piyon : Tas
    {
        public Piyon(TasRengi renk) : base(renk, "pawn") { }

        public override void HareketAlaniniHesapla(Konum k)
        {
            k.Yukari();
            KonumHesaplayici.KareKonumGoster(k);
            k.Yukari();
            KonumHesaplayici.KareKonumGoster(k);
        }
    }
}