using System;
using System.Collections.Generic;
using System.Text;

namespace nesne_son_hali
{
    class Motosiklet:Arac
    {
        public Motosiklet(string plaka) : base(AracTipi.MOTOSIKLET, plaka) { parkYeriTipi = ParkYeriTipi.MOTOSIKLET; }
    }
}
