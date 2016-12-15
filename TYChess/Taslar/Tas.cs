using System.Drawing;
using System.Resources;
using TYChess.Properties;
using System.Collections.Generic;
using TYChess.KonumServisleri;

namespace TYChess.Taslar
{
    public class Tas
    {
        public TasRengi TasRengi { get; set; }
        public string ImageFileName { get; set; }
        public List<Konum> HareketAlani { get; set; }

        private readonly ResourceManager _resManager;

        public Tas(TasRengi renk, string imageFileName)
        {
            TasRengi = renk;
            ImageFileName = imageFileName;
            HareketAlani = new List<Konum>();
            _resManager = new ResourceManager("TYChess.Properties.Resources", typeof(Resources).Assembly);
        }

        public virtual void HareketAlaniniHesapla(Konum k) { }

        public virtual Image GetIcon()
        {
            return _resManager.GetObject($"{(TasRengi == TasRengi.Beyaz ? "white" : "black")}_{ImageFileName}") as Image;
        }
    }
}