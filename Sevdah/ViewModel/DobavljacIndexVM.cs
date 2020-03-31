using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.Models
{
    public class DobavljacIndexVM
    {
        public List<Row> Dobavljaci { get; set; }

        public class Row
        {
            public int DobavljacID { get; set; }
            public string Naziv { get; set; }
            public string ID_broj { get; set; }

            public string PDV_broj { get; set; }
            public string Adresa { get; set; }

            public string Grad { get; set; }
            public string ZiroRacun { get; set; }
            public string Telefon { get; set; }
            public double? Kredit { get; set; }
            public double? Dugovanje { get; set; }

        }

        public string srchTxt { get; set; }
    }
}
