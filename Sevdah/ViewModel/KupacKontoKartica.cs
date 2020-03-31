using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class KupacKontoKartica
    {
        public class Row
        {
            public double Duguje { get; set; }
            public double Potrazuje { get; set; }
            public DateTime Datum { get; set; }
            public string VezniDokument { get; set; }
            public double Saldo { get; set; }
        }
        public List<Row> redovi { get; set; }
        public double Saldo { get; set; }
        public int KupacId { get; set; }
        public string NazivKupca { get; set; }
        public string AdresaKupca { get; set; }
        public double SumaDuguje { get; set; }
        public double SumaPotrazuje { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string Grad { get; set; }

        //
        public double prethodnoDugovanje { get; set; }
    }
}
