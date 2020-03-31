using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacunDobavljacaDetaljiVM
    {
        public RacunDobavljaca racun { get; set; }

        public List<RacunProizvodDobavljaca> stavke { get; set; }
        public int zadnjiID { get; set; }


    }
}
