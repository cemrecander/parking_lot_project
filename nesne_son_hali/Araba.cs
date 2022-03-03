using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Araba:Arac
    {
        public Araba(string plaka) : base(AracTipi.ARABA, plaka) { parkYeriTipi = ParkYeriTipi.ARABA; }
    }
}
