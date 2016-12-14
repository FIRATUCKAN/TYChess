using System;
using System.Drawing;
using System.Resources;
using TYChess.Properties;
using System.Collections.Generic;

namespace TYChess.Taslar
{
    public class Tas
    {
        public TasRengi TasRengi { get; set; }
        public string ImageFileName { get; set; }
        public List<Konum> HareketAlani { get; set; }

        ResourceManager resManager;

        public Tas(TasRengi renk, string imageFileName)
        {
            TasRengi = renk;
            ImageFileName = imageFileName;
            HareketAlani = new List<Konum>();
            resManager = new ResourceManager("TYChess.Properties.Resources", typeof(Resources).Assembly);
        }

        public virtual void HareketAlaniniHesapla(Konum k) { }

        public virtual Image GetIcon()
        {
            return resManager.GetObject(string.Format("{0}_{1}", (TasRengi == TasRengi.Beyaz ? "white" : "black"), ImageFileName)) as Image;
        }
    }
}