using System;
using TYChess.Taslar;

namespace TYChess
{
    public class Eleman
    {
        public int ID { get; set; }
        public Tas Tas { get; set; }
        public Konum Konum { get; set; }
        public Kare Kare { get; set; }
        public bool IsChange { get; set; }

        public bool TasVarMi
        {
            get { return Tas != null; }
        }
    }
}
