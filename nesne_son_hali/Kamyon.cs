using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Kamyon:Arac
    {
        public Kamyon(string plaka) : base(AracTipi.KAMYON, plaka) { parkYeriTipi = ParkYeriTipi.KAMYON; }
    }
}
