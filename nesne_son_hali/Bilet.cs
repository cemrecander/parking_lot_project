using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Bilet
    {
        public ParkYeri ParkYeri { get; set; }
        public Musteri BiletSahibi { get; set; }
        public string Plaka { get; set; }
        public DateTime BiletKesilmeZamani { get; set; }
        public Bilet(Musteri musteri)
        {
            ParkYeri = musteri._musteri;
            BiletSahibi = musteri;
            Plaka = musteri.Arac.plaka;
            BiletKesilmeZamani = Zaman.SaatKac();
        }
    }
}
