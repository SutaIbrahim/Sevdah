using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacunDobavljacaDodajStavkuVM
    {
        public RacunProizvodDobavljaca stavka { get; set; }

        public List<SelectListItem> proizvodi { get; set; }
    }
}
