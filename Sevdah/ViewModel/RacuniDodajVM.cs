using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System.Collections.Generic;

namespace Sevdah.ViewModel
{
    public class RacuniDodajVM
    {
        public Racun racun { get; set; }
        public List<SelectListItem> listaKupaca { get; set; }
    }
}
