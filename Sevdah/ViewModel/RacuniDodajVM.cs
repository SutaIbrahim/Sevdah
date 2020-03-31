using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniDodajVM
    {
        public Racun racun { get; set; }
        public List<SelectListItem> listaKupaca { get; set; }

    }
}
