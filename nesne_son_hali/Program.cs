using System;

namespace nesne_son_hali
{
    class Program
    {
        static void Main(string[] args)
        {
            int atla = 0;
            ParkYeri park = new ParkYeri("Balkes otoparkı", 2, 3, 4);
            Biletİslemleri bilet = new Biletİslemleri();
            int musteri1 = 0;
            musteri1 = park.MusteriEkle(new Araba("10 blk 1010"));
            park.musteriler[musteri1].BiletAl();
            park.musteriler[musteri1].ParkEt(ParkYeriTipi.ARABA);
            Console.Write("Şuan saat {0}.Kaç saat ileri atlamak istersiniz?", Zaman.SaatKac());
            atla = Convert.ToInt32(Console.ReadLine());
            Zaman.Atla(atla);
            park.musteriler[musteri1].ParktanCikar();
            park.JsonYaz();
        }
    }
}
