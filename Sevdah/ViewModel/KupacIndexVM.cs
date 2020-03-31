using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class KupacIndexVM
    {
        public List<Row> Kupci { get; set; }

        public class Row
        {
            public int KupacID { get; set; }
            public string NazivKupca { get; set; }
            public string ID_broj { get; set; }

            public string PDV_broj { get; set; }
            public string Adresa { get; set; }

            public string Grad { get; set; }
            public double? Kredit { get; set; }
            public double? Dugovanje { get; set; }
        }

        public string srchTxt { get; set; }
    }
}
