using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace nesne_son_hali
{
    class ParkYeri
    {
            public string ParkAdi { get; set; }
            public Dictionary<ParkYeriTipi, int> ParkYer;
            public Dictionary<ParkYeriTipi, int> BosParkYer;
            public Dictionary<ParkYeriTipi, int> ParkFiyatlandirma;
            public List<Musteri> musteriler { get; set; }
            [JsonInclude]
            public int toplamMusteriSayisi { get; set; }
            private int GunlukFiyatlandirma;
            private int ArabaFiyatlandirma;
            private int KamyonFiyatlandirma;
            private int MotosikletFiyatlandirma;
            private int EnAzFiyat;
            public ParkYeri(string parkAdi, int araba, int kamyon, int motosiklet)
            {
                ParkAdi = parkAdi;
                GunlukFiyatlandirma = 50;
                MotosikletFiyatlandirma = 1;
                ArabaFiyatlandirma = 2;
                KamyonFiyatlandirma = 3;
                EnAzFiyat = 2;
                ParkFiyatlandirma = new Dictionary<ParkYeriTipi, int>();
                ParkYer = new Dictionary<ParkYeriTipi, int>();
                BosParkYer = new Dictionary<ParkYeriTipi, int>();
                ParkFiyatlandirma.Add(ParkYeriTipi.MOTOSIKLET, MotosikletFiyatlandirma);
                ParkFiyatlandirma.Add(ParkYeriTipi.KAMYON, KamyonFiyatlandirma);
                ParkFiyatlandirma.Add(ParkYeriTipi.ARABA, ArabaFiyatlandirma);
                ParkYer.Add(ParkYeriTipi.ARABA, araba);
                ParkYer.Add(ParkYeriTipi.KAMYON, kamyon);
                ParkYer.Add(ParkYeriTipi.MOTOSIKLET, motosiklet);
                BosParkYer.Add(ParkYeriTipi.ARABA, araba);
                BosParkYer.Add(ParkYeriTipi.KAMYON, kamyon);
                BosParkYer.Add(ParkYeriTipi.MOTOSIKLET, motosiklet);
                musteriler = new List<Musteri>();
                toplamMusteriSayisi = 0;
            }
            public int MusteriEkle(Arac arac)
            {
                return EkleMusteri(arac);
            }
            protected int EkleMusteri(Arac arac)
            {
                if (BosParkYeri(arac.ParkYeriTipiGetir()) <= 0)
                {
                    Console.WriteLine("Hiç boş {0} yeri yok.", arac.ParkYeriTipiGetir());
                    return -2;
                }
                int indeks = MusteriOtoparktaMi(arac);
                if (indeks != -1)
                {
                    Console.WriteLine("{0} plakalı araç zaten otoparkta.", musteriler[indeks].Arac.plaka);
                    return -3;
                }
                else
                {
                    Musteri musteri = new Musteri(this, arac);
                    musteriler.Add(musteri);
                    toplamMusteriSayisi++;
                    indeks = musteriler.IndexOf(musteri);
                    Console.WriteLine("{0} plakalı araç park edildi.", arac.plaka);
                    return indeks;
                }
            }
            private int MusteriOtoparktaMi(Arac arac)
            {
                return musteriler.FindIndex(a => a.Arac.plaka == arac.plaka);
            }
            private int BosParkYeri(ParkYeriTipi tip)
            {
                return BosParkYer[tip];
            }
            public int FaturaHesapla(Musteri musteri)
            {
                if (musteri.Arac.bilet == null)
                {
                    Console.WriteLine("Bilet mevcut değil.");
                    return 0;
                }
                int fiyatlandirma = ParkFiyatlandirma[musteri.ParkEdilenTip];
                double parkSuresi = Zaman.SaatKac().Subtract(musteri.Arac.bilet.BiletKesilmeZamani).TotalHours;
                if (parkSuresi <= 24)
                {
                    return Convert.ToInt32(Math.Ceiling(EnAzFiyat * parkSuresi * fiyatlandirma));
                }
                else
                {
                    return Convert.ToInt32(Math.Ceiling(GunlukFiyatlandirma * (parkSuresi % 24) * fiyatlandirma));
                }
            }
            public void JsonYaz()
            {
                Json.Yaz(this, ParkAdi);
            }
        }
    }

