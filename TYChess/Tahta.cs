using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using TYChess.Taslar;

namespace TYChess
{
    public partial class Tahta : Form
    {
        //public List<Kare> Kareler { get; set; }

        public Tahta()
        {
            InitializeComponent();
        }

        private void Tahta_Load(object sender, EventArgs e)
        {
        }

        //public void HareketYap(Kare kaynakKare, Kare hedefKare)
        //{
        //    hedefKare.Tas = kaynakKare.Tas;
        //    hedefKare.Refresh();

        //    kaynakKare.Tas = null;
        //    kaynakKare.Refresh();
        //}

        private void btnOyunuBaslat_Click(object sender, EventArgs e)
        {
            Oyun yeniOyun = new Oyun();
            Program.AktifOyun = yeniOyun;
            KareleriCiz();
            //yeniOyun.AdresleriGoster = true;
            yeniOyun.HedefTahta = this;
            yeniOyun.OyunuTazele();

            //TahtaCizici c = new TahtaCizici();
            //c.Oyun = yeniOyun;
            //c.Ciz();

            
        }

        private void KareleriCiz()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Kare k = new Kare((10 + i * 50), (10 + j * 50), 50, 50);
                    if (i % 2 == 0)
                        k.KareRengi = (j % 2 == 0) ? KareRengi.Siyah : KareRengi.Beyaz;
                    else k.KareRengi = (j % 2 == 0) ? KareRengi.Beyaz : KareRengi.Siyah;
                    k.Click += Program.AktifOyun.KareClick;

                    Konum konum = new Konum(j + 1, i + 1);
                    Eleman eleman = Program.AktifOyun.ElemanBul(konum);
                    eleman.Kare = k;
                    k.ID = eleman.ID;
                    
                    this.Controls.Add(k);
                }
            }
        }

        private void btnAdresleriGoster_Click(object sender, EventArgs e)
        {
            
        }

        public void KareEkle(Kare k)
        {
            Controls.Add(k);
        }


        public void AdresiLabelaYaz(string adres, Konum konum)
        {
            label1.Text = adres;
            label2.Text = string.Format("{0}, {1}", konum.X, konum.Y);
        }
    }
}