using System;
using System.Linq;

namespace TYChess
{
    public struct Konum
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Konum(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Sag() { X++; }
        public void Sol() { X--; }
        public void Yukari() { Y--; }
        public void Asagi() { Y++; }
        public void SagYukari() { X++; Y--; }
        public void SagAsagi() { X++; Y++; }
        public void SolYukari() { X--; Y--; }
        public void SolAsagi() { X--; Y++; }

        public bool TahtaIcindeMi()
        {
            return X <= 8 && X >= 1 && Y <= 8 && Y >= 1;
        }
    }
}