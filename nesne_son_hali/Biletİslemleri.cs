using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Biletİslemleri
    {
        public static bool BiletKontrol(Musteri musteri)
        {
            if (musteri.Arac.bilet == null)
            {
                BiletKes(musteri);
                Console.WriteLine("{0} plakalı araç için bilet kesildi. {1}", musteri.Arac.plaka, musteri.Arac.bilet.BiletKesilmeZamani);
                return true;
            }
            else
            {
                Console.WriteLine("{0} plakalı aracın zaten bileti var.", musteri.Arac.plaka);
                return false;
            }
        }
        private static void BiletKes(Musteri musteri)
        {
            musteri.Arac.bilet = new Bilet(musteri);
            musteri.ParktaMi = true;
        }
        public static void BiletSil(Musteri musteri)
        {
            if (musteri.Arac.bilet != null)
            {
                musteri.Arac.bilet = null;
                Console.WriteLine("Bilet silindi.", Zaman.SaatKac());
            }
            else
            {
                Console.WriteLine("Müşterinin bileti yok.");
                return;
            }
        }
    }
}
