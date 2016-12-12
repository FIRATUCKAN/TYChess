using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using TYChess.Taslar;

namespace TYChess
{
    public class Oyun
    {
        Kare kaynakKare;
        bool doMove;

        public Kare SeciliKare;
        public Dictionary<string, Tas> Baslangic;
        public List<Kare> Kareler { get; set; }
        public Tahta HedefTahta { get; set; }
        public bool AdresleriGoster { get; set; }

        public Oyun()
        {
            Kareler=new List<Kare>();
            Baslangic = new Dictionary<string, Tas>();
            doMove = false;
        }

        public void KareClick(object sender, EventArgs e)
        {
            Kare k = sender as Kare;
            HedefTahta.AdresiLabelaYaz(k.Adres, k.Konum);
            //ilk tiklama
            if (!doMove)
            {
                if (k.Tas != null)
                    k.Tas.HareketAlaniniHesapla(k.Konum);
                kaynakKare = k;
                doMove = true;
                return;
            }

            HedefTahta.HareketYap(kaynakKare, k);
            doMove = false;
            //k.Tas = kaynakKare.Tas; //hedef karenin tasini kaynak karenin tasi yaptik
            //kaynakKare.Tas = null; //kaynak karede artik tas yok
        }

        public void OyunuTazele()
        {

        }

        public void OyunBaslat()
        {
            #region Dizilis
            Baslangic.Clear();
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
    }
}