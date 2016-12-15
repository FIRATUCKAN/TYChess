using System;
using System.Linq;
using System.Collections.Generic;
using TYChess.KonumServisleri;
using TYChess.Taslar;

namespace TYChess
{
    public class Oyun
    {
        Konum _kaynakKonum;
        Konum _hedefKonum;
        bool _doMove;

        public Kare SeciliKare;
        public List<Eleman> OyunHaritasi;

        //public Dictionary<string, Tas> Baslangic;
        public Tahta HedefTahta { get; set; }
        public bool AdresleriGoster { get; set; }

        public Oyun()
        {
            //Kareler = new List<Kare>();
            //Baslangic = new Dictionary<string, Tas>();
            _doMove = false;

            #region InitOyunHaritasi
            OyunHaritasi = new List<Eleman>();
            ElemanlariEkle();

            TasEkle(new Konum(1, 1), new Kale(TasRengi.Beyaz));
            TasEkle(new Konum(2, 1), new At(TasRengi.Beyaz));
            TasEkle(new Konum(3, 1), new Fil(TasRengi.Beyaz));
            TasEkle(new Konum(4, 1), new Sah(TasRengi.Beyaz));
            TasEkle(new Konum(5, 1), new Vezir(TasRengi.Beyaz));
            TasEkle(new Konum(6, 1), new Fil(TasRengi.Beyaz));
            TasEkle(new Konum(7, 1), new At(TasRengi.Beyaz));
            TasEkle(new Konum(8, 1), new Kale(TasRengi.Beyaz));
            TasEkle(new Konum(1, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(2, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(3, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(4, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(5, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(6, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(7, 2), new Piyon(TasRengi.Beyaz));
            TasEkle(new Konum(8, 2), new Piyon(TasRengi.Beyaz));

            TasEkle(new Konum(1, 8), new Kale(TasRengi.Siyah));
            TasEkle(new Konum(2, 8), new At(TasRengi.Siyah));
            TasEkle(new Konum(3, 8), new Fil(TasRengi.Siyah));
            TasEkle(new Konum(4, 8), new Sah(TasRengi.Siyah));
            TasEkle(new Konum(5, 8), new Vezir(TasRengi.Siyah));
            TasEkle(new Konum(6, 8), new Fil(TasRengi.Siyah));
            TasEkle(new Konum(7, 8), new At(TasRengi.Siyah));
            TasEkle(new Konum(8, 8), new Kale(TasRengi.Siyah));
            TasEkle(new Konum(1, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(2, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(3, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(4, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(5, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(6, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(7, 7), new Piyon(TasRengi.Siyah));
            TasEkle(new Konum(8, 7), new Piyon(TasRengi.Siyah));
            #endregion
        }

        public void KareClick(object sender, EventArgs e)
        {
            var k = sender as Kare;
            if (!_doMove)
            {
                ClearIsSelected();
                //if (k.Tas != null)
                //    k.Tas.HareketAlaniniHesapla(k.Konum);
                // ReSharper disable once PossibleNullReferenceException
                _kaynakKonum = k.Konum;
                _doMove = true;
                return;
            }

            // ReSharper disable once PossibleNullReferenceException
            _hedefKonum = k.Konum;
            HareketYap(_kaynakKonum, _hedefKonum);
            _doMove = false;
        }

        private static void HareketYap(Konum kaynakKonum, Konum hedefKonum)
        {
            int tmpX = hedefKonum.X;
            int tmpY = hedefKonum.Y;

            hedefKonum.X = kaynakKonum.X;
            hedefKonum.Y = kaynakKonum.Y;

            kaynakKonum.X = tmpX;
            kaynakKonum.Y = tmpY;

            //HedefTahta.Refresh();

            var ekaynak = Program.AktifOyun.ElemanBul(kaynakKonum);
            var ehedef = Program.AktifOyun.ElemanBul(hedefKonum);

            ekaynak.Kare.Refresh();
            ehedef.Kare.Refresh();

        }



        #region Helpers
        private void ElemanlariEkle()
        {
            int id = 1;
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    OyunHaritasi.Add(new Eleman()
                    {
                        Id = id++,
                        Konum = new Konum(y, x)
                    });
                }
            }
        }
        private void TasEkle(Konum k, Tas t)
        {
            ElemanBul(k).Tas = t;
        }
        public Eleman ElemanBul(int id)
        {
            return OyunHaritasi.FirstOrDefault(e => e.Id == id);
        }
        public Eleman ElemanBul(Konum konum)
        {
            return OyunHaritasi.FirstOrDefault(e => e.Konum.X == konum.X && e.Konum.Y == konum.Y);
        }

        public void ClearIsSelected()
        {
            foreach (var eleman in OyunHaritasi)
            {
                eleman.IsSelected= false;
            }
            HedefTahta.Refresh();

        }

        #endregion
    }
}