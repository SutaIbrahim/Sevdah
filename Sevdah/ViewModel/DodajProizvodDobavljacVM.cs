using Microsoft.AspNetCore.Mvc.Rendering;
using Sevdah.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sevdah.ViewModel
{
    public class DodajProizvodDobavljacVM
    {

        public List<SelectListItem> Proizvodi { get; set; }
        public ProizvodDobavljac ProizvodDobavljac { get; set; }
        public int DobavljacId { get; set; }
        public string NazivDobavljaca { get; set; }
    }
}
