using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class ProizvodiIndexVM
    {
        public class Row
        {
            public int ProizvodId { get; set; }
            public string BarKod { get; set; }
            public string Naziv { get; set; }
            public float MasaUKg { get; set; }
            public double CijenaBezPDV { get; set; }
            public double CijenaSaPDV { get; set; }
        }
        public List<Row> listaProizvoda { get; set; }
    }
}
