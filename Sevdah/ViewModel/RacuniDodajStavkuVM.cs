using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniDodajStavkuVM
    {
        public RacunProizvod stavka { get; set; }
        public List<SelectListItem> listaProizvoda { get; set; }
        public float komada { get; set; }
        public int RacunId { get; set; }
        public int KupacId { get; set; }
        public string Kupac { get; set; }

        public List<OdobreniRabat> Rabati { get; set; }

    }
}
