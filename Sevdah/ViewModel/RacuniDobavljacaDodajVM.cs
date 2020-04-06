using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sevdah.ViewModel
{
    public class RacuniDobavljacaDodajVM
    {
        public List<SelectListItem> Dobavljaci { get; set; }

        public string BrojRacuna { get; set; }
        public int DobavljacID { get; set; }
        public int ZadnjiID { get; set; }
        public string Datum { get; set; } = DateTime.Now.ToShortDateString();
    }
}
