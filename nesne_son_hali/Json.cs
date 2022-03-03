using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace nesne_son_hali
{
    class Json
    {
        public static void Yaz(Object o, string dosyaAdi)
        {
            string yol = @".\..\..\..\" + dosyaAdi + ".json";
            string cikti = Duzenle(o);
            using (StreamWriter sw = new StreamWriter(yol))
            {
                sw.WriteLine(cikti);
            }
        }
        public static string Duzenle(Object o)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var cikti = JsonSerializer.Serialize(o, options);
            return cikti;
        }
    }
}
