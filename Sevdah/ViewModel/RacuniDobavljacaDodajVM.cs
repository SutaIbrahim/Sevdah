using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class RacuniDobavljacaDodajVM
    {

        public List<SelectListItem> Dobavljaci { get; set; }

        public string BrojRacuna { get; set; }
        public int DobavljacID { get; set; }
        public int ZadnjiID { get; set; }

    }
}
