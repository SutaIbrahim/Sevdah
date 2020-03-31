using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class DobavljacKontoKartica
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
        public int DobavljacId { get; set; }
        public string NazivDobavljaca { get; set; }
        public string AdresaDobavljaca { get; set; }
        public double SumaDuguje { get; set; }
        public double SumaPotrazuje { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string Grad { get; set; }

        //
        public double prethodnoDugovanje { get; set; }
    }
}
