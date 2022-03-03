using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Musteri
    {
        public ParkYeri _musteri { get; set; }
        public ParkYeri ParkEdilenYer { get; set; }
        public Arac Arac { get; set; }
        public ParkYeriTipi ParkEdilenTip { get; set; }
        public bool ParktaMi { get; set; }
        public bool OdemeYapildiMi { get; set; }
        public Musteri(ParkYeri parkYeri, Arac arac)
        {
            _musteri = parkYeri;
            Arac = arac;
            ParktaMi = true;
            OdemeYapildiMi = false;
        }
        public void BiletAl()
        {
            Biletİslemleri.BiletKontrol(this);
        }
        public bool ParkEt(ParkYeriTipi tip)
        {
            if (Arac.bilet == null)
            {
                Console.WriteLine("Biletiniz yok. Bilet almaya yönlendiriliyorsunuz.");
                BiletAl();
            }
            if (Arac.ParkEdildiMi)
            {
                Console.WriteLine("Aracınız zaten parkta.");
                return false;
            }
            if (Arac.ParkYeriTipiGetir() == tip)
            {
                ParkEdilenTip = tip;
                Arac.ParkEdildiMi = true;
                ParkEdilenYer = _musteri;
                ParkEdilenYer.BosParkYer[ParkEdilenTip]--;
                Console.WriteLine("Aracınız {0} yerine park edildi.", ParkEdilenYer);
                return true;
            }
            else
            {
                Console.WriteLine("Aracınıza uygun {0} yeri bulunamadı.", Arac.ParkYeriTipiGetir());
                return false;
            }
        }
        public bool ParktanCikar()
        {
            if (OdemeYapildiMi == false)
            {
                Console.WriteLine("Öncelikle ödemeyi yapınız.");
                OdemeYap();
            }
            if (Arac.ParkEdildiMi)
            {
                ParkEdilenYer.BosParkYer[ParkEdilenTip]++;
                Arac.ParkEdildiMi = false;
                Console.WriteLine("Biletiniz siliniyor...");
                Biletİslemleri.BiletSil(this);
                Console.WriteLine("Aracınız parktan çıkarıldı.");
                return true;
            }
            else
            {
                Console.WriteLine("Aracınız parkta değil.");
                return false;
            }
        }
        public void OdemeYap()
        {
            if (OdemeYapildiMi == false)
            {
                Console.WriteLine("{0} lira ödeme yapmanız gerekmektedir.", _musteri.FaturaHesapla(this));
                Console.WriteLine("Ödeme yapıldı.");
                OdemeYapildiMi = true;
            }
        }
    }
}
