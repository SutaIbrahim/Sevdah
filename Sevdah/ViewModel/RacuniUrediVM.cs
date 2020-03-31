using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniUrediVM
    {
        public Racun racun { get; set; }
        public List<RacunProizvod> listaStavki { get; set; }
        public int zadnjiID { get; set; }

    }
}
