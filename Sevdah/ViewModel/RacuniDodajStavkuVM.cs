using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System.Collections.Generic;

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
