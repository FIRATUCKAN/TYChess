using System;
using System.Windows.Forms;
using System.Collections.Generic;

using TYChess.Taslar;

namespace TYChess
{
    public partial class Tahta : Form
    {
        public Tahta()
        {
            InitializeComponent();
        }

        private void Tahta_Load(object sender, EventArgs e)
        {
        }

        public void HareketYap(Kare kaynakKare, Kare hedefKare)
        {
            hedefKare.Tas = kaynakKare.Tas;
            hedefKare.Refresh();

            kaynakKare.Tas = null;
            kaynakKare.Refresh();
        }

        private void btnOyunuBaslat_Click(object sender, EventArgs e)
        {
            Oyun yeniOyun = new Oyun();
            //yeniOyun.AdresleriGoster = true;
            yeniOyun.HedefTahta = this;
            yeniOyun.OyunBaslat();

            TahtaCizici c = new TahtaCizici();
            c.Oyun = yeniOyun;
            c.Ciz();

            Program.AktifOyun = yeniOyun;
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