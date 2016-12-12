using System;
using System.Windows.Forms;

namespace TYChess
{
    public static class Program
    {
        public static Oyun AktifOyun;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tahta());
        }
    }

    public enum TasRengi { Siyah = 1, Beyaz = 2 };
}