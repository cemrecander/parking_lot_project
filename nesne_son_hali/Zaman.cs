using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    public static class Zaman
    {
        private static DateTime zaman;
        static Zaman()
        {
            zaman = DateTime.Now;
        }
        public static DateTime SaatKac()
        {
            return zaman;
        }
        public static void Atla(double time)
        {
            if (time < 0)
            {
                Console.WriteLine("Sadece ileri atlanabilir.");
                return;
            }
            zaman = zaman.AddHours(time);
            Console.WriteLine("{0} saat atlandı.", time);
        }
    }
}
