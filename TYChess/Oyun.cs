using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using TYChess.Taslar;

namespace TYChess
{
    public class Oyun
    {
        Konum kaynakKonum;
        Konum hedefKonum;
        bool doMove;

        public Kare SeciliKare;
        public List<Eleman> OyunHaritasi;

        //public Dictionary<string, Tas> Baslangic;
        public Tahta HedefTahta { get; set; }
        public bool AdresleriGoster { get; set; }

        public Oyun()
        {
            //Kareler = new List<Kare>();
            //Baslangic = new Dictionary<string, Tas>();
            doMove = false;

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
            Kare k = sender as Kare;
            //HedefTahta.AdresiLabelaYaz(k.Adres, k.Konum);
            //ilk tiklama
            if (!doMove)
            {
                //if (k.Tas != null)
                //    k.Tas.HareketAlaniniHesapla(k.Konum);
                kaynakKonum = k.Konum;
                doMove = true;
                return;
            }

            hedefKonum = k.Konum;
            HareketYap(kaynakKonum, hedefKonum);
            OyunuTazele();
            doMove = false;
            //k.Tas = kaynakKare.Tas; //hedef karenin tasini kaynak karenin tasi yaptik
            //kaynakKare.Tas = null; //kaynak karede artik tas yok
        }

        private void HareketYap(Konum kaynakKonum, Konum hedefKonum)
        {
            int tmpX = hedefKonum.X;
            int tmpY = hedefKonum.Y;

            hedefKonum.X = kaynakKonum.X;
            hedefKonum.Y = kaynakKonum.Y;

            kaynakKonum.X = tmpX;
            kaynakKonum.Y = tmpY;

            HedefTahta.Refresh();

            Eleman e = Program.AktifOyun.ElemanBul(new Konum(6, 7));
            e.Kare.Refresh();

            //List<Eleman> elemanlar = Program.AktifOyun.OyunHaritasi;

            //Eleman kaynak = OyunHaritasi.Where(e => e.Konum.X == kaynakKonum.X && e.Konum.Y == kaynakKonum.Y).First();
            //var hq = OyunHaritasi.Where(e => e.Konum.X == hedefKonum.X && e.Konum.Y == hedefKonum.Y);

            //if (hq.Any())
            //{
            //    //hedefte tas varsa burasi
            //}
            //else
            //{
            //    kaynak.Konum = hedefKonum;
            //}
        }

        public void OyunuTazele()
        {

            //for (int x = 1; x <= 8; x++)
            //{
            //    for (int y = 1; y <= 8; y++)
            //    {
            //        var qe = OyunHaritasi.Where(e => e.Konum.X == x && e.Konum.Y == y);
            //        var qk = HedefTahta.Kareler.Where(k => k.Konum.X == x && k.Konum.Y == y);

            //        if (qe.Any())
            //        {
            //            Eleman e = qe.FirstOrDefault();
            //            Kare k = qk.First();
            //            k.Tas = e.Tas;
            //        }
            //    }
            //}
        }

        public void OyunBaslat()
        {
            #region Dizilis
            Baslangic.Add("A1", new Kale(TasRengi.Beyaz));
            Baslangic.Add("B1", new At(TasRengi.Beyaz));
            Baslangic.Add("C1", new Fil(TasRengi.Beyaz));
            Baslangic.Add("D1", new Sah(TasRengi.Beyaz));
            Baslangic.Add("E1", new Vezir(TasRengi.Beyaz));
            Baslangic.Add("F1", new Fil(TasRengi.Beyaz));
            Baslangic.Add("G1", new At(TasRengi.Beyaz));
            Baslangic.Add("H1", new Kale(TasRengi.Beyaz));
            Baslangic.Add("A2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("B2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("C2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("D2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("E2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("F2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("G2", new Piyon(TasRengi.Beyaz));
            Baslangic.Add("H2", new Piyon(TasRengi.Beyaz));

            Baslangic.Add("A8", new Kale(TasRengi.Siyah));
            Baslangic.Add("B8", new At(TasRengi.Siyah));
            Baslangic.Add("C8", new Fil(TasRengi.Siyah));
            Baslangic.Add("D8", new Vezir(TasRengi.Siyah));
            Baslangic.Add("E8", new Sah(TasRengi.Siyah));
            Baslangic.Add("F8", new Fil(TasRengi.Siyah));
            Baslangic.Add("G8", new At(TasRengi.Siyah));
            Baslangic.Add("H8", new Kale(TasRengi.Siyah));
            Baslangic.Add("A7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("B7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("C7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("D7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("E7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("F7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("G7", new Piyon(TasRengi.Siyah));
            Baslangic.Add("H7", new Piyon(TasRengi.Siyah));
            #endregion
        }

        public void OyunuKaydet()
        {

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
                        ID = id++,
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
            return OyunHaritasi.Where(e => e.ID == id).FirstOrDefault();
        }
        public Eleman ElemanBul(Konum konum)
        {
            return OyunHaritasi.Where(e => e.Konum.X == konum.X && e.Konum.Y == konum.Y).FirstOrDefault();
        }
        #endregion
    }
}