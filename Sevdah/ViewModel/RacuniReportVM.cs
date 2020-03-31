using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniReportVM
    {
        public Racun racun { get; set; }
        public List<RacunProizvod> listaStavki { get; set; }
    }
}
