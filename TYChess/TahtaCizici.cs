using System;
using System.Windows.Forms;

using TYChess.Taslar;

namespace TYChess
{
    public class TahtaCizici
    {
        public Oyun Oyun { get; set; }

        public TahtaCizici()
        {
        }

        public void Ciz()
        {
            //string adres = "NN";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    string adres = ((char)(65 + j)).ToString() + (i + 1).ToString();
                    Konum konum = new Konum(j + 1, i + 1);
                    Kare k = new Kare((10 + i * 50), (10 + j * 50), 50, 50);
                    k.Click += KareClick;
                    k.Click += Oyun.KareClick;

                    if (Oyun.Baslangic.ContainsKey(adres))
                    {
                        Tas t = Oyun.Baslangic[adres];
                        k.Tas = t;
                        //t.Kare = k;
                    }

                    k.Adres = adres;
                    k.Konum = konum;
                    k.AdresiGoster = Oyun.AdresleriGoster;

                    if (i % 2 == 0)
                        k.KareRengi = (j % 2 == 0) ? KareRengi.Siyah : KareRengi.Beyaz;
                    else k.KareRengi = (j % 2 == 0) ? KareRengi.Beyaz : KareRengi.Siyah;

                    Oyun.Kareler.Add(k);
                    Oyun.HedefTahta.KareEkle(k);
                }
            }
        }

        private void KareClick(object sender, EventArgs e)
        {
            Oyun o = Program.AktifOyun;

            if (o.SeciliKare == null) return;

            o.SeciliKare.IsSelected = false;
            o.SeciliKare.Refresh();

            //foreach (Control c in Oyun.HedefKontrol.Controls)
            //{
            //    if (!(c is Kare)) continue;

            //    Kare k = c as Kare;
            //    if (!k.IsSelected) continue;

            //    k.IsSelected = false;
            //    k.Refresh();
            //    break;
            //}
        }
    }
}