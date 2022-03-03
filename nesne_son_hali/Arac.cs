using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    abstract class Arac
    {
        public string plaka { get; }
        public AracTipi tip { get; }
        protected ParkYeriTipi parkYeriTipi;
        public bool ParkEdildiMi;
        public Arac(AracTipi tip, string plaka)
        {
            ParkEdildiMi = false;
            this.plaka = plaka;
            this.tip = tip;
        }
        public Bilet bilet;
        public ParkYeriTipi ParkYeriTipiGetir()
        {
            return parkYeriTipi;
        }
    }
}
